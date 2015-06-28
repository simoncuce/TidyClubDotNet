namespace TidyClubDotNet.Service.Base
{
    using TidyClubDotNet.Model;

    public class AllServiceBase<TRequest, TResponse> : ServiceBase<TResponse>
        where TResponse : ModelBase, new()
        where TRequest : ModelBase, new()
    {
        protected readonly IListService<TResponse> ListService;

        protected readonly IDeleteService DeleteService;

        protected readonly IGetService<TResponse> GetService;

        protected readonly ICreateService<TRequest, TResponse> CreateService;

        protected readonly IUpdateService<TRequest> UpdateService;


        public AllServiceBase(string url, ResponseToken token, string endpoint) : base(url, token, endpoint)
        {
            this.ListService = new ListServiceBase<TResponse>(url, token, endpoint);
            this.DeleteService = new DeleteServiceBase<TResponse>(url, token, endpoint);
            this.GetService = new GetServiceBase<TResponse>(url, token, endpoint);
            this.CreateService = new CreateServiceBase<TRequest, TResponse>(url, token, endpoint);
            this.UpdateService = new UpdateServiceBase<TRequest, TResponse>(url, token, endpoint);
        }
    }
}
