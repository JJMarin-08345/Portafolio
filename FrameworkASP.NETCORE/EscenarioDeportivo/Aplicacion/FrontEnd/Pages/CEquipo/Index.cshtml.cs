using System.Transactions;
using System.Linq;
using System.Collections;
using System.Security.AccessControl;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CEquipo
{
    public class IndexModel : PageModel
    {
        //Atributos
        private readonly IREquipo objEquipo;
        private readonly IRDeportista objDeportista;
        private readonly IREntrenador objEntrenador;
        public List<Equipo> lstEquipos {get;set;}
        public List<Entrenador> lstEntrenadores {get;set;}
        public List<Deportista> lstDeportistas {get;set;}
        
        //Metodo constructor por defecto
        public IndexModel(IREquipo _objEquipo,IRDeportista _objDeportista,IREntrenador _objEntrenador){
            this.objEquipo = _objEquipo;
            this.objDeportista = _objDeportista;
            this.objEntrenador = _objEntrenador;
        }
        public ActionResult OnGet(){
            lstEquipos = objEquipo.ListarEquipoList();
            lstDeportistas = objDeportista.ListarDeportistaList();
            lstEntrenadores = objEntrenador.ListarEntrenadorList();
            
            for(int i=0;i<lstEquipos.Count;i++){
                objEntrenador.BuscarEntrenador(lstEquipos[i].Id);
            }
            return Page();
        }
    }
}
