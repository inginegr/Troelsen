using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AutoLotDALEF;

namespace AutoLotDALEF.Repo
{
    public class BaseRepo<T> : IDisposable, IRepo<T> where T:EntityBase, new()
    {
        private readonly DbSet<T> table;
        private readonly AutoLotEntities db;

        public BaseRepo()
        {
            db = new AutoLotEntities();
            table = db.Set<T>();
        }

        protected AutoLotEntities context => db;
        public void Dispose()
        {
            db?.Dispose();
        }

        internal int SaveChanges()
        {
            try
            {
                return db.SaveChanges();
            }
            catch(DbUpdateConcurrencyException ex)
            {
                throw;
            }
            catch(DbUpdateException ex)
            {
                throw;
            }
            catch(CommitFailedException ex)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public T GetOne(int? id) => table.Find(id);
        public virtual List<T> GetAll() => table.ToList();

        public List<T> ExecuteQuery(string sql) => table.SqlQuery(sql).ToList();
        public List<T> ExecuteQuery(string sql, object[] SqlParametersObjects) => table.SqlQuery(sql, SqlParametersObjects).ToList();

        public int Add(T entity)
        {
            table.Add(entity);
            return SaveChanges();
        }
        public int AddRange(IList<T> entities)
        {
            table.AddRange(entities);
            return SaveChanges();
        }

        public int Save(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }

        public int Delete(int id, byte[] timeStamp)
        {
            db.Entry(new T() { Id = id, Timestamp = timeStamp }).State = EntityState.Deleted;
            return SaveChanges();
        }
        public int Delete(T entity)
        {
            db.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }
    }

    public class InventoryRepo : BaseRepo<Inventory>
    {
        public override List<Inventory> GetAll() => context.Inventories.OrderBy(x => x.PetName).ToList();
    }
}
