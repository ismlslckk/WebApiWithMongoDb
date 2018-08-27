using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using WebApiMongoDb.DaoImpl;
using WebApiMongoDb.DAO;
using WebApiMongoDb.Models;
using MongoDB.Bson;

namespace WebApiMongoDb.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductDao _productDao;

        public ProductController(IProductDao productDao)
        {
            _productDao = productDao;
        }

        [HttpGet("all")]
        public IActionResult All()
        {
            return Ok(_productDao.All().OrderByDescending(x=>x.Price));
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm]Product p)
        {
            _productDao.Add(p);
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult Update([FromForm]Product p)
        { 
           _productDao.Update(p);
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromForm]string id)
        {
            _productDao.Delete(id);
            return Ok();
        }
    }
}