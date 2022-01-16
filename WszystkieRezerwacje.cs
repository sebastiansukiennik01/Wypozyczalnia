using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia
{
    class WszystkieRezerwacje : IWRezerwacje
    {
        //fields
        static int liczbaRezerwacji;
        List<Rezerwacja> listaRezerwacji;

        //constructors
        static WszystkieRezerwacje()
        {
            liczbaRezerwacji = 0;
        }

        public WszystkieRezerwacje()
        {
            listaRezerwacji = new List<Rezerwacja>();
        }

        //methods
        public void Dodaj(Rezerwacja r)
        {
            liczbaRezerwacji++;
            listaRezerwacji.Add(r);
        }

        public void Usun(Rezerwacja r)
        {
            liczbaRezerwacji--;
            listaRezerwacji.Remove(r);
        }

        public void Usun(Klient k, Samochod s)
        {
            foreach(Rezerwacja r in listaRezerwacji)
            {
                if(r.Klient.Equals(k) && r.Samochod.Equals(s))
                {
                    listaRezerwacji.Remove(r);
                }
            }
        }

        public Rezerwacja Ostatnia()
        {
            if (!listaRezerwacji.Any())
                throw new EmptyListException("Lista rezerwacji nie zawiera żadnej rezerwacji!");
            else
                return listaRezerwacji.Last();
        }

        public int PodajIlosc()
        {
            return listaRezerwacji.Count();
        }

        public int PodajIloscDzisiaj()
        {
            int iloscDzis = 0;
            foreach (Rezerwacja r in listaRezerwacji)
            {
                if (r.DataUtworzenia.Date == DateTime.Now.Date)
                {
                    iloscDzis++;
                }
            }
            return iloscDzis;
        }

        public List<Rezerwacja> PodajUtworzoneDzisiaj()
        {
            List<Rezerwacja> result = new List<Rezerwacja>();
            foreach (Rezerwacja r in listaRezerwacji)
            {
                if (r.DataUtworzenia.Date == DateTime.Now.Date)
                {
                    result.Add(r);
                }
            }
            if (!result.Any())
                throw new EmptyListException($"Lista rezerwacji, nie zawiera żadnych rezerwacji utworzonych dzisiaj {DateTime.Now.Date}");

            return result;
        }

        public List<Rezerwacja> WypiszTrwajace()
        {
            List<Rezerwacja> result = new List<Rezerwacja>();
            foreach (Rezerwacja r in listaRezerwacji)
            {
                if (r.PoczatekRezerwacji < DateTime.Now && r.KoniecRezerwacji > DateTime.Now)
                {
                    result.Add(r);
                }
            }
            if (!result.Any())
                throw new EmptyListException($"Lista rezerwacji, nie zawiera żadnych aktualnie trwających rezerwacji");

            return result;
        }

        public List<Rezerwacja> WypiszWszystkie()
        { 
            return listaRezerwacji;    //chyba najgłupsza z wszystkich
        }

        public List<Rezerwacja> SortujPoUtworzenie()
        {
            List<Rezerwacja> result = listaRezerwacji;
            result = listaRezerwacji.OrderBy((Rezerwacja arg) => arg.DataUtworzenia).ToList();  //powinno działać ale nie wiadomo
            if (!result.Any())
                throw new EmptyListException($"Lista rezerwacji nie zawiera żadnego wynajmu do posegregowania");
            return result;
        }
    }
}
