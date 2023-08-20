﻿namespace Application.DTOs;

public record CustomerDTO
{
    public int Id { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }
}
