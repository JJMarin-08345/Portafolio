using Dominio;
using System.Collections.Generic;
using System.Linq;

namespace Persistencia{
    public class RArbitro:IRArbitro{ //Esta clase "RArbitro" debe implementar el IRArbitro
        //Atributos
        private readonly AppContext appContext;
        //Se hace de tipo AppContext porque ahí es donde se manipula la base de datos
        private static Arbitro arbi;

        //Metodos
        //Constructor por defecto
        public RArbitro(AppContext _appContext){//Este es super importante
            this.appContext = _appContext;
        }

        //Metodos CRUD
        //Crear Arbitro
        public bool CrearArbitro(Arbitro arbitro){
            //if(!Existencia(arbitro)){
                try{
                    this.appContext.Arbitros.Add(arbitro);
                    this.appContext.SaveChanges();
                    return true;
                }catch(System.Exception){
                    /*En caso que sea false, en la pagina debe mostrar un mensaje*/
                    return false;
                }
            //}
            return false;
        }

        //Buscar Arbitro
        public Arbitro BuscarArbitro(int id){
            arbi = appContext.Arbitros.Find(id);
            //Aun falta por hacer
            return arbi;
        }

        //Modificat Arbitro
        public bool ModificarArbitro(Arbitro arbitro){
            arbi=this.appContext.Arbitros.Find(arbitro.Id);
            if(arbi!=null){
                try
                {
                    arbi.Documento=arbitro.Documento;
                    arbi.Nombres=arbitro.Nombres;
                    arbi.Apellidos=arbitro.Apellidos;
                    arbi.Deporte=arbitro.Deporte;
                    arbi.Rh=arbitro.Rh;
                    arbi.Celular=arbitro.Celular;
                    arbi.ColegioInstruccionId=arbitro.ColegioInstruccionId;
                    arbi.TorneoId=arbitro.TorneoId;
                    //if(!Existencia(arbi)){
                        this.appContext.SaveChanges();
                        return true;
                    //}
                }
                catch (System.Exception)
                {
                    return false;
                }
            }
            return false;
        }

        //Eliminar Arbitro
        public bool EliminarArbitro(int id){
            arbi = this.appContext.Arbitros.Find(id);
            /*Este de arriba se hace para buscar primero, y luego
            la condicional es si encontró algo*/
            if(arbi!=null){
                try
                {
                    this.appContext.Arbitros.Remove(arbi);
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

        //Listar Arbitro
        public List<Arbitro> ListarArbitrosList(){
            return this.appContext.Arbitros.ToList();
        }
        public IEnumerable<Arbitro> ListarArbitrosIE(){
            return this.appContext.Arbitros;
        }

        //Verificar si ya existe un arbitro
        private bool Existencia(Arbitro arbitro){
            arbi = this.appContext.Arbitros.FirstOrDefault(
                    a=>a.Documento==arbitro.Documento);
            if(arbi!=null){
                //Si es diferente de null, o sea lleno, si existe tal arbitro
                return true;
            }
            return false;
        }
    }
}