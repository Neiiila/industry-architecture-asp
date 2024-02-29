using ErrorOr ; 
namespace PolyGlotLab.ServiceErrors
{
    public static class Errors
    {
        public static class User
        {
            public static Error NotFound => Error.NotFound(
                 code: "user_not_found",
                 description: "The user was not found."
            );

            public static Error InvalidName => Error.Validation(
                 code: "user_invalid_name",
                 description: $"The name must be at least {Models.User.MinNameLength} characters long and at most { Models.User.MaxNameLength }."
            );
            public static Error InvalidPassword => Error.Validation(
                 code: "user_invalid_password",
                 description: $"The password must be at least {Models.User.MinPasswordLength} characters long and at most { Models.User.MaxPasswordLength }."
            );

            public static Error InvalidEmail => Error.Validation(
                 code: "user_invalid_email",
                 description: $"The email must be at least {Models.User.MinEmailLength} characters long and at most { Models.User.MaxEmailLength }."
            );
        }
    }
}
