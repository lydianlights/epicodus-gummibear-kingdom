using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GummiBearKingdom.Models;

namespace GummiBearKingdom.Data
{
    public interface IDbRepo<T>
    {
        IQueryable<T> Data { get; }
        T Save(T obj);
        T Update(T obj);
        void Delete(T obj);
        void DeleteAll();
    }
}
