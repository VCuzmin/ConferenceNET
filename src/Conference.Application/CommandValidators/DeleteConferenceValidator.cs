using Conference.Domain.Repositories;
using Conference.PublishedLanguage.Commands;
using FluentValidation;

namespace Conference.Application.CommandValidators
{
    public class DeleteConferenceValidator : AbstractValidator<DeleteConference>
    {
        public DeleteConferenceValidator(IConferenceRepository conferenceRepository)
        {
            RuleFor(command => command.Id).Must(x =>
            {
                return x > 0;
            }).WithMessage("Invalid id");
            
            RuleFor(command => command.Id).MustAsync(async (id, cancellationToken) =>
            {
                var identification = await conferenceRepository.GetConferenceByIdAsync(id, cancellationToken);
                return identification != null;
            }).WithMessage(x => $"Conference with id {x.Id} does not exist and cannot be deleted");
        }
    }
}