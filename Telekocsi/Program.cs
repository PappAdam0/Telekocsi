using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;

namespace Telekocsi
{
    class Program
    {
        static List<Autok> autok = new List<Autok>();
        static List<Igeny> igeny = new List<Igeny>();

        static void Beolvas()
        {
            StreamReader be = new StreamReader("autok.csv");
            be.ReadLine();
            while (!be.EndOfStream)
            {
                autok.Add(new Autok(be.ReadLine()));
            }
            be.Close();


            Console.WriteLine($"2. Feladat\n\t{autok.Count} autós hirdet fuvart");

            StreamReader be2 = new StreamReader("igenyek.csv");
            be2.ReadLine();
            while (!be2.EndOfStream)
            {
                igeny.Add(new Igeny(be2.ReadLine()));
            }
            be2.Close();
        }

        static void harmadik()
        {
            int hely = 0;
            foreach (var i in autok)
            {
                if (i.Indulas == "Budapest" && i.Cel == "Miskolc")
                {
                    hely = hely + i.Ferohely;
                }
            }
            Console.WriteLine($"3. Feladat:\n\tÖsszesen {hely} férőhelyet hirdettek az autósok Budapestről Miskolcra");
        }

        static void negyedik()
        {

            //Dictionary<string,int> utvonalak = new Dictionary<string, int>();
            //foreach (var a in autok)
            //{
            //    if (!utvonalak.ContainsKey(a.Utvonal))
            //    {
            //        utvonalak.Add(a.Utvonal, a.Ferohely);
            //    }
            //    else
            //    {
            //        utvonalak[a.Utvonal] = utvonalak[a.Utvonal] + a.Ferohely;
            //    }
            //}

            //foreach (var i in utvonalak)
            //{
            //    if (max < i.Value)
            //    {
            //        max = i.Value;
            //        utv = i.Key;
            //    }
            //}

            int max = 0;
            string utv = "";

            var utvonalak = from a in autok
                            orderby a.Utvonal
                            group a by a.Utvonal into temp
                            select temp;
            foreach (var ut in utvonalak)
            {
                int fh = ut.Sum(x => x.Ferohely);
                if (max < fh)
                {
                    max = fh;
                    utv = ut.Key;
                }
            }

            Console.WriteLine("4. Feladat:");
            Console.WriteLine($"A legtöbb férőhelyet ({max}) a {utv} útvonalon ajánlottak fel a hírdetők");


        }

       static void otos()
        {
            Console.WriteLine("5. feladat");

            foreach (var igeny in igeny)
            {
                int i = igeny.VanAuto(autok);

                if (i > -1)
                {
                    Console.WriteLine($"{igeny.Azonosito}=>{autok[i].Rendszam}");
                }
            }

            Console.WriteLine();
        }

        static void hatos()
        {
            StreamWriter file = new StreamWriter("utasuzenetek.txt");

            foreach (var igeny in igeny)
            {
                int i = igeny.VanAuto(autok);

                if (i > -1)
                {
                    file.WriteLine($"{igeny.Azonosito}: Rendszám: {autok[i].Rendszam}, Telefonszám: {autok[i].Telefonszam}");
                }
                else
                {
                    file.WriteLine($"{igeny.Azonosito}: Sajnos nem sikerült autót találni");
                }
            }


            file.Close();
        }
        static void Main(string[] args)
        {
            Beolvas();
            harmadik();
            negyedik();
            otos();
            hatos();


            Console.ReadKey();
        }
    }
}
