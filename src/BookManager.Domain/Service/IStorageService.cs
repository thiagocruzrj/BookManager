﻿using System;
using System.Threading.Tasks;

namespace BookManager.Domain.Service
{
    public interface IStorageService : IDisposable
    {
        Task<bool> DebitStock(Guid bookId, int amount);
        Task<bool> RestoreStock(Guid bookId, int amount);
    }
}
