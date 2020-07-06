using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Poulina.GestionCommentaire.Domain.Models;


namespace Poulina.GestionCommentaire.Data.Repository
{
    public class RepositoryUser
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public RepositoryUser(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            var httpClient = _httpClientFactory.CreateClient("User");
            var response = await httpClient.GetAsync($"Users");
            string responseStream = response.Content.ReadAsStringAsync().Result;

            try
            {
                var users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(responseStream);

                return await Task<List<User>>.FromResult(users);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}



