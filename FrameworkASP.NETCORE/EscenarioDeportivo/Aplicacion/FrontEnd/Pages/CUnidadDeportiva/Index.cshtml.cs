using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CUnidadDeportiva
{
    public class IndexModel : PageModel
    {
        private readonly IRUnidadDeportiva objUnidad;
        public IEnumerable<UnidadDeportiva> lstUnidades {get;set;}
        //Constructor
        public IndexModel(IRUnidadDeportiva _objUni){
            this.objUnidad=_objUni;
        }
        public void OnGet()
        {
            lstUnidades=objUnidad.ListarUniDeportivaIE();
        }
    }
}
