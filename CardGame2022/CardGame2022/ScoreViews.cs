using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame2022
{

    public class ScoreViews
    {

        private int spaceBeetween = 16;

        public Size BoxScoreSize { get; set; } = new Size(90,180);

        public int Epaisseur { get; set; } = 1;

        public Color Couleur { get; set; } = Color.Black;

        public Point Position { get; set; } = new Point(20, 320);


        public void DrawTheBoxScoreGame(Graphics g, List<List<int>> score)
        {
            Rectangle r = new Rectangle(Position,BoxScoreSize);
            Pen p = new Pen(Couleur, Epaisseur);
            g.DrawRectangle(p, r);
            g.DrawString("Score Game", new Font("Times New Roman", 10, FontStyle.Bold), Brushes.Black, Position.X,Position.Y-20);
            DrawTheScoreGame(g, score);
            
        }

        public void DrawTheScoreGame(Graphics g, List<List<int>> score ) {
            
            for (int i = 0; i < score.Count; i++)
            {
                int sum = 0;
                for (int j = 0; j < score[i].Count; j++)
                {
                    sum += score[i][j];                  
                }
                Point position = new Point(Position.X, Position.Y + i * spaceBeetween);
                g.DrawString("Player " + i + " = " + sum, new Font("Times New Roman", 8, FontStyle.Bold), Brushes.Black, position);
                
            }
        }

    }
}
