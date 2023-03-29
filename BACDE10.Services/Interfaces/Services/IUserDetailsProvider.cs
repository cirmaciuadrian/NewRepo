namespace BACDE10.BusinessLogic.Interfaces.Services;

public interface IUserDetailsProvider
{
    Guid GetUserId();

    void SetUserId(Guid userId);
}
