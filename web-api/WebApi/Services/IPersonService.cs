﻿using System;
using System.Collections.Generic;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IPersonService
    {
        IEnumerable<Person> GetPeople();
        Person GetPerson(Guid id);
    }
}
