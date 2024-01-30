using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Data
    {
        public IQueryable<Player> checkifplayerexistsindb(string username)
        {
            BattleshipDataContext bscontext = new BattleshipDataContext();
            
            
                var player = bscontext.Players.Where(p => p.Username == username);
                return player;
            
        }
        public IQueryable<Player> confirmpasswordindb(string username, string password)
        {
            BattleshipDataContext bscontext = new BattleshipDataContext();
            
                var player = bscontext.Players.Where(p => p.Username == username && p.Password == password);
                return player;
            
        }
        public void addplayerindb(string username, string password)
        {
            BattleshipDataContext bscontext = new BattleshipDataContext();
            
                Player player = new Player();
                player.Username = username;
                player.Password = password;
                bscontext.Players.InsertOnSubmit(player);
                bscontext.SubmitChanges();
            
        }
        public IQueryable<Game> CheckIncompleteGames(string player1Id, string player2Id)
        {
            BattleshipDataContext bscontext = new BattleshipDataContext();

            return from game in bscontext.Games
                   where game.CreatorFK == player1Id && game.OpponentFK == player2Id && !game.Complete
                   select game;
        }
    }
}