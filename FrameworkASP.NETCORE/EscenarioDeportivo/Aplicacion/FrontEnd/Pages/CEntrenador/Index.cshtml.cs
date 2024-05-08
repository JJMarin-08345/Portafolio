using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CEntrenador
{
    public class IndexModel : PageModel
    {
        //Atributos
        private readonly IREntrenador objEntrenador;
        private readonly IREquipo objEquipo;
        public List<Entrenador> lstEntrenadores {get;set;}
        public Equipo equipo {get;set;}
        //Constructor
        public IndexModel(IREntrenador _objEntrenador,IREquipo _objEquipo){
            this.objEntrenador = _objEntrenador;
            this.objEquipo = _objEquipo;
        }
        public void OnGet(){
            lstEntrenadores=objEntrenador.ListarEntrenadorList();
            for(int i=0;i<lstEntrenadores.Count;i++){
                if(lstEntrenadores[i].EquipoId!=null){
                    equipo=objEquipo.BuscarEquipo(int.Parse(""+lstEntrenadores[i].EquipoId));
                }else{
                    break;
                }
            }
        }
    }
}
