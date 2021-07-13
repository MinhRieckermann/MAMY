using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Threading.Tasks;
using WebAPI_Team.Entities;
using WebAPI_Team.Models;

namespace WebAPI_Team.DAL
{
    public class UnitOfWork : IDisposable
    {
        private TeamDBContext context = new TeamDBContext();
        private bool disposed = false;
        private GenericRepository<Account> accountRepository;
        private GenericRepository<STG_SportData> stg_SportDataRepository;
        private GenericRepository<OddAnalysis> oddAnalysisRepository;

        public GenericRepository<Account> AccountRepository
        {
            get
            {

                if (this.accountRepository == null)
                {
                    this.accountRepository = new GenericRepository<Account>(context);
                }
                return accountRepository;
            }
        }

        public GenericRepository<STG_SportData> STG_SportDataRepository
        {
            get
            {

                if (this.stg_SportDataRepository == null)
                {
                    this.stg_SportDataRepository = new GenericRepository<STG_SportData>(context);
                }
                return stg_SportDataRepository;
            }
        }

        public GenericRepository<OddAnalysis> OddAnalysisRepository
        {
            get
            {

                if (this.oddAnalysisRepository == null)
                {
                    this.oddAnalysisRepository = new GenericRepository<OddAnalysis>(context);
                }
                return oddAnalysisRepository;
            }
        }


        private GenericRepository<Product> productRepository;
        private GenericRepository<Order> orderRepository;
        private GenericRepository<Orders_detail> orders_detailRepository;
        private GenericRepository<Category> categoryRepository;


        public GenericRepository<Product> ProductRepository
        {
            get
            {

                if (this.productRepository == null)
                {
                    this.productRepository = new GenericRepository<Product>(context);
                }
                return productRepository;
            }
        }

        public GenericRepository<Order> OrderRepository
        {
            get
            {

                if (this.orderRepository == null)
                {
                    this.orderRepository = new GenericRepository<Order>(context);
                }
                return orderRepository;
            }
        }

        public GenericRepository<Orders_detail> Orders_detailRepository
        {
            get
            {

                if (this.orders_detailRepository == null)
                {
                    this.orders_detailRepository = new GenericRepository<Orders_detail>(context);
                }
                return orders_detailRepository;
            }
        }
        public GenericRepository<Category> CategoryRepository
        {
            get
            {

                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new GenericRepository<Category>(context);
                }
                return categoryRepository;
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}