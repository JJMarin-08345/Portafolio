using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CDeportista
{
    public class CreateModel : PageModel
    {
        //Atributos
        private readonly IRDeportista objDeportista;
        private readonly IREquipo objEquipo;
        [BindProperty]
        public Deportista deportista {get;set;}
        public IEnumerable<Equipo> lstEquipos {get;set;}
        //Metodo constructor
        public CreateModel(IRDeportista _objDeportista,IREquipo _objEquipo){
            this.objDeportista = _objDeportista;
            this.objEquipo = _objEquipo;
        }

        public ActionResult OnGet()
        {
            lstEquipos=objEquipo.ListarEquipoIE();
            return Page();
        }
        public ActionResult OnPost(){
            if(!ModelState.IsValid){
                lstEquipos=objEquipo.ListarEquipoIE();
                return Page();
            }
            if(objDeportista.CrearDeportista(deportista)){
                return RedirectToPage("./Index");
            }else{
                lstEquipos=objEquipo.ListarEquipoIE();
                ViewData["Error"]="Ya existe un deportista con este mismo documento \r"+
                                    "\r O, debe tener mínimo 12 años para participar";
                return Page();
            }
        }
    }
}
