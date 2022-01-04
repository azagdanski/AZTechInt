using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AZTechInt.Modele
{
    public class Zamowienie
    {
        public string ZamowienieId { get; set; }
        public string RezerwacjaOd { get; set; }
        public string RezerwacjaDo { get; set; }
        public string NadanyNumer { get; set; }
        public string ImieNazwisko { get; set; }
        public string AdresEmail { get; set; }
        public string Telefon { get; set; }
        public string DodatkoweProsby { get; set; }
        public string LodzId { get; set; }
        public string Suma { get; set; }
    }
}
