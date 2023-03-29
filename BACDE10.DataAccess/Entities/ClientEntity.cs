using BACDE10.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;

namespace BACDE10.DataAccess.Entities;

public partial class ClientEntity : IEntity
{
    public int? Id { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }
}
