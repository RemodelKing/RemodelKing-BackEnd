using backend.Register.Domain.Models;
using backend.Register.Domain.Repositories;
using backend.Register.Domain.Services;
using backend.Register.Domain.Services.Communication;

namespace backend.Register.Services;

public class PortfolioServiceImpl: IPortfolioService
{
    private readonly IPortfolioRepository _portfolioRepository;
    private readonly IUnitOfWork _unitOfWork;


    public PortfolioServiceImpl(IPortfolioRepository portfolioRepository, IUnitOfWork unitOfWork)
    {
        _portfolioRepository = portfolioRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Portfolio>> ListAsync()
    {
        return await _portfolioRepository.ListAsync();
    }

    public async Task<PortfolioResponse> CreateAsync(Portfolio portfolio)
    {
        try
        {
            //Actions
            await _portfolioRepository.AddAsync(portfolio);
            await _unitOfWork.CompleteAsync();
            return new PortfolioResponse(portfolio);
        }
        catch (Exception e)
        {
            return new PortfolioResponse($"Failed to register a portfolio: {e.Message}");
        }
    }
}