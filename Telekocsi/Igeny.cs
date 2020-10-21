namespace Telekocsi
{
    internal class Igeny
    {
        public string Azonosito { get; private set; }
        public string Indulas { get; private set; }
        public string Cel { get; private set; }
        public int Szemelyek { get; private set; }
        public Igeny(string sor)
        {
            string[] adat = sor.Split(';');
            Azonosito = adat[0];
            Indulas = adat[1];
            Cel = adat[2];
            Szemelyek = int.Parse(adat[3]);
        }
    }
}