using AutoMapper;
using CleanArchitectureSystem.Application.Contracts.Interface;
using CleanArchitectureSystem.Application.Exceptions;
using MediatR;

namespace CleanArchitectureSystem.Application.Features.AppUser.Commands.AppUser.Update
{
    public class UpdateAppUserCommandHandler(IMapper mapper, IAppUserRepository appUserRepository) : IRequestHandler<UpdateAppUserCommand, Unit>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IAppUserRepository _appUserRepository = appUserRepository;

        public async Task<Unit> Handle(UpdateAppUserCommand request, CancellationToken cancellationToken)
        {
            // validate data        
            var validator = new UpdateAppUserCommandValidator(_appUserRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid details", validationResult);
            }

            // convert to domain object
            var user = _mapper.Map<Domain.AppUser>(request);

            // update the database
            await _appUserRepository.UpdateAsync(user);

            // return Unit
            throw new NotImplementedException();
        }
    }
}
