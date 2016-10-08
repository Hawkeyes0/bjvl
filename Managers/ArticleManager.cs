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
    public class ArticleManager : IDisposable
    {
        ApplicationDbContext db;
        protected internal virtual ILogger Logger { get; set; }

        public ArticleManager(DbContextOptions<ApplicationDbContext> options, ILogger<CategoryManager> logger)
        {
            db = new ApplicationDbContext(options);
            Logger = logger;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<Article> GetArticle(int id)
        {
            return await db.Articles.SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Article>> GetArticles(int categoryId, int page = 1, int pageSize = 8)
        {
            int skip = (page - 1) * pageSize;

            var query = db.Articles.Where(e => e.CategoryId == categoryId).OrderByDescending(e => e.IsTop).ThenBy(e => e.CreateDate);

            return await query.Skip(skip).Take(pageSize).ToListAsync();
        }

        public async Task CreateArticle(string title, string titleFontColor
            , string author, string copyFrom, int categoryId, string keyword
            , string description, string content, string thumble, int userId, string username)
        {
            Article art = new Article()
            {
                Title = title,
                TitleFontColor = titleFontColor,
                Author = author,
                CopyFrom = copyFrom,
                CategoryId = categoryId,
                Keyword = keyword,
                Description = description,
                Content = content,
                CreateDate = new DateTime(),
                Thumble = thumble,
                CreatorId = userId,
                CreatorName = username
            };

            db.Articles.Add(art);
            await db.SaveChangesAsync();
        }

        public async Task UpdateArticle(Article article)
        {
            Article art = await db.Articles.SingleOrDefaultAsync(e => e.Id == article.Id);
            art.CloneFrom(article);
            await db.SaveChangesAsync();
        }

        public async Task DeleteArticle(int id)
        {
            var art = await db.Articles.SingleOrDefaultAsync(e => e.Id == id);
            if (art == null)
                return;
            db.Remove(art);
            await db.SaveChangesAsync();
        }
    }
}