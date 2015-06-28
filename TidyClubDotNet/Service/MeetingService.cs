namespace TidyClubDotNet.Service
{
    using System.Collections.Generic;

    using TidyClubDotNet.Authentication;
    using TidyClubDotNet.Model;
    using TidyClubDotNet.Service.RestService;
    using TidyClubDotNet.Service.RestService.Interface;

    public class MeetingService : Interface.IList<Meeting>
    {
        private readonly IListRestService<Meeting> listService; 

        public MeetingService(string url, ResponseToken token) 
        {
            this.listService = new ListServiceBase<Meeting>(url, token, "meetings");
        }

        public List<Meeting> List(int limit = 0, int offset = 0)
        {
            return this.listService.List(limit, offset);
        }
    }
}
