using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CEntrenador
{
    public class CreateModel : PageModel
    {
        //Atributos
        private readonly IREntrenador objEntrenador;
        private readonly IREquipo objEquipo;
        [BindProperty]
        public Entrenador entrenador {get;set;}
        public IEnumerable<Equipo> lstEquipos {get;set;}
        //Constructor
        public CreateModel(IREntrenador _objEntrenador,IREquipo _objEquipo){
            this.objEntrenador = _objEntrenador;
            this.objEquipo = _objEquipo;
        }
        public ActionResult OnGet(){
            lstEquipos=objEquipo.ListarEquipoIE();
            return Page();
        }
        public ActionResult OnPost(){
            if(!ModelState.IsValid){
                lstEquipos=objEquipo.ListarEquipoIE();
                return Page();
            }
            if(objEntrenador.CrearEntrenador(entrenador)){
                return RedirectToPage("./Index");
            }else{
                lstEquipos=objEquipo.ListarEquipoIE();
                ViewData["Error"]="Ya existe un entrenador con este mismo documento \n"+
                                    "\n O ya hay un entrenador a cargo de este equipo";
                return Page();
            }
        }
    }
}
