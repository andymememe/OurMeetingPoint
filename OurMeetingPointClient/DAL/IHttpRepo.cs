using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OurMeetingPointClient.DAL
{
    interface IHttpRepo<T, TDetail>
    {
        Task<TDetail> GetItemById(int id);
        Task<IEnumerable<TDetail>> GetItems();
        Task<HttpStatusCode> Create(T item);
        Task<HttpStatusCode> Update(int id, T item);
        Task<HttpStatusCode> Delete(int id);
    }
}
