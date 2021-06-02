using MongoDB.Bson;
using System;

namespace AFORO255.AZURE.Report.ConfigCollection
{
    public class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;

    }
}
