namespace PolyGlotLab.Contracts.User ;
public record UpsertUserRequest
(
    string firstName ,
    string lastName ,
    string email ,
    string password ,
    DateTime dateOfBirth ,
    DateTime createdDate
);
    
