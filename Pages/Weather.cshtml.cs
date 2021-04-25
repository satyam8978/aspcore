using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using AspCorePractie.Model;
using System.Net.Http.Headers;
using System.Text.Json;
namespace AspCorePractie.Pages
{
    public class WeatherModel : PageModel
    {
        private readonly IHttpClientFactory _ClientFactory;
        IEnumerable<WeatherClass> weathers;
        public WeatherModel(IHttpClientFactory clientFactory)
        {

            _ClientFactory = clientFactory;
        }
        [BindProperty]
    
        public IList<WeatherClass> WeatherClass { get; set; }
        public async Task  OnGet()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44347/weatherforecast");
            var client = _ClientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                weathers = await JsonSerializer.DeserializeAsync
                    <IEnumerable<WeatherClass>>(responseStream);

                WeatherClass = weathers.ToList();
            }
          
        }

   
    }
}
