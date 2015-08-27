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
 * Created:2014/4/21 22:16:36
 * 
 * Class:TaskTest
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
    public class TaskTest : TestExcute
    {

        public override bool Off {
            get {
                return base.Off;
            }
        }


        public override void Execute() {
            head_test();
            get_test();
            post_test();
            put_test();
            delete_test();
            patch_test();
            body_test();
            upload_test();
            err_test();
        }

        void err_test() {
            string url = "http://localhost:3982/home/head2";

            lrTag("head_test  task", "=", 10);

            var task = HttpHelper.HeadTask(url).ContinueWith(x =>
            {

                if (x.IsFaulted || x.Exception != null) {
                    var agg = x.Exception as AggregateException;
                    foreach (var ex in agg.InnerExceptions) {
                        Console.WriteLine(ex);
                    }
                }
            });

        }

        private void head_test() {
            string url = "http://localhost:3982/home/head";

            lrTag("head_test  task", "=", 10);

            Console.WriteLine(HttpHelper.HeadTask(url).Result.StatusCode);
        }

        private void upload_test() {
            string url = "http://localhost:3982/home/Upload";

            var parameters = new { name = "提交文件内容", age = 23 };

            var file = AppDomain.CurrentDomain.BaseDirectory + "/hello2.txt";
            File.WriteAllText(file, "hellp upload.上传内容.");

            HttpHelper.UploadTask(
                url,
                new[] { new HttpHelper.NamedFileStream("t1", "hello2.txt", File.OpenRead(file)) },
                parameters,
                method: HttpHelper.HttpVerb.Post)
                .ContinueWith(x =>
                {
                    Console.WriteLine(x.Result.ToStringResult());
                });
        }

        private void body_test() {
            string url = "http://localhost:3982/api/share/index";
            var json = "{\"Name\":\"JohnWu\",\"Age\":12}";
            lrTag("body_test", "=", 10);
            HttpHelper.BodyTask(url, new MemoryStream(Encoding.UTF8.GetBytes(json)), HttpHelper.HttpVerb.Post).ContinueWith(x =>
            {

                Console.WriteLine(x.Result.ToStringResult());
            }); ;
        }

        private void patch_test() {
            string url = "http://localhost:3982/home/patch";

            lrTag("patch_test  task", "=", 10);

            HttpHelper.PatchTask(url, new { name = "Johnwu", age = 123 }).ContinueWith(x =>
            {

                Console.WriteLine(x.Result.ToStringResult());
            });
        }

        private void delete_test() {
            string url = "http://localhost:3982/home/delete";

            lrTag("delete_test  task", "=", 10);

            HttpHelper.DeleteTask(url, new { name = "Johnwu", age = 123 }).ContinueWith(x =>
            {
                Console.WriteLine(x.Result.ToStringResult());
            });
        }

        private void put_test() {
            string url = "http://localhost:3982/home/put";

            lrTag("put_test  task", "=", 10);

            HttpHelper.PutTask(url, new { name = "Johnwu", age = 123 }).ContinueWith(x =>
            {

                Console.WriteLine(x.Result.ToStringResult());
            });
        }

        private void post_test() {
            string url = "http://localhost:3982/home/post";

            lrTag("post_test  task", "=", 10);

            HttpHelper.PostTask(url, new { name = "Johnwu", age = 123 }).ContinueWith(x =>
            {

                Console.WriteLine(x.Result.ToStringResult());
            });
        }

        private void get_test() {

            string url = "http://localhost:3982/";

            lrTag("get_test  task", "=", 10);

            HttpHelper.GetTask(url).ContinueWith(x =>
            {
                Console.WriteLine(x.Result.ToStringResult());
            });

            HttpHelper.GetTask(url, new { name = "Johnwu", age = 123 }).ContinueWith(x =>
            {
                Console.WriteLine(x.Result.ToStringResult());
            });

        }
    }
}
