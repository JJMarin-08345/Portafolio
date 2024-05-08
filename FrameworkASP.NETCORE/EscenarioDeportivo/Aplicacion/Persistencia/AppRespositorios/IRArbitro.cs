using Dominio;
using System.Collections.Generic;
//Interfaz Arbitro
namespace Persistencia{
    public interface IRArbitro{ //IR significa Interfaz tonxs InterfazdeArbitro
    //También debe siempre ser public interface
        //Metodos CRUD
        public bool CrearArbitro(Arbitro arbitro);
        public Arbitro BuscarArbitro(int id);
        public bool ModificarArbitro(Arbitro arbitro);
        public bool EliminarArbitro(int id);
        public List<Arbitro> ListarArbitrosList();
        public IEnumerable<Arbitro> ListarArbitrosIE();
    }
}