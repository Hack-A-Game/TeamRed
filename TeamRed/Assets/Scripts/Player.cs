using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{

    public class Player
    {
        public int playerId;
        public List<Character> characters;
		public Castle castle;
        public List<Cell> castleCells;

        public Player (int id)
        {
            playerId = id;
            characters = new List<Character>();
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

		public void BeginTurn() {
			foreach (Character c in characters) {
				c.BeginTurn ();
			}
		}
    }

}
