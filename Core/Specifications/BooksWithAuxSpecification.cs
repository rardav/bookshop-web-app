using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class BooksWithAuxSpecification : BaseSpecification<Book>
    {
        public BooksWithAuxSpecification()
        {
            AddInclude(x => x.Author);
            AddInclude(x => x.Genre);
            AddInclude(x => x.Publisher);
            AddInclude(x => x.Language);
        }

        public BooksWithAuxSpecification(int id) 
            : base(x => x.Id == id)
        {
            AddInclude(x => x.Author);
            AddInclude(x => x.Genre);
            AddInclude(x => x.Publisher);
            AddInclude(x => x.Language);
        }
    }
}