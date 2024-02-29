using ErrorOr ; 
using PolyGlotLab.ServiceErrors;
namespace PolyGlotLab.Services.User
{
    using PolyGlotLab.Models;
    using System;

    public class UserService : IUserService
    {
        private static readonly Dictionary<Guid , User>  _userRepository = new() ;
        public ErrorOr<Created>  CreateUser(Models.User user){

            
            _userRepository.Add(user.Id, user);
            return Result.Created;
        }
        
        public ErrorOr<User> GetUser(Guid id){
            if( _userRepository.TryGetValue(id, out var user)){
                return user;
            }

            return Errors.User.NotFound;
        }

        public ErrorOr<UpsertedUser>  UpsertUser(User user){
            var isNewlyCreated = !_userRepository.ContainsKey(user.Id);
            _userRepository[user.Id] = user;
            _userRepository[user.Id].UpdatedDates.Add(DateTime.Now);
            return new UpsertedUser(isNewlyCreated);
        }

        public ErrorOr<Deleted>  DeleteUser(Guid id){
            _userRepository.Remove(id);
            return Result.Deleted;  
        }
    }
}