using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using webapi.DAL;

namespace webapi.Mapping
{
    public class LogMap : EntityTypeConfiguration<Log>
    {
        public LogMap()
        {
            this.ToTable("Log");
            this.HasKey(l => l.id);
            this.Ignore(l => l.LogLevel);
            this.HasOptional(l => l.User)
                .WithMany()
                .HasForeignKey(l => l.UserId)
                .WillCascadeOnDelete(true);//表示级联删除，当主表记录删除时附表记录也删除
        }
    }
}