using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Persistencia;
using Dominio;
using System.Collections.Generic;

namespace FrontEnd.Page.CArbitro
{
    public class EditModel : PageModel{
        //Atributos
        private readonly IRArbitro objArbitro;
        //Para propiedades navigacionales
        private readonly IRColegioInstruccion objColegio;
        private readonly IRTorneo objTorneo;

        [BindProperty]
        public Arbitro arbitro {get;set;}
        //Para propiedades navigacionales
        public IEnumerable<ColegioInstruccion> Colegios {get;set;}
        public IEnumerable<Torneo> Torneos {get;set;}

        public EditModel(IRArbitro _objArbitro,IRColegioInstruccion _objColegio,IRTorneo _objTorneo){
            this.objArbitro = _objArbitro;
            this.objColegio = _objColegio;
            this.objTorneo = _objTorneo;
        }

        public ActionResult OnGet(int id){
            Colegios = objColegio.ListarColegiosIE();
            Torneos=objTorneo.ListarTorneosIE();
            arbitro=objArbitro.BuscarArbitro(id);
            if(arbitro==null){
                ViewData["Error"]="No se encontró el arbitro";
                return Page();
            }
            return Page();
        }
        public ActionResult OnPost(){
            if(!ModelState.IsValid){
                Colegios = objColegio.ListarColegiosIE();
                Torneos=objTorneo.ListarTorneosIE();
                return Page();
            }
            if(objArbitro.ModificarArbitro(arbitro)){
                return RedirectToPage("./Index");
            }else{
                Colegios = objColegio.ListarColegiosIE();
                Torneos=objTorneo.ListarTorneosIE();
                ViewData["Error"]="Ya existe un arbitro con este mismo documento";
                return Page();
            }
            return Page();
        }
    }
}
