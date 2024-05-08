using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistencia;
using Dominio;

namespace FrontEnd.Pages.CColegio
{
    public class DetailsModel : PageModel
    {
        //Atributos
        private readonly IRColegioInstruccion objColegio;
        private readonly IRArbitro objArbitro;
        public ColegioInstruccion colegio {get;set;}
        public List<Arbitro> arbitros {get;set;}
        //Metodos
        //Constructor por defecto
        public DetailsModel(IRColegioInstruccion _objColegio,IRArbitro _objArbitro){
            this.objColegio = _objColegio;
            this.objArbitro = _objArbitro;
        }
        public ActionResult OnGet(int id)
        {
            colegio = objColegio.BuscarColegio(id);
            arbitros = objArbitro.ListarArbitrosList();
            if(colegio==null){
                ViewData["Error"]="No se ha encontrado el Colegio";
                return Page();
            }
            return Page();
        }
    }
}
