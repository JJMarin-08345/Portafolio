using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CDeportista
{
    public class IndexModel : PageModel
    {
        //Atributos
        private readonly IRDeportista objDeportista;
        private readonly IREquipo objEquipo;
        public List<Deportista> lstDeportistas {get;set;}
        //Metodo Constructor
        public IndexModel(IRDeportista _objDeportista,IREquipo _objEquipo){
            this.objDeportista = _objDeportista;
            this.objEquipo = _objEquipo;
        }
        public ActionResult OnGet()
        {
            lstDeportistas=objDeportista.ListarDeportistaList();
            for(int i=0;i<lstDeportistas.Count;i++){
                objEquipo.BuscarEquipo(lstDeportistas[i].EquipoId);
            }
            return Page();
        }
    }
}
