using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WS_Collector
{
    class Card
    {
        public int ID { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string Expansion { get; set; }
        public string CardType { get; set; }
        public int Level { get; set; }  // Assuming it's an integer.
        public int Power { get; set; }  // Assuming it's an integer.
        public string Soul { get; set; }
        public string Rarity { get; set; }
        public string Trigger { get; set; }
        public string SpecialAttribute { get; set; }
        public string FlavorText { get; set; }
        public string CardText { get; set; }
        public string ImageLink { get; set; }

        // This will store the actual image if you're pulling it from the database
        public Image CardImage { get; set; }

        // This is the binary data, probably not necessary to store in this class 
        // unless you have a specific use for it outside of converting to the Image.
        // public byte[] BinaryImageData { get; set; }
    }
}
