using Dominio;
using System.Collections.Generic;

namespace Persistencia{
    public class REntrenador:IREntrenador{
        //Atributos
        private readonly AppContext appContext;
        private static Entrenador entrenador;

        //Metodos
        //Contructor por defecto
        public REntrenador(AppContext _appContext){
            this.appContext=_appContext;
        }

        //Metodos CRUD
        //Crear Entrenador
        public bool CrearEntrenador(Entrenador trenador){
            try{
                this.appContext.Entrenadores.Add(trenador);
                this.appContext.SaveChanges();
                return true;
            }catch(System.Exception){
                //Ya existe
                return false;
            }
            return false;
        }

        //Buscar Entrenador
        public Entrenador BuscarEntrenador(int id){
            entrenador=this.appContext.Entrenadores.Find(id);
            return entrenador;
        }

        //Modificar Entrenador
        public bool ModificarEntrenador(Entrenador trenador){
            entrenador= this.appContext.Entrenadores.Find(trenador.Id);
            /*El entrenador que nos llega, lo almacenamos en la variable entrenador y 
            posteriormente le asignamos los valores que se ingresen en el entrenador*/
            if(entrenador!=null){
                try
                {
                    entrenador.Documento=trenador.Documento;
                    entrenador.Nombres=trenador.Nombres;   
                    entrenador.Apellidos=trenador.Apellidos;
                    entrenador.Deporte=trenador.Deporte;
                    entrenador.Celular=trenador.Celular;
                    entrenador.Correo=trenador.Correo;
                    entrenador.EquipoId=trenador.EquipoId;
                    //if(!Existencia(entrenador)){
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

        //Eliminar ENtrenador
        public bool EliminarEntrenador(int id){
            entrenador=this.appContext.Entrenadores.Find(id);
            if(entrenador!=null){//Entonces si existe y lo eliminaremos
                try{
                    this.appContext.Entrenadores.Remove(entrenador);
                    this.appContext.SaveChanges();
                    return true;
                }catch(System.Exception){
                    return false;
                }
            }
            return false;
        }

        //Listar Entrenador
        public List<Entrenador> ListarEntrenadorList(){
            return this.appContext.Entrenadores.ToList();
        }
        public IEnumerable<Entrenador> ListarEntrenadorIE(){
            return this.appContext.Entrenadores;
        }

        //Validaciones
        private bool Existencia(Entrenador trenador){
            entrenador=this.appContext.Entrenadores.FirstOrDefault(
                e=>e.Documento==trenador.Documento);
                
            if(entrenador!=null){
                //El entrenador ya existe
                return true;
            }
            return false;
        }
    }
}