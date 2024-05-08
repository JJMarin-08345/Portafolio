using Dominio;
using System.Collections.Generic;
using System.Linq;

namespace Persistencia{
    public class RColegioInstruccion:IRColegioInstruccion{
        //Esto siempre va, impletenta la clase Interfaz  
        private readonly AppContext appContext;
        private static ColegioInstruccion colegio;

        //Constructor por defecto
        public RColegioInstruccion(AppContext _appContext){
            this.appContext=_appContext;
        }

        //Metodos CRUD
        //Crear Colegio
        public bool CrearColegio(ColegioInstruccion cole){
            if(!Existencia(cole)){
                try
                {
                    this.appContext.ColegiosInstrucciones.Add(cole);
                    this.appContext.SaveChanges();
                    return true;
                }
                catch (System.Exception)
                {
                    return false;
                }
            }
            return false;
        }

        //Buscar Colegio
        public ColegioInstruccion BuscarColegio(int id){
            return colegio=this.appContext.ColegiosInstrucciones.Find(id);
        }

        //Modificar Colegio
        public bool ModificarColegio(ColegioInstruccion col){
            colegio=this.appContext.ColegiosInstrucciones.Find(col.Id);
            if(colegio!=null){
                try
                {
                    colegio.Nit=col.Nit;
                    colegio.RazonSocial=col.RazonSocial;
                    colegio.Direccion=col.Direccion;
                    colegio.Licencia=col.Licencia;
                    colegio.Deporte=col.Deporte;
                    colegio.Telefono=col.Telefono;
                    //colegio.Arbitros=col.Arbitros;
                    this.appContext.SaveChanges();
                    return true;
                }
                catch (System.Exception)
                {
                    return false;
                }
            }
            return false;
        }

        //Eliminar Colegio
        public bool EliminarColegio (int id){
            colegio=this.appContext.ColegiosInstrucciones.Find(id);
            if(colegio!=null){
                try
                {
                    this.appContext.ColegiosInstrucciones.Remove(colegio);
                    this.appContext.SaveChanges();
                    return true;
                }
                catch (System.Exception)
                {
                    return false;
                }
            }
            return false;
        }

        //Listar Colegios con List
        public List<ColegioInstruccion> ListarColegiosList(){
            return this.appContext.ColegiosInstrucciones.ToList();
        }

        //Listar Colegios con IEnumerable
        public IEnumerable<ColegioInstruccion> ListarColegiosIE(){
            return this.appContext.ColegiosInstrucciones;
        }

        //Validaciones
        private bool Existencia(ColegioInstruccion col){
            colegio=this.appContext.ColegiosInstrucciones.FirstOrDefault(
                c=>c.Nit==col.Nit);

            if(colegio!=null){
                //Si existe
                return true;
            }
            return false;
        }

    }
}