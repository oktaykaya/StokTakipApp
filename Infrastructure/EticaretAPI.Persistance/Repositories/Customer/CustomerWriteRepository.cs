﻿using EticaretAPI.Application.Repositories;
using EticaretAPI.Domain.Entities;
using EticaretAPI.Persistance.c
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretAPI.Persistance.Repositories
{
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(EticaretAPIDbContext context) : base(context)
        {
        }
    }
}