using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Persistencia;
using Dominio;

namespace FrontEnd.Pages.CColegio
{
    public class IndexModel : PageModel
    {
        //Atributos
        private readonly IRColegioInstruccion objColegio;
        public IEnumerable<ColegioInstruccion> Colegios;
        //Metodos
        //Constructor
        public IndexModel(IRColegioInstruccion _objColegio){
            this.objColegio = _objColegio;
        }
        public void OnGet()
        {
            Colegios = objColegio.ListarColegiosIE();
        }
    }
}
