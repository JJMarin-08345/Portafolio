using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Dominio;
using Persistencia;

namespace FrontEnd.Pages.CTorneoEquipos
{
    public class IndexModel : PageModel
    {
        private readonly IRTorneoEquipo objTorneoEquipo;
        private readonly IREquipo objEquipo;
        private readonly IRTorneo objTorneo;
        public IEnumerable<Equipo> lstEquipos {get;set;}
        public Equipo equipo {get;set;}
        public List<Torneo> lstTorneos { get; set; }
        public List<TorneoEquipo> lstTorneoEquipos {get;set;}
        //Constructor por defecto
        public IndexModel(IRTorneoEquipo _objTorneoEquipo,IREquipo _objEquipo,IRTorneo _objTorneo){
            this.objTorneoEquipo =_objTorneoEquipo;
            this.objEquipo = _objEquipo;
            this.objTorneo = _objTorneo;
        }
        public void OnGet(){
            lstEquipos=objEquipo.ListarEquipoIE();
            lstTorneos=objTorneo.ListarTorneosList();
            lstTorneoEquipos=objTorneoEquipo.ListarTorneoEquipoList();
            for(int i=0;i<lstTorneoEquipos.Count;i++){
                //torneo=objTorneo.BuscarTorneo(lstTorneoEquipos[i].TorneoId);
                equipo=objEquipo.BuscarEquipo(lstTorneoEquipos[i].EquipoId);
            }
        }
    }
}
