﻿using GymManagerApp.Domain.Common;

namespace GymManagerApp.Domain.Entities;

public class Training : BaseEntity
{
    public TrainingType Type { get; private set; }

    public DateTime ScheduledAt { get; private set; }

    public User Trainer { get; private set; }

    public int MaxParticipants { get; private set; }

    public List<Member> Participants { get; private set; }

    private Training() { }

    private Training(TrainingType type, DateTime scheduledAt, User trainer, int maxParticipants)
    {
        Type = type;
        ScheduledAt = scheduledAt;
        Trainer = trainer;
        MaxParticipants = maxParticipants;
        Participants = new();
    }

    public static Training Create(TrainingType type, DateTime scheduledAt, User trainer, int maxParticipants)
    {
        return new Training(type, scheduledAt, trainer, maxParticipants);
    }

    public void Update(DateTime scheduledAt, int maxParticipants)
    {
        ScheduledAt = scheduledAt;
        MaxParticipants = maxParticipants;
    }

    public bool IsUpcoming(DateTime currentTime)
    {
        return ScheduledAt > currentTime;
    }
}