using AFORO255.AZURE.Report.ConfigCollection;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AFORO255.AZURE.Report.Repositories
{
    public interface IMongoRepository<TDocument> where TDocument : IDocument
    {
        IEnumerable<TDocument> FilterBy(Expression<Func<TDocument, bool>> filterExpression);
    }
}
