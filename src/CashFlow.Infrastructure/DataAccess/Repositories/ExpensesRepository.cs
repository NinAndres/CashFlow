﻿using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace CashFlow.Infrastructure.DataAccess.Repositories;

internal class ExpensesRepository : IExpensesReadOnlyRepository, IExpensesWhiteOnlyRepository, IExpensesUpdateOnlyRepository
{
    private readonly CashFlowDbContext _dbContext;
    public ExpensesRepository(CashFlowDbContext dbContext) => _dbContext = dbContext;

    public async Task Add(Expense expense)
    {
        await _dbContext.Expenses
            .AddAsync(expense);
    }

    public async Task<List<Expense>> GetAll(User user)
    {
        return await _dbContext.Expenses
            .AsNoTracking()
            .Where(expense => expense.UserId == user.Id)
            .ToListAsync();
    }

    async Task<Expense?> IExpensesReadOnlyRepository.GetById(User user, long id)
    {
        return await GetFullExpense()
            .AsNoTracking()
            .FirstOrDefaultAsync(expense => expense.Id == id && expense.UserId == user.Id);
    }

    async Task<Expense?> IExpensesUpdateOnlyRepository.GetById(User user, long id)
    {
        return await GetFullExpense()
            .FirstOrDefaultAsync(expense => expense.Id == id && expense.UserId == user.Id);
    }

    public async Task Delete(long id)
    {
        var result = await _dbContext.Expenses
            .FindAsync(id);
        _dbContext.Expenses.Remove(result!);
    }

    public void Update(Expense expense)
    {
        _dbContext.Expenses.Update(expense);
    }

    private IIncludableQueryable<Expense, ICollection<Tag>> GetFullExpense()
    {
        return _dbContext.Expenses
             .Include(expense => expense.Tags);
    }
}