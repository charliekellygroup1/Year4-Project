using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Iteration1.Models.Game
{
    public class Trick
    {
        public Trick(string cardUrl, int trickIndex)
        {
            this.TrickCard = cardUrl;
            this.TrickIndex = trickIndex;
        }
        public Trick()
        {

        }

        public string TrickCard { get;  set; }
        public int TrickIndex { get;  set; }
        public int ID { get;  set; }


    }
}