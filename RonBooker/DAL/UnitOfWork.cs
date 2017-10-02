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
        ISportFacilityRepository _sportfacilities;
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



        public ISportFacilityRepository SportFacilities
        {
            get
            {
                if (_sportfacilities == null)
                    _sportfacilities = new SportFacilityRepository(_context);

                return _sportfacilities;
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
