using System;
using Dominio;
using System.Linq;
using System.Collections.Generic;

namespace Persistencia{
    public class RTorneoEquipo:IRTorneoEquipo{
        //Atributos
        private readonly AppContext appContext;
        private static TorneoEquipo torneoEquipo;
        //Constructor por defecto
        public RTorneoEquipo(AppContext _appContext){
            this.appContext = _appContext;
        }
        //Metodos CRUD
        public bool CrearTorneoEquipo(TorneoEquipo torneEquipo){
            if(!Existencia(torneEquipo)){
                try{
                    this.appContext.TorneoEquipos.Add(torneEquipo);
                    this.appContext.SaveChanges();
                    return true;
                }catch(System.Exception){
                    return false;
                }
            }
            return false;
        }
        public IEnumerable<TorneoEquipo> ListarTorneoEquipoIE(){
            return this.appContext.TorneoEquipos;
        }
        public List<TorneoEquipo> ListarTorneoEquipoList(){
            return this.appContext.TorneoEquipos.ToList();
        }
        public bool Existencia(TorneoEquipo tornEquipo){
            torneoEquipo=this.appContext.TorneoEquipos.FirstOrDefault(to=>to.TorneoId==tornEquipo.TorneoId
                                                    && to.EquipoId ==tornEquipo.EquipoId);
            if(torneoEquipo!=null){
                //Entonces ya existe
                return true;
            }
            return false;
        }
    }
}