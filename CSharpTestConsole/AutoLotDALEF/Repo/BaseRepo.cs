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
    }
}
