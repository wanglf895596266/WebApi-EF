using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi.DAL
{
    public class Entity<TPrimaryKey>:IEntiey<TPrimaryKey>
    {
        public virtual TPrimaryKey id { get; set; }
        
    }

    public interface IEntiey<TPrimaryKey>
    {
        TPrimaryKey id { get; set; }
    }

}