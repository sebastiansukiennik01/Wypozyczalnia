using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia
{
    class WszystkieWynajmy : IWWynajmy
    {
        //fields
        static int liczbaWynajmow;
        List<Wynajem> listaWynajmow;


        //constructors
        static WszystkieWynajmy()
        {
            liczbaWynajmow = 0;
        }

        public WszystkieWynajmy()
        {
            listaWynajmow = new List<Wynajem>();
        }

        //methods
        public void Dodaj(Wynajem w)
        {
            liczbaWynajmow++;
            listaWynajmow.Add(w);
        }

        public void Usun(Wynajem w)
        {
            liczbaWynajmow--;
            listaWynajmow.Remove(w);
        }

        public void Usun(Klient k, Samochod s)
        {
            foreach(Wynajem w in listaWynajmow)
            {
                if(w.Klient.Equals(k) && w.Samochod.Equals(s))
                {
                    listaWynajmow.Remove(w);
                }
            }
        }

        public Wynajem Ostatnia()
        {
            return listaWynajmow.Last();
        }

        public int PodajIlosc()
        {
            return listaWynajmow.Count();
        }

        public int PodajIloscDzisiaj()
        {
            int iloscDzisiaj = 0;
            foreach(Wynajem w in listaWynajmow)
            {
                if(w.DataUtworzenia.Date == DateTime.Now.Date)
                {
                    iloscDzisiaj++;
                }
            }
            return iloscDzisiaj;
        }

        public List<Wynajem> PodajUtworzoneDzisiaj()
        {
            List<Wynajem> result = new List<Wynajem>();
            foreach(Wynajem w in listaWynajmow)
            {
                if(w.DataUtworzenia == DateTime.Now.Date)
                {
                    result.Add(w);
                }
            }
            if (!result.Any())
                throw new EmptyListException($"Lista wynajmów nie zawiera żadnego wynajmu utworzonego dzisiaj ({DateTime.Now.Date})");
            return result;
        }

        public List<Wynajem> SortujPoUtworzenie()
        {
            List<Wynajem> result = listaWynajmow;
            result.OrderBy((Wynajem arg) => arg.DataUtworzenia).ToList();
            if (!result.Any())
                throw new EmptyListException($"Lista wynajmów nie zawiera żadnego wynajmu do posegregowania");
            return result;
        }

        public List<Wynajem> WypiszTrwajace()
        {
            List<Wynajem> result = new List<Wynajem>();
            foreach (Wynajem w in listaWynajmow)
            {
                if (w.PoczatekWynajmu < DateTime.Now && w.KoniecWynajmu > DateTime.Now)
                {
                    result.Add(w);
                }
            }
            if (!result.Any())
                throw new EmptyListException($"Lista wynajmów nie zawiera żadnego wynajmu utworzonego dzisiaj ({DateTime.Now.Date})");
            return result;
        }

        public List<Wynajem> WypiszWszystkie()
        {
            return listaWynajmow;
        }
    }
}
