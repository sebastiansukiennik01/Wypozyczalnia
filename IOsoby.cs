using System.Collections.Generic;

namespace Wypozyczalnia
{
    interface IOsoby
    {
        void Dodaj(Osoba o);
        void Usun(string pesel);
        List<Osoba> Wyszukaj(string imie, string nazwisko);
        string WypiszWszystkich();
        int PodajIlosc();
    }
}
