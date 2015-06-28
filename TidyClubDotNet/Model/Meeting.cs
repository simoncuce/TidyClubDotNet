namespace TidyClubDotNet.Model
{
    using System;
    using System.Collections.Generic;

    public class Meeting : ModelBase, IConversion<Meeting, Meeting.MeetingRequest, Meeting.MeetingRequest>
    {
        public string Name { get; set; }

        public string Body { get; set; }

        public DateTime Date { get; set; }

        public int Duration { get; set; }

        public string Location { get; set; }

        public List<Topic> Topics { get; set; }

        public Meeting CreateFromResponse(Meeting.MeetingRequest response)
        {
            throw new NotImplementedException();
        }

        public new Meeting.MeetingRequest CreateRequest()
        {
            throw new NotImplementedException();
        }

        public class MeetingRequest : ModelBase
        {
            public string Name { get; set; }

            public string Body { get; set; }

            public DateTime Date { get; set; }

            public int Duration { get; set; }

            public string Location { get; set; }

            public int[] Topics { get; set; }
        }
    }
}
