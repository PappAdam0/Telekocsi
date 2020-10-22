namespace Telekocsi
{
    internal class Autok
    {
        public string Indulas { get; private set; }
        public string Cel { get; private set; }
        public string Rendszam { get; private set; }
        public string Telefonszam { get; private set; }
        public int Ferohely { get; private set; }
        public string Utvonal { get; private set; }
        public Autok(string sor)
        {
            string[] adat = sor.Split(';');
            Indulas = adat[0];
            Cel = adat[1];
            Rendszam = adat[2];
            Telefonszam = adat[3];
            Ferohely = int.Parse(adat[4]);
            Utvonal = Indulas + "-" + Cel;
        }
       
    }
}