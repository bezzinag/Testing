using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Logic
    {
        private Data data = new Data();

        public bool checkIfPlayerExists(string username)
        {
            // Call to Data layer returns IQueryable<Player>
            var checkplayer = data.checkifplayerexistsindb(username);
            // Convert IQueryable<Player> to bool to indicate existence
            return checkplayer.Any(); // .Any() checks if there are any records in the IQueryable result
        }

        public bool checkPassword(string username, string password)
        {
            var checkpassword = data.confirmpasswordindb(username, password);
            return checkpassword.Any();
        }
        public void addPlayer(string username, string password)
        {
            data.addplayerindb(username, password);
        }
        public bool checkIfGameExists(string player1Id, string player2Id)
        {
            var checkgame = data.CheckIncompleteGames(player1Id, player2Id);
            return checkgame.Any();
        }

    }
}
