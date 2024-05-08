using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistencia{

    public class RDeportista:IRDeportista{
        //Atributos
        private readonly AppContext appContext;
        private static Deportista deportista;

        //Constructor por defecto
        public RDeportista(AppContext _appContext){
            this.appContext=_appContext;
        }
        public bool CrearDeportista(Deportista depor){
            if(CalcularEdad(depor)>=12){
                try{
                    this.appContext.Deportistas.Add(depor);
                    this.appContext.SaveChanges();
                    return true;
                }catch(System.Exception){
                    return false;
                }
            }
            return false;
        }

        //Buscar Deportista
        public Deportista BuscarDeportista(int id){
            deportista=this.appContext.Deportistas.Find(id);
            return deportista;

        }

        //Modificar Deportista
        public bool ModificarDeportista(Deportista depor){
            deportista=this.appContext.Deportistas.Find(depor.Id);
            if(deportista!=null){
                try
                {
                    deportista.Documento=depor.Documento;
                    deportista.Nombres=depor.Nombres;
                    deportista.Apellidos=depor.Apellidos;
                    deportista.Genero=depor.Genero;
                    deportista.Deporte=depor.Deporte;
                    deportista.FechaNacimiento=depor.FechaNacimiento;
                    deportista.Rh=depor.Rh;
                    deportista.Eps=depor.Eps;
                    deportista.Celular=depor.Celular;
                    deportista.Correo=depor.Correo;
                    deportista.EquipoId=depor.EquipoId;
                    //if(!Existencia(deportista)){
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

        //Eliminar Deportista
        public bool EliminarDeportista(int id){
            deportista=this.appContext.Deportistas.Find(id);
            if(deportista!=null){
                try
                {
                    this.appContext.Deportistas.Remove(deportista);
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
        //Listar Deportista por filtro
        public IEnumerable<Deportista> ListarDeportistaXFiltro(string filtro){
            var deportistas=ListarDeportistaIE();//Es para obtener todos los deportistas
            if(deportistas!=null){
                if(String.IsNullOrEmpty(filtro)){//Preguntamos si el string filtro no es nulo o vacio
                    deportistas=deportistas.Where(d=>d.Nombres.Contains(filtro));
                                            /*Hacemos una busqueda sobre el campo Nombre y que contenga 
                                            el valor a buscar*/
                }
            }
            return deportistas;
        }

        //Listar Deportista
        public List<Deportista> ListarDeportistaList(){
            return this.appContext.Deportistas.ToList();
        }
        public IEnumerable<Deportista> ListarDeportistaIE(){
            return this.appContext.Deportistas;
        }   

        //Validar existencia
        private bool Existencia(Deportista depor){
            deportista=this.appContext.Deportistas.FirstOrDefault(
                        d=>d.Documento==depor.Documento);
                        
            if(deportista!=null){
                //El deportista si existe
                return true;
            }
            return false;
        }
        //Calcular edad
        private int CalcularEdad(Deportista depor){
            DateTime fechaActual = DateTime.Today;
            int yearActual= fechaActual.Year;
            int anios = yearActual - depor.FechaNacimiento.Year;
            return anios;
        }
    }
}