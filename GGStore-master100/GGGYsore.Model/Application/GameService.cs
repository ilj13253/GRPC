using GGGYsore.Model.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GGGYsore.Model.Application
{
     public class GameService
    {
        private readonly HttpClient httpClient  = new();
        private readonly string urlGGGYsotreWebApi=string.Empty;
        private const string nameFileConfiguration= "appsettings.json";
        //private readonly StringContent requestContent = new (gameJson, Encoding.UTF8, mediaType:"application/json");
        public GameService() {
            var ServicesSection = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile(nameFileConfiguration).Build().GetSection("Services");
            //var section = ServicesSection.GetSection("Services");
           // var response = await httpClient.GetAsync(section["GGGYsotreapi"]);
           //if (ServicesSection["GGGYsotreapi"] is not null) {
                urlGGGYsotreWebApi = ServicesSection["GGGYsotreapi"]??throw new Exception();
            //}
        }
        public async Task<List<GameModel>> GetGamesAsync()
        {
            // var httpClient = new HttpClient();
            //var section = config.GetSection("Services");
            //var weatherClientConfig = section.GetSection("GGGYsotreapi").ToString();
            //config.https://localhost:7292/Game
            //var response = await httpClient.GetAsync(section["GGGYsotreapi"]);
            var response = await httpClient.GetAsync(urlGGGYsotreWebApi);
            string content = await response.Content.ReadAsStringAsync();
            var gamesModel = JsonSerializer.Deserialize<List<GameModel>>(content)??throw new Exception();
            /*
            if (gamesModel is not null)
            {
                foreach (var gameModel in gamesModel)
                {
                    Console.WriteLine(gameModel);
                }
            }
            */
            return gamesModel;
        }

       public async Task DeleteGameByIdAsync(int id)=>
        
             await httpClient.DeleteAsync($"{urlGGGYsotreWebApi}/{id}");
        

       public async Task PostGameAsync(GameModel gameModel)
        {
            /*
            var gameDto = new GameDto
            {
                Title = "Batman",
                Description = "Джокер опять сбежал",
                IdGenres = [1, 2],
                Publisher = "Sony",
                DateRelease = new DateOnly(2009, 10, 10)
            };
            */
            var gameJson = JsonSerializer.Serialize(gameModel);
            var requestContent = new StringContent(gameJson, Encoding.UTF8, mediaType:"application/json");
            var response = await httpClient.PostAsync(urlGGGYsotreWebApi, requestContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
        }

       public async Task PutGameByIdAsync(GameModel gameModel)
        {
            /*
            var gameDto = new GameDto
            {
                Title = "Batman",
                Description = "Джокер опять сбежал",
                IdGenres = [1, 2],
                Publisher = "Sony",
                DateRelease = new DateOnly(2009, 10, 10)
            };
            */
            var gameJson = JsonSerializer.Serialize(gameModel);
            var requestContent = new StringContent(gameJson, Encoding.UTF8, "application/json");
            var response = await  httpClient.PutAsync($"{urlGGGYsotreWebApi}{gameModel.Id}", requestContent);
            response.EnsureSuccessStatusCode();
           // var content = await response.Content.ReadAsStringAsync();
        }

      public  async Task GetGameByIdAsync(int id)
        {
            var response = await httpClient.GetAsync($"{urlGGGYsotreWebApi}{id}");
            string content = await response.Content.ReadAsStringAsync();
            var gameModel = JsonSerializer.Deserialize<GameModel>(content);
            Console.WriteLine(gameModel);
        }
    }
}
