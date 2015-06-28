namespace TidyClubDotNet.Service
{
    using System;

    using TidyClubDotNet.Authentication;
    using TidyClubDotNet.Misc;
    using TidyClubDotNet.Model;
    using TidyClubDotNet.Service.Interface;
    using TidyClubDotNet.Service.RestService;
    using TidyClubDotNet.Service.RestService.Interface;

    public class UserService : ICreate<User>
    {
        private readonly ICreateRestService<User.UserRequest, User.UserResponse> createRestService;

        public UserService(string url, ResponseToken token)
        {
            this.createRestService = new CreateServiceBase<User.UserRequest, User.UserResponse>(url, token, "users");
        }

        public User Create(User item)
        {
            CustomContract.Requires<ArgumentNullException>(item != null, "User is null");
            CustomContract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(item.FirstName), "First name is not set");
            CustomContract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(item.LastName), "Last name is not set");
            CustomContract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(item.Email), "Email is not set");
            CustomContract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(item.Password), "Password is not set");

            var response = this.createRestService.Create(item.CreateRequest());

            return new User().CreateFromResponse(response);
        }
    }
}
