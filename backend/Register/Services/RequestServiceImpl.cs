using backend.Register.Domain.Models;
using backend.Register.Domain.Repositories;
using backend.Register.Domain.Services;
using backend.Register.Domain.Services.Communication;

namespace backend.Register.Services;

public class RequestServiceImpl: IRequestService
{
    private readonly IRequestRepository _requestRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RequestServiceImpl(IRequestRepository requestRepository, IUnitOfWork unitOfWork)
    {
        _requestRepository = requestRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Request>> ListAsync()
    {
        return await _requestRepository.ListAsync();
    }

    public async Task<RequestResponse> CreateAsync(Request request)
    {
        try
        {
            await _requestRepository.AddAsync(request);
            await _unitOfWork.CompleteAsync();

            return new RequestResponse(request);
        }
        catch (Exception e)
        {
            return new RequestResponse($"An error occurred while saving the category: {e.Message}");
        }
    }
}