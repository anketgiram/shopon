using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoponWebApp.Models
{
    public class Pager
    {
        public int TotalItems { get; private set; } //to make it as readonly
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
        public Pager()
        {

        }
        public Pager(int totalItems,int page,int pageSize=20)
        {
            int totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            int currentPage = page;
            int startPage = currentPage - 3;
            int endPage = currentPage + 2;

            if(startPage<=0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;
            }
            if(endPage>totalPages)
            {
                endPage = totalPages;
                if(endPage>10)
                {
                    startPage = endPage - 9;
                }
            }
            this.TotalItems = totalItems;
            this.CurrentPage = currentPage;
            this.PageSize = pageSize;
            this.TotalPages = totalPages;
            this.StartPage = startPage;
            this.EndPage = endPage;
        }
    }
}
