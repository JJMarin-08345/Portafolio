using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CArbitro
{
    public class DetailsModel : PageModel
    {
        //Atributos
        private readonly IRArbitro objArbitro;
        //Para la propiedad navigacional
        private readonly IRTorneo objTorneo;
        //Para la propiedad navigacional
        private readonly IRColegioInstruccion objColegio;
        public Arbitro arbitro {get;set;}
        //Para las propiedades navigacionales
        public ColegioInstruccion colegio {get;set;}
        public Torneo torneo {get;set;}
        //Metodos
        //Constructor por defecto
        public DetailsModel(IRArbitro _objArbitro,IRColegioInstruccion _objColegio, IRTorneo _objTorneo){
            this.objArbitro = _objArbitro;
            this.objColegio = _objColegio;
            this.objTorneo = _objTorneo;
        }
        
        public ActionResult OnGet(int id){
            arbitro = objArbitro.BuscarArbitro(id);
            if(arbitro==null){
                //Esto no debería pasar
                ViewData["Error"]="No se encontró el Arbitro";
                return Page();
            }else{
                colegio = objColegio.BuscarColegio(arbitro.ColegioInstruccionId);
                if(arbitro.TorneoId!=null){
                    torneo = objTorneo.BuscarTorneo(int.Parse(""+arbitro.TorneoId));
                    //return Page();
                }
            }
            return Page();
        }
        /*
        --COMENTARIOS IMPORTANTES DE LO QUE SE REALIZÓ

        Para empezar, tengo que traerme las Interfaces de ColegioInstruccion y Torneo puesto que
        necesito buscar el Nombre del colegio al que pertence el Arbitro y el Nombre del Torneo también
        por eso hago la función de buscar el colegio por el (arbitro.ColegioInstruccionId) e igualmente 
        con el torneo, la diferencia aquí esque como TorneoId es un int? y no un int necesito parsearlo 
        pero antes de eso necesito verificar si el arbitro si tiene un TorneoId, 
        por eso digo if(arbitro.TorneoId!=null) entonces buscalo, pero si es null, no es
        necesario buscar

        En el Details.cshtml, Solo pongo arbitro.Colegio.RazonSocial, ya que la entidad Arbitro
        posee una propiedad de tipo ColegioInstruccion llamada Colegio e igualmente Torneo

        */
    }
}
