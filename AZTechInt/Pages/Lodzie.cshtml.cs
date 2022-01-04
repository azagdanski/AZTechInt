using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AZTechInt.Modele;
using AZTechInt.Serwisy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AZTechInt.Pages
{
    public class LodzieModel : PageModel
    {
        public readonly Serwis _s;
        public LodzieModel(Serwis s)
        {
            _s = s;
        }
        public IEnumerable<LodzModel> list { get; set; }
        public void OnGet()
        {
            list = _s.PobierzWszystkieLodki();
        }
    }
}
