using Microsoft.AspNetCore.Mvc;
using PolyGlotLab.Contracts.User;
using PolyGlotLab.Models;
using PolyGlotLab.Services.User;
using ErrorOr ;     

namespace PolyGlotLab.Controllers
{
    
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("")]
        public IActionResult CreateUser( [FromBody] CreateUserRequest request)
        {
            // map the request to a user model
            ErrorOr<User> requestToUser = Models.User.From(request);

            if( requestToUser.IsError )
            {
                return Problem(requestToUser.Errors);
            }
            var user = requestToUser.Value;
            // call the service to add the user in the database
            ErrorOr<Created> createdUserResult = _userService.CreateUser(user);
            // // map the user to a response that will be returned
            // UserResponse response = new UserResponse(user.Id, user.FirstName, user.LastName, user.Email, user.Password , user.DateOfBirth, user.CreatedDate, user.UpdatedDates);
            return createdUserResult.Match(
                created => CreatedUser(user),
                errors => Problem(errors)
            );
        }

        

        [HttpGet("{id:guid}")]
        public IActionResult GetUser(Guid  id)
        {
            ErrorOr<User> getUserResult = _userService.GetUser(id);
            
            return getUserResult.Match(
                user => Ok(MapUserResponse(user)),
                errors => Problem(errors)); 

            // if (getUserResult.IsError)
            // {
            //     return NotFound();
            // }
            // var user = getUserResult.Value;

            // UserResponse response = MapUserResponse(user);
            
            // return Ok(response);
        }

       
        [HttpPut("{id:guid}")]
        public IActionResult UpsertUser(Guid  id, UpsertUserRequest request)
        {
            ErrorOr<User> requestToUser =  Models.User.From(request, id);
            if( requestToUser.IsError )
            {
                return Problem(requestToUser.Errors);
            }
            var user = requestToUser.Value;
            ErrorOr<UpsertedUser> upserteUserResult = _userService.UpsertUser(user);
            return upserteUserResult.Match(
                upserted => upserted.isNewlyCreated ? CreatedUser(user) : NoContent(),
                errors => Problem(errors)
            );
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteUser(Guid  id)
        {
            ErrorOr<Deleted> deleteUserResult = _userService.DeleteUser(id);

            return deleteUserResult.Match(
                deleted => NoContent(),
                errors => Problem(errors)
            );
            
        }

         private static UserResponse MapUserResponse(User user)
        {
            return new UserResponse(user.Id,
                                                    user.FirstName,
                                                    user.LastName,
                                                    user.Email,
                                                    user.Password,
                                                    user.DateOfBirth,
                                                    user.CreatedDate,
                                                    user.UpdatedDates);
        }

        private CreatedAtActionResult CreatedUser(User user)
        {
            return CreatedAtAction(
                actionName: nameof(GetUser),
                routeValues: new { id = user.Id },
                value: MapUserResponse(user)
            );
        }

    }
}