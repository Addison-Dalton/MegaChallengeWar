using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MegaChallengeWar
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void PlayButtonClick(object sender, EventArgs e)
        {
            Game game = new Game();
            game.InitializeGame();
            game.Play();
            DisplayGameSummary(game);
        }

        private void DisplayGameSummary(Game game)
        {
            battleSummaryLabel.Text = game.GetGameSummary();
        }
    }
}