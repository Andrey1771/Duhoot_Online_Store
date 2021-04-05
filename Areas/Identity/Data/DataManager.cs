﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopDuhootWeb.Areas.Repositories.Abstract;

namespace OnlineShopDuhootWeb.Areas.Identity.Data
{
    public class DataManager
    {
        public IProductSiteCardRepository ProductSiteCardRep { get; set; }

        public DataManager(IProductSiteCardRepository productSiteCardRepository)
        {
            ProductSiteCardRep = productSiteCardRepository;
        }
    }
}