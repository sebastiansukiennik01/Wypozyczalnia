using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia
{
    class Klienci : IOsoby
    {
        //fields
        int liczbaKlientow;
        List<Osoba> listaKlientow; 


        //methods
        public void Dodaj(Osoba o)
        {
            liczbaKlientow++;
            listaKlientow.Add(o);
        }

        public void Usun(string pesel)
        {
            foreach(Osoba o in listaKlientow)
            {
                if(o.Pesel == pesel)
                {
                    listaKlientow.Remove(o);
                    liczbaKlientow--;
                }
            }
        }

        public int PodajIlosc()
        {
            return listaKlientow.Count();
        }

        public string WypiszWszystkich()
        {
            StringBuilder sb = new StringBuilder();
            foreach(Osoba o in listaKlientow)
            {
                sb.AppendLine(o.ToString());
            }
            return sb.ToString();
        }

        public List<Osoba> Wyszukaj(string imie, string nazwisko)
        {
            List<Osoba> result = new List<Osoba>();
            foreach (Osoba o in listaKlientow)
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
