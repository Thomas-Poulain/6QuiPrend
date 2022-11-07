using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame2022
{
    /// <summary>
    /// The game controller object allows a logic (GameLogic object) and view (MainWindow object) to communicate
    /// </summary>
    internal class GameController
    {
        #region Association attributes
        private GameLogic gameLogic;
        private MainWindow mainWindow;
        private int playerNumberCurrent;
        #endregion
        #region Properties accessed by the logic
        /// <summary>
        /// The integer (checked) entered by the current user for the current interaction.
        /// </summary>
        internal int CurrentInt { get; private set; }
        /// <summary>
        /// The possible integer inputs to choose from selectable for the user for the next interaction.
        /// </summary>
        internal List<int> AllowedInput { get; set; }
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor. Creates a new game logic.
        /// </summary>
        /// <param name="numberOfPlayers">The number of players (1-10) for the new game.</param>
        internal GameController(int numberOfPlayers)
        {
            gameLogic = new GameLogic(numberOfPlayers, this);
        }
        #endregion
        #region Methods called by the logic or view
        /// <summary>
        /// Method called by the logic when the state of the game (cards on the table) should be displayed.
        /// </summary>
        /// <param name="allRows">Each row of cards as a list of list of cards.</param>
        internal void UpdateState(List<List<int>> allRows)
        {
          //  mainWindow.WriteLine("All rows on the table:");
          //  mainWindow.WriteLine(gameLogic.AllRowsToString(allRows));
            for (int i=0; i<allRows.Count; i++)
            {
                mainWindow.UpdateRow(i, allRows[i]);
            }
            for (int i = 0; i < gameLogic.GetNumberOfPlayers(); i++)
            {
                mainWindow.UpdateHand(i, gameLogic.GetCurrentHandForPlayer(i));
                mainWindow.UpdateScore(i, gameLogic.GetCurrentScoreForPlayer(i));
            }
        }
        
        /// <summary>
        /// Method used by the window when a command is entered.
        /// </summary>
        /// <param name="text">The command entered, shoukd be an int within AllowedInput.</param>
        internal void Interpret(string text)
        {
            if (int.TryParse(text, out int res))
            {
                if (AllowedInput.Contains(res))
                {
                    CurrentInt = res;
                    AllowedInput = null;
                    gameLogic.ActOnce();
                }
            }
        }
        /// <summary>
        /// Method called to start the game.
        /// </summary>
        /// <param name="mainWindow">The window (view) to use for this game.</param>
        internal void StartMeUp(MainWindow mainWindow)
        {
            this.mainWindow= mainWindow;
            gameLogic.ActOnce();
        }
        /// <summary>
        /// Method used by the logic to say that the game has ended.
        /// </summary>
        internal void DisplayGameOverMessage()
        {
            AllowedInput = new List<int> { 0 };
        }
        /// <summary>
        /// Method used to prompt player "player" to select a card from their hand
        /// </summary>
        /// <param name="player">The player to select</param>
        internal void AskPlayerForCard(int player)
        {
            DisplayPlayerHand(player);
            DisplayCardSelectPromptForPlayer(player);
        }
        /// <summary>
        /// Method called to display the cards selected by players
        /// </summary>
        /// <param name="cardsSelectedByPlayers">The cards arranged by player</param>
        internal void DisplayCardsSelected(Dictionary<int, int> cardsSelectedByPlayers)
        {
            gameLogic.ActOnce();
        }

        /// <summary>
        /// display the instruction
        /// </summary>
        internal void DisplayTheRowChose() {
            MessageBox.Show("Click on a row to put your card ");
        }

        /// <summary>
        /// Method called to end a rubber
        /// </summary>
        internal void DisplayRubberOver()
        {
            gameLogic.ActOnce();
        }

        /// <summary>
        /// Method used to reset the input whenever necessary
        /// </summary>
        internal void ResetInput() => CurrentInt = -1;


        #endregion
        #region Private methods

        /// <summary>
        /// Display the player hand 
        /// </summary>
        /// <param name="player">the index of player</param>
        private void DisplayPlayerHand(int player)
        {
            mainWindow.announceTheTurn(player);
            mainWindow.setLabelCurrenPlayert("Player " + player + ", this is your hand:");
            mainWindow.drawHandCurrent(player,gameLogic.GetCurrentHandForPlayer(player));
        }
        /// <summary>
        /// Display the Card select for player
        /// </summary>
        /// <param name="i"></param>
        private void DisplayCardSelectPromptForPlayer(int i)
        { 
            playerNumberCurrent = i;
        }

        /// <summary>
        /// the Round is gone
        /// </summary>
        internal void RoundGone()
        {
            gameLogic.newRound();
        }

        /// <summary>
        /// Enable the new round
        /// </summary>
        internal void EnableNewRound() {
            mainWindow.EnableNewRound();
        }

        /// <summary>
        /// start a new a game 
        /// </summary>
        internal void NewGame()
        {
            gameLogic = new GameLogic(gameLogic.GetNumberOfPlayers(), this);
        }

        /// <summary>
        /// get the number of player
        /// </summary>
        /// <returns></returns>
        public int getNumberPlayer()
        {
            return gameLogic.getNumberPlayer();
        }

        #endregion
    }
}
