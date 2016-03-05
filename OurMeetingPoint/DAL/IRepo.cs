using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurMeetingPoint.DAL
{
    public interface IRepo<T, TDetail> : IDisposable
    {
        TDetail GetItemById(int id);
        IEnumerable<TDetail> GetItems();
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}
