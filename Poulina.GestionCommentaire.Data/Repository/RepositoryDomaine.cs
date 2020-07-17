using Poulina.GestionCommentaire.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Poulina.GestionCommentaire.Data.Repository
{
    public class RepositoryDomaine
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public RepositoryDomaine(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<IEnumerable<Domaine>> GetDomaine()
        {
            var httpClient = _httpClientFactory.CreateClient("MS");
            var response = await httpClient.GetAsync($"Domaine");
            string responseStream = response.Content.ReadAsStringAsync().Result;

            try
            {
                var users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Domaine>>(responseStream);

                return await Task<List<Domaine>>.FromResult(users);
            }
            catch (Exception )
            {
                return null;
            }
        }

        public async Task<IEnumerable<Ms>> GetMs()
        {
            var httpClient = _httpClientFactory.CreateClient("MS");
            var response = await httpClient.GetAsync($"MS");
            string responseStream = response.Content.ReadAsStringAsync().Result;

            try
            {
                var users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Ms>>(responseStream);

                return await Task<List<Ms>>.FromResult(users);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
