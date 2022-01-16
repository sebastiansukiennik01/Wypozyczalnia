using System.Collections.Generic;

namespace Wypozyczalnia
{
    interface IWWynajmy
    {
        void Dodaj(Wynajem w);
        void Usun(Wynajem w);
        void Usun(Klient k, Samochod s);
        Wynajem Ostatnia();
        List<Wynajem> WypiszWszystkie();
        List<Wynajem> WypiszTrwajace();
        int PodajIlosc();
        int PodajIloscDzisiaj();
        List<Wynajem> PodajUtworzoneDzisiaj();
        List<Wynajem> SortujPoUtworzenie();
    }
}
