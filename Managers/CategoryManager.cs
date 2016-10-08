using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Net.Bjvl.Models;
using WebApplication.Data;

namespace Net.Bjvl.Managers
{
    public class CategoryManager : IDisposable
    {
        ApplicationDbContext db;
        protected internal virtual ILogger Logger { get; set; }

        public CategoryManager(DbContextOptions<ApplicationDbContext> options, ILogger<CategoryManager> logger)
        {
            db = new ApplicationDbContext(options);
            Logger = logger;
        }

        public async Task CreateCategory(string title, string subTitle, string keyword, int parentId = 0)
        {
			Category category = new Category()
			{
				Title = title,
				SubTitle = subTitle,
				Keyword = keyword,
				ParentId = parentId,
				Sort = 0,
				ShowIndexCount = 8
			};

			db.Categories.Add(category);
            await db.SaveChangesAsync();
        }

		public async Task UpdateCategory(Category category)
		{
			Category origin = await db.Categories.SingleOrDefaultAsync(e=>e.Id == category.Id);
			origin.CloneFrom(category, nameof(category.Id));

			await db.SaveChangesAsync();
		}

        public async Task DeleteCategory(int id)
        {
            bool inUse = await db.Articles.AnyAsync(e=>e.CategoryId == id);
            if(inUse)
            {
                throw new Exception($"Cannot delete the {nameof(Category)} {id} is used.");
            }
            db.Categories.Remove(await db.Categories.SingleAsync(e=>e.Id == id));
            await db.SaveChangesAsync();
        }

        public async Task<List<Category>> GetCategories(int page = 1, int pageSize = 8)
        {
            int skip = (page - 1) * pageSize;
            var query = db.Categories.OrderBy(e=>e.Sort).Skip(skip).Take(pageSize);
            return await query.ToListAsync();
        }

        public async Task<Category> GetCategory(int id){
            return await db.Categories.SingleOrDefaultAsync(e => e.Id == id);
        }

        public void Dispose()
        {
            ;
        }
    }
}