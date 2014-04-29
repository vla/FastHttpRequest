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
 * Created:2014/4/18 16:05:59
 * 
 * Class:SampleTest
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
    public class SampleTest : TestExcute
    {

        public override bool Off {
            get {
                return false;
            }
        }

        public override void Execute() {
            head_test();
            get_test();
            post_test();
            put_test();
            delete_test();
            patch_test();

            //测试timeout
            var param = new HttpHelper.HttpParam();
            param.Timeout = TimeSpan.FromSeconds(3);
            param.URL = "http://192.168.0.133:8002";
            param.Header = new System.Net.WebHeaderCollection();
            param.Header.Add("X_FORWARDED_FOR", "20.3.2.8");
            var rtl = HttpHelper.Request(param);

            body_test();
            upload_test();
            err_test();
        }

        void err_test() {
            string url = "http://localhost:3982/home/head2";

            lrTag("head_test  task", "=", 10);

            var rtl = HttpHelper.HeadInfo(url);
            Console.WriteLine(rtl.IsCanceled);
            Console.WriteLine(rtl.IsCompleted);
            Console.WriteLine(rtl.IsFaulted);
            Console.WriteLine(rtl.Exception);

        }

        void upload_test() {

            string url = "http://localhost:3982/home/upload";


            var parameters = new { name = "提交文件内容", age = 23 };

            var file = AppDomain.CurrentDomain.BaseDirectory + "/hello2.txt";
            File.WriteAllText(file, "hellp upload.上传内容.");

            var result = HttpHelper.Upload(url, new[] { new HttpHelper.NamedFileStream("t1", "hello2.txt", File.OpenRead(file)) }, parameters);
            var sr = new StreamReader(result.Result);
            Console.WriteLine(sr.ReadToEnd());

            Console.WriteLine(HttpHelper.UploadToString(url, new[] { new HttpHelper.NamedFileStream("t1", "hello2.txt", File.OpenRead(file)) }, parameters));
            Console.WriteLine(Encoding.UTF8.GetString(HttpHelper.UploadToBytes(url, new[] { new HttpHelper.NamedFileStream("t1", "hello2.txt", File.OpenRead(file)) }, parameters)));

            HttpHelper.Upload(url, new[] { new HttpHelper.NamedFileStream("t1", "hello21.txt", File.OpenRead(file)) }, (c) =>
            {
                var sr2 = new StreamReader(c.Result);
                Console.WriteLine(sr2.ReadToEnd());
            }, parameters, HttpHelper.HttpVerb.Post);

            HttpHelper.Upload(url, new[] { new HttpHelper.NamedFileStream("t1", "hello22.txt", File.OpenRead(file)) }, (string c) =>
            {
                Console.WriteLine(c);
            }, parameters, HttpHelper.HttpVerb.Post);
            HttpHelper.Upload(url, new[] { new HttpHelper.NamedFileStream("t1", "hello23.txt", File.OpenRead(file)) }, (byte[] c) =>
            {
                Console.WriteLine(Encoding.UTF8.GetString(c));
            }, parameters, HttpHelper.HttpVerb.Post);
        }

        void body_test() {
            string url = "http://localhost:3982/api/share";

            var json = "{\"Name\":\"JohnWu\",\"Age\":12}";
            lrTag("body_test", "=", 10);

            var result = HttpHelper.Body(url, new MemoryStream(Encoding.UTF8.GetBytes(json)), HttpHelper.HttpVerb.Post);
            var sr = new StreamReader(result.Result);

            Console.WriteLine(sr.ReadToEnd());
            Console.WriteLine(HttpHelper.BodyToString(url, new MemoryStream(Encoding.UTF8.GetBytes(json)), HttpHelper.HttpVerb.Post));
            Console.WriteLine(Encoding.UTF8.GetString(HttpHelper.BodyToBytes(url, new MemoryStream(Encoding.UTF8.GetBytes(json)), HttpHelper.HttpVerb.Post)));

            lrTag("body_test  async", "=", 10);


            HttpHelper.Body(url, new MemoryStream(Encoding.UTF8.GetBytes(json)), (c) =>
            {
                var sr2 = new StreamReader(c.Result);
                Console.WriteLine(sr2.ReadToEnd());
            }, HttpHelper.HttpVerb.Post);
            HttpHelper.Body(url, new MemoryStream(Encoding.UTF8.GetBytes(json)), (string c) =>
            {
                Console.WriteLine(c);
            }, HttpHelper.HttpVerb.Post);
            HttpHelper.Body(url, new MemoryStream(Encoding.UTF8.GetBytes(json)), (byte[] c) =>
            {
                Console.WriteLine(Encoding.UTF8.GetString(c));
            }, HttpHelper.HttpVerb.Post);
        }

        void head_test() {

            string url = "http://localhost:3982/home/head";

            lrTag("head_test  sync", "=", 10);

            var result = HttpHelper.HeadInfo(url);

            Console.WriteLine(result.StatusCode);
            Console.WriteLine("Header count:" + result.Header.Count);

            lrTag("head_test  async", "=", 10);


            HttpHelper.Head(url, (c) =>
            {
                Console.WriteLine(c.StatusCode);
                Console.WriteLine("Header count:" + c.Header.Count);
            });
        }

        void get_test() {

            string url = "http://localhost:3982/";

            lrTag("get_test  sync", "=", 10);

            var result = HttpHelper.Get(url);
            var sr = new StreamReader(result.Result);
            Console.WriteLine(sr.ReadToEnd());

            result = HttpHelper.Get(url, new { name = "Johnwu", age = 123 });
            sr = new StreamReader(result.Result);
            Console.WriteLine(sr.ReadToEnd());

            Console.WriteLine(HttpHelper.GetString(url));
            Console.WriteLine(HttpHelper.GetString(url, new { name = "Johnwu", age = 123 }));

            Console.WriteLine(Encoding.UTF8.GetString(HttpHelper.GetBytes(url)));
            Console.WriteLine(Encoding.UTF8.GetString(HttpHelper.GetBytes(url, new { name = "Johnwu", age = 123 })));

            lrTag("get_test  async", "=", 10);


            HttpHelper.Get(url, (c) =>
            {
                var sr2 = new StreamReader(c.Result);
                Console.WriteLine(sr2.ReadToEnd());
            });

            HttpHelper.Get(url, new { name = "Johnwu", age = 123 }, (c) =>
            {
                var sr2 = new StreamReader(c.Result);
                Console.WriteLine(sr2.ReadToEnd());
            });


            HttpHelper.Get(url, (string c) =>
            {
                Console.WriteLine(c);
            });

            HttpHelper.Get(url, new { name = "Johnwu", age = 123 }, (string c) =>
            {
                Console.WriteLine(c);
            });

            HttpHelper.Get(url, (byte[] c) =>
            {
                Console.WriteLine(Encoding.UTF8.GetString(c));
            });

            HttpHelper.Get(url, new { name = "Johnwu", age = 123 }, (byte[] c) =>
            {
                Console.WriteLine(Encoding.UTF8.GetString(c));
            });
        }
        void post_test() {

            string url = "http://localhost:3982/home/post";

            lrTag("post_test  sync", "=", 10);

            var result = HttpHelper.Post(url, new { name = "Johnwu", age = 123 });
            var sr = new StreamReader(result.Result);

            Console.WriteLine(sr.ReadToEnd());
            Console.WriteLine(HttpHelper.PostToString(url, new { name = "Johnwu", age = 123 }));
            Console.WriteLine(Encoding.UTF8.GetString(HttpHelper.PostToBytes(url, new { name = "Johnwu", age = 123 })));

            lrTag("post_test  async", "=", 10);


            HttpHelper.Post(url, new { name = "Johnwu", age = 123 }, (c) =>
            {
                var sr2 = new StreamReader(c.Result);
                Console.WriteLine(sr2.ReadToEnd());
            });
            HttpHelper.Post(url, new { name = "Johnwu", age = 123 }, (string c) =>
            {
                Console.WriteLine(c);
            });
            HttpHelper.Post(url, new { name = "Johnwu", age = 123 }, (byte[] c) =>
            {
                Console.WriteLine(Encoding.UTF8.GetString(c));
            });
        }

        void put_test() {

            string url = "http://localhost:3982/home/put";

            lrTag("put_test  sync", "=", 10);

            var result = HttpHelper.Put(url, new { name = "Johnwu", age = 123 });
            var sr = new StreamReader(result.Result);

            Console.WriteLine(sr.ReadToEnd());
            Console.WriteLine(HttpHelper.PutToString(url, new { name = "Johnwu", age = 123 }));
            Console.WriteLine(Encoding.UTF8.GetString(HttpHelper.PutToBytes(url, new { name = "Johnwu", age = 123 })));

            lrTag("put_test  async", "=", 10);


            HttpHelper.Put(url, new { name = "Johnwu", age = 123 }, (c) =>
            {
                var sr2 = new StreamReader(c.Result);
                Console.WriteLine(sr2.ReadToEnd());
            });
            HttpHelper.Put(url, new { name = "Johnwu", age = 123 }, (string c) =>
            {
                Console.WriteLine(c);
            });
            HttpHelper.Put(url, new { name = "Johnwu", age = 123 }, (byte[] c) =>
            {
                Console.WriteLine(Encoding.UTF8.GetString(c));
            });
        }

        void delete_test() {

            string url = "http://localhost:3982/home/Delete";

            lrTag("delete_test  sync", "=", 10);

            var result = HttpHelper.Delete(url, new { name = "Johnwu", age = 123 });
            var sr = new StreamReader(result.Result);

            Console.WriteLine(sr.ReadToEnd());
            Console.WriteLine(HttpHelper.DeleteToString(url, new { name = "Johnwu", age = 123 }));
            Console.WriteLine(Encoding.UTF8.GetString(HttpHelper.DeleteToBytes(url, new { name = "Johnwu", age = 123 })));

            lrTag("delete_test  async", "=", 10);


            HttpHelper.Delete(url, new { name = "Johnwu", age = 123 }, (c) =>
            {
                var sr2 = new StreamReader(c.Result);
                Console.WriteLine(sr2.ReadToEnd());
            });
            HttpHelper.Delete(url, new { name = "Johnwu", age = 123 }, (string c) =>
            {
                Console.WriteLine(c);
            });
            HttpHelper.Delete(url, new { name = "Johnwu", age = 123 }, (byte[] c) =>
            {
                Console.WriteLine(Encoding.UTF8.GetString(c));
            });
        }

        void patch_test() {

            string url = "http://localhost:3982/home/Patch";

            lrTag("patch_test  sync", "=", 10);

            var result = HttpHelper.Patch(url, new { name = "Johnwu", age = 123 });
            var sr = new StreamReader(result.Result);

            Console.WriteLine(sr.ReadToEnd());
            Console.WriteLine(HttpHelper.PatchToString(url, new { name = "Johnwu", age = 123 }));
            Console.WriteLine(Encoding.UTF8.GetString(HttpHelper.PatchToBytes(url, new { name = "Johnwu", age = 123 })));

            lrTag("patch_test  async", "=", 10);


            HttpHelper.Patch(url, new { name = "Johnwu", age = 123 }, (c) =>
            {
                var sr2 = new StreamReader(c.Result);
                Console.WriteLine(sr2.ReadToEnd());
            });
            HttpHelper.Patch(url, new { name = "Johnwu", age = 123 }, (string c) =>
            {
                Console.WriteLine(c);
            });
            HttpHelper.Patch(url, new { name = "Johnwu", age = 123 }, (byte[] c) =>
            {
                Console.WriteLine(Encoding.UTF8.GetString(c));
            });
        }
    }
}
