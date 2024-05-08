using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CEquipo
{
    public class CreateModel : PageModel
    {
        //Atributos
        private readonly IREquipo objEquipo;
        private readonly IRPatrocinador objPatrocinador;
        [BindProperty]
        public Equipo equipo {get;set;}
        public IEnumerable<Patrocinador> lstPatrocinadores {get;set;}
        //Metodo Constructor por defecto
        public CreateModel(IREquipo _objEquipo,IRPatrocinador _objPatrocinador){
            this.objEquipo = _objEquipo;
            this.objPatrocinador = _objPatrocinador;
        }
        public ActionResult OnGet(){
            lstPatrocinadores=objPatrocinador.ListarPatrocinadorIE();
            return Page();
        }
        public ActionResult OnPost(){
            if(!ModelState.IsValid){
                lstPatrocinadores=objPatrocinador.ListarPatrocinadorIE();
                return Page();
            }
            if(objEquipo.CrearEquipo(equipo)){
                return RedirectToPage("./Index");
            }else{
                lstPatrocinadores=objPatrocinador.ListarPatrocinadorIE();
                ViewData["Error"]="Ya existe un equipo con este mismo nombre \n"+
                                    "\n O ya hay un equipo con ese mismo entrenador";
                return Page();
            }
        }
    }
}
