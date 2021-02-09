using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UtilityInspect.TaskService.Models
{
    public class FieldOrderTask
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FieldOrderTaskID { get; set; }

        [Required]
        public string FieldOrderID { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Progress { get; set; }
    }
}