namespace TidyClubDotNet.Model
{
    using System;

    using Newtonsoft.Json;

    public class Task : ModelBase, IConversion<Task, Task.TaskResponse, Task.TaskRequest>
    {
        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public Contact Contact { get; set; }

        public Category Category { get; set; }

        public Task CreateFromResponse(TaskResponse response)
        {
            return new Task
                       {
                           Date = response.Date,
                           DueDate = response.DueDate,
                           Description = response.Description,
                           Title = response.Title,
                           Id = response.Id,
                           CreateAt = response.CreateAt
                       };
        }

        public new TaskRequest CreateRequest()
        {
            return new TaskRequest
                       {
                           Date = this.Date,
                           DueDate = this.DueDate,
                           Description = this.Description,
                           Title = this.Title,
                           Id = this.Id,
                           CreateAt = this.CreateAt,
                           Contact = this.Contact.Id,
                           Category = this.Category.Id
                       };
        }

        public class TaskResponse : ModelBase
        {
            [JsonProperty(PropertyName = "title")]
            public string Title { get; set; }

            [JsonProperty(PropertyName = "date")]
            public DateTime Date { get; set; }

            [JsonProperty(PropertyName = "description")]
            public string Description { get; set; }

            [JsonProperty(PropertyName = "due_date")]
            public DateTime DueDate { get; set; }

            [JsonProperty(PropertyName = "contact_id")]
            public int Contact { get; set; }

            [JsonProperty(PropertyName = "category_id")]
            public int Category { get; set; }
        }

        public class TaskRequest : ModelBase
        {
            [JsonProperty(PropertyName = "title")]
            public string Title { get; set; }

            [JsonProperty(PropertyName = "date")]
            public DateTime Date { get; set; }

            [JsonProperty(PropertyName = "description")]
            public string Description { get; set; }

            [JsonProperty(PropertyName = "due_date")]
            public DateTime DueDate { get; set; }

            [JsonProperty(PropertyName = "contact_id")]
            public int Contact { get; set; }

            [JsonProperty(PropertyName = "category_id")]
            public int Category { get; set; }
        }
    }
}
