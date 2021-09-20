using MediatR;
using System;

namespace Conference.Application.Commands
{
    public class DeleteConference : IRequest
    {
        public int Id { get; set; }
    }
}