using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        public struct adat1
        {
            public char tipus;
            public string cimszo;
            public int osszeg;
            public string date;
        }

        //befektetes kezelesehez
        public struct adat2
        {
            public string nev;
            public int Oertek; //Részvény értéke
            public int Bertek; //Birtokolt részvény értéke
            public string date;
        }

        static adat1[] bevetel = new adat1[150];
        static adat1[] kiadas = new adat1[150];
        static adat2[] befektetes = new adat2[150];

        static string[] date = DateTime.Today.ToString().Split('.');

        static int menuszam = 0;
        static int n = 0;
        //Menu
        static int menu(string menupont1, string menupont2, string menupont3, string menupont4)
        {
            int bekeres;
            Console.SetCursorPosition(10,0);
            Console.WriteLine("Üdvözöllek az önfejlesztés világában!");
            Console.SetCursorPosition(15, 4);
            Console.Write(menupont1); // befektetések
            Console.SetCursorPosition(15, 6);
            Console.Write(menupont2); // teendők
            Console.SetCursorPosition(15, 8);
            Console.Write(menupont3); // olvasott könyvek
            Console.SetCursorPosition(15, 10);
            Console.WriteLine(menupont4); // meditáció
            Console.SetCursorPosition(15, 12);
            Console.WriteLine("5. Vissza"); // meditáció
            Console.SetCursorPosition(15, 14);
            Console.Write("Kérem válasszon egy számot: ");
            bekeres = int.Parse(Console.ReadLine());
            return bekeres;
        }

        //mentés animáció
        static void mentes()
        {
            Console.Clear();
            Console.Write("Mentés.");
            Thread.Sleep(1000);
            Console.Clear();
            Console.Write("Mentés..");
            Thread.Sleep(1000);
            Console.Clear();
            Console.Write("Mentés...");
            Console.Clear();
        }

        //pénzügy bevételek
        static void bevetelek()
        {
            int i = 0;

            Console.Write("Vége -> *");
            Console.SetCursorPosition(5, 3);
            Console.Write("Kérem adja meg az elem címszavát: ");
            bevetel[i].cimszo = Console.ReadLine();
            while (bevetel[i].cimszo != "*")
            {
                bevetel[i].tipus = 'b';
                Console.SetCursorPosition(5, 5);
                Console.Write($"Kérem adja meg a(z) {bevetel[i].cimszo} összegét: ");
                bevetel[i].osszeg = int.Parse(Console.ReadLine());
                bevetel[i].date = DateTime.Now.ToString();
                i++;

                mentes();

                Console.Write("Vége -> *");
                Console.SetCursorPosition(5, 3);
                Console.Write("Kérem adja meg az elem címszavát: ");
                bevetel[i].cimszo = Console.ReadLine();
            }
            n = i;

            //eddigi sorok beolvasása
            int length = File.ReadAllLines("bevetel.txt").Length;
            string[] seged = new string[length];
            FileStream f1 = new FileStream("bevetel.txt", FileMode.Open);
            StreamReader sr = new StreamReader(f1);

            seged[0] = sr.ReadLine();
            for (int h = 1; h < length; h++)
            {
                seged[h] = sr.ReadLine();
            }
            sr.Close();
            f1.Close();

            FileStream f2 = new FileStream("bevetel.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(f2);

            //eddigi sorok kiírása
            for (int g = 0; g < length; g++)
            {
                sw.WriteLine(seged[g]);
            }

            //újjonnan hozzáadott sorok kiírása
            for (int j = 0; j < n; j++)
            {
                sw.WriteLine($"{bevetel[j].cimszo}|{bevetel[j].tipus}|{bevetel[j].osszeg}|{bevetel[j].date}");
            }
            sw.Close();
            f2.Close();

            mentes();
            menuszam = menu("1. Pénzügy", "2. Teendők", "3. Olvasott könyvek", "4. Meditáció");
            menuDontes(ref menuszam);
        }

        //pénzügy kiadások
        static void kiadasok()
        {
            int i = 0;

            Console.Write("Vége -> *");
            Console.SetCursorPosition(5, 3);
            Console.Write("Kérem adja meg az elem címszavát: ");
            kiadas[i].cimszo = Console.ReadLine();
            while (kiadas[i].cimszo != "*")
            {
                kiadas[i].tipus = 'k';
                Console.SetCursorPosition(5, 5);
                Console.Write($"Kérem adja meg a(z) {kiadas[i].cimszo} összegét: ");
                kiadas[i].osszeg = int.Parse(Console.ReadLine());
                kiadas[i].date = DateTime.Now.ToString();
                i++;

                mentes();

                Console.Write("Vége -> *");
                Console.SetCursorPosition(5, 3);
                Console.Write("Kérem adja meg az elem címszavát: ");
                kiadas[i].cimszo = Console.ReadLine();
            }
            n = i;

            //eddigi sorok beolvasása
            int length = File.ReadAllLines("kiadas.txt").Length;
            string[] seged = new string[length];
            FileStream f1 = new FileStream("kiadas.txt", FileMode.Open);
            StreamReader sr = new StreamReader(f1);

            seged[0] = sr.ReadLine();
            for (int h = 1; h < length; h++)
            {
                seged[h] = sr.ReadLine();
            }
            sr.Close();
            f1.Close();

            FileStream f2 = new FileStream("kiadas.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(f2);

            //eddigi sorok kiírása
            for (int g = 0; g < length; g++)
            {
                sw.WriteLine(seged[g]);
            }

            //újjonnan hozzáadott sorok kiírása
            for (int j = 0; j < n; j++)
            {
                sw.WriteLine($"{kiadas[j].cimszo}|{kiadas[j].tipus}|{kiadas[j].osszeg}|{kiadas[j].date}");
            }
            sw.Close();
            f2.Close();

            mentes();
            menuszam = menu("1. Pénzügy", "2. Teendők", "3. Olvasott könyvek", "4. Meditáció");
            menuDontes(ref menuszam);
        }
    
        /*
        ╔ -> alt + 201
        ╚ -> alt + 200
        ╩ -> alt + 202
        ╦ -> alt + 203
        ╠ -> alt + 204
        ╣ -> alt + 185
        ║ -> alt + 186
        ╬ -> alt + 206
        ═ -> alt + 205
        ╗ -> alt + 187
        ╝ -> alt + 188
        */

        //statisztikák hetekre
        static void stat7()
        {
            //bevétel beolvasás
            bevetel = new adat1[150];
            int length = File.ReadAllLines("bevetel.txt").Length;
            string[] seged = new string[length];

            int bevetelOssz = 0;
            adat1[] segedAdatB = new adat1[length];

            FileStream f1 = new FileStream("bevetel.txt", FileMode.Open);
            StreamReader sr = new StreamReader(f1);

            string fejlec = sr.ReadLine();
            for (int h = 1; h < length; h++)
            {
                seged = sr.ReadLine().Split('|');
                bevetel[h].cimszo = seged[0];
                bevetel[h].tipus = char.Parse(seged[1]);
                bevetel[h].osszeg = int.Parse(seged[2]);
                bevetel[h].date = seged[3];
            }
            sr.Close();
            f1.Close();

            for (int i = 0; i < length; i++)
            {
                bevetelOssz += bevetel[i].osszeg;
            }

            //kiadás beolvasás
            kiadas = new adat1[150];
            int length1 = File.ReadAllLines("kiadas.txt").Length;
            string[] seged1 = new string[length];

            int kiadasOssz = 0;
            adat1[] segedAdat = new adat1[length1];

            FileStream f2 = new FileStream("kiadas.txt", FileMode.Open);
            StreamReader sr1 = new StreamReader(f2);

            string fejlec1 = sr1.ReadLine();
            for (int h = 1; h < length1; h++)
            {
                seged1 = sr1.ReadLine().Split('|');
                kiadas[h].cimszo = seged1[0];
                kiadas[h].tipus = char.Parse(seged1[1]);
                kiadas[h].osszeg = int.Parse(seged1[2]);
                kiadas[h].date = seged1[3];
            }
            sr1.Close();
            f2.Close();

            for (int i = 0; i < length1; i++)
            {
                kiadasOssz += kiadas[i].osszeg;
            }

            //Jelenlegi vagyon
            int vagyon = bevetelOssz - kiadasOssz;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Az ön össz vagyona: {vagyon}Ft");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($" kiadások:  {kiadasOssz}Ft");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" bevételek: {bevetelOssz}Ft");
            Console.ResetColor();

            //Eddigi Összes kiadások növekvő sorrendben
            //kiadás növekvő sorrend
            for (int i = length-1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (kiadas[j].osszeg > kiadas[j+1].osszeg)
                    {
                        segedAdat[j] = kiadas[j];
                        kiadas[j] = kiadas[j + 1];
                        kiadas[j + 1] = segedAdat[j];
                    }
                }
            }

            //Eddigi összes bevétel növekvő sorrendben
            //bevétel növekvő sorrend
            for (int i = length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (bevetel[j].osszeg > bevetel[j + 1].osszeg)
                    {
                        segedAdatB[j] = bevetel[j];
                        bevetel[j] = bevetel[j + 1];
                        bevetel[j + 1] = segedAdatB[j];
                    }
                }
            }

            //Legnagyobb kiadás
            int maxKiadas = 0;

            for (int i = 0; i < length1; i++)
            {
                if (kiadas[maxKiadas].osszeg < kiadas[i].osszeg)
                {
                    maxKiadas = i;
                }
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Legnagyobb kiadás:");
            Console.ResetColor();
            Console.WriteLine($" Megnevezés: {kiadas[maxKiadas].cimszo} \n Összeg: {kiadas[maxKiadas].osszeg} \n Dátum: {kiadas[maxKiadas].date}");

            //Legnagyobb bevétel
            int maxBevetel = 0;

            for (int i = 0; i < length1; i++)
            {
                if (bevetel[maxBevetel].osszeg < bevetel[i].osszeg)
                {
                    maxBevetel = i;
                }
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Legnagyobb bevétel:");
            Console.ResetColor();
            Console.WriteLine($" Megnevezés: {bevetel[maxBevetel].cimszo} \n Összeg: {bevetel[maxBevetel].osszeg} \n Dátum: {bevetel[maxBevetel].date}");

            //Bevétel kiírása
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Bevételek");
            Console.ResetColor();
            Console.WriteLine(fejlec);
            for (int i = 1; i < length; i++)
            {
                Console.WriteLine($"{bevetel[i].cimszo} \t {bevetel[i].tipus} \t {bevetel[i].osszeg} \t {bevetel[i].date}");
            }

            //kiadások kiírása
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Kiadások");
            Console.ResetColor();
            Console.WriteLine(fejlec1);
            for (int i = 1; i < length1; i++)
            {
                Console.WriteLine($"{kiadas[i].cimszo} \t {kiadas[i].tipus} \t {kiadas[i].osszeg} \t {kiadas[i].date}");
            }

            Console.ReadKey();
            Console.Clear();
            menuszam = menu("1. Pénzügy", "2. Teendők", "3. Olvasott könyvek", "4. Meditáció");
            menuDontes(ref menuszam);
        }

        //Mennyit fektetett be, hova, mikor
        static void befektetesekHozzaadasa()
        {
            int i = 0;

            Console.Write("Vége -> *");
            Console.SetCursorPosition(5, 3);
            Console.Write("Kérem adja meg az elem címszavát: ");
            befektetes[i].nev = Console.ReadLine();
            while (befektetes[i].nev != "*")
            {
                Console.SetCursorPosition(5, 5);
                Console.Write($"Kérem adja meg a(z) {befektetes[i].nev} értékét: ");
                befektetes[i].Oertek = int.Parse(Console.ReadLine());
                Console.SetCursorPosition(5, 7);
                Console.Write($"Kérem adja meg a(z) {befektetes[i].nev} birtokolt értékét: ");
                befektetes[i].Bertek = int.Parse(Console.ReadLine());
                befektetes[i].date = DateTime.Now.ToString();
                i++;

                mentes();

                Console.Write("Vége -> *");
                Console.SetCursorPosition(5, 3);
                Console.Write("Kérem adja meg az elem címszavát: ");
                befektetes[i].nev = Console.ReadLine();
            }
            n = i;

            //eddigi sorok beolvasása
            int length = File.ReadAllLines("befektetesek.txt").Length;
            string[] seged = new string[length];
            FileStream f1 = new FileStream("befektetesek.txt", FileMode.Open);
            StreamReader sr = new StreamReader(f1);

            seged[0] = sr.ReadLine();
            for (int h = 1; h < length; h++)
            {
                seged[h] = sr.ReadLine();
            }
            sr.Close();
            f1.Close();

            FileStream f2 = new FileStream("befektetesek.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(f2);

            //eddigi sorok kiírása
            for (int g = 0; g < length; g++)
            {
                sw.WriteLine(seged[g]);
            }

            //újjonnan hozzáadott sorok kiírása
            for (int j = 0; j < n; j++)
            {
                sw.WriteLine($"{befektetes[j].nev}|{befektetes[j].Oertek}|{befektetes[j].Bertek}|{befektetes[j].date}");
            }
            sw.Close();
            f2.Close();

            mentes();
            menuszam = menu("1. Pénzügy", "2. Teendők", "3. Olvasott könyvek", "4. Meditáció");
            menuDontes(ref menuszam);
        }

        //befektetés statisztika
        static void befektetesStat()
        {
            Console.WriteLine("Listázáshoz kérem válasszon a menüpontokból");

            int n = File.ReadAllLines("befektetesek.txt").Length-1;
            string[] seged = new string[6];

            FileStream f = new FileStream("befektetesek.txt", FileMode.Open);
            StreamReader sr = new StreamReader(f);

            string fejlec = sr.ReadLine();
            for (int i = 0; i < n; i++)
            {
                seged = sr.ReadLine().Split('|');
                befektetes[i].nev = seged[0];
                befektetes[i].Oertek = int.Parse(seged[1]);
                befektetes[i].Bertek = int.Parse(seged[2]);
                befektetes[i].date = seged[3];
            }
            sr.Close();
            f.Close();

            for (int i = 0; i < n; i++)
            {
                if (befektetes[i].nev == befektetes[i+1].nev)
                {

                }

                Console.WriteLine($"{i+1}. {befektetes[i].nev}");
            }
        }

        //befektetések menü
        static void befektetesekmenu()
        {
            int Bmenuszam = menu("1. Befektetés hozzáadása", "2. Befektetések Statisztika", "", "");
            switch (Bmenuszam)
            {
                case 1: //1-es menüpont
                    Console.Clear();
                    befektetesekHozzaadasa();
                    break;
                case 2: //2-es menüpont
                    Console.Clear();
                    befektetesStat();
                    break;
                case 5: // Vissza
                    Console.Clear();
                    menuszam = menu("1. Pénzügy", "2. Teendők", "3. Olvasott könyvek", "4. Meditáció");
                    menuDontes(ref menuszam);
                    break;
                default:
                    break;
            }
        }

        //pénzügy menü
        static void penzugyMenu()
        {
            int Bmenuszam = menu("1. Bevételek", "2. Kiadások", "3. Befektetések", "4. Statisztika");
            switch (Bmenuszam)
            {
                case 1:
                    Console.Clear();
                    bevetelek();
                    break;
                case 2:
                    Console.Clear();
                    kiadasok();
                    break;
                case 3:
                    Console.Clear();
                    befektetesekmenu();
                    break;
                case 4:
                    Console.Clear();
                    stat7();
                    break;
                case 5:
                    Console.Clear();
                    menuszam = menu("1. Pénzügy", "2. Teendők", "3. Olvasott könyvek", "4. Meditáció");
                    menuDontes(ref menuszam);
                    break;
                default:
                    break;
            }
        }

        //Teendők menü
        static void teendokMenu()
        {
            int Tmenuszam = menu("1. Teendő hozzáadása", "2. Teendők Listázása", "", "");
            switch (Tmenuszam)
            {
                case 1: //1-es menüpont
                    Console.Clear();
                    Console.WriteLine("Teendő hozzáadása");
                    break;
                case 2: //2-es menüpont
                    Console.Clear();
                    Console.WriteLine("Teendő Listázása");
                    break;
                case 5: // Vissza
                    Console.Clear();
                    menuszam = menu("1. Pénzügy", "2. Teendők", "3. Olvasott könyvek", "4. Meditáció");
                    menuDontes(ref menuszam);
                    break;
                default:
                    break;
            }
        }

        //könyvek menü
        static void konyvMenu()
        {
            int Kmenuszam = menu("1. Olvasott könyv hozzáadása", "2. Olvasott könyvek Listázása", "", "");
            switch (Kmenuszam)
            {
                case 1: //1-es menüpont
                    Console.Clear();
                    Console.WriteLine("Olvasott könyv hozzáadása");
                    break;
                case 2: //2-es menüpont
                    Console.Clear();
                    Console.WriteLine("Olvasott könyvek Listázása");
                    break;
                case 5: // Vissza
                    Console.Clear();
                    menuszam = menu("1. Pénzügy", "2. Teendők", "3. Olvasott könyvek", "4. Meditáció");
                    menuDontes(ref menuszam);
                    break;
                default:
                    break;
            }
        }

        //Menu "agy"
        static void menuDontes(ref int beszam)
        {
            switch (beszam)
            {
                case 1:
                    Console.Clear();
                    penzugyMenu();
                    break;
                case 2:
                    Console.Clear();
                    teendokMenu();
                    break;
                case 3:
                    Console.Clear();
                    konyvMenu();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("meditáció");
                    break;
                case 5:
                    Console.Clear();
                    menuszam = menu("1. Pénzügy", "2. Teendők", "3. Olvasott könyvek", "4. Meditáció");
                    menuDontes(ref menuszam);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Kérem helyes számot adjon meg!");
                    Console.ReadKey();
                    break;
            }
        }

        static void Main(string[] args)
        {
            menuszam = menu("1. Pénzügy", "2. Teendők", "3. Olvasott könyvek", "4. Meditáció");
            menuDontes(ref menuszam);

            Console.ReadKey();
        }
    }
}
