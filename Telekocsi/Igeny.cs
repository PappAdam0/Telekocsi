using System.Collections.Generic;

namespace Telekocsi
{
    internal class Igeny
    {
        public string Azonosito { get; private set; }
        public string Indulas { get; private set; }
        public string Cel { get; private set; }
        public int Szemelyek { get; private set; }
        public string Utvonal { get; set; }
        public Igeny(string sor)
        {
            string[] adat = sor.Split(';');
            Azonosito = adat[0];
            Indulas = adat[1];
            Cel = adat[2];
            
            Szemelyek = int.Parse(adat[3]);
            Utvonal = Indulas + "-" + Cel;

        }
        public int VanAuto(List<Autok> autok)
        {
            int i = 0;
            while (i< autok.Count && 
                !(Utvonal == autok[i].Utvonal && Szemelyek <= autok[i].Ferohely))
            {
                i++;
            }
            if (i <autok.Count)
            {
                return i;
            }
            else
            {
                return -1;
            }
        }
    }
}