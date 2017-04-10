using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace test
{
    class Program
    {
        public class Product
        {
            public int Id { get; set; }

            ////public string Name { get; set; }

            public string Category { get; set; }

            public decimal Price { get; set; }
        }

        public class User
        {
            public int id { get; set; }

            public string name { get; set; }
        }

        public class Result
        {
            public string Flag { get; set; }

            public string Error { get; set; }

            public List<User> Data { get; set; }
        }

        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            var parameters = new Dictionary<string, string>
            {
                {"id","3" },
                {"name", "eeee"}
            };

            //2、3、4采用的EF的方式操作数据库
            #region 直接查询数据集合

            //var back = client.GetAsync(string.Format("http://localhost:64104/api/Product/GetProduct/{0}", 1)).Result.Content.ReadAsStringAsync()
            //        .Result;

            #endregion


            #region 采用的EF的方式操作数据库

            //查询数据库中User的数据集合同时把JSON转成List对象
            //var back = client.GetAsync("http://localhost:64104/api/User/GetUserList").Result.Content.ReadAsStringAsync()
            //        .Result;
            //var confirmResult =
            //  JsonConvert.DeserializeObject<List<User>>(back);

            var back = client.GetAsync("http://localhost:64104/api/User/GetListToJson").Result.Content.ReadAsStringAsync()
                    .Result;
            var confirmResult =
              JsonConvert.DeserializeObject<Result>(back);
            //往数据库中的User添加一条记录信息
            //var back =
            //    client.PostAsync("http://localhost:64104/api/User/AddUser", new FormUrlEncodedContent(parameters))
            //        .Result.Content.ReadAsStringAsync()
            //        .Result;

            //对数据库中的User删除一条记录信息
            //var back =
            //    client.PostAsync("http://localhost:64104/api/User/DelUser", new FormUrlEncodedContent(parameters))
            //        .Result.Content.ReadAsStringAsync()
            //        .Result;

            //更新数据库User表中的记录信息
            //var back =
            // client.PostAsync("http://localhost:64104/api/User/UpdateUser", new FormUrlEncodedContent(parameters))
            //     .Result.Content.ReadAsStringAsync()
            //     .Result;

            #endregion


            //var back =
            //    client.GetAsync("http://localhost:64104/api/Log/LogList").Result.Content.ReadAsStringAsync().Result;


        }
    }
}
