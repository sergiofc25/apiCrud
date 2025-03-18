using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Interface.Actions;

public interface IReadRepository<T, Y, X, Z, M, L> where T : class
{
    T Obten(Y Id);

    IEnumerable<T> Obten_Paginado(Y Opcion, X Valor, Z Condicion, M Inicio, L Fin);

    Y Obten_Paginado_Cantidad(Y Opcion, X Valor, Z Condicion);

    Y Obten_Cantidad();
}

