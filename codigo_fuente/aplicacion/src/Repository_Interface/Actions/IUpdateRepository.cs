using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Interface.Actions;

internal interface IUpdateRepository<T> where T : class
{
    int Obten_Cantidad_Existente(T t);

    int Actualiza(T t);

    int Actualiza_Condicion(T t);
}

