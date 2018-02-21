using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EE.Education.Site.EF.Interfaces;

namespace EE.Education.Site.Infrastructure.Repositories
{
    public interface IDataRepository
    {
        IQueryable<TEntity> Select<TEntity>() where TEntity : class, IEntity;
        IQueryable<TEntity> Select<TEntity>(Expression<Func<TEntity, bool>> selector) where TEntity : class, IEntity;

        TEntity Get<TEntity>(int id) where TEntity : class, IDomainEntity;
        TEntity Get<TEntity>(Expression<Func<TEntity, bool>> selector) where TEntity : class, IDomainEntity;

        void Add<TEntity>(TEntity entity) where TEntity : class, IDomainEntity;
        void Add<TEntity>(params TEntity[] entities) where TEntity : class, IDomainEntity;

        void Delete<TEntity>(TEntity entity) where TEntity : class, IEntity;
        void Delete<TEntity>(params TEntity [] entities) where TEntity : class, IEntity;

        void Apply();
    }
}