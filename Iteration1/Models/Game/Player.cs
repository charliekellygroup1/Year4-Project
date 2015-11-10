using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Iteration1.Models.Game
{
    public class Player
    {
        public Player(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
        public int ID { get; set; }
    }
}