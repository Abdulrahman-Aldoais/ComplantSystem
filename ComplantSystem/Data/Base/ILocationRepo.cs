using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComplantSystem.Models.Data.Base
{
    public interface ILocationRepo<T>
    {
     
        T Find(int Id);
        List<T> List();
        List<T> ListByFilter(Func<T, bool> lamda);
    }
}
