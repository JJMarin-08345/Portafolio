using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Persistencia;
using Dominio;

namespace FrontEnd.Pages.CTorneo
{
    public class IndexModel : PageModel
    {
        //Atributos
        private readonly IRTorneo objTorneo;
        public IEnumerable<Torneo> Torneos {get;set;}
        //Metodos
        //Contructor por defecto
        public IndexModel(IRTorneo _objTorneo){
            this.objTorneo = _objTorneo;
        }
        public void OnGet()
        {
            Torneos=objTorneo.ListarTorneosIE(); 
        }
    }
}
