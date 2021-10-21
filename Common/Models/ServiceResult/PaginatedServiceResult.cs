using System;
using System.Collections.Generic;

namespace Blog.Common.Models.ServiceResult
{
    /// <summary>
    /// Class to create a paginatedr result
    /// </summary>
    /// <typeparam name="T">type of data in the list</typeparam>
    public class PaginatedServiceResult<T> : ServiceResult
    {
        public int PageNumber { get; set; }

        public int TotalPages { get; set; }

        public int PageSize { get; set; }

        public int TotalRecords { get; set; }

        public DateTime? From { get; set; }

        public DateTime? To { get; set; }

        public Uri FirstPage { get; set; }

        public Uri LastPage { get; set; }

        public Uri NextPage { get; set; }

        public Uri PreviousPage { get; set; }

        public ICollection<T> Data { get; set; }

        public PaginatedServiceResult()
        {
        }

        public PaginatedServiceResult(ServiceError error) : base(error)
        {
        }

        public PaginatedServiceResult(
            int pageNumber,
            int totalPages,
            int pageSize,
            int totalRecords,
            Uri firstPage,
            Uri lastPage,
            Uri nextPage,
            Uri previousPage,
            DateTime? from,
            DateTime? to,
            List<T> data)
        {
            PageNumber = totalRecords.Equals(0) ? 0 : pageNumber;
            TotalPages = totalPages;
            PageSize = pageSize;
            TotalRecords = totalRecords;
            FirstPage = firstPage;
            LastPage = lastPage;
            NextPage = nextPage;
            PreviousPage = previousPage;
            From = from;
            To = to;
            Data = data;
        }
    }
}
