using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BusinessAndDataProject.Models
{
    public class Note
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("completed")]
        public bool Completed;

    }
}
