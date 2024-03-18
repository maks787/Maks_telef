using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace Maks_telef
{
    public class Telefon
    {
        public string Nimetus { get; set; }
        public string Tootja { get; set; }
        public int Hind { get; set; }
        public string Pilt { get; set; }

        public Telefon(string nimetus, string tootja, int hind, string pilt)
        {
            Nimetus = nimetus;
            Tootja = tootja;
            Hind = hind;
            Pilt = pilt;
            
        }
    }
}