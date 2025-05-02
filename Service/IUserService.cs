public interface IUserService
{
    Task<string> Authenticate(LoginDto loginDto);

}