using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XML_NOTES
{
    public class Player
    {
        [XmlElement("Player_Name")]
        public string name;
        [XmlElement("HighScore")]
        public int highScore;

        public Player()
        {
            this.name = "?";
            this.highScore = -1;
        }

        public Player(string name, int highScore)
        {
            this.name = name;
            this.highScore = highScore;
        }

    }
}
