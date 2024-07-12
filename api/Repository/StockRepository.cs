using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public StockRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public Task<List<Stock>> GetAllAsync()
        {
            return _dbContext.Stocks.ToListAsync();
        }
    }
}