using Newtonsoft.Json;

namespace VaporStore.DataProcessor.Dtos.Export
{
    internal class ExportGenreDto
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Genre")]
        public string Genre { get; set; }

        [JsonProperty("Games")]
        public ExportGameDto[] Games { get; set; }

        [JsonProperty("TotalPlayers")]
        public int TotalPlayersCount { get; set; }
    }
}