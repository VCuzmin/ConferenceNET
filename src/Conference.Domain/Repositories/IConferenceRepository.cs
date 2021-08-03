﻿using Conference.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Conference.Domain.Repositories
{
    public interface IConferenceRepository
    {
        Task<List<ConferenceXAttendee>> GetConferences(int conferenceId, string atendeeEmail);
    }
}