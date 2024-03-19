using System;
using System.Collections.Generic;
using System.Text;

namespace Maks_telef
{
    public class riik
    {
        public string Nimetus { get; set; }
        public string Pealinn { get; set; }
        public int inimesed { get; set; }
        public string Pilt { get; set; }

        public riik(string nimetus, string tootja, int hind, string pilt)
        {
            Nimetus = nimetus;
            Pealinn = tootja;
            inimesed = hind;
            Pilt = pilt;

        }
    }
}
