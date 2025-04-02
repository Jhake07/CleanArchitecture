﻿using MediatR;

namespace CleanArchitectureSystem.Application.Features.AppUser.Commands.AppUser.Create
{
    public class CreateAppUserCommand : IRequest<int>
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
