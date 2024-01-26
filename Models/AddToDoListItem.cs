using System.Text.Json.Serialization;

namespace ToDoList.Api.Models
{
    public class AddToDoListItem
    {
        public AddToDoListItem(string title, string description)
        {
            Title = title;
            Description = description;
        }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

}
