using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame2022
{
    /// <summary>
    /// A window that displays the view and UI for a game
    /// </summary>
    internal partial class MainWindow : Form
    {
        #region Association attributes
        ScoreViews scoreViews = new ScoreViews();
        private List<List<int>> scores = new List<List<int>>();
        private List<List<CardView>> allCardsView = new List<List<CardView>>();
        private List<CardView> currentHand = new List<CardView>();
        private readonly GameController gameController;
        private int numRowOk = -1;
        #endregion
        #region Constructor
        internal MainWindow(GameController gameController)
        {
            InitializeComponent();
            this.gameController = gameController;
            for (int i = 0; i < 4; i++)
            {
                List<CardView> list = new List<CardView>();
                allCardsView.Add(list);
            }

            for (int i = 0; i < gameController.getNumberPlayer(); i++)
            {
                scores.Add(new List<int>());
            }
            gameController.StartMeUp(this);
        }
        #endregion
        #region Methods called by the controller
 
        /// <summary>
        /// Method called by the controler to update one row of cards on the table
        /// </summary>
        /// <param name="row">The number of the row</param>
        /// <param name="cards">The list of cards</param>
        /// <summary>
        /// Method called by the controler to update one row of cards on the table
        /// </summary>
        /// <param name="row">The number of the row</param>
        /// <param name="cards">The list of cards</param>
        internal void UpdateRow(int row, List<int> cards)
        {
            allCardsView[row].Clear();
            for (int i = 0; i < cards.Count(); i++)
            {
                CardView cv = new CardView(cards[i]);
                allCardsView[row].Add(cv);
                allCardsView[row][i].setPoint(new Point(150 + 65 * i, 20 + 90 * row));
            }
            Refresh();
        }

        /// <summary>
        /// Method called to display the cards of a player in dedicated controls.
        /// </summary>
        /// <param name="player">The player selected.</param>
        /// <param name="cards">The cards to display.</param>
        internal void UpdateHand(int player, List<int> cards)
        {
            
            currentHand.Clear();
            for (int l = 0; l < cards.Count(); l++)
            {
                CardView cv = new CardView(cards[l]);
                currentHand.Add(cv);
                currentHand[l].setPoint(new Point(150 + 65 * l, 400));
            }
            Refresh();
            
        }

        /// <summary>
        /// Method called to display the score in dedicated controls.
        /// </summary>
        /// <param name="player">The player selected.</param>
        /// <param name="score">The score of the player.</param>
        internal void UpdateScore(int player, int score)
        {
            scores[player].Add(score);
        }

        /// <summary>
        /// Draw a hand for the current
        /// </summary>
        /// <param name="player"> the index of players</param>
        /// <param name="cards"> the card list</param>
        internal void drawHandCurrent(int player, List<int> cards)
        {
            List<CardView> cardsHand = new List<CardView>();
            for (int i = 0; i < cards.Count(); i++)
            {
                cardsHand.Add(new CardView(cards[i]));
                cardsHand[i].setPoint(new Point(150 + 65 * i, 400));
            }
            currentHand = cardsHand;
            Refresh();
        }

        #endregion
        #region Event handling

        /// <summary>
        /// the paint of windows
        /// </summary>
        /// <param name="sender"> the sender</param>
        /// <param name="e"> the event</param>
        private void MainWindow_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < allCardsView.Count(); i++)
            {
                for (int j = 0; j < allCardsView[i].Count(); j++)
                {
                    if (allCardsView[i][j] != null)
                    {
                        allCardsView[i][j].drawCard(e.Graphics);
                    }
                }
            }

            scoreViews.DrawTheBoxScoreGame(e.Graphics, scores);

            for (int i = 0; i < currentHand.Count(); i++)
            {
                if (currentHand[i] != null)
                {
                    currentHand[i].drawCard(e.Graphics);
                }
            }
        }

        /// <summary>
        /// create a new round
        /// </summary>
        /// <param name="sender"> the sender</param>
        /// <param name="e"> the event</param>
        private void NewRound_Click(object sender, EventArgs e)
        {
            DisableNewRound();
            gameController.RoundGone();
        }

        /// <summary>
        /// Enable the new round buttom
        /// </summary>
        internal void EnableNewRound()
        {
            newRound.Enabled = true;
            newRound.BackColor = Color.White;
        }

        /// <summary>
        /// Disable the new round buttom
        /// </summary>
        private void DisableNewRound()
        {
            newRound.Enabled = false;
            newRound.BackColor = Color.Gray;
        }

        /// <summary>
        /// reboot the score
        /// </summary>
        private void ScoreReboot()
        {
            for (int i = 0; i < scores.Count(); i++) { scores[i].Clear(); }

        }
        
        /// <summary>
        /// create a new game
        /// </summary>
        /// <param name="sender"> the sender </param>
        /// <param name="e"> the event </param>
        private void NewGame_Click(object sender, EventArgs e)
        {
            ScoreReboot();
            gameController.NewGame();
            gameController.StartMeUp(this);
        }

        /// <summary>
        /// Show the current player
        /// </summary>
        /// <param name="s"> </param>
        public void setLabelCurrenPlayert(String s)
        {
            labelCurrentPlayer.Text = s;
        }

        /// <summary>
        /// Announce the turn of the next player
        /// </summary>
        /// <param name="players"></param>
        public void announceTheTurn(int player) {
            MessageBox.Show("Its the turn of the player " + player);
        }
        #endregion

        /// <summary>
        /// select a card 
        /// </summary>
        /// <param name="e">the event</param>
        /// <returns></returns>
        private CardView selectCard(MouseEventArgs e)
        {
            CardView card = new CardView(0);
            for (int i = 0; i < currentHand.Count(); i++)
            {
                if (currentHand[i] != null)
                {
                    Point cmp = currentHand[i].GetPoint();
                    if (e.Location.X >= cmp.X && e.Location.X <= cmp.X + currentHand[i].getCardWidth())
                    {
                        if (e.Location.Y >= cmp.Y && e.Location.Y <= cmp.Y + currentHand[i].getCardHeight())
                        {
                            card = currentHand[i];
                        }
                    }
                }
            }
            return card;
        }

        /// <summary>
        /// select the row
        /// </summary>
        /// <param name="e"></param>
        public void selectRow(MouseEventArgs e)
        {
            numRowOk = -1;
            for (int i = 0; i < allCardsView.Count(); i++)
            {
                for(int j = 0; j < allCardsView[i].Count(); j++)
                {
                    if (allCardsView[i][j] != null)
                    {
                        Point cmp = allCardsView[i][j].GetPoint();
                        if (e.Location.X >= cmp.X && e.Location.X <= cmp.X + allCardsView[i][j].getCardWidth())
                        {
                            if (e.Location.Y >= cmp.Y && e.Location.Y <= cmp.Y + allCardsView[i][j].getCardHeight())
                            {
                                numRowOk = i;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// get the 
        /// </summary>
        /// <returns></returns>
        public int getNumRow()
        {
            return numRowOk;
        }

        /// <summary>
        /// Methode call when the mouse is down
        /// </summary>
        /// <param name="sender"> the sender </param>
        /// <param name="e"> the event </param>
        private void MainWindow_MouseDown(object sender, MouseEventArgs e)
        {
            CardView selectingCard = selectCard(e);
            if (selectingCard.getCardNumber() != 0)
            {
                gameController.Interpret(selectingCard.getCardNumber().ToString());
                currentHand.Remove(selectingCard);
            }
            selectRow(e);
            gameController.Interpret(numRowOk.ToString());
        }
    }
}
