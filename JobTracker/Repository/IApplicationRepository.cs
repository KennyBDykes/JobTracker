public interface IApplicationRepository
{
    Task CreateApplication(Application app);
    Task UpdateApplication(Application app);
    Task<IEnumerable<Application>> GetApplicationsByStatus(string status);
    Task<IEnumerable<Application>> GetApplicationsByUserId(Guid userId);
    Task<Application> GetApplicationByAppIdAndUserId(Guid id, Guid userId);
    Task<Application> GetApplicationById(Guid id);
    Task DeleteApplication(Application application);


}