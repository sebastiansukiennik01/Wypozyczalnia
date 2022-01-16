using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia
{
    public class Wynajem
    {
        //fields
        static int numerWynajmu = 1;
        DateTime poczatekWynajmu;
        DateTime koniecWynajmu;
        DateTime dataUtworzenia;
        Samochod samochod;
        Pracownik pracownik;
        Klient klient;


        //accessors
        public static int NumerWynajmu { get => numerWynajmu; set => numerWynajmu = value; }
        public DateTime PoczatekWynajmu { get => poczatekWynajmu; set => poczatekWynajmu = value; }
        public DateTime KoniecWynajmu { get => koniecWynajmu; set => koniecWynajmu = value; }
        public DateTime DataUtworzenia { get => dataUtworzenia; set => dataUtworzenia = value; }
        public Samochod Samochod { get => samochod; set => samochod = value; }
        public Pracownik Pracownik { get => pracownik; set => pracownik = value; }
        public Klient Klient { get => klient; set => klient = value; }


        //construcors
        public Wynajem()
        {
            numerWynajmu++;
        }

        public Wynajem(string poczatekWynajmu, string koniecWynajmu, Samochod samochod, Pracownik pracownik, Klient klient)
            : this()
        {
            this.poczatekWynajmu = DateTime.Parse(poczatekWynajmu);
            this.koniecWynajmu = DateTime.Parse(koniecWynajmu);
            this.samochod = samochod;
            this.pracownik = pracownik;
            this.klient = klient;
        }

        //methods
        public void CzyStaraData()
        {
            if (DateTime.Now > poczatekWynajmu || DateTime.Now > koniecWynajmu)
            {
                throw new PastDateException("Wybrana data początku/końca wynajmu jest z przeszłości! Wybierz poprawną datę i spróbuj pownownie.");
            }
        }

        public void CzyPoczatekGTKonie()
        {
            if(poczatekWynajmu > koniecWynajmu)
            {
                throw new WrongReturnDateException("Data konca wynajmu nie może poprzedzać daty rozpoczęcia! Wybierz poprawną datę i spróbuj pownownie.");
            }
        }
    }
}
