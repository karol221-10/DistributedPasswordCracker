using CrackerTaskDistributor.api;
using CrackerTaskDistributor.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CrackerTaskDistributor.service
{
    class BruteForceRangeDeterminator : RangeDeterminator
    {
        private string pocz = "a";
        private string kon;
        private Mutex mutex = new Mutex();
        private List<string> listaWyrazow = new List<string>();
        private string ReplaceAtIndex(int i, char value, string word)
        {
            char[] letters = word.ToCharArray();
            letters[i] = value;
            return string.Join("", letters);
        }
        private void start2end(string pocz, string kon)
        {
            string nowy = "";
            bool f = true;//flaga wy koncowych wyrazow  typu zzz czy tez zzzzz
            int flaga, i, dl, dl2;//flaga to gdzie teraz jestesmy, niekoniecznie dlufgosc wyrazu
            while (1 == 1)
            {
                if (pocz == kon)
                    break;
                flaga = pocz.Length - 1;
                listaWyrazow.Add(pocz);

                pocz = ReplaceAtIndex(flaga, (char)(pocz[flaga] + 1), pocz);
                while (flaga > 0 && (int)(pocz[flaga]) == 123)
                {
                    pocz = ReplaceAtIndex(flaga - 1, (char)(pocz[flaga - 1] + 1), pocz);
                    pocz = ReplaceAtIndex(flaga, 'a', pocz);
                    flaga = flaga - 1;
                }
                if (pocz == kon)
                    break;
                dl = pocz.Length;
                for (i = 0; i < dl; i++)
                {
                    if (pocz[i] != 'z')
                    {
                        f = false;
                        break;
                    }
                    f = true;
                }
                if (f == true)
                {


                    dl2 = pocz.Length + 1;
                    for (i = 0; i < dl2; i++)
                    {
                        nowy = nowy + "a";
                    }
                    pocz = nowy;
                    nowy = "";
                }

                if (pocz == kon)
                    break;
            }
        }


        private string przedzialy(string pocz, int licznik)
        {
            int licznik_lokalny = 0;
            string nowy = "";
            bool f = true;//flaga wy koncowych wyrazow  typu zzz czy tez zzzzz
            int flaga, i, dl, dl2;//flaga to gdzie teraz jestesmy, niekoniecznie dlufgosc wyrazu
            while (1 == 1)
            {
                flaga = pocz.Length - 1;
                if (licznik_lokalny == licznik)
                    return pocz;

                pocz = ReplaceAtIndex(flaga, (char)(pocz[flaga] + 1), pocz);
                while (flaga > 0 && (int)(pocz[flaga]) == 123)
                {
                    pocz = ReplaceAtIndex(flaga - 1, (char)(pocz[flaga - 1] + 1), pocz);
                    pocz = ReplaceAtIndex(flaga, 'a', pocz);
                    flaga = flaga - 1;
                }

                dl = pocz.Length;
                for (i = 0; i < dl; i++)
                {
                    if (pocz[i] != 'z')
                    {
                        f = false;
                        break;
                    }
                    f = true;
                }
                if (f == true)
                {
                    if (licznik_lokalny == licznik)
                        return pocz;

                    dl2 = pocz.Length + 1;
                    for (i = 0; i < dl2; i++)
                    {
                        nowy = nowy + "a";
                    }
                    pocz = nowy;
                    nowy = "";
                    if (licznik_lokalny == licznik)
                        return pocz;
                }

                if (licznik_lokalny == licznik)
                    return pocz;

                licznik_lokalny++;
            }

        }

        private List<string> KolejneWyrazy(string pocz, string kon)//metoda ma wywyolac metode start2end juz z bezpiecznym zakresem. unika niebezpiecznych sytuacji takich jak podanie poczatku zarkesu jako z
        {
            bool f = true;
            string nowy = "";
            int dl = pocz.Length;
            for (int i = 0; i < dl; i++)
            {
                if (pocz[i] != 'z')
                {
                    f = false;
                    break;
                }
                f = true;
            }

            if (f == true)
            {
                listaWyrazow.Add(pocz);


                int dl2 = pocz.Length + 1;
                for (int i = 0; i < dl2; i++)
                {
                    nowy = nowy + "a";
                }
                pocz = nowy;
                nowy = "";
                start2end(pocz, kon);
            }
            else
            {
                start2end(pocz, kon);
            }


            List<string> kopiaListaWyrazow = new List<string>(listaWyrazow);
            listaWyrazow.Clear();
            return kopiaListaWyrazow;

        }
        private string reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        private string number2letter(int liczba)
        {

            char word = (char)(liczba + 96);
            string s = word.ToString();
            return s;
        }
        private string dec2string(double liczba)
        {
            string wspak = "";
            int calkowita, zaokraglona;
            double reszta, wynik;
            bool flaga = true;
            while (flaga)
            {
                if (liczba % 26 == 0)
                {

                    wspak = wspak + number2letter(26);
                    liczba = (liczba / 26) - 1;
                    if (liczba == 0)
                    {
                        flaga = false;
                    }
                }
                else
                {
                    wynik = liczba / 26;
                    if (wynik < 1)
                    {
                        flaga = false;
                    }
                    calkowita = Convert.ToInt32(Math.Floor(wynik));
                    reszta = wynik - calkowita;

                    zaokraglona = Convert.ToInt32(reszta * 26);

                    wspak = wspak + number2letter(zaokraglona);
                    liczba = calkowita;
                }
            }
            wspak = reverse(wspak);
            return wspak;
        }

        private List<string> pobierzKolejnyPrzedzial(int ile_elementow)
        {
            List<string> lista = new List<string>();
            kon = przedzialy(pocz, ile_elementow);
            string pocz_kopia = pocz;
            pocz = kon;
            lista.Add(pocz_kopia);
            lista.Add(kon);
            return lista;
        }
        public CrackPasswordRange GetAndIncrement(int chunkSize)
        {
            CrackPasswordRange crackPasswordRange = new CrackPasswordRange();
            var range = pobierzKolejnyPrzedzial(chunkSize);
            crackPasswordRange.startPointer = range[0];
            crackPasswordRange.endPointer = range[1];
            return crackPasswordRange;
        }
    }
}
