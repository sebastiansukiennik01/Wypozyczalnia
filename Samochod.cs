using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Wypozyczalnia
{
    public enum EnumPaliwa {benzyna,diesel,gaz}
    public enum EnumSkrzyniaBiegow { manualna, automatyczna}
    abstract public class Samochod : IEquatable<Samochod>
    {
        //fields
        static int idSamochodu;
        string marka;
        string model;
        string nrRejestracyjny;
        float przebieg;
        int iloscMiejsc;
        int rokProdukcji;
        int pojBagaznika;
        double spalanie;
        float kosztZaDzien;
        EnumPaliwa paliwo;
        EnumSkrzyniaBiegow skrzynia;

        //constructors
        static Samochod()
        {
            idSamochodu = 1;
        }
        public Samochod()
        {
            idSamochodu++;
        }


        public Samochod(string marka, string model, string nrRejestracyjny, float przebieg, int iloscMiejsc, int rokProdukcji, int pojBagaznika, double spalanie, float kosztZaDzien, EnumPaliwa paliwo, EnumSkrzyniaBiegow skrzynia)
            :this()
        {
            this.marka = marka;
            this.model = model;
            this.nrRejestracyjny = nrRejestracyjny;
            this.przebieg = przebieg;
            this.iloscMiejsc = iloscMiejsc;
            this.rokProdukcji = rokProdukcji;
            this.pojBagaznika = pojBagaznika;
            this.spalanie = spalanie;
            this.kosztZaDzien = kosztZaDzien;
            this.paliwo = paliwo;
            this.skrzynia = skrzynia;
        }

        //accessors
        public int IdSamochodu { get => idSamochodu; set => idSamochodu = value; }
        public string Marka { get => marka; set => marka = value; }
        public string Model { get => model; set => model = value; }
        public string NrRejestracyjny { 
            get => nrRejestracyjny;
            set
            {
                if (!Regex.IsMatch(value, @"[A-Z]{2}([A-Z]|[0-9]){5}"))
                { throw new FormatRejestracjiException(); }
                nrRejestracyjny = value;
            }
        }
        public float Przebieg { get => przebieg; set => przebieg = value; }
        public int RokProdukcji { get => rokProdukcji; set => rokProdukcji = value; }
        public int PojBagaznika { get => pojBagaznika; set => pojBagaznika = value; }
        public double Spalanie { get => spalanie; set => spalanie = value; }
        public EnumPaliwa Paliwo { get => paliwo; set => paliwo = value; }
        public EnumSkrzyniaBiegow Skrzynia { get => skrzynia; set => skrzynia = value; }
        public int IloscMiejsc { get => iloscMiejsc; set => iloscMiejsc = value; }
        public float KosztZaDzien { get => kosztZaDzien; set => kosztZaDzien = value; }

        //methods
        public bool Equals(Samochod other)
        {
            return this.IdSamochodu == other.IdSamochodu;
        }
    }

    public class Limuzyna : Samochod
    {
        double dlugosc;
        static bool szofer;

        public double Dlugosc { get => dlugosc; set => dlugosc = value; }
        public bool Szofer { get => szofer; set => szofer = value; }

        static Limuzyna()
        {
            szofer = false;
        }
        public Limuzyna () : base() {}

        public Limuzyna(string marka, string model, string nrRejestracyjny, float przebieg, int iloscMiejsc, int rokProdukcji, int pojBagaznika, double spalanie, float kosztZaDzien, EnumPaliwa paliwo, EnumSkrzyniaBiegow skrzynia, double dlugosc, bool _szofer)
            : base(marka, model, nrRejestracyjny, przebieg, iloscMiejsc, rokProdukcji, pojBagaznika, spalanie, kosztZaDzien, paliwo, skrzynia)
        {
            this.dlugosc = dlugosc;
            _szofer = szofer;
        }
    }

    public class Osobowe : Samochod
    {
        public Osobowe() : base() { }
        public Osobowe(string marka, string model, string nrRejestracyjny, float przebieg, int iloscMiejsc, int rokProdukcji, int pojBagaznika, double spalanie, float kosztZaDzien, EnumPaliwa paliwo, EnumSkrzyniaBiegow skrzynia)
            : base(marka, model, nrRejestracyjny, przebieg, iloscMiejsc, rokProdukcji, pojBagaznika, spalanie, kosztZaDzien, paliwo, skrzynia)
        {
        }
    }

    public class VAN : Samochod
    {
        float wysokosc;
        float maxZaladunek;

        public float Wysokosc { get => wysokosc; set => wysokosc = value; }
        public float MaxZaladunek { get => maxZaladunek; set => maxZaladunek = value; }

        public VAN() : base() { }
        public VAN(string marka, string model, string nrRejestracyjny, float przebieg, int iloscMiejsc, int rokProdukcji, int pojBagaznika, double spalanie, float kosztZaDzien, EnumPaliwa paliwo, EnumSkrzyniaBiegow skrzynia,float wysokosc, float maxZaladunek)
            : base(marka, model, nrRejestracyjny, przebieg, iloscMiejsc, rokProdukcji, pojBagaznika, spalanie, kosztZaDzien, paliwo, skrzynia)
        {
            this.wysokosc = wysokosc;
            this.maxZaladunek = maxZaladunek;
        }



    }

    public class Dostawczy: Samochod
    {
        float wysokosc;
        float maxZaladunek;
        float dlugoscLadowni;

        public float Wysokosc { get => wysokosc; set => wysokosc = value; }
        public float MaxZaladunek { get => maxZaladunek; set => maxZaladunek = value; }

        public Dostawczy() : base() { }
        public Dostawczy(string marka, string model, string nrRejestracyjny, float przebieg, int iloscMiejsc, int rokProdukcji, int pojBagaznika, double spalanie, float kosztZaDzien, EnumPaliwa paliwo, EnumSkrzyniaBiegow skrzynia, float wysokosc, float maxZaladunek, float dlugoscLadowni)
            : base(marka, model, nrRejestracyjny, przebieg, iloscMiejsc, rokProdukcji, pojBagaznika, spalanie, kosztZaDzien, paliwo, skrzynia)
        {
            this.wysokosc = wysokosc;
            this.maxZaladunek = maxZaladunek;
            this.dlugoscLadowni = dlugoscLadowni;
        }
    }

    public class FormatRejestracjiException : Exception
    {
        public FormatRejestracjiException() : base() { }
    }
}
