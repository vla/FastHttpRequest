#region Description

// ==++== 
//
//   Copyright (c) v.la Corporation.  All rights reserved.
//
// ==--== 
/* ---------------------------------------------------------------------------
 *
 * Author:JohnWu Email:v.la@Live.cn
 * 
 * Created:2014/4/17 22:33:40
 * 
 * Class:HttpHelperTest
 * 
 * Version:
 * 
 * Purpose:
 *
 * Edit Description
 *
 * ---------------------------------------------------------------------------
 * */

#endregion Description

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using HttpRequest;

namespace ConsoleTest
{
    public class HttpHelperTest : TestExcute
    {

        public override bool Off {
            get {
                return false;
            }
        }

        public override void Execute() {
            testReqest();
            uploadTest();
            async_body();
            sync_upload();
            sync_request();
            sync_body();
        }

        void async_body() {
            var json = "{\"Name\":\"JohnWu\",\"Age\":12}";
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            HttpHelper.Request(
             new HttpHelper.HttpParam()
             {
                 URL = "http://localhost:3982/api/share",
                 ContentType = "text/json",
                 Method = HttpHelper.HttpVerb.Post,

             }, ms,
              callback: (r) =>
              {
                  var sr = new StreamReader(r.Result);

                  Console.WriteLine("async_body \n" + sr.ReadToEnd());

                  r.Result.Close();
              }
          );
        }

        void sync_body() {
            HttpHelper.HttpParam param = new HttpHelper.HttpParam();
            param.URL = "http://localhost:3982/api/share";
            param.Method = HttpHelper.HttpVerb.Post;
            param.ContentType = "text/json";
            var json = "{\"Name\":\"JohnWu\",\"Age\":12}";
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            var r = HttpHelper.Request(param, ms);

            var sr = new StreamReader(r.Result);

            Console.WriteLine("sync_body \n" + sr.ReadToEnd());

            r.Result.Close();
        }

        void sync_upload() {
            HttpHelper.HttpParam param = new HttpHelper.HttpParam();
            param.URL = "http://localhost:3982/home/upload";
            param.Method = HttpHelper.HttpVerb.Post;
            param.Parameters = new { name = "提交文件内容", age = 23 };
            var file = AppDomain.CurrentDomain.BaseDirectory + "/hello2.txt";

            File.WriteAllText(file, "hellp upload.上传内容.");

            var r = HttpHelper.Request(param, new[] { new HttpHelper.NamedFileStream("t1", "hello2.txt", File.OpenRead(file)) });

            File.Delete(file);

            var sr = new StreamReader(r.Result);

            Console.WriteLine("sync_upload \n" + sr.ReadToEnd());

            r.Result.Close();
        }

        void sync_request() {
            var r = HttpHelper.Request(
          new HttpHelper.HttpParam()
          {
              URL = "http://localhost:3982/home/index",
              ContentType = "application/x-www-form-urlencoded",
              Method = HttpHelper.HttpVerb.Get,
              Parameters = new { name = "Get  阿斯顿", age = 23 }

          }
       );
            using (r.Result) {
                var sr = new StreamReader(r.Result);

                Console.WriteLine("sync_request \n" + sr.ReadToEnd());

            }

            r = HttpHelper.Request(
                  new HttpHelper.HttpParam()
                  {
                      URL = "http://localhost:3982/home/post",
                      ContentType = "application/x-www-form-urlencoded",
                      Method = HttpHelper.HttpVerb.Post,
                      Parameters = new { name = "Post 阿斯顿", age = 23 }
                  }
             );

            var sr2 = new StreamReader(r.Result);

            Console.WriteLine("sync_request \n" + sr2.ReadToEnd());

            r.Result.Close();
        }

        void uploadTest() {
            HttpHelper.HttpParam param = new HttpHelper.HttpParam();
            param.URL = "http://localhost:3982/home/upload";
            param.Method = HttpHelper.HttpVerb.Post;
            param.Parameters = new { name = "提交文件内容", age = 23 };
            var file = AppDomain.CurrentDomain.BaseDirectory + "/hello.txt";

            File.WriteAllText(file, "hellp upload.上传内容.");

            HttpHelper.Request(param, new[] { new HttpHelper.NamedFileStream("t1", "hello.txt", File.OpenRead(file)) },
            callback: (r) =>
            {
                File.Delete(file);

                var sr = new StreamReader(r.Result);

                Console.WriteLine("uploadTest \n" + sr.ReadToEnd());

                r.Result.Close();
            });
        }

        void testReqest() {

            HttpHelper.Request(
           new HttpHelper.HttpParam()
           {
               URL = "http://localhost:3982/home/index",
               ContentType = "application/x-www-form-urlencoded",
               Method = HttpHelper.HttpVerb.Get,
               Parameters = new { name = "Get  阿斯顿", age = 23 }

           },
            callback: (r) =>
            {
                var sr = new StreamReader(r.Result);

                Console.WriteLine("testReqest \n" + sr.ReadToEnd());

                r.Result.Close();
            }
        );

            HttpHelper.Request(
                  new HttpHelper.HttpParam()
                  {
                      URL = "http://localhost:3982/home/post",
                      ContentType = "application/x-www-form-urlencoded",
                      Method = HttpHelper.HttpVerb.Post,
                      Parameters = new { name = "Post 阿斯顿", age = 23 }
                  },
             callback: (r) =>
             {
                 var sr = new StreamReader(r.Result);

                 Console.WriteLine("testReqest \n" + sr.ReadToEnd());

                 r.Result.Close();
             }
             );
        }
    }
}
