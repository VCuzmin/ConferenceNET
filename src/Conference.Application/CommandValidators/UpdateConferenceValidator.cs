using Conference.Domain.Repositories;
using Conference.PublishedLanguage.Commands;
using FluentValidation;
using System;

namespace Conference.Application.CommandValidators
{
    public class UpdateConferenceValidator : AbstractValidator<UpdateConference>
    {
        public UpdateConferenceValidator(IConferenceRepository conferenceRepository)
        {

            RuleFor(command => command.Id).Must(x =>
            {
                return x> 0;
            }).WithMessage("Invalid id");

            RuleFor(command => command.Id).MustAsync(async (id, cancellationToken) =>
            {
                var identification = await conferenceRepository.GetConferenceByIdAsync(id, cancellationToken);
                return identification != null;
            }).WithMessage(x => $"Conference with name {x.Name} does not exist and cannot be updated");

            RuleFor(command => command.Name).Must(x =>
            {
                return !string.IsNullOrEmpty(x);
            }).WithMessage("Empty name");

            RuleFor(command => command.CategoryId).Must(x =>
            {
                return x > 0;
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
                return x > DateTime.MinValue && x < DateTime.MaxValue;
            }).WithMessage("End date must have a value");

            RuleFor(command => command.OrganizerEmail).Must(x =>
            {
                return !string.IsNullOrEmpty(x);
            }).WithMessage("Empty OrganizerEmail");

            RuleFor(command => command.OrganizerEmail).EmailAddress().WithMessage("OrganizerEmail must be a valid email address");


        }
    }
}