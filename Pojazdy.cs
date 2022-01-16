using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia
{
    class Pojazdy : IPojazdy
    {
        static int liczbaSamochodow;
        List<Samochod> listaPojazdow;

        //constructors
        static Pojazdy()
        {
            liczbaSamochodow = 0;
        }

        public Pojazdy()
        {
            listaPojazdow = new List<Samochod>();
        }

        //methods
        public void Dodaj(Samochod s)
        {
            liczbaSamochodow++;
            listaPojazdow.Add(s);
        }

        public void Usun(Samochod s)
        {
            liczbaSamochodow--;
            listaPojazdow.Remove(s);
        }

        public Samochod Wyszkuj(int idSamochodu)
        {
            foreach(Samochod s in listaPojazdow)
            {
                if(s.IdSamochodu == idSamochodu)
                {
                    return s;
                }
            }
            //tu kod teoretycznie nie powinien dojść jeżeli mamy samochód o podanym ID, dlatego wyjątek jest bez if/try_catch
            new EmptyListException($"W liście samochodów nie istnieje pojazd o IDSamochodu: {idSamochodu}!");
            return null;
        }

        public List<Samochod> Wyszukaj(string marka)
        {
            List<Samochod> result_list = new List<Samochod>();
            foreach (Samochod s in listaPojazdow)
            {
                if (s.Marka == marka)
                {
                    result_list.Add(s);
                }
            }
            if (!result_list.Any())
                new EmptyListException($"W liście samochodów nie istnieje pojazd marki: {marka}!");
            return result_list;
        }

        public List<Samochod> Wyszukaj(float przebieg)
        {
            List<Samochod> result_list = new List<Samochod>();
            foreach (Samochod s in listaPojazdow)
            {
                if (s.Przebieg < przebieg)
                {
                    result_list.Add(s);
                }
            }
            if (!result_list.Any())
                new EmptyListException($"W liście samochodów nie istnieje pojazd, którego przebieg jest mniejszy niż: {przebieg}!");
            return result_list;
        }

        public List<Samochod> Wyszukaj(int iloscMiejsc)
        {
            List<Samochod> result_list = new List<Samochod>();
            foreach (Samochod s in listaPojazdow)
            {
                if (s.IloscMiejsc == iloscMiejsc)
                {
                    result_list.Add(s);
                }
            }
            if (!result_list.Any())
                new EmptyListException($"W liście samochodów nie istnieje pojazd, który posiada wybraną ilość miejsc: {iloscMiejsc}!");
            return result_list;
        }

        public List<Samochod> Wyszukaj(EnumSkrzyniaBiegow skrzynia)
        {
            List<Samochod> result_list = new List<Samochod>();
            foreach (Samochod s in listaPojazdow)
            {
                if (s.Skrzynia == skrzynia)
                {
                    result_list.Add(s);
                }
            }
            if (!result_list.Any())
                new EmptyListException($"W liście samochodów nie istnieje pojazd ze skrzynią: {skrzynia}!");
            return result_list;
        }

        public List<Samochod> WyszukajKosztDz(float kosztDzienny)
        {
            List<Samochod> result_list = new List<Samochod>();
            foreach (Samochod s in listaPojazdow)
            {
                if (s.KosztZaDzien < kosztDzienny)
                {
                    result_list.Add(s);
                }
            }
            if (!result_list.Any())
                new EmptyListException($"W liście samochodów nie istnieje pojazd, którego koszt dzienny jest mniejszy niż: {kosztDzienny}!");
            return result_list;
        }

        public List<Samochod> WyszukajRokPr(int rokProdukcji)
        {
            List<Samochod> result_list = new List<Samochod>();
            foreach (Samochod s in listaPojazdow)
            {
                if (s.RokProdukcji < rokProdukcji)
                {
                    result_list.Add(s);
                }
            }
            if (!result_list.Any())
                new EmptyListException($"W liście samochodów nie istnieje pojazd, którego rok produkcji jest mniejszy niż: {rokProdukcji}!");
            return result_list;
        }

        public List<Samochod> SortujAlfabetycznie()
        {
            throw new NotImplementedException();
        }

        public List<Samochod> SortujPoKosztDz()
        {
            throw new NotImplementedException();
        }

        public List<Samochod> SortujPoRokPr()
        {
            throw new NotImplementedException();
        }
    }
    class EmptyListException : Exception
    {
        public EmptyListException() : base() { }
        public EmptyListException(string message) : base(message) { }
    }
}
