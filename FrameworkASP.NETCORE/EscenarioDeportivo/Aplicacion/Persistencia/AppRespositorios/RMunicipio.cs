using System.Collections.Generic;
using System.Linq;
using Dominio;

namespace Persistencia{
    public class RMunicipio:IRMunicipio{
        private readonly AppContext appContext;
        private static Municipio municipio;
        
        //Constructor por defecto
        public RMunicipio(AppContext _appContext){
            this.appContext=_appContext;
        }

        //Metodos CRUD
        //Crear Municipio
        public bool CrearMunicipio(Municipio mun){
            if(!Existencia(mun)){
                try{
                    this.appContext.Municipios.Add(mun);
                    this.appContext.SaveChanges();
                    return true;
                }catch(System.Exception){
                    return false;
                }
            }//Sino, enviar mensaje de que ese municipio ya existe(Por el nombre)
            return false;
        }

        //Buscar Municipio
        public Municipio BuscarMunicipio(int id){
            /*return this.appContext.Municipios.
                                       Where(x=>x.Id==id)
                                       .SingleOrDefault();*/
            //municipio=this.appContext.Municipios.Find(id);
            //return municipio;
            return this.appContext.Municipios.Find(id);
        }
        public bool ModificarMunicipio(Municipio mun){
            municipio=this.appContext.Municipios.Find(mun.Id);
            if(municipio!=null){
                try{
                    municipio.Nombre=mun.Nombre;
                    //municipio.Torneos=mun.Torneos;
                    if(!Existencia(mun)){
                        this.appContext.SaveChanges();
                        return true;
                    }
                }
                catch (System.Exception)
                {
                    return false;   
                }
            }
            return false;
        }
        //Eliminar Municipio
        public bool EliminarMunicipio(int id){
            municipio = this.appContext.Municipios.Find(id);
            if(municipio!=null){
                try{
                    this.appContext.Municipios.Remove(municipio);
                    this.appContext.SaveChanges();
                    return true;
                }catch(System.Exception){
                    return false;
                }
            }
            return false;
        }
        //Listar Municipio
        public List<Municipio> ListarMunicipiosList(){
            /*using(var ctx = new AppContext()){
                return ctx.Municipios
                          .ToList();
            }*/
            return this.appContext.Municipios.ToList();
        }
        public IEnumerable<Municipio> ListarMunicipiosIE(){
            return this.appContext.Municipios;
        }

        private bool Existencia(Municipio mun){
            municipio = this.appContext.Municipios.FirstOrDefault(
                m=> m.Nombre== mun.Nombre);
                
            if(municipio != null){
                //El municipio ya existe
                return true;
            }
            return false;
        }
    }
}