using MTS_Diplom.Models.Enums;

namespace MTS_Diplom.Models;

public class User
{
    public UserType UserType { get; set; }
    public string Username { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}