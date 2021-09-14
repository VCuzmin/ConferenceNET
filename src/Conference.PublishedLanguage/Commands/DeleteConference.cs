using MediatR;
using System;

namespace Conference.PublishedLanguage.Commands
{
    public class DeleteConference : IRequest
    {
        public int Id { get; set; }
    }
}