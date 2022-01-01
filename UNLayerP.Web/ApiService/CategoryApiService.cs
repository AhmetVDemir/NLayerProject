using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UNLayerP.Web.DTOs;

namespace UNLayerP.Web.ApiService
{
    public class CategoryApiService
    {

        private readonly HttpClient _httpClient;

        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {

            IEnumerable<CategoryDto> categoryDtos;
            var response = await _httpClient.GetAsync(_httpClient.BaseAddress + "categories");
            if (response.IsSuccessStatusCode)
            {
                categoryDtos = JsonConvert.DeserializeObject<IEnumerable<CategoryDto>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                categoryDtos = null;
            }
            return categoryDtos;

        }



        public async Task<CategoryDto> AddAsync(CategoryDto categoryDto)
        {
            var strCont = new StringContent(JsonConvert.SerializeObject(categoryDto),Encoding.UTF8,"application/json");
            var res = await _httpClient.PostAsync(_httpClient.BaseAddress + "categories", strCont);

            if (res.IsSuccessStatusCode)
            {
                categoryDto = JsonConvert.DeserializeObject<CategoryDto>(await res.Content.ReadAsStringAsync());
                return categoryDto;
            }
            else { return null; }
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var res = await _httpClient.GetAsync($"categories/{id}");
            if (res.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<CategoryDto>(await res.Content.ReadAsStringAsync());
            }
            else { return null; }
        }

        public async Task<bool> Update(CategoryDto categoryDto)
        {
            var strContetn = new StringContent(JsonConvert.SerializeObject(categoryDto), Encoding.UTF8,"application/json");
            var res = await _httpClient.PutAsync("categories", strContetn);
            if (res.IsSuccessStatusCode)
            {
                return true;
            }
            else { return false; }
        }

        public async Task<bool> Remmove(int id)
        {
            var res = await _httpClient.DeleteAsync($"categories/{id}");
            if (res.IsSuccessStatusCode)
            {
                return true;
            }
            else { return false; }
        }

    }
}
