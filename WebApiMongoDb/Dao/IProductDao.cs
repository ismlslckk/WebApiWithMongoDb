﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiMongoDb.Models;

namespace WebApiMongoDb.Dao
{
    public interface IProductDao: ICrud<Product>
    {
    }
}
