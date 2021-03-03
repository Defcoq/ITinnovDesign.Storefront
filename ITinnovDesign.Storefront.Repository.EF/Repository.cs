using ITinnovDesign.Storefront.Infrastructure.Domain;
using ITinnovDesign.Storefront.Infrastructure.Querying;
using ITinnovDesign.Storefront.Infrastructure.UnitOfWork;
using ITinnovDesign.Storefront.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ITinnovDesign.Storefront.Repository.EF
{
    public abstract class Repository<T, TEntityKey> where T :EntityBase<TEntityKey>, IAggregateRoot
    {
        private IUnitOfWork _uow;
       public DbSet<T> Table { get; }

        //public Repository(IUnitOfWork uow)
        //{
        //    _uow = uow;
        //}

        public ITInnovDesignSorefrontContext Context { get; }

        private readonly bool _disposeContext;
    

        //  protected QuoteGeneratorRepositoryBase(IServiceScopeFactory serviceScopeFactory)
        protected Repository(ITInnovDesignSorefrontContext context, IUnitOfWork uow)
        {
           
            Context = context;
            _uow = uow;

           Table = Context.Set<T>();
        }
        protected Repository(DbContextOptions<ITInnovDesignSorefrontContext> options, IUnitOfWork uow) : this(new ITInnovDesignSorefrontContext(options), uow)
 
        {
            _disposeContext = true;
        }

        public virtual void Dispose()
        {
            if (_disposeContext)
            {
                Context.Dispose();
            }
        }

        public void Save(T entity)
        {
            Table.Add(entity);
            Context.SaveChanges();
        }

        public void Update(T entity)
        {
            Table.Update(entity);
            Context.SaveChanges();
        }

        public void Add(T entity)
        {
            Table.Add(entity);
          
        }

        public void Remove(T entity)
        {
            Table.Remove(entity);
            Context.SaveChanges();

        }

        public void Save()
        {
            Context.SaveChanges();
            
        }

        public T FindBy(TEntityKey id)
        {
            
            return Table.Find(id);
        }

        public IEnumerable<T> FindAll()
        {


            return Table;
        }

   
       

        public IEnumerable<T> FindAll(int index, int count)
        {


            return Table.Skip(index).Take(count);
        }

        public virtual IQueryable<T> GetAll() => Table;

        public IEnumerable<T> FindBy(IQueryable<T> query)
        {


            return query.ToList();
        }

        public IEnumerable<T> FindBy(IQueryable<T> query, int index, int count)
        {
           

            return query.Skip(index).Take(count);
        }


        public IEnumerable<T> FindBy(Expression<Func<T, object>> query)
        {


            return Table.OrderBy(query).ToList();
        }

        public IEnumerable<T> FindBy(Expression<Func<T, object>> query, int index, int count)
        {


            return Table.OrderBy(query).Skip(index).Take(count);
        }


    }
}
