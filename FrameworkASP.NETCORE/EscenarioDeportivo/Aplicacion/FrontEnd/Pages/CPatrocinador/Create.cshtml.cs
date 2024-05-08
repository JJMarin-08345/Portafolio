using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CPatrocinador
{
    public class CreateModel : PageModel
    {
        //Atributos
        private readonly IRPatrocinador objPatrocinador;
        [BindProperty]
        public Patrocinador patrocinador {get;set;}
        //Metodo Constructor
        public CreateModel(IRPatrocinador _objPatrocinador){
            this.objPatrocinador = _objPatrocinador;
        }
        public ActionResult OnGet(){
            return Page();
        }
        public ActionResult OnPost(){
            if(!ModelState.IsValid){
                return Page();
            }
            if(objPatrocinador.CrearPatrocinador(patrocinador)){
                return RedirectToPage("Index");
            }else{
                ViewData["Error"]="Ya existe un Patrocinador con ese documento";
                return Page();
            }

        }
    }
}
