using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace FrontEnd.Page.CColegio
{
    public class CreateModel : PageModel{
        //Atributos
        private readonly IRColegioInstruccion objColegio;
        [BindProperty]
        public ColegioInstruccion colegio {get;set;}
        //Metodos
        //Constructor
        public CreateModel(IRColegioInstruccion _objColegio){
            this.objColegio = _objColegio;
        }
        public ActionResult OnGet()
        {
            return Page();
        }
        public ActionResult OnPost(){
            if(!ModelState.IsValid){
                return Page();
            }
            if(objColegio.CrearColegio(colegio)){
                return RedirectToPage("./Index");
            }else{
                ViewData["Error"]="Ya hay un Colegio con este mismo NIT";
                return Page();
            }
            return Page();
        }
    }
}
