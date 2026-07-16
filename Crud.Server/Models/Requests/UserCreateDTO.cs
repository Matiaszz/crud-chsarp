namespace Crud.Server.Models.Dtos;

public record UserCreateDTO(string FirstName, string LastName, string Email, string Password)
{

}