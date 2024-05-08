using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CEscenario
{
    public class IndexModel : PageModel
    {
        private readonly IREscenario objEscenario;
        public IEnumerable<Escenario> lstEscenarios { get; set; }
        //Constructor
        public IndexModel(IREscenario _objEscenario){
            this.objEscenario = _objEscenario;
        }
        public ActionResult OnGet()
        {
            lstEscenarios=objEscenario.ListarEscenarioIE();
            return Page();
        }
    }
}
