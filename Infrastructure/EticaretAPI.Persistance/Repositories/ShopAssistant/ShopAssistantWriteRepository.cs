﻿using EticaretAPI.Application.Repositories;
using EticaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretAPI.Persistance.Repositories
{
    public class ShopAssistantWriteRepository : WriteRepository<ShopAssistant>, IShopAssistantWriteRepository
    {
        public ShopAssistantWriteRepository(EticaretAPIDbContext context) : base(context)
        {
        }
    }
}
