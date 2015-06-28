namespace TidyClubDotNet.Model
{
    using System;

    public class Topic
    {
        public Contact Owner { get; set; }

        public string Title { get; set; }

        public DateTime? Date { get; set; }

        public string Category { get; set; }

        public Task Task { get; set; }
    }
}
