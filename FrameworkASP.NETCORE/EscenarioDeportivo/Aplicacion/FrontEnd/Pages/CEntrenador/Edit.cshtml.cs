using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CEntrenador
{
    public class EditModel : PageModel
    {
        private readonly IREntrenador objEntrenador;
        private readonly IREquipo objEquipo;
        [BindProperty]
        public Entrenador entrenador {get;set;}
        public IEnumerable<Equipo> lstEquipos {get;set;}
        public EditModel(IREntrenador _objEntrenador,IREquipo _objEquipo){
            this.objEntrenador = _objEntrenador;
            this.objEquipo = _objEquipo;
        }
        public ActionResult OnGet(int id){
            lstEquipos = objEquipo.ListarEquipoIE();
            entrenador=objEntrenador.BuscarEntrenador(id);
            if(entrenador==null){
                ViewData["Error"]="No se encontró el Entrenador";
                return Page();
            }
            return Page();
        }
        public ActionResult OnPost(){
            if(!ModelState.IsValid){
                lstEquipos = objEquipo.ListarEquipoIE();
                return Page();
            }
            if(objEntrenador.ModificarEntrenador(entrenador)){
                return RedirectToPage("./Index");
            }else{
                lstEquipos = objEquipo.ListarEquipoIE();
                ViewData["Error"]="Ya existe un Entrenador con este documento \n"+
                                    "\n o ya hay un entrenador asignado para este equipo";
                return Page();
            }
        }
    }
}
