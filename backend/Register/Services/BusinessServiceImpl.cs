using backend.Register.Domain.Models;
using backend.Register.Domain.Repositories;
using backend.Register.Domain.Services;
using backend.Register.Domain.Services.Communication;

namespace backend.Register.Services;

public class BusinessServiceImpl: IBusinessService
{
    private readonly IBusinessRepository _businessRepository;
    private readonly IUnitOfWork _unitOfWork;


    public BusinessServiceImpl(IBusinessRepository businessRepository, IUnitOfWork unitOfWork)
    {
        _businessRepository = businessRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Business>> ListAsync()
    {
        return await _businessRepository.ListAsync();
    }

    public async Task<BusinessResponse> CreateAsync(Business business)
    {
        try
        {
            //Validations
            if (business.Password != business.ConfirmPassword)
                return new BusinessResponse("Different passwords was received"); 
            //Actions
            await _businessRepository.AddAsync(business);
            await _unitOfWork.CompleteAsync();
            return new BusinessResponse(business);
        }
        catch (Exception e)
        {
            return new BusinessResponse($"Failed to register a business: {e.Message}");
        }
    }
}