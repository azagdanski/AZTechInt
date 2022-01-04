using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AZTechInt.Modele;
using AZTechInt.Serwisy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AZTechInt.Pages
{
    public class ZamowienieModel : PageModel
    {
        public readonly Serwis _s;
        public ZamowienieModel(Serwis s)
        {
            _s = s;
        }
        public LodzModel lm { get; set; }
        [BindProperty(SupportsGet = true)]
        public Zamowienie zam { get; set; }
        public void OnGet(string LodzId)
        {
            lm = _s.PobierzJednaLodz(LodzId);
        }

        public IActionResult OnPost(IFormCollection r)
        {
            zam = new Zamowienie()
            {
                RezerwacjaOd = r["RezerwacjaOd"],
                RezerwacjaDo = r["RezerwacjaDo"],
                LodzId = r["LodzId"],
                ImieNazwisko = r["ImieNazwisko"],
                AdresEmail = r["AdresEmail"],
                Telefon = r["Telefon"],
                DodatkoweProsby = r["DodatkoweProsby"]
            };
            zam = _s.ZapiszZam(zam);
            return RedirectToPage("Zamowienie", zam = zam);
        }
    }
}
