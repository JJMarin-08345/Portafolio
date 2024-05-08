using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CMunicipio
{
    public class EditModel : PageModel
    {
        //Atributos
        private readonly IRMunicipio objMunicipio;
        [BindProperty]
        public Municipio municipio {get;set;}

        //Metodos
        //Constructores
        public EditModel(IRMunicipio _objMunicipio){
            this.objMunicipio = _objMunicipio;
        }
        public ActionResult OnGet(int id){
            municipio=objMunicipio.BuscarMunicipio(id);
            return Page();
        }
        public ActionResult OnPost(){
            if(!ModelState.IsValid){
                return Page();
            }
            if(objMunicipio.ModificarMunicipio(municipio)){
                return RedirectToPage("./Index");
            }else{
                ViewData["Error"]="Ya hay un municipio con este mismo nombre";
                return Page();
            }
            return Page();
        }
    }
}
