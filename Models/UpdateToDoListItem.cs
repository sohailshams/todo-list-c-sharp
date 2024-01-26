using System.Text.Json.Serialization;

namespace ToDoList.Api.Models
{
    public class UpdateToDoListItem
    {
        public UpdateToDoListItem(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }

        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

}
