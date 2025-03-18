using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Interface.Actions;

public interface IRemoveRepository<T> where T : class
{
    int Elimina(T t);
}

