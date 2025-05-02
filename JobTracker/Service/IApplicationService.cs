public interface IApplicationService
{
    Task CreateApp(CreateApplicationDto dto, Guid userId);
    Task UpdateApp(Guid id, UpdateApplicationDto dto);
    Task DeleteApp(Guid id);
    Task DeleteAppByUser(Guid id, Guid userId);
    Task<IEnumerable<GetApplicationDto>> GetApplicationsByUserId(Guid userId);
    Task<IEnumerable<GetApplicationDto>> GetApplicationsByStatus(ApplicationStatus status);
}