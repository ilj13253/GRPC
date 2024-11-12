using System.Text.Json.Serialization;

namespace GGGYsore.Model.Domain
{
   public class GameModel
    {
        [JsonPropertyName("id")]
        public required int Id { get; set; }

        [JsonPropertyName("title")]
        public required string Title { get; set; }

        [JsonPropertyName("description")]
        public required string Description { get; set; }

        [JsonPropertyName("publisher")]
        public required string Publisher { get; set; }
        /*
        [JsonPropertyName("IdGenres")]
        public required List<int>IdGenres { get; set; }
        */
        [JsonPropertyName("dateRelease")]
        public required DateOnly DateRelease { get; set; }
        /*
        public override string ToString() =>
            $"Id: {Id}, Title: {Title}, Description: {Description}, Publisher: {Publisher}, DateRelease: {DateRelease.ToString("D")}";
        */
    }
}
