using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monument_Scann.Models
{
    public class PaginatedList<T> : List<T>
    {
        public int PageAllMonument { get; private set; }
        public int TotalPages { get; private set; }

        public PaginatedList(List<T> items, int count, int pageAllMonument, int pageSize)
        {
            PageAllMonument = pageAllMonument;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageAllMonument > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageAllMonument < TotalPages);
            }
        }

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageAllMonument, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageAllMonument - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageAllMonument, pageSize);
            }
    }
}
