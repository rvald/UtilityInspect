using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UtilityInspect.FieldOrderService.Models
{
    public class FieldOrder
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FieldOrderID { get; set; }

        [Required]
        public string EmployeeID { get; set; }

        [Required]
        public string CreatedDate { get; set; }

        [Required]
        public string Notes { get; set; }
    }
}