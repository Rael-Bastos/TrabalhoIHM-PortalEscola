﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoIHM.Domain.Interfaces.UoW
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}
