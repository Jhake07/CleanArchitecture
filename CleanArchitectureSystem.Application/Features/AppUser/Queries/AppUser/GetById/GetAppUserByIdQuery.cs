using MediatR;

namespace CleanArchitectureSystem.Application.Features.AppUser.Queries.AppUser.GetById
{
    public record GetAppUserByIdQuery(int id) : IRequest<AppUserDto> { }
}
