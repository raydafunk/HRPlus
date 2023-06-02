﻿namespace HRPlus.Application.Contracts.Presistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(int id);   
    } 
}
