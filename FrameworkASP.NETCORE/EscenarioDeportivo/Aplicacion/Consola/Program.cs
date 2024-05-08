using Dominio;
using Persistencia;
using System;
using System.Collections.Generic;

namespace Consola{
    class Program{
        private static IRMunicipio objMunicipio = new RMunicipio(new Persistencia.AppContext());
        private static IRDeportista objDeportista = new RDeportista(new Persistencia.AppContext());
        static void Main(string[] args){
            Console.Clear();
            Deportista deportista = objDeportista.BuscarDeportista(1);
            //Console.WriteLine(deportista.FechaNacimiento);
            Console.WriteLine(deportista.CalcularEdad());
        }
        private static void Menu(){
            
            /*
            int opcion=0;
            Console.WriteLine("1- CREAR MUNICIPIO");
            Console.WriteLine("2- BUSCAR MUNICIPIO");
            Console.WriteLine("3- ELIMINAR MUNICIPIO");
            Console.WriteLine("4- MODIFICAR MUNICIPIO");
            Console.WriteLine("5- LISTAR MUNICIPIOS");
            Console.WriteLine("6- SALIR");
            opcion=int.Parse(Console.ReadLine());
            switch (opcion){
                case 1:
                    CrearMunicipio();
                    break;
                case 2:
                    BuscarMunicipio();
                    break;
                case 3:
                    EliminarMunicipio();
                    break;
                case 4:
                    ModifiMunicipio();
                    break;
                case 5:
                    ListarMunicipios();
                    break;
                case 6:
                    Console.WriteLine("Hasta luego");
                    break;
                default:
                    Console.WriteLine("Escriba algo correcto");
                    Console.Clear();
                    break;
            }*/
        }

        private static void CrearMunicipio(){
            Municipio mun = new Municipio();
            Console.WriteLine("Escriba el nombre del municipio");
            mun.Nombre=Console.ReadLine();

            if(objMunicipio.CrearMunicipio(mun)){
                Console.WriteLine("Se ha creado el municipio {0}",mun.Nombre);
            }else{
                Console.WriteLine("Ya existe un municipio con este mismo nombre: {0}",mun.Nombre);
            }
            
            Clear();
        }
        private static void BuscarMunicipio(){
            int getId=0;
            Console.WriteLine("Digite el Id del municipio a bucar");
            Municipio mun=objMunicipio.BuscarMunicipio(getId=int.Parse(Console.ReadLine()));
            if(mun!=null){
                Console.WriteLine(mun.Id+" "+mun.Nombre);
            }else{
                Console.WriteLine("No existe el municipio con el Id");
            }
            Clear();
        }
        private static void EliminarMunicipio(){
            Console.WriteLine("Digite el Id del municipio a eliminar");
            bool existe=objMunicipio.EliminarMunicipio(int.Parse(Console.ReadLine()));
            if(existe){
                Console.WriteLine("Se ha eliminado el municipio");
            }else{
                Console.WriteLine("No existe el municipio con el Id");
            }
            Clear();
        }
        private static void ModifiMunicipio(){
            /*Si sirve, en la base de datos no se actualiza, pero aquí en consola si*/
            Municipio mun= new Municipio();
            Console.WriteLine("Ingrese el Id del municipio a modificar");
            mun.Id=int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nuevo nombre del municipio");
            mun.Nombre=Console.ReadLine();
            bool funciono= objMunicipio.ModificarMunicipio(mun);
            if(funciono)
            {
                Console.WriteLine("Municipio actualizado con exito...");
            }
            else
            {
                Console.WriteLine("No fue posible realizar la modificacion");
            }
            Clear();
        }
        private static void ListarMunicipios(){
            List<Municipio> lstMuni=objMunicipio.ListarMunicipiosList();
            foreach(var munpo in lstMuni){
                Console.WriteLine(munpo.Id+" "+munpo.Nombre);
            }
            lstMuni.Clear();
            Console.WriteLine(lstMuni.Count);
            Clear();
        }
        private static void Clear(){
            Console.WriteLine("Digite una tecla para continuar");
            Console.ReadLine();
            Console.Clear();
            Menu();
        }
    }
}
