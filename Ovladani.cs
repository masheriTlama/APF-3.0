using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APF_3._0
{
    internal class Ovladani : Form1
    {
        MediaPlayer mp;
        List<string> drzeneKlavesy;
        int puvodniSirka;
        int puvodniVyska;
        public Ovladani(MediaPlayer _mp, int _puvodniSirka, int _puvodniVyska)
        {
            mp = _mp;           
            drzeneKlavesy = new List<string>();
            puvodniSirka = _puvodniSirka;
            puvodniVyska = _puvodniVyska;
        }

        public void Drzim(string klavesa)
        {
            drzeneKlavesy.Add(klavesa);
        }

        public void Poustim(string klavesa)
        {
            //drzeneKlavesy.RemoveAll(x => x == klavesa);
            drzeneKlavesy.Clear();  // git test
        }

        public void RozklicujPrikaz(string klavesa)
        {
            if (klavesa == "W" && drzeneKlavesy.Contains("ShiftKey")) { Povol(15); }
            else if (klavesa == "S" && drzeneKlavesy.Contains("ShiftKey")) { Povol(-15); }
            else if (klavesa == "W") { Povol(5); }
            else if (klavesa == "S") { Povol(-5); }
            else if (klavesa == "D" && drzeneKlavesy.Contains("ShiftKey")) { Posun(15); }
            else if (klavesa == "A" && drzeneKlavesy.Contains("ShiftKey")) { Posun(-15); }
            else if (klavesa == "D") { Posun(5); }
            else if (klavesa == "A") { Posun(-5); }

            else if (klavesa == "E" && drzeneKlavesy.Contains("ControlKey")) { Preskoc(); }

            //drzeneKlavesy.Add(klavesa);
        }

        private void Povol(int pocet)
        {
            mp.Volume += pocet;
        }

        private void Posun(int pocet)
        {
            mp.Position += pocet / (mp.Media.Duration / 1000f);
        }

        private void Preskoc()
        {
            mp.Position = 1;
        }
    }
}
