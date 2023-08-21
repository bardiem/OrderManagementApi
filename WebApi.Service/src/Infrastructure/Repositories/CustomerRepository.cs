using Application.Commands;
using Application.DTOs;
using Application.Interfaces;
using Application.Mappers;
using Infrastructure.Common.Persistence;
using Infrastructure.Common.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;
    private readonly CustomerMapper _customerMapper;
    private readonly IDateTime _dateTime;

    public CustomerRepository(ApplicationDbContext context, CustomerMapper customerMapper, IDateTime dateTime)
    {
        _context = context;
        _customerMapper = customerMapper;
        _dateTime = dateTime;
    }

    public async Task<CustomerDTO> CreateCustomer(CreateCustomerCommand createCustomerCommand, CancellationToken cancellationToken)
    {
        var customer = _customerMapper.ToEntity(createCustomerCommand);
        customer.Created = _dateTime.UtcNow;
        customer.LastModified = _dateTime.UtcNow;

        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync(cancellationToken);

        return _customerMapper.ToDto(customer);
    }

    public async Task<IList<CustomerDTO>> GetAllCustomers(CancellationToken cancellationToken)
    {
        var customers = await _context.Customers.ToListAsync();
        var mapped = customers.Select(c => _customerMapper.ToDto(c)).ToList();

        return mapped;
    }
}