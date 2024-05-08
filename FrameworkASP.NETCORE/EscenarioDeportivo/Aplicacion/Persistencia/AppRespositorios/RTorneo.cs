using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistencia
{
    public class RTorneo:IRTorneo{
        private readonly AppContext appContext;
        private static Torneo torneo;
        public RTorneo(AppContext _appContext){
            this.appContext=_appContext;
        }
        public bool CrearTorneo(Torneo torn){
            if(!Existe(torn)){
                try
                {
                    this.appContext.Torneos.Add(torn);
                    this.appContext.SaveChanges();
                    return true;
                }
                catch (System.Exception)
                {
                    return false;
                }
            }
            //Sino, ya hay un torneo con mismo nombre
            return false;
        }
        public Torneo BuscarTorneo(int id){
            return this.appContext.Torneos.Find(id);
            
        }
        public bool EliminarTorneo(int id){
            torneo=this.appContext.Torneos.Find(id);
            if(torneo!=null){
                try{
                    this.appContext.Torneos.Remove(torneo);
                    this.appContext.SaveChanges();
                    return true;
                }catch(System.Exception){
                    return false;
                }
            }
            return false;
        }
        public bool ModificarTorneo(Torneo torn){
            torneo=this.appContext.Torneos.Find(torn.Id);
            if(torneo!=null){
                try
                {
                    torneo.Nombre=torn.Nombre;
                    torneo.Categoria=torn.Categoria;
                    torneo.Deporte=torn.Deporte;
                    torneo.FechaInicio=torn.FechaInicio;
                    torneo.FechaFin=torn.FechaFin;
                    torneo.CantidadEquipos=torn.CantidadEquipos;
                    torneo.MunicipioId=torn.MunicipioId;
                    torneo.PatrocinadorId=torn.PatrocinadorId;
                    //torneo.Arbitros=torn.Arbitros;
                    //torneo.UnidadesDeportivas=torn.UnidadesDeportivas;
                    //torneo.TorneoEquipos=torn.TorneoEquipos;
                    this.appContext.SaveChanges();
                    return true;
                }
                catch (System.Exception)
                {
                    return false;
                }
            }
            return true;
        }
        public List<Torneo> ListarTorneosList(){
            return this.appContext.Torneos.ToList();
        }
        public IEnumerable<Torneo> ListarTorneosIE(){
            return this.appContext.Torneos;
        }

        private bool Existe(Torneo torn){
            torneo=this.appContext.Torneos.FirstOrDefault(
                t=>t.Nombre==torn.Nombre);
                
            if(torneo!=null){
                //El torneo ya existe
                return true;
            }
            return false;
        }
    }
}