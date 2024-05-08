using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistencia{
    public class REscenario:IREscenario{
        //Atributos
        private readonly AppContext appContext;
        private static Escenario escenario;
        //Metodos
        //Constructor por defecto
        public REscenario(AppContext _appContext){
            this.appContext = _appContext;
        }
        //Metodos CRUD
        //Crear Escenario
        public bool CrearEscenario(Escenario esc){
            try
            {
                this.appContext.Escenarios.Add(esc);
                this.appContext.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        //Buscar Escenario
        public Escenario BuscarEscenario(int id){
            return this.appContext.Escenarios.Find(id);
        }

        //Modificar Escenario
        public bool ModificarEscenario(Escenario esc){
            escenario=this.appContext.Escenarios.Find(esc.Id);
            if(escenario!=null){
                //Si existe y se puede modificar
                try{
                    escenario.Nombre=esc.Nombre;
                    escenario.Tipo=esc.Tipo;
                    escenario.Espectadores=esc.Espectadores;
                    escenario.UnidadDeportivaId=esc.UnidadDeportivaId;
                    this.appContext.SaveChanges();
                    return true;
                }catch(System.Exception){
                    return false;
                }
            }
            return false;
        }

        //Eliminar Escenario
        public bool EliminarEscenario(int id){
            escenario=BuscarEscenario(id);
            if(escenario!=null){
                try
                {
                    this.appContext.Escenarios.Remove(escenario);
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

        //Listar Escenarios
        public List<Escenario> ListarEscenarioList(){
            return this.appContext.Escenarios.ToList();
        }
        public IEnumerable<Escenario> ListarEscenarioIE(){
            return this.appContext.Escenarios;
        }

        //Validaciones
        private bool Existencia(Escenario esc){
            escenario=this.appContext.Escenarios.FirstOrDefault(
                e=>e.Nombre==esc.Nombre);
            if(escenario!=null){
                //Si existe
                return true;
            }
            return false;
        }
    }
}