using System.Collections.Generic;
using Dominio;

namespace Persistencia{
    public class RPatrocinador:IRPatrocinador{
        //Atributos
        private readonly AppContext appContext;
        private static Patrocinador patrocinador;

        //Metodos 
        //Constructor por defecto
        public RPatrocinador(AppContext _appContext){
            this.appContext = _appContext;
        }

        //Metodos CRUD
        //Crear Patrocinador
        public bool CrearPatrocinador(Patrocinador pat){
            try
            {
                this.appContext.Patrocinadores.Add(pat);
                this.appContext.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
            return false;
        }

        //Buscar Patrocinador
        public Patrocinador BuscarPatrocinador(int id){
            return this.appContext.Patrocinadores.Find(id);
        }

        //Modificar Patrocinador
        public bool ModificarPatrocinador(Patrocinador pat){
            patrocinador=this.appContext.Patrocinadores.Find(pat.Id);
            if(patrocinador!=null){
                try
                {
                    patrocinador.Documento=pat.Documento;
                    patrocinador.Nombres=pat.Nombres;
                    patrocinador.Deporte=pat.Deporte;
                    patrocinador.Direccion=pat.Direccion;
                    patrocinador.Telefono=pat.Telefono;
                    patrocinador.Ciudad=pat.Ciudad;
                    patrocinador.Personeria=pat.Personeria;
                    this.appContext.SaveChanges();
                    return true;//Tengo mis dudas y esque como el documento si es el mismo, va a entrar
                }
                catch (System.Exception)
                {
                    return false;
                }
            }
            return false;
        }

        //Eliminar Patrocinador
        public bool EliminarPatrocinador(int id){
            patrocinador=this.appContext.Patrocinadores.Find(id);
            if(patrocinador!=null){
                try
                {
                    this.appContext.Patrocinadores.Remove(patrocinador);
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

        //Listar Patrocinador
        public List<Patrocinador> ListarPatrocinadorList(){
            return this.appContext.Patrocinadores.ToList();
        }
        public IEnumerable<Patrocinador> ListarPatrocinadorIE(){
            return this.appContext.Patrocinadores;
        }

        //Validaciones
        private bool Existencia(Patrocinador pat){
            patrocinador=this.appContext.Patrocinadores.FirstOrDefault(
                p=>p.Documento==pat.Documento);

            if(patrocinador!=null){
                //Ya existe el patrocinador
                return true;
            }
            return false;
        }
    }
}