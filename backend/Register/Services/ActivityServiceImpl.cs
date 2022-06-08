using backend.Register.Domain.Models;
using backend.Register.Domain.Repositories;
using backend.Register.Domain.Services;
using backend.Register.Domain.Services.Communication;

namespace backend.Register.Services;

public class ActivityServiceImpl: IActivityService
{
    private readonly IActivityRepository _activityRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ActivityServiceImpl(IActivityRepository activityRepository, IUnitOfWork unitOfWork)
    {
        _activityRepository = activityRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Activity>> ListAsync()
    {
        return await _activityRepository.ListAsync();
    }

    public async Task<ActivityResponse> CreateAsync(Activity activity)
    {
        try
        {
            //Actions
            await _activityRepository.AddAsync(activity);
            await _unitOfWork.CompleteAsync();
            return new ActivityResponse(activity);
        }
        catch (Exception e)
        {
            return new ActivityResponse($"Failed to register a activity: {e.Message}");
        }
    }
    
}