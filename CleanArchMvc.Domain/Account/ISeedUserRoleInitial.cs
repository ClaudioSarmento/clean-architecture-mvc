namespace CleanArchMvc.Domain.Account;

public interface ISeedUserRoleInitial
{
    Task SeedUsersAsync();
    Task SeedRolesAsync();
}
