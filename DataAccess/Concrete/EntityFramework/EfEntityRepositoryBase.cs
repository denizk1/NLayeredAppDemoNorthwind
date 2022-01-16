using DataAccess.Abstract;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //bana bir entity ve context ver bunlar reposityorye aktarılsın
    public class EfEntityRepositoryBase<TEntity, TContext> : IRepository<TEntity> 
        where TEntity : class, IEntity, new()
        where TContext : DbContext,new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addEntity = context.Entry(entity);// gönderilen producttı veritabanındakiyle eslestiriyor
                addEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var delEntity = context.Entry(entity);// gönderilen producttı veritabanındakiyle eslestiriyor
                delEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {

            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();//eger product ise bununla ilgili tüm verileri getir
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var upEntity = context.Entry(entity);// gönderilen producttı veritabanındakiyle eslestiriyor
                upEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
