namespace TidyClubDotNet.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    using Newtonsoft.Json;

    using RestSharp;

    using TidyClubDotNet.Authentication;
    using TidyClubDotNet.Misc;
    using TidyClubDotNet.Model;
    using TidyClubDotNet.Service.Interface;
    using TidyClubDotNet.Service.RestService;

    public class TicketService : ServiceBase<Ticket.TicketResponse>
    {
        public TicketService(string url, ResponseToken token)
            : base(url, token, "events")
        {
        }

        public List<Ticket> List(Event eventName, bool sold = false)
        {
            string url = sold
                             ? this.Endpoint + "/" + eventName.Id + "/tickets"
                             : this.Endpoint + "/" + eventName.Id + "/tickets/sold";

            var request = this.GetRequest(url, Method.GET);

            var response = this.Client.Execute(request);

            var keyResponse = JsonConvert.DeserializeObject<List<Ticket.TicketResponse>>(response.Content);

            return this.ProcessResult(keyResponse, HttpStatusCode.OK).Select(ticket => new Ticket().CreateFromResponse(ticket)).ToList();
        }

        public Ticket Get(Event item, int id)
        {
            CustomContract.Requires<ArgumentNullException>(id > 0, "Id is 0 or less");

            var request = this.GetRequest(this.Endpoint + "/" + item.Id + "/tickets/" + id, Method.GET);

            var response = this.Client.Execute(request);

            var keyResponse = JsonConvert.DeserializeObject<Ticket.TicketResponse>(response.Content);

            this.ProcessResult(response, HttpStatusCode.OK);

            return new Ticket().CreateFromResponse(keyResponse);
        }

        public Ticket Create(Event item)
        {
            CustomContract.Requires<ArgumentNullException>(item != null, "Event is null");
            CustomContract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(item.Name), "Name is not set");

            var request = this.GetRequest(this.Endpoint + "/" + item.Id + "/tickets", Method.POST);

            request.AddBody(item);

            var response = this.Client.Execute(request);

            var keyResponse = JsonConvert.DeserializeObject<Ticket.TicketResponse>(response.Content);

            this.ProcessResult(response, HttpStatusCode.Created);

            return new Ticket().CreateFromResponse(keyResponse);
        }

        public bool Update(Event item, Ticket ticket)
        {
            CustomContract.Requires<ArgumentNullException>(item != null, "Item is null");
            CustomContract.Requires<ArgumentNullException>(ticket != null, "Item is null");

            CustomContract.Requires<ArgumentNullException>(item.Id > 0, "Id is 0 or less");
            CustomContract.Requires<ArgumentNullException>(ticket.Id > 0, "Id is 0 or less");

            var request = this.GetRequest(this.Endpoint + "/" + item.Id + "/tickets/" + ticket.Id, Method.PUT);

            request.AddBody(ticket);

            var response = this.Client.Execute(request);

            return this.ProcessResult(response, HttpStatusCode.OK);
        }

        public bool Delete(Event item, int id)
        {
            CustomContract.Requires<ArgumentNullException>(id > 0, "Id is 0 or less");
            CustomContract.Requires<ArgumentNullException>(item != null, "Item is null");

            var request = this.GetRequest(this.Endpoint + "/" + item.Id + "/tickets/" + id, Method.DELETE);

            var response = this.Client.Execute(request);

            this.ProcessResult(response, HttpStatusCode.OK);

            return true;
        }
    }
}
