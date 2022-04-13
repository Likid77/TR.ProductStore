﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TR.Data.Infrastructures
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private DbContext _dataContext;
        public DbContext DataContext { get { return _dataContext; } }
        public DatabaseFactory() { _dataContext = new TRContext(); }
        protected override void DisposeCore()
        {
            if (_dataContext != null)
            _dataContext.Dispose();
        }
    }
}
