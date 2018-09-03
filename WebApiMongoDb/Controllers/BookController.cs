using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiMongoDb.Dao;
using WebApiMongoDb.Models;

namespace WebApiMongoDb.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookDao _bookDao;

        public BookController(IBookDao bookDao)
        {
            _bookDao = bookDao;
        }

        [HttpGet("all")]
        public IActionResult All()
        {
            return Ok(_bookDao.All());
        }

        [HttpGet("{id}")]
        public IActionResult All(string id)
        {
            return Ok(_bookDao.GetById(id));
        }

        [HttpPost("listByFeatures")]
        public IActionResult ListByFeatures([FromForm]Book b,string orderBy)
        {
            return Ok(_bookDao.ListByFeatures(b,orderBy));
        }

        [HttpGet("groupBy")]
        public IActionResult GroupBy(string columns)
        {
            return Ok(_bookDao.GroupBy(columns));
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm]Book b)
        {
            _bookDao.Add(b);
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult Update([FromForm]Book p)
        {
            _bookDao.Update(p);
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromForm]string id)
        {
            _bookDao.Delete(id);
            return Ok();
        }

        [HttpGet("totalCount")]
        public IActionResult TotalCount()
        {
            return Ok(_bookDao.TotalCount());
        }

        [HttpGet("createIndex")]
        public IActionResult CreateIndex(string column)
        {
            return Ok(_bookDao.CreateIndexByColumn(column));
        }

        [HttpGet("indexs")]
        public IActionResult Indexs()
        {
            return Ok(_bookDao.Indexs());
        }
    }
}