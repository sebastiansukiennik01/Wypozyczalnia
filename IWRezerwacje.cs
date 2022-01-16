using System.Collections.Generic;

namespace Wypozyczalnia
{
    interface IWRezerwacje
    {
        void Dodaj(Rezerwacja r);
        void Usun(Rezerwacja r);
        void Usun(Klient k, Samochod s);
        Rezerwacja Ostatnia();
        List<Rezerwacja> WypiszWszystkie();
        List<Rezerwacja> WypiszTrwajace();
        int PodajIlosc();
        int PodajIloscDzisiaj();
        List<Rezerwacja> PodajUtworzoneDzisiaj();
        List<Rezerwacja> SortujPoUtworzenie();
    }
}
