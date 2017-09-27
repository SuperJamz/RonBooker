// ======================================
// Author: Ebenezer Monney
// Email:  info@ebenmonney.com
// Copyright (c) 2017 www.ebenmonney.com
// 
// ==> Gun4Hire: contact@ebenmonney.com
// ======================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using DAL.Repositories.Interfaces;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext _context;

        IMemberRepository _members;
        IProductRepository _products;
        IBookingsRepository _bookings;



        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }



        public IMemberRepository Members
        {
            get
            {
                if (_members == null)
                    _members = new MemberRepository(_context);

                return _members;
            }
        }



        public IProductRepository Products
        {
            get
            {
                if (_products == null)
                    _products = new ProductRepository(_context);

                return _products;
            }
        }



        public IBookingsRepository Bookings
        {
            get
            {
                if (_bookings == null)
                    _bookings = new BookingsRepository(_context);

                return _bookings;
            }
        }




        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
