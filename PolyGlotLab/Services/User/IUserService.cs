using ErrorOr ; 

namespace PolyGlotLab.Services.User
{
    public interface IUserService
    {
        ErrorOr<Created> CreateUser( Models.User user);
        ErrorOr<Deleted> DeleteUser(Guid id);
        ErrorOr<Models.User> GetUser(Guid id); // it returns an ErrorOr type, which is a custom type that can hold either an error or a user
 
        ErrorOr<UpsertedUser> UpsertUser( Models.User user);

    }
}
