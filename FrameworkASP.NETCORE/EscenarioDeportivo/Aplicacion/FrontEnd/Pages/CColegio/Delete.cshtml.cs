using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistencia;
using Dominio;

namespace FrontEnd.Pages.CColegio
{
    public class DeleteModel : PageModel
    {
        //Atributos
        private readonly IRColegioInstruccion objColegio;
        private readonly IRArbitro objArbitro;
        [BindProperty]
        public ColegioInstruccion colegio {get;set;}
        public List<Arbitro> arbitros {get;set;}
        //Metodos
        //Constructor
        public DeleteModel(IRColegioInstruccion _objColegio,IRArbitro _objArbitro){
            this.objColegio = _objColegio;
            this.objArbitro = _objArbitro;
        }
        public ActionResult OnGet(int id){
            arbitros=objArbitro.ListarArbitrosList();
            colegio=objColegio.BuscarColegio(id);
            if(colegio==null){
                //Entonces no se encontró el colegio, aunque no deberia pasar
                ViewData["Error"]="No se encontró el Colegio";
                return Page();
            }
            return Page();
        }
        public ActionResult OnPost(){
            if(objColegio.EliminarColegio(colegio.Id)){
                return RedirectToPage("./Index");
            }else{
                arbitros=objArbitro.ListarArbitrosList();
                ViewData["Error"]="No se pudo eliminar este Colegio, se eliminarían los arbitros que ha egresado";
                return Page();
            }
            return Page();
        }
    }
}
