using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gate
{
    public class Gate
    {
        #region Eigenschaften
        private string _name;

        #endregion

        #region Accessoren/Modifier
        public string Name { get => _name; set => _name = value; }

        #endregion

        #region Konstruktoren
        public Gate()
        {
            Name = "";
        }
        public Gate(string g="")
        {
            Name = g;
        }

        #endregion

        #region Worker

        #endregion
    }
}