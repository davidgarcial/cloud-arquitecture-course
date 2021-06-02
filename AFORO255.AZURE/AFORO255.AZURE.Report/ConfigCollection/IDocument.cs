using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace AFORO255.AZURE.Report.ConfigCollection
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        ObjectId Id { get; set; }

        DateTime CreatedAt { get; }
    }
}
