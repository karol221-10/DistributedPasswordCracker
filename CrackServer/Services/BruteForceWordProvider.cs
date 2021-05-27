using CrackServer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrackServer.Services
{
    public class BruteForceWordProvider : IWordProvider
    {
        static List<string> listaWyrazow = new List<string>();
        static string ReplaceAtIndex(int i, char value, string word)
        {
            char[] letters = word.ToCharArray();
            letters[i] = value;
            return string.Join("", letters);
        }
        static void start2end(string pocz, string kon)
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


        static string przedzialy(string pocz, int licznik)
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
        static string reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        static string number2letter(int liczba)
        {

            char word = (char)(liczba + 96);
            string s = word.ToString();
            return s;
        }
        static string dec2string(double liczba)
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

        public string[] getWords(string startPointer, string endPointer)
        {
            bool f = true;
            string nowy = "";
            int dl = startPointer.Length;
            for (int i = 0; i < dl; i++)
            {
                if (startPointer[i] != 'z')
                {
                    f = false;
                    break;
                }
                f = true;
            }

            if (f == true)
            {
                listaWyrazow.Add(startPointer);


                int dl2 = startPointer.Length + 1;
                for (int i = 0; i < dl2; i++)
                {
                    nowy = nowy + "a";
                }
                startPointer = nowy;
                nowy = "";
                start2end(startPointer, endPointer);
            }
            else
            {
                start2end(startPointer, endPointer);
            }


            List<string> kopiaListaWyrazow = new List<string>(listaWyrazow);
            listaWyrazow.Clear();
            return kopiaListaWyrazow.ToArray();
        }
    }
}
