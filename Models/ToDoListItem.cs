namespace ToDoList.Api.Models
{
    public class ToDoListItem
    {
        public ToDoListItem(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }

        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

