
using ErrorOr;
using PolyGlotLab.Contracts.User;
using PolyGlotLab.ServiceErrors;

namespace PolyGlotLab.Models
{
    public class User
    {
        public const int MinNameLength = 2;
        public const int MaxNameLength = 50;
        public const int MinPasswordLength = 8;
        public const int MaxPasswordLength = 50;
        public const int MinEmailLength = 5;
        public const int MaxEmailLength = 50;

        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Password { get; }
        public DateTime DateOfBirth { get; }
        public DateTime CreatedDate { get; }
    

        public List<DateTime> UpdatedDates { get ; set ; }

        private User(Guid id, string firstName, string lastName, string email, string password, DateTime dateOfBirth, DateTime createdDate)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            DateOfBirth = dateOfBirth;
            CreatedDate = createdDate;
            UpdatedDates = new List<DateTime>();
        }

        public static ErrorOr<User> Create(string firstName, 
                                            string lastName, 
                                            string email, 
                                            string password, 
                                            DateTime dateOfBirth,
                                            Guid? id = null)
        {
            List<Error> errors = new();
           if ( firstName.Length is < MinNameLength or > MaxNameLength || 
                lastName.Length is < MinNameLength or > MaxNameLength)
              {
                errors.Add(Errors.User.InvalidName) ;
              }

            if ( password.Length is < MinPasswordLength or > MaxPasswordLength)
              {
                errors.Add(Errors.User.InvalidPassword);
              }

            if ( email.Length is < MinEmailLength or > MaxEmailLength)
              {
                errors.Add(Errors.User.InvalidEmail);
              }
            
            if( errors.Count > 0)
            {
                return errors;
            }

            return new User(id ?? Guid.NewGuid(), firstName, lastName, email, password, dateOfBirth, DateTime.Now);
        }

        public static ErrorOr<User> From(CreateUserRequest request)
        {
            return Create(request.firstName, 
                          request.lastName, 
                          request.email, 
                          request.password, 
                          request.dateOfBirth);
        }

        public static ErrorOr<User> From(UpsertUserRequest request, Guid id)
        {
            return Create(request.firstName, 
                          request.lastName, 
                          request.email, 
                          request.password, 
                          request.dateOfBirth,
                          id);
        }
    }
}