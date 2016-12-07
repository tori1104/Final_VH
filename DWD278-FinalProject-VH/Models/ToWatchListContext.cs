using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DWD278_FinalProject_VH.Models
{
    public class ToWatchListContext: DbContext
    {
        public ToWatchListContext(): base("ToWatchListContext")
        {

        }

        public DbSet<Rating> Rating { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<ToWatchList> ToWatchList { get; set; }
        public DbSet<TypeStatus> TypeStatus { get; set; }

    }
}