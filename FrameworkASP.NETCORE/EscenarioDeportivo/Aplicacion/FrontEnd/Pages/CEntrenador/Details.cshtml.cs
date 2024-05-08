using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CEntrenador
{
    public class DetailsModel : PageModel
    {
        private readonly IREntrenador objEntrenador;
        private readonly IREquipo objEquipo;
        public Entrenador entrenador {get;set;}
        public Equipo equipo {get;set;}
        public DetailsModel(IREntrenador _objEntrenador,IREquipo _objEquipo){
            this.objEntrenador = _objEntrenador;
            this.objEquipo = _objEquipo;
        }
        public ActionResult OnGet(int id){
            entrenador=objEntrenador.BuscarEntrenador(id);
            if(entrenador==null){
                ViewData["Error"]="No se encontró el entrenador";
                return Page();
            }else{
                equipo=objEquipo.BuscarEquipo(entrenador.EquipoId);
                return Page();
            }
        }
    }
}
