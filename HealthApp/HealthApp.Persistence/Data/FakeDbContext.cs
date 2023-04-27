﻿using HealthApp.Domain.Entities;

namespace HealthApp.Persistence.Data;

public class FakeDbContext : IFakeDbContext
{
    public List<Patient> _patients { get; set; }
    public List<Doctor> _doctors { get; set; }
    public List<Card> _cards { get; set; }
}