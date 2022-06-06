using backend.Register.Domain.Models;
using backend.Register.Domain.Repositories;
using backend.Register.Domain.Services;
using backend.Register.Domain.Services.Communication;

namespace backend.Register.Services;

public class ClientServiceImpl: IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ClientServiceImpl(IClientRepository clientRepository, IUnitOfWork unitOfWork)
    {
        _clientRepository = clientRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Client>> ListAsync()
    {
        return await _clientRepository.ListAsync();
    }

    public async Task<ClientResponse> CreateAsync(Client client)
    {
        try
        {
            //Validations
            if (client.Password != client.ConfirmPassword)
                return new ClientResponse("Different passwords was received");

            //Actions
            await _clientRepository.AddAsync(client);
            await _unitOfWork.CompleteAsync();
            return new ClientResponse(client);
        }
        catch (Exception e)
        {
            return new ClientResponse($"Failed to register a client: {e.Message}");
        }
    }
    
}