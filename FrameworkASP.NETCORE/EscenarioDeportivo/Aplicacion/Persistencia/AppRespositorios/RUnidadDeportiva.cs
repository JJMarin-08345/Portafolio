using System;
using System.Collections.Generic;
using System.Linq;
using Dominio;

namespace Persistencia{

    public class RUnidadDeportiva:IRUnidadDeportiva{
        //Atributos
        private readonly AppContext appContext;
        private static UnidadDeportiva uniDepor;

        //Metodos
        //Constructor por defecto
        public RUnidadDeportiva(AppContext _appContext){
            this.appContext = _appContext;
        }

        //Metodos CRUD
        //Crear Unidad Deportiva
        public bool CrearUniDeportiva(UnidadDeportiva unidad){
            try
            {
                this.appContext.UnidadesDeportivas.Add(unidad);
                this.appContext.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
            return false;
        }
        
        //Buscar Unidad Deportiva
        public UnidadDeportiva BuscarUniDeporiva(int id){
            return this.appContext.UnidadesDeportivas.Find(id);
        }
        
        //Modificar Unidad Deportiva
        public bool ModificarUniDeportiva(UnidadDeportiva unidad){
            uniDepor=this.appContext.UnidadesDeportivas.Find(unidad.Id);
            if(uniDepor!=null){
                //Si hay una unidad deportiva
                try
                {
                    uniDepor.Nombre=unidad.Nombre;
                    uniDepor.Ciudad=unidad.Ciudad;
                    uniDepor.Direccion=unidad.Direccion;
                    uniDepor.TorneoId=unidad.TorneoId;
                    //uniDepor.Escenarios=unidad.Escenarios;
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
        
        //Eliminar Unidad Deportiva
        public bool EliminarUniDeportiva(int id){
            uniDepor=this.appContext.UnidadesDeportivas.Find(id);
            if(uniDepor!=null){
                try
                {
                    this.appContext.UnidadesDeportivas.Remove(uniDepor);
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

        //Listar Unidad Deportiva
        public List<UnidadDeportiva> ListarUniDeportivaList(){
            return this.appContext.UnidadesDeportivas.ToList();
        }
        public IEnumerable<UnidadDeportiva> ListarUniDeportivaIE(){
            return this.appContext.UnidadesDeportivas;
        }

        //Validacion
        private bool Existencia(UnidadDeportiva uni){
            uniDepor=this.appContext.UnidadesDeportivas.FirstOrDefault(
                ud=>ud.Direccion==uni.Direccion);
            if(uniDepor!=null){
                //Ya existe una con la misma dirección
                return true;
            }
            // Entonces no existe
            return false;
        }

    }
}