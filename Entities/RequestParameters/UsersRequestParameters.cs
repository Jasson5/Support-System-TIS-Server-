using Microsoft.AspNetCore.Mvc;

namespace Entities.RequestParameters
{
    [BindProperties]
    public class UsersRequestParameters
    {
        [BindProperty]
        public string Search { get; set; }
        public string Code { get; set; }
    }
}
