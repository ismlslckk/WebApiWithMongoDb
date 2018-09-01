using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace WebApiMongoDb.Models
{
    public class Product:ModelBase
    {

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("price")]
        public double Price { get; set; }

        [BsonElement("quantity")]
        public int Quantity { get; set; }

        [BsonElement("status")]
        public bool Status { get; set; }

        [BsonElement("date")]
        public DateTime Date { get; set; }

        [BsonElement("categoryId")]
        public int CategoryId { get; set; }
    }
}
