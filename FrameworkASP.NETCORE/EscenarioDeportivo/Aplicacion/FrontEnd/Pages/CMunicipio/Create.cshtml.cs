using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CMunicipio
{
    public class CreateModel : PageModel
    {
        //Atributos
        private readonly IRMunicipio objMunicipio;

        [BindProperty]
        public Municipio municipio {get;set;}
        
        //Metodos
        public CreateModel(IRMunicipio _objMunicipio){
            this.objMunicipio = _objMunicipio;
        }

        //Enviar informacion y/o vista
        public ActionResult OnGet()
        {
            return Page();
        }

        public ActionResult OnPost(){
            if(!ModelState.IsValid){
                return Page();
            }
            if(objMunicipio.CrearMunicipio(municipio)){
                return RedirectToPage("Index");
            }else{
                ViewData["Error"]="Ya existe un municipio con este mismo nombre";
                return Page();
            }
            return Page();
        }
    }
}
