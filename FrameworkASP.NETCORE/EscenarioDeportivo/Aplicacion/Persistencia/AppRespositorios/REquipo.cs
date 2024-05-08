using System;
using System.Collections.Generic;
using System.Linq;
using Dominio;

namespace Persistencia{
    public class REquipo:IREquipo{
        //Atributos
        private readonly AppContext appContext;
        private static Equipo equipo;

        //Metodos
        //Constructor por defecto
        public REquipo(AppContext _appContext){
            this.appContext = _appContext;
        }

        //Metodos CRUD
        //Crear Equipo
        public bool CrearEquipo(Equipo equ){
            try{
                this.appContext.Equipos.Add(equ);
                this.appContext.SaveChanges();
                return true;
            }catch(System.Exception){
                return false;
            }
            return false;
        }

        //Buscar Equipo
        public Equipo BuscarEquipo(int id){
            return this.appContext.Equipos.Find(id);
        }

        //Modificar Equipo
        public bool ModificarEquipo(Equipo equ){
            equipo=this.appContext.Equipos.Find(equ.Id);
            if(equipo!=null){
                //Entonces si encontró un equipo
                try
                {
                    equipo.Nombre=equ.Nombre;
                    equipo.Tecnico=equ.Tecnico;
                    equipo.Jugadores=equ.Jugadores;
                    equipo.PatrocinadorId=equ.PatrocinadorId;
                    //equipo.Deportistas=equ.Deportistas;
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

        //Eliminar Equipo
        public bool EliminarEquipo(int id){
            equipo=this.appContext.Equipos.Find(id);
            if(equipo!=null){
                try
                {
                    this.appContext.Equipos.Remove(equipo);
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

        //Listar Equipo
        public List<Equipo> ListarEquipoList(){
            return this.appContext.Equipos.ToList();
        }
        public IEnumerable<Equipo> ListarEquipoIE(){
            return this.appContext.Equipos;
        }

        //Validaciones
        private bool Existencia(Equipo equ){
            equipo=this.appContext.Equipos.FirstOrDefault(
                e=>e.Nombre==equ.Nombre);

            if(equipo!=null){
                //Entonces el equipo ya existe
                return true;
            }
            return false;
        }
    }
}