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
    public class ReviewHttpRepo : IHttpRepo<Review, ReviewDetail>
    {
        private string _apiSuffix;
        private string _baseAddress;

        public ReviewHttpRepo(string suffix, string address)
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

        public async Task<HttpStatusCode> Create(Review item)
        {
            using (HttpClient client = _CreateHttpClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(_apiSuffix, item).ConfigureAwait(false);
                return response.StatusCode;
            }
        }

        public async Task<HttpStatusCode> Delete(int id)
        {
            using (HttpClient client = _CreateHttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync(_apiSuffix + id).ConfigureAwait(false);
                return response.StatusCode;
            }
        }

        public async Task<ReviewDetail> GetItemById(int id)
        {
            using (HttpClient client = _CreateHttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(_apiSuffix + id).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var review = JsonConvert.DeserializeObject<ReviewDetail>(content);

                    return review;
                }

                return new ReviewDetail();
            }
        }

        public async Task<List<ReviewDetail>> GetItems()
        {
            using (HttpClient client = _CreateHttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(_apiSuffix).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var reviews = JsonConvert.DeserializeObject<List<ReviewDetail>>(content);

                    return reviews;
                }

                return new List<ReviewDetail>();
            }
        }

        public async Task<HttpStatusCode> Update(int id, Review item)
        {
            using (HttpClient client = _CreateHttpClient())
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(_apiSuffix + id, item).ConfigureAwait(false);
                return response.StatusCode;
            }
        }
    }
}