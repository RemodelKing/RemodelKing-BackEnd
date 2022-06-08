﻿using backend.Register.Domain.Repositories;
using backend.RemodelKing.Domain.Models;
using backend.RemodelKing.Domain.Repositories;
using backend.RemodelKing.Domain.Services;
using backend.RemodelKing.Domain.Services.Communication;

namespace backend.RemodelKing.Services;

public class PaymentServiceImpl: IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PaymentServiceImpl(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork)
    {
        _paymentRepository = paymentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Payment>> ListAsync()
    {
        return await _paymentRepository.ListAsync();
    }

    public async Task<PaymentResponse> CreateAsync(Payment payment)
    {
        try
        {
            await _paymentRepository.AddAsync(payment);
            await _unitOfWork.CompleteAsync();
            return new PaymentResponse(payment);
        }
        catch (Exception e)
        {
            return new PaymentResponse($"Error while creating payments: {e.Message}");
        }
    }
}