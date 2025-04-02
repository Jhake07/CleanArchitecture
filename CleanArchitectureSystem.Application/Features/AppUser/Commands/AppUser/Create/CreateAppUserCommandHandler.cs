using AutoMapper;
using CleanArchitectureSystem.Application.Contracts.Interface;
using CleanArchitectureSystem.Application.Exceptions;
using MediatR;

namespace CleanArchitectureSystem.Application.Features.AppUser.Commands.AppUser.Create
{
    public class CreateAppUserCommandHandler(IMapper mapper, IAppUserRepository appUserRepository) : IRequestHandler<CreateAppUserCommand, int>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IAppUserRepository _appUserRepository = appUserRepository;

        public async Task<int> Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            // Validate data
            var validator = new CreateAppUserCommandValidator(_appUserRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid details", validationResult);
            }

            // Convert to domain object
            var user = _mapper.Map<Domain.AppUser>(request);

            // Add to database
            await _appUserRepository.CreateAsync(user);

            // Return record id
            return user.Id;

            throw new NotImplementedException();
        }
    }
}
