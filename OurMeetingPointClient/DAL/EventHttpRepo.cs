using OurMeetingPoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;

namespace OurMeetingPointClient.DAL
{
    public class EventHttpRepo : IHttpRepo<Event, EventDetail>
    {
        private string _apiSuffix;
        private string _baseAddress;

        public EventHttpRepo(string suffix, string address)
        {
            _apiSuffix = suffix;
            _baseAddress = address;
        }

        private HttpClient _CreateHttpClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_baseAddress);

            return client;
        }

        public async Task<HttpStatusCode> Create(Event item)
        {
            using(HttpClient client = _CreateHttpClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(_apiSuffix, item);
                return response.StatusCode;
            }
        }

        public async Task<HttpStatusCode> Delete(int id)
        {
            using (HttpClient client = _CreateHttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync(_apiSuffix + id);
                return response.StatusCode;
            }
        }

        public async Task<EventDetail> GetItemById(int id)
        {
            using (HttpClient client = _CreateHttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(_apiSuffix + id);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var @event = JsonConvert.DeserializeObject<EventDetail>(content);

                    return @event;
                }

                return new EventDetail();
            }
        }

        public async Task<IEnumerable<EventDetail>> GetItems()
        {
            using (HttpClient client = _CreateHttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(_apiSuffix);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var events = JsonConvert.DeserializeObject<List<EventDetail>>(content);

                    return events;
                }

                return new List<EventDetail>();
            }
        }

        public async Task<HttpStatusCode> Update(int id, Event item)
        {
            using (HttpClient client = _CreateHttpClient())
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(_apiSuffix + id, item);
                return response.StatusCode;
            }
        }
    }
}