using Application.Interfaces;

namespace Api
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService() //(IHttpContextAccessor httpContextAccessor)
        {
            UserId = "TODO:CHANGE"; //httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            IsAuthenticated = UserId != null;
        }

        public string UserId { get; }

        public bool IsAuthenticated { get; }
    }
}
