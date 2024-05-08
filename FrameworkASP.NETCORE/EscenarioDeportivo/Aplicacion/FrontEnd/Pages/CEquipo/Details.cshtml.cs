using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CEquipo
{
    public class DetailsModel : PageModel
    {
        //Atributos
        private readonly IREquipo objEquipo;
        //Propiedades navigacionales
        private readonly IRPatrocinador objPatrocinador;
        private readonly IREntrenador objEntrenador;
        private readonly IRDeportista objDeportista;
        [BindProperty]
        public Equipo equipo {get;set;}
        //Propiedades navigacionales
        public Patrocinador patrocinador {get;set;}
        public IEnumerable<Entrenador> lstEntrenador {get;set;}
        public List<Deportista> deportistas {get;set;}
        //Constructor
        public DetailsModel(IREquipo _objEquipo,IRPatrocinador _objPatrocinador,IREntrenador _objEntrenador,
                            IRDeportista _objDeportista){
            this.objEquipo = _objEquipo;
            this.objPatrocinador = _objPatrocinador;
            this.objEntrenador = _objEntrenador;
            this.objDeportista = _objDeportista;
        }
        public ActionResult OnGet(int id){
            deportistas = objDeportista.ListarDeportistaList();
            equipo = objEquipo.BuscarEquipo(id);
            if(equipo==null){
                ViewData["Error"]="No se encontró el equipo";
                return Page();
            }else{
                patrocinador=objPatrocinador.BuscarPatrocinador(equipo.PatrocinadorId);
                lstEntrenador=objEntrenador.ListarEntrenadorIE();
            }
            return Page();
        }
    }
}
