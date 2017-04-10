using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using webapi.DAL;
using webapi.Models;

namespace webapi.Controllers
{
    public class UserController : ApiController
    {
        //EF方式操作数据库，操作步骤：
        //----------------
        //----------------
        //1、在项目中NuGet包中添加EntityFrameWork
        //2、定义一个类例如DAL下的User，表示数据库中要新建的表
        //3、定义一个Map类如Mapping下的UserMap,继承自EntityTypeConfiguration，在构造函数中设置表名及其列约束
        //4、在Web.config中添加一个连接字符串
        //5、定义一个类例如DAL下的AccountContext,构造函数指定刚添加的连接字符串，同时继承自System.Data.Entity.DbContext,通常用这个类来完成EF操作
        //   在这个类中实现OnModelCreating这个方法的主体。
        //6、打开工具->NuGet包管理器->程序包管理器
        //   执行命令：Enable-Migrations， 打开Migrations文件夹
        //   执行命令：Update-Database，初始化数据库，
        //   如果执行失败,执行命令：Add-Migration addFirst，来进行第一次数据迁移操作后，重新执行updata-database操作。
        //以上操作就完成数据库的初始化操作。
        //----------------
        //----------------

        //EF数据迁移操作：
        //--------------
        //--------------
        //打开工具->NuGet包管理器->程序包管理器
        //执行命令：Add-Migration addtest1，添加一次数据迁移操作
        //执行命令：Update-Database，更新数据库信息
        private AccountContext DbContext = new AccountContext();

        [System.Web.Http.HttpGet]
        public IEnumerable<UserModel> GetUserList()
        {
            return DbContext.UserList.ToList().Select(t => new UserModel
            {
                id = t.id,
                name = t.name
            });
            //var list = DbContext.UserList.SqlQuery("select top 1 * from Users").ToList().Select(t => new UserModel
            //{
            //    id=t.id,
            //    name=t.name
            //});
            //return list;
        }

        public Result<List<UserModel>> GetListToJson()
        {
            var model = DbContext.UserList.ToList().Select(t => new UserModel
            {
                id = t.id,
                name = t.name
            }).ToList();

            var result = new Result<List<UserModel>>
            {
                Flag = "1",
                Data = model
            };
            return  result;
        }

        [System.Web.Http.HttpPost]
        public Result<String> AddUser(UserModel model)
        {
            var result = new Result<string>();
            try
            {
                var user = new User();
                user.name = model.name;
                DbContext.UserList.Add(user);
                DbContext.SaveChanges();
                result.Flag = "成功";
                return result;
            }
            catch (Exception ex)
            {
                result.Flag = "失败";
                result.Error = ex.Message;
                return result;
            }
           
        }

        [System.Web.Http.HttpPost]
        public Result<String> DelUser(UserModel model)
        {
            var result = new Result<String>();
            try
            {
                var user = DbContext.UserList.FirstOrDefault(t=>t.name==model.name);
                DbContext.UserList.Remove(user);
                DbContext.SaveChanges();
                result.Flag = "成功";
                return result;
            }
            catch (Exception ex)
            {
                result.Flag = "失败";
                result.Error = ex.Message;
                return result;
            }
        }

        [System.Web.Http.HttpPost]
        public Result<String> UpdateUser(UserModel model)
        {
            var result = new Result<String>();
            try
            {
                var user = DbContext.UserList.FirstOrDefault(t => t.id == model.id);
                user.name = model.name;
                DbContext.SaveChanges();
                result.Flag = "成功";
                return result;
            }
            catch (Exception ex)
            {
                result.Flag = "失败";
                result.Error = ex.Message;
                return result;
            }
        }
    }
}
