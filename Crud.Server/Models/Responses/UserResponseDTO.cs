namespace Crud.Server.Models.Dtos.Responses;

public record UserResponseDTO(string FirstName, string LastName, string Email)
{
    public UserResponseDTO(User user)
        : this(user.FirstName, user.LastName, user.Email)
    {
    }
}