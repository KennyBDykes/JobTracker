
public class ApplicationService : IApplicationService
{
    private IApplicationRepository _repository;
    public ApplicationService(IApplicationRepository repository)
    {
        _repository = repository;
    }
    public async Task CreateApp(CreateApplicationDto dto, Guid userId)
    {
        var entity = new Application
        {
             AppliedDate = DateTime.Now.ToUniversalTime(),
             Position = dto.Position,
             Status = "Applied",
             Company = dto.Company,
             Notes = dto.Notes,
             UserId = userId,
        };
        await _repository.CreateApplication(entity);
    }

    public async Task DeleteApp(Guid id)
    {
       var existing = await _repository.GetApplicationById(id);
        
        if (existing == null)
        {
           throw new ArgumentException("Application not found");
        }
        await _repository.DeleteApplication(existing);
    }

    public async Task DeleteAppByUser(Guid id, Guid userId)
    {
        var existing = await _repository.GetApplicationByAppIdAndUserId(id, userId);
        
        if (existing == null)
        {
           throw new ArgumentException("Application for not found");
        }
        await _repository.DeleteApplication(existing);
    }

    public async Task<IEnumerable<GetApplicationDto>> GetApplicationsByStatus(ApplicationStatus status)
    {
        var mapper = StatusMapper(status);
        var apps = await _repository.GetApplicationsByStatus(mapper);
        return MapToDtoList(apps);
    }

    public async Task<IEnumerable<GetApplicationDto>> GetApplicationsByUserId(Guid userId)
    {
        var userApps =  await _repository.GetApplicationsByUserId(userId);
        return MapToDtoList(userApps);
    }

    public async Task UpdateApp(Guid id, UpdateApplicationDto dto)
    {
        var existing = await _repository.GetApplicationById(id);
        
        if (existing == null)
        {
           throw new ArgumentException("Application not found");
        }
        var mapper = StatusMapper(dto.Status);
        if(!String.IsNullOrEmpty(mapper)) existing.Status = mapper;
        if(!String.IsNullOrEmpty(dto.Company)) existing.Company = dto.Company;
        if(!String.IsNullOrEmpty(dto.Position)) existing.Position = dto.Position;
        if(!String.IsNullOrEmpty(dto.Notes)) existing.Notes = dto.Notes;
      
        await _repository.UpdateApplication(existing);
    }
    private IEnumerable<GetApplicationDto> MapToDtoList(IEnumerable<Application> app)
    {
         List<GetApplicationDto> result = new List<GetApplicationDto>();
         
         foreach( var appItem in app)
         {
          result.Add(new GetApplicationDto
          {
            Id = appItem.Id,
            Position = appItem.Position,
            Notes = appItem.Notes,
            Company = appItem.Company
          });
         }

         return result;
    }
    private string? StatusMapper(ApplicationStatus status)
    {
        switch(status)
        {
            case ApplicationStatus.Applied:
            return "Applied";

            case ApplicationStatus.Interviewing:
             return "Interviewing";

            case ApplicationStatus.Offer:
             return "Offer";

            case ApplicationStatus.Rejected:
             return "Rejected";
            
            default:
             return null;
        }
    }
    private string? StatusMapper(FinalStatus? status)
    {
        switch(status)
        {
            case FinalStatus.Interviewing:
             return "Interviewing";

            case FinalStatus.Offer:
             return "Offer";

            case FinalStatus.Rejected:
             return "Rejected";
            
            default:
             return null;
        }
    }
    
}