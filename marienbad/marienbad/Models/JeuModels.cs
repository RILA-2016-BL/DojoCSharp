using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace marienbad.Models
{
    public class JeuModels
    {
       
        public List<int> Items { get; set; }
        public String Nickname { get; set; }
        public Boolean Checked { get; set; }
        public int Row { get; set; }
        public int Count { get; set; }
        public JeuModels()
        {
            Row = -1;
            Count = 0;
        }
    }
}