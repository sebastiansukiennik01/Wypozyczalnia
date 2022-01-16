using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia
{
    public enum EnumPlcie { K, M }
    abstract public class Osoba : IEquatable<Osoba>
    {
        //fields
        string imie;
        string nazwisko;
        string pesel;
        int nrTel;
        EnumPlcie plec;
        DateTime dataUrodzenia;

        //constructors
        public Osoba() { }
        
        public Osoba(string imie, string nazwisko, string pesel, int nrTel, EnumPlcie plec, string dataUrodzenia)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.pesel = pesel;
            this.nrTel = nrTel;
            this.plec = plec;
            this.dataUrodzenia = DateTime.Parse(dataUrodzenia);
        }

        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public string Pesel
        {
            get => pesel;
            set
            {
                if (value.Length != 11)
                {
                    throw new FormatException("PESEL niepoprawny");
                }
                pesel = value;

            }
        }
        public int NrTel { get => nrTel; set => nrTel = value; }
        public EnumPlcie Plec { get => plec; set => plec = value; }
        public DateTime DataUrodzenia { get => dataUrodzenia; set => dataUrodzenia = value; }


        //methods
        public void Czy18()
        {
            if ((DateTime.Now - dataUrodzenia).TotalDays / 365 < 18)
            {
                throw new NiepelnoletniException("Osoba jest niepełnoletnia!!!!!!");
            }
        }

        public bool Equals(Osoba other)
        {
            return this.Pesel == other.pesel;
        }
    }
    public class Klient : Osoba
    {
        //fields
        string email;
        DateTime dataZapisu;
        static int liczbaWynajmow;
        static float rabatVIP;



        //accessors
        public string Email { get => email; set => email = value; }
        public DateTime DataZapisu { get => dataZapisu; set => dataZapisu = value; }
        public int LiczbaWynajmow { get => liczbaWynajmow; set => liczbaWynajmow = value; }
        public float RabatVIP { get => rabatVIP; set => rabatVIP = value; }




        //constructors
        static Klient()
        {
            liczbaWynajmow = 0;
            rabatVIP = 0;
        }



        public Klient()
        {
            liczbaWynajmow++;
        }



        public Klient(string imie, string nazwisko, string pesel, int nrTel, EnumPlcie plec, string dataUrodzenia, string email, string dataZapisu)
        : base(imie, nazwisko, pesel, nrTel, plec, dataUrodzenia)
        {
            this.email = email;
            this.dataZapisu = DateTime.Parse(dataZapisu);
        }



        //mehtods



    
}
    public class Pracownik : Osoba
    {
        //fields
        int idPracownika;
        string pozycja;
        string miasto;
        int kodPocztowy;
        string ulica;
        string nrDomu;

        //accessors
        public int IdPracownika { get => idPracownika; set => idPracownika = value; }
        public string Pozycja { get => pozycja; set => pozycja = value; }
        public string Miasto { get => miasto; set => miasto = value; }
        public int KodPocztowy { get => kodPocztowy; set => kodPocztowy = value; }
        public string Ulica { get => ulica; set => ulica = value; }
        public string NrDomu { get => nrDomu; set => nrDomu = value; }

        //constructors
        public Pracownik(string imie, string nazwisko, string pesel, int nrTel, EnumPlcie plec, string dataUrodzenia, int idPracownika, string pozycja, string miasto, int kodPocztowy, string ulica, string nrDomu) : base(imie, nazwisko, pesel, nrTel, plec, dataUrodzenia)
        {
            this.idPracownika = idPracownika;
            this.pozycja = pozycja;
            this.miasto = miasto;
            this.kodPocztowy = kodPocztowy;
            this.ulica = ulica;
            this.nrDomu = nrDomu;
        }

        //mehtods


    }
}
public class NiepelnoletniException : Exception
{
    public NiepelnoletniException() : base() { }
    public NiepelnoletniException(string message) : base(message) { }
}

