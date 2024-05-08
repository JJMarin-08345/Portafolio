using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CDeportista
{
    public class DetailsModel : PageModel
    {
        //Atributos
        private readonly IRDeportista objDeportista;
        private readonly IREquipo objEquipo;
        public Deportista deportista {get;set;}
        public Equipo equipo {get;set;}
        //Metodo Constructor
        public DetailsModel(IRDeportista _objDeportista,IREquipo _objEquipo){
            this.objDeportista = _objDeportista;
            this.objEquipo = _objEquipo;
        }
        public ActionResult OnGet(int id){
            deportista = objDeportista.BuscarDeportista(id);
            if(deportista==null){
                //Esto no debería pasar
                ViewData["Error"]="No se encontró el Deportista";
                return Page();
            }else{
                equipo = objEquipo.BuscarEquipo(deportista.EquipoId);
                return Page();
            }
        }
    }
}
