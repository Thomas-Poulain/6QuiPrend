using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame2022
{
    public class CardView
    {
        Point point;
        int cardNumber;
        int cardMalus;
        int cardHeight = 80;
        int cardWidth = 50;
        Size size;

        /// <summary>
        /// the constructor of CardView
        /// </summary>
        /// <param name="c"></param>
        public CardView(int c)
        {
            cardNumber = c;
            cardMalus = cardsHandling(cardNumber);
            size = new Size(cardWidth, cardHeight);
        }

        /// <summary>
        /// Calculate the malus number
        /// </summary>
        /// <param name="cardNumber"> card number </param>
        /// <returns> malus number of the card</returns>
        public int cardsHandling(int cardNumber)
        {
            int malus = 1;
            Boolean find = false;
            if (!find && cardNumber == 55)
            {
                find = true;
                malus = 7;
            }
            if (!find && cardNumber % 11 == 0)
            {
                find = true;
                malus = 5;
            }
            if (!find && cardNumber % 10 == 0)
            {
                find = true;
                malus = 3;
            }
            if (!find && cardNumber % 5 == 0)
            {
                malus = 2;
            }
            return malus;
        }

        /// <summary>
        /// Draw the card on the graphics
        /// </summary>
        /// <param name="e">graphic</param>
        public void drawCard(Graphics e)
        {
            Pen p = new Pen(Color.Black, 3);
            Rectangle r = new Rectangle(point, size);
            e.DrawRectangle(p, r);
            drawMalus(e);
        }

        public int getCardNumber() { return cardNumber; }
        public int getCardMalus() { return cardMalus; }
        public Size getCardSize() { return size; }
        public int getCardWidth() { return cardWidth; }
        public int getCardHeight() { return cardHeight; }
        public Point GetPoint() { return point; }
        public void setPoint(Point point) { this.point = point; }

        /// <summary>
        /// Draw the card's strings on the graphics
        /// </summary>
        /// <param name="e">graphic</param>
        public void drawMalus(Graphics e)
        {
            int spaceNumber = 10;
            if (cardNumber < 10)
            {
                spaceNumber = 7;
            }
            Point p1 = new Point(point.X + (cardWidth / 2)-spaceNumber, point.Y+25);
            Point p2 = new Point(point.X + (cardWidth / 2)-5, point.Y+60);
            Point p3 = new Point(point.X +5, point.Y+10);
            Point p4 = new Point(point.X + 8, point.Y + 45);
            e.DrawString(this.getCardNumber().ToString(), new Font("Times New Roman", 10, FontStyle.Bold), Brushes.Black,p1);
            e.DrawString(this.getCardMalus().ToString(), new Font("Times New Roman", 8, FontStyle.Bold), Brushes.Black,p2);
            e.DrawString("Number :", new Font("Times New Roman", 7, FontStyle.Bold), Brushes.Black, p3);
            e.DrawString("Malus :", new Font("Times New Roman", 7, FontStyle.Bold), Brushes.Black, p4);
        }
    }
}