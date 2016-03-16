using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{

    public class Player
    {
        public int playerId;
        List<Character> characters;
		public Castle castle;
		public Cell castleCell;
        public Player (int id)
        {
            playerId = id;
        }

        public bool CompareTo(Player other)
        {
            if(other!= null)
                return playerId == other.playerId;
            else
            {
                return false;
            } 
        }

        public void SpawnPlayers()
        {
            
        }
    }

}
