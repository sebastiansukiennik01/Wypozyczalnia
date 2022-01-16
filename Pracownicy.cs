using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia
{
    class Pracownicy : IOsoby
    {
        //fields
        int liczbaPracownikow;
        List<Osoba> listaPracownikow;


        //methods
        public void Dodaj(Osoba o)
        {
            liczbaPracownikow++;
            listaPracownikow.Add(o);
        }

        public void Usun(string pesel)
        {
            foreach(Osoba o in listaPracownikow)
            {
                if(o.Pesel == pesel)
                {
                    listaPracownikow.Remove(o);
                    liczbaPracownikow--;
                }
            }
        }

        public int PodajIlosc()
        {
            return listaPracownikow.Count();
        }

        public string WypiszWszystkich()
        {
            StringBuilder sb = new StringBuilder();
            foreach(Osoba o in listaPracownikow)
            {
                sb.AppendLine(o.ToString());
            }
            return sb.ToString();
        }

        public List<Osoba> Wyszukaj(string imie, string nazwisko)
        {
            List<Osoba> result = new List<Osoba>();
            foreach(Osoba o in listaPracownikow)
            {
                if(o.Imie == imie & o.Nazwisko == nazwisko)
                {
                    result.Add(o);
                }
            }
            return result;
        }
    }
}
