using System.Collections.Generic;

namespace Wypozyczalnia
{
    interface IPojazdy
    {
        void Dodaj(Samochod s);
        void Usun(Samochod s);
        Samochod Wyszkuj(int idSamochodu);
        List<Samochod> Wyszukaj(string marka);
        List<Samochod> Wyszukaj(float przebieg);
        List<Samochod> Wyszukaj(int iloscMiejsc);
        List<Samochod> WyszukajRokPr(int rokProdukcji);
        List<Samochod> WyszukajKosztDz(float kosztDzienny);
        List<Samochod> Wyszukaj(EnumSkrzyniaBiegow skrzynia);
        List<Samochod> SortujPoRokPr();
        List<Samochod> SortujPoKosztDz();
        List<Samochod> SortujAlfabetycznie();
    }
}
