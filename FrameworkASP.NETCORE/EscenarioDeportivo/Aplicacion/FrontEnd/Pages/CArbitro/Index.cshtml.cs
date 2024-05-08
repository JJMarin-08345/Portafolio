using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Persistencia;
using Dominio;

namespace FrontEnd.Pages.CArbitro
{
    public class IndexModel : PageModel
    {
        //Atributos
        private readonly IRArbitro objArbitro;
        public IEnumerable<Arbitro> arbitros;
        //Metodos 
        //Constructor
        public IndexModel(IRArbitro _objArbitro){
            this.objArbitro = _objArbitro;
        }
        public void OnGet()
        {
            arbitros=objArbitro.ListarArbitrosIE();
        }
    }
}
