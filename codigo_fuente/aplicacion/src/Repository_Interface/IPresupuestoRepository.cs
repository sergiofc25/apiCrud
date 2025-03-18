using Model.Entitie;

namespace Repository_Interface
{
    public interface IPresupuestoRepository
    {
        (int, int, bool, bool, IEnumerable<Ent_Presupuesto>) Obten_Paginado(int RegistroPagina, int NumeroPagina, string PorNombre);
        Ent_Presupuesto Obten_x_Id(int Pre_Id);
        int Existe(string Pre_Nombre, bool Pre_Estado);
        int Crea(Ent_Presupuesto Ent_Presupuesto);
        int Existente(int Pre_Id, string Pre_Nombre, bool Pre_Estado);
        int Actualiza(Ent_Presupuesto Ent_Presupuesto);
        int Actualiza_Condicion(int Pre_Id, bool Pre_Estado);
    }
}
