using Newtonsoft.Json;
using OurMeetingPoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace OurMeetingPoint.DAL.Http
{
    public class MeetingPointHttpRepo : IHttpRepo<MeetingPoint, MeetingPointDetail>
    {
        private string _apiSuffix;
        private string _baseAddress;

        public MeetingPointHttpRepo(string suffix, string address)
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

        public async Task<HttpStatusCode> Create(MeetingPoint item)
        {
            using (HttpClient client = _CreateHttpClient())
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

        public async Task<MeetingPointDetail> GetItemById(int id)
        {
            using (HttpClient client = _CreateHttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(_apiSuffix + id);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var meetingPoint = JsonConvert.DeserializeObject<MeetingPointDetail>(content);

                    return meetingPoint;
                }

                return new MeetingPointDetail();
            }
        }

        public async Task<List<MeetingPointDetail>> GetItems()
        {
            using (HttpClient client = _CreateHttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(_apiSuffix);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var meetingPoints = JsonConvert.DeserializeObject<List<MeetingPointDetail>>(content);

                    return meetingPoints;
                }

                return new List<MeetingPointDetail>();
            }
        }

        public async Task<HttpStatusCode> Update(int id, MeetingPoint item)
        {
            using (HttpClient client = _CreateHttpClient())
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(_apiSuffix + id, item);
                return response.StatusCode;
            }
        }
    }
}