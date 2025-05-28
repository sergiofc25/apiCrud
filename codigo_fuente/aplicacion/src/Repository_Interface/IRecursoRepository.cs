using Model.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Interface
{
    public interface IRecursoRepository
    {
        IEnumerable<Ent_Recurso> Obten_x_Partida(int Par_Id);
        int Crea_APU(Ent_Recurso Ent_Recurso);
        IEnumerable<Ent_Recurso> Obten();
        IEnumerable<Ent_Recurso> Obten_Precio_x_Partida(int Par_Id);
        (int, int, bool, bool, IEnumerable<Ent_Recurso>) Obten_Paginado(int RegistroPagina, int NumeroPagina, string? PorNombre);
        Ent_Recurso Obten_x_Id(int Cli_Id);
        (int, string) Crea(Ent_Recurso Recurso);
        //Task<(int, string)> Crea(ManzanaModel Ent_Manzana);
        string Actualiza(Ent_Recurso Recurso);
        //Task<string> Actualiza(ManzanaModel Ent_Manzana);
        int Actualiza_Condicion(int Rec_Id, bool Rec_Estado);
        //int Actualiza_APU(Ent_Recurso Ent_Recurso);

    }
}
