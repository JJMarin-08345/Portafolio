using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CPatrocinador
{
    public class DetailsModel : PageModel
    {
        //Atributos
        private readonly IRPatrocinador objPatrocinador;
        //Para propiedades navigacionales
        private readonly IREquipo objEquipo;
        private readonly IRTorneo objTorneo;
        public Patrocinador patrocinador {get;set;}
        //Para las propiedades navigacionales
        public List<Equipo> equipos { get; set; }
        public List<Torneo> torneos {get;set;}

        //Metodo Constructor por defecto
        public DetailsModel(IRPatrocinador _objPatrocinador,IREquipo _objEquipo,IRTorneo _objTorneo){
            this.objPatrocinador = _objPatrocinador;
            this.objEquipo = _objEquipo;
            this.objTorneo = _objTorneo;
        }
        public ActionResult OnGet(int id)//id capturado en el index
        {
            patrocinador = objPatrocinador.BuscarPatrocinador(id);
            torneos = objTorneo.ListarTorneosList();
            equipos = objEquipo.ListarEquipoList();
            if(patrocinador==null){
                //Esto no debería pasar
                torneos = objTorneo.ListarTorneosList();
                equipos = objEquipo.ListarEquipoList();
                ViewData["Error"]="No se encontró el Patrocinador";
                return Page();
            }
            return Page();
        }
    }
}
