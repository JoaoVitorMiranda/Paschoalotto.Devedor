﻿using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Paschoalotto.Devedor.Domain.Interfaces.Services;
using Paschoalotto.Devedor.Domain.Models.Services;

namespace Paschoalotto.Devedor.Infra.Services
{
    public class ViaCEPService : IViaCEPService
    {
        private readonly HttpClient _httpClient;

        public ViaCEPService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ViaCEP> GetByCEPAsync(string cep)
        {
            ViaCEP result = null;

            HttpResponseMessage response = await _httpClient.GetAsync($"{cep}/json", HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            try
            {
                if (response.Content is object)
                {
                    var stream = await response.Content.ReadAsStreamAsync();
                    result = await JsonSerializer.DeserializeAsync<ViaCEP>(stream);
                }
            }
            finally
            {
                response.Dispose();
            }

            return result;
        }
    }
}
