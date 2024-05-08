using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CPatrocinador
{
    public class IndexModel : PageModel
    {
        //Atributos
        private readonly IRPatrocinador objPatrocinador;
        public IEnumerable<Patrocinador> patrocinadores {get;set;}
        //Metodo Constructor
        public IndexModel(IRPatrocinador _objPatrocinador){
            this.objPatrocinador = _objPatrocinador;
        }
        public ActionResult OnGet(){
            patrocinadores=objPatrocinador.ListarPatrocinadorIE();
            return Page();
        }
    }
}
