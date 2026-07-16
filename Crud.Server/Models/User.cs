
using System.ComponentModel.DataAnnotations.Schema;
using Crud.Server.Models.Dtos.Responses;

namespace Crud.Server.Models;

public class User(string firstName, string lastName, string email, string password)
{
    public Guid Id { get; set; }
    public string FirstName { get; private set; } = firstName;
    public string LastName { get; private set; } = lastName;

    public string Email { get; private set; } = email;

    public string Password { get; private set; } = password;

    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";

    public UserResponseDTO ToResponse()
    {
        return new UserResponseDTO(this);
    }

}