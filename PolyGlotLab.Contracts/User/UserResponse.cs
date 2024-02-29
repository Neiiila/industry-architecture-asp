namespace PolyGlotLab.Contracts.User ;
public record UserResponse
(
    Guid id ,
    string firstName ,
    string lastName ,
    string email ,
    string password ,
    DateTime dateOfBirth ,
    DateTime createdDate, 
    List<DateTime> updatedDates 
);