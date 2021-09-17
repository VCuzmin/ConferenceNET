using Conference.Domain.Repositories;
using Conference.Application.Commands;
using FluentValidation;
using System;

namespace Conference.Application.CommandValidators
{
    public class CreateConferenceValidator : AbstractValidator<CreateConference>
    {
        public CreateConferenceValidator(IConferenceRepository conferenceRepository)
        {
            RuleFor(command => command.Name).Must(x =>
            {
                return !string.IsNullOrEmpty(x);
            }).WithMessage("Empty name");

            RuleFor(command => command.CategoryId).Must(x =>
            {
                return x> 0;
            }).WithMessage("CategoryId must be greater than 0");

            RuleFor(command => command.ConferenceTypeId).Must(x =>
            {
                return x > 0;
            }).WithMessage("ConferenceTypeId must be greater than 0");

            RuleFor(command => command.StartDate).Must(x =>
            {
                return x > DateTime.MinValue && x < DateTime.MaxValue;
            }).WithMessage("Start date must have a value");

            RuleFor(command => command.EndDate).Must(x =>
            {
                return x > DateTime.MinValue && x< DateTime.MaxValue;
            }).WithMessage("End date must have a value");

            RuleFor(command => command.OrganizerEmail).Must(x =>
            {
                return !string.IsNullOrEmpty(x);
            }).WithMessage("Empty OrganizerEmail");

            RuleFor(command => command.OrganizerEmail).EmailAddress().WithMessage("OrganizerEmail must be a valid email address");

            RuleFor(command => command.Name).MustAsync(async (name, cancellationToken) =>
            {
                var identification = await conferenceRepository.GetConferenceByNameAsync(name, cancellationToken);
                return identification != null;
            }).WithMessage(x=> $"Conference with name {x.Name} already exists");
        }
    }
}