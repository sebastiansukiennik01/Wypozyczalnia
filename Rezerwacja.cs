using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia
{
    public class Rezerwacja 
    {
        //fields
        static long numerRezerwacji = 1;
        DateTime poczatekRezerwacji;
        DateTime koniecRezerwacji;
        DateTime dataUtworzenia;
        Samochod samochod;
        Pracownik pracownik;
        Klient klient;


        //accessors
        public static long NumerRezerwacji { get => numerRezerwacji; set => numerRezerwacji = value; }
        public DateTime PoczatekRezerwacji { get => poczatekRezerwacji; set => poczatekRezerwacji = value; }
        public DateTime KoniecRezerwacji { get => koniecRezerwacji; set => koniecRezerwacji = value; }
        public DateTime DataUtworzenia { get => dataUtworzenia; set => dataUtworzenia = value; }
        public Samochod Samochod { get => samochod; set => samochod = value; }
        public Pracownik Pracownik { get => pracownik; set => pracownik = value; }
        public Klient Klient { get => klient; set => klient = value; }


        //constructors
        public Rezerwacja()
        {
            numerRezerwacji +=1;
        }

        public Rezerwacja(string poczatekRezerwacji, string koniecRezerwacji, Samochod samochod, Pracownik pracownik, Klient klient, string dataUtworzenia)
            :this()
        {
            this.poczatekRezerwacji = DateTime.Parse(poczatekRezerwacji);
            this.koniecRezerwacji = DateTime.Parse(koniecRezerwacji);
            this.dataUtworzenia = DateTime.Parse(dataUtworzenia);
            this.Samochod = samochod;
            this.Pracownik = pracownik;
            this.Klient = klient;
        }


        //methods
        public void CzyDataZPrzyszlosci()
        {
            if (DateTime.Now > poczatekRezerwacji)
            {
                throw new PastDateException("Wybrany dzień upłynął 🙁");
            }
        }

        public void CzyDataPowrotuPoPoczątku()
        {
            if (poczatekRezerwacji > koniecRezerwacji)
            {
                throw new WrongReturnDateException("Data powrotu nie może poprzedzać daty początku!");
            }
        }
    }

    public class PastDateException : Exception
    {
        public PastDateException() : base() { }
        public PastDateException(string message) : base(message) { }
    }

    public class WrongReturnDateException : Exception
    {
        public WrongReturnDateException() : base() { }
        public WrongReturnDateException(string message) : base(message) { }
    }
}