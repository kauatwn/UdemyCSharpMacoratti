﻿using CatalogDb.API.Context;

namespace CatalogDb.API.Repositories
{
    public class UnitOfWork<T>(AppDbContext context) : IUnitOfWork<T> where T : class
    {
        private IRepository<T>? _repository;
        private ICategoryRepository? _categoryRepository;
        private IProductRepository? _productRepository;
        private readonly AppDbContext _context = context;

        public IRepository<T> Repository
        {
            get
            {
                // Null coalescing.
                // Se _repository for null, recebe Repository<T>(_context).
                // Se não, recebe _repository.
                return _repository ??= new Repository<T>(_context);
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                return _categoryRepository ??= new CategoryRepository(_context);
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return _productRepository ??= new ProductRepository(_context);
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
