using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crud
{
    public class Crudes
    {
        private readonly Data Context;
        private readonly DbSet<Model> dbSet;
        private readonly IMapper Mapper;

        public Crudes(Data Context, IMapper Mapper)
        {
            this.Context = Context;
            dbSet = Context.Set<Model>();
            this.Mapper = Mapper;
        }

        public async Task<Model> CreateAsync(ModelDto modelDto)
        {
            var model = Mapper.Map<Model>(modelDto);

            await dbSet.AddAsync(model);

            Context.SaveChanges();

            return model;
        }

        public async Task<Model> GetAsync(string product)
        {
            return await dbSet.FirstOrDefaultAsync(p => p.ProductName == product);
        }

        public async Task<Model> UpdateAsync(Model model)
        {
            var mod = await dbSet.FirstOrDefaultAsync(p => p.Id == model.Id);

            if (mod is null)
                return null;
            
            Context.Entry(mod).State = EntityState.Detached;
            
            var entry = dbSet.Update(model);

            await Context.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var model = await dbSet.FirstOrDefaultAsync(p => p.Id == id);
            
            if (model is null)
                return false;
            
            dbSet.Remove(model);

            await Context.SaveChangesAsync();

            return true;
        }
        
        public async Task<IEnumerable<Model>> GetAllAsync()
        {
            return dbSet;
        }
    }
}
