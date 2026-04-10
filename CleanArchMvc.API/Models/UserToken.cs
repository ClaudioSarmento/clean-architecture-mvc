namespace CleanArchMvc.API.Models;

public class UserToken
{
    public string Token { get; set; } = default!;
    public DateTime Expiration { get; set; } = default!;
}   
