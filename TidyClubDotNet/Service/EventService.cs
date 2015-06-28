namespace TidyClubDotNet.Service
{
    using System;
    using System.Collections.Generic;

    using TidyClubDotNet.Authentication;
    using TidyClubDotNet.Misc;
    using TidyClubDotNet.Model;
    using TidyClubDotNet.Service.Interface;
    using TidyClubDotNet.Service.RestService;
    using TidyClubDotNet.Service.RestService.Interface;

    public class EventService : IService<Event>
    {
        private readonly ICreateRestService<Event, Event> createRestService;
        private readonly IListRestService<Event> listRestService;
        private readonly IGetRestService<Event> getRestService;
        private readonly IDeleteRestService<Event> deleteRestService;
        private readonly IUpdateRestService<Event, Event> updateRestService; 

        public EventService(string url, ResponseToken token) 
        {
            this.createRestService = new CreateServiceBase<Event, Event>(url, token, "events");
            this.listRestService = new ListServiceBase<Event>(url, token, "events");
            this.getRestService = new GetServiceBase<Event>(url, token, "events");
            this.deleteRestService = new DeleteServiceBase<Event>(url, token, "events");
            this.updateRestService = new UpdateServiceBase<Event, Event>(url, token, "events");
        }

        public Event Create(Event item)
        {
            CustomContract.Requires<ArgumentNullException>(item != null, "Event is null");
            CustomContract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(item.Name), "Event Name is not set");
            CustomContract.Requires<ArgumentNullException>(item.StartDate != null, "Event start date is null");

            return this.createRestService.Create(item);
        }

        public List<Event> List(int limit = 0, int offset = 0)
        {
            return this.listRestService.List(limit, offset);
        }

        public bool Delete(int id)
        {
            return this.deleteRestService.Delete(id);
        }

        public Event Get(int id)
        {
            return this.getRestService.Get(id);
        }

        public bool Update(Event item)
        {
            CustomContract.Requires<ArgumentNullException>(item != null, "Event is null");
            CustomContract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(item.Name), "Event Name is not set");
            CustomContract.Requires<ArgumentNullException>(item.StartDate != null, "Event start date is null");

            return this.updateRestService.Update(item);
        }
    }
}
