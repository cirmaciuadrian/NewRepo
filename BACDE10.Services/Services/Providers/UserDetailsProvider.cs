using BACDE10.BusinessLogic.Interfaces.Services;

namespace BACDE10.BusinessLogic.Services.Providers;

public class UserDetailsProvider : IUserDetailsProvider
{
    private Guid UserId { get; set; }
    
    public Guid GetUserId()
    {
        return UserId;
    }

    public void SetUserId(Guid userId)
    {
        UserId = userId;
    }
}
