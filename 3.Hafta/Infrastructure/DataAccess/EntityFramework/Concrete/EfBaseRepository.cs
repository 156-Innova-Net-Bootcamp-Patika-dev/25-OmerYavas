using Infrastructure.DataAccess.Abstract;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.DataAccess.EntityFramework.Concrete
{
    public abstract class EfBaseRepository<TEntity, TContext>
        : IBaseDAL<TEntity>
        where TEntity : BaseEntity, new()
        where TContext : DbContext, new()
    {

        /// <summary>
        /// //Gelen entity'e göre veritabanından kaydı siler. 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Başarılı işlem yapılırsa geriye 0 dan büyük bir değer döner.</returns>
        public int Delete(TEntity entity)
        {
            using (TContext ctx = new TContext())
            {
                var entry = ctx.Entry(entity);
                entry.State = EntityState.Deleted;
                try
                {
                    return ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.StackTrace);
                }

            }
        }


        /// <summary>
        /// Gönderilen Id'ye sahip kaydı veritabanından kaydı bulup siler.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Başarılı işlem yapılırsa geriye 0 dan büyük bir değer döner.</returns>
        public int Delete(int id)
        {
            return Delete(Get(x => x.Id == id));
        }


        /// <summary>
        /// Gönderilen filtreye uyan tek bir kaydı döndürür. 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includeList">Include edilecek tabloları tutar.</param>
        /// <returns>İstenen türde kayıt döner.</returns>
        public TEntity Get(Expression<Func<TEntity, bool>> filter, params string[] includeList)
        {
            using (TContext ctx = new TContext())
            {
                IQueryable<TEntity> _dbSet = ctx.Set<TEntity>();

                if (includeList.Length > 0)
                {
                    foreach (var item in includeList)
                    {
                        _dbSet = _dbSet.Include(item);
                    }
                }

                return _dbSet.SingleOrDefault(filter);
            }
        }


        /// <summary>
        /// Gönderilen filtre olursa uyan kayıtları, filtre null ise tüm kayıtları getirir.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includeList">Include edilecek tabloları tutar.</param>
        /// <returns>İstenen türde kayıtları döner.</returns>
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, params string[] includeList)
        {
            using (TContext ctx = new TContext())
            {
                IQueryable<TEntity> _dbSet = ctx.Set<TEntity>();

                if (includeList.Length > 0)
                {
                    foreach (var item in includeList)
                    {
                        _dbSet = _dbSet.Include(item);
                    }
                }

                return filter == null
                        ? _dbSet.ToList()
                        : _dbSet.Where(filter).ToList();
            }
        }

        /// <summary>
        /// Gönderilen Id değerine sahip kaydı getirir.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeList"></param>
        /// <returns>İstenen türde kaydı döner.</returns>
        public TEntity GetById(int id, params string[] includeList)
        {
            using (TContext ctx = new TContext())
            {
                IQueryable<TEntity> _dbSet = ctx.Set<TEntity>();

                if (includeList.Length > 0)
                {
                    foreach (var item in includeList)
                    {
                        _dbSet = _dbSet.Include(item);
                    }
                }

                return _dbSet.SingleOrDefault(x => x.Id == id);
            }
        }

        /// <summary>
        /// Gönderilen entity'i veritabanında ilgili tabloya kaydeder.
        /// </summary>
        /// <param name="entity"></param>
        public int Insert(TEntity entity)
        {
            using (TContext ctx = new TContext())
            {
                entity.IsActive = true;
                entity.IsDelete = true;
                entity.CreatedDate = DateTime.Now;
                entity.UpdatedDate = DateTime.Now;

                var entry = ctx.Entry(entity);
                entry.State = EntityState.Added;

                try
                {
                    return ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.StackTrace);
                }

            }
        }


        /// <summary>
        /// Gönderilen entity'i veritabanında ilgili tabloda bulup günceller.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Güncelleme işlemi başarılı olur ise geriye 0 dan büyük değer döner.</returns>
        public int Update(TEntity entity)
        {
            using (TContext ctx = new TContext())
            {
                entity.UpdatedDate = DateTime.Now;

                var entry = ctx.Entry(entity);
                entry.State = EntityState.Modified;
                try
                {
                    return ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.StackTrace);
                }
            }
        }
    }
}
