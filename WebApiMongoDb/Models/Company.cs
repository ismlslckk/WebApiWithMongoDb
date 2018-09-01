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
    public class Company:ModelBase
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("permalink")]
        public string Permalink { get; set; }

        [BsonElement("crunchbase_url")]
        public string CrunchbaseUrl { get; set; }

        [BsonElement("homepage_url")]
        public string HomepageUrl { get; set; }

        [BsonElement("blog_url")]
        public string BlogUrl { get; set; }

        [BsonElement("blog_feed_url")]
        public string BlogFeedUrl { get; set; }

        [BsonElement("twitter_username")]
        public object TwitterUsername { get; set; }

        [BsonElement("category_code")]
        public string CategoryCode { get; set; }

        [BsonElement("number_of_employees")]
        public object NumberOfEmployees { get; set; }

        [BsonElement("founded_year")]
        public object FoundedYear { get; set; }

        [BsonElement("founded_month")]
        public object FoundedMonth { get; set; }

        [BsonElement("founded_day")]
        public object FoundedDay { get; set; }

        [BsonElement("deadpooled_year")]
        public object DeadpooledYear { get; set; }

        [BsonElement("deadpooled_month")]
        public object DeadpooledMonth { get; set; }

        [BsonElement("deadpooled_day")]
        public object DeadpooledDay { get; set; }

        [BsonElement("deadpooled_url")]
        public object DeadpooledUrl { get; set; }

        [BsonElement("tag_list")]
        public string TagList { get; set; }

        [BsonElement("alias_list")]
        public object AliasList { get; set; }

        [BsonElement("email_address")]
        public object EmailAddress { get; set; }

        [BsonElement("phone_number")]
        public object PhoneNumber { get; set; }

        [BsonElement("description")]
        public object Description { get; set; }

        [BsonElement("created_at")]
        public object CreatedAt { get; set; }

        [BsonElement("updated_at")]
        public object UpdatedAt { get; set; }

        [BsonElement("overview")]
        public string Overview { get; set; }

        [BsonElement("image")]
        public Image Image { get; set; }

        [BsonElement("products")]
        public AcquiringCompany[] Products { get; set; }

        [BsonElement("relationships")]
        public Relationship[] Relationships { get; set; }

        [BsonElement("competitions")]
        public Competition[] Competitions { get; set; }

        [BsonElement("providerships")]
        public object[] Providerships { get; set; }

        [BsonElement("total_money_raised")]
        public string TotalMoneyRaised { get; set; }

        [BsonElement("funding_rounds")]
        public object[] FundingRounds { get; set; }

        [BsonElement("investments")]
        public object[] Investments { get; set; }

        [BsonElement("acquisition")]
        public Acquisition Acquisition { get; set; }

        [BsonElement("acquisitions")]
        public object[] Acquisitions { get; set; }

        [BsonElement("offices")]
        public Office[] Offices { get; set; }

        [BsonElement("milestones")]
        public object[] Milestones { get; set; }

        [BsonElement("ipo")]
        public object Ipo { get; set; }

        [BsonElement("video_embeds")]
        public object[] VideoEmbeds { get; set; }

        [BsonElement("screenshots")]
        public object[] Screenshots { get; set; }

        [BsonElement("external_links")]
        public object[] ExternalLinks { get; set; }

        [BsonElement("partners")]
        public object[] Partners { get; set; }
    }
}
