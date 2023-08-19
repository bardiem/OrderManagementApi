using Application.Commands;
using Application.DTOs;
using Infrastructure.Common.Persistence.Entities;

namespace Application.Mappers;

public class CustomerMapper
{
    public CustomerDTO ToDto(CustomerEntity entity)
    {
        var dto = new CustomerDTO
        {
            Email = entity.Email,
            UserName = entity.UserName,
            Id = entity.Id
        };
        return dto;
    }

    public CustomerEntity ToEntity(CreateCustomerCommand command)
    {
        var entity = new CustomerEntity
        {
            Email = command.Email,
            UserName = command.UserName,
            PasswordHash = command.PasswordHash
        };

        return entity;
    }
}
