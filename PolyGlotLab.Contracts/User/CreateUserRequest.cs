namespace PolyGlotLab.Contracts.User ;
public record CreateUserRequest
(
    string firstName ,
    string lastName ,
    string email ,
    string password ,
    DateTime dateOfBirth 
);


