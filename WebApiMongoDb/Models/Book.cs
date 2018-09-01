using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApiMongoDb.Models
{
    public class Book:ModelBase
    { 

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("isbn")]
        public string Isbn { get; set; }

        [BsonElement("pageCount")] public long PageCount { get; set; } = -1;

        [BsonElement("publishedDate")]
        public DateTime PublishedDate { get; set; }

        [BsonElement("thumbnailUrl")]
        public string ThumbnailUrl { get; set; }

        [BsonElement("shortDescription")]
        public string ShortDescription { get; set; }

        [BsonElement("longDescription")]
        public string LongDescription { get; set; }

        [BsonElement("status")]
        public string Status { get; set; }

        [BsonElement("authors")]
        public string[] Authors { get; set; }

        [BsonElement("categories")]
        public string[] Categories { get; set; }
    }
}
