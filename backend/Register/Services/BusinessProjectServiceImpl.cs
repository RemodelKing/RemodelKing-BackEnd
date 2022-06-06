using backend.Register.Domain.Models;
using backend.Register.Domain.Repositories;
using backend.Register.Domain.Services;
using backend.Register.Domain.Services.Communication;

namespace backend.Register.Services;

public class BusinessProjectServiceImpl: IBusinessProjectService
{
    private readonly IBusinessProjectRepository _businessProjectRepository;
    private readonly IUnitOfWork _unitOfWork;

    public BusinessProjectServiceImpl(IBusinessProjectRepository businessProjectRepository, IUnitOfWork unitOfWork)
    {
        _businessProjectRepository = businessProjectRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<BusinessProject>> ListAsync()
    {
        return await _businessProjectRepository.ListAsync();
    }

    public async Task<BusinessProjectResponse> CreateAsync(BusinessProject businessProject)
    {
        try {
            await _businessProjectRepository.AddAsync(businessProject);
            await _unitOfWork.CompleteAsync();
            
            return new BusinessProjectResponse(businessProject);
        }
        catch (Exception e) {
            return new BusinessProjectResponse($"An error occurred while saving the category: {e.Message}");
        }
    }

    public Task<BusinessProjectResponse> DeleteAsync(int businessId)
    {
        throw new NotImplementedException();
    }
}