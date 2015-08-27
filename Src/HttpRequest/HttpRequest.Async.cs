#region Description

// ==++==
//
// FastHttpRequest Application Development Framework
// Copyright (C) 2010-2014 v.la@live.cn
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// ==--==
/* ---------------------------------------------------------------------------
 *
 * Author:JohnWu Email:v.la@Live.cn
 *
 * Created:2014/4/18 14:14:57
 *
 * Class:HttpHelper.Async
 *
 * Version:1.0
 *
 * Purpose:
 * 
 * 提供简单快速的Http异步请求
 *
 * Edit Description
 *
 * ---------------------------------------------------------------------------
 * */

#endregion Description

using System;
using System.Collections;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequest
{
    /// <summary>
    ///  Http连接操作帮助类
    /// </summary>
    public partial class HttpHelper
    {

        #region 支持基于任务方式

        #region Get

        /// <summary>
        /// Http异步请求Get方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        /// <returns>Task</returns>
        public static Task<HttpResult> GetTask(string url, string contentType = "", WebHeaderCollection header = null) {
            return _TaskRq(url, HttpVerb.Get, contentType, header);
        }

        /// <summary>
        /// Http异步请求Get方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        /// <returns>Task</returns>
        public static Task<HttpResult> GetTask(string url, object parameters, string contentType = "", WebHeaderCollection header = null) {
            return _TaskRq(url, parameters, HttpVerb.Get, contentType, header);
        }

        #endregion Get

        #region Head

        /// <summary>
        /// Http异步请求Head方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="header"></param>
        public static Task<HttpResult> HeadTask(string url, WebHeaderCollection header = null) {
            return _TaskRq(url, HttpVerb.Head, string.Empty, header);
        }

        #endregion Head

        #region Post

        /// <summary>
        /// Http异步请求Post方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        /// <returns>Task</returns>
        public static Task<HttpResult> PostTask(string url, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            return _TaskRq(url, HttpVerb.Post, contentType, header);
        }

        /// <summary>
        /// Http异步请求Post方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        /// <returns>Task</returns>
        public static Task<HttpResult> PostTask(string url, object parameters, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            return _TaskRq(url, parameters, HttpVerb.Post, contentType, header);
        }

        #endregion Post

        #region Put

        /// <summary>
        /// Http异步请求Put方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        /// <returns>Task</returns>
        public static Task<HttpResult> PutTask(string url, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            return _TaskRq(url, HttpVerb.Put, contentType, header);
        }

        /// <summary>
        /// Http异步请求Put方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        /// <returns>Task</returns>
        public static Task<HttpResult> PutTask(string url, object parameters, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            return _TaskRq(url, parameters, HttpVerb.Put, contentType, header);
        }

        #endregion Put

        #region Delete

        /// <summary>
        /// Http异步请求Delete方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        /// <returns>Task</returns>
        public static Task<HttpResult> DeleteTask(string url, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            return _TaskRq(url, HttpVerb.Delete, contentType, header);
        }

        /// <summary>
        /// Http异步请求Delete方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        /// <returns>Task</returns>
        public static Task<HttpResult> DeleteTask(string url, object parameters, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            return _TaskRq(url, parameters, HttpVerb.Delete, contentType, header);
        }

        #endregion Delete

        #region Patch

        /// <summary>
        /// Http异步请求Patch方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        /// <returns>Task</returns>
        public static Task<HttpResult> PatchTask(string url, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            return _TaskRq(url, HttpVerb.Patch, contentType, header);
        }

        /// <summary>
        /// Http异步请求Patch方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        /// <returns>Task</returns>
        public static Task<HttpResult> PatchTask(string url, object parameters, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            return _TaskRq(url, parameters, HttpVerb.Patch, contentType, header);
        }

        #endregion Patch

        #region Body

        /// <summary>
        /// Http异步请求发送 Body
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="body">Body</param>
        /// <param name="method">请求方法</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        /// <returns>Task</returns>
        public static Task<HttpResult> BodyTask(string url, Stream body, HttpVerb method = HttpVerb.Get, string contentType = "text/json", WebHeaderCollection header = null) {
            var cts = new TaskCompletionSource<HttpResult>();
            Request(new HttpParam { URL = url, Method = method, ContentType = contentType, Header = header }, body, (result) =>
            {
                if (result.IsFaulted)
                    cts.SetException(result.Exception);
                else if (result.IsCanceled)
                    cts.SetCanceled();
                else if (result.IsCompleted)
                    cts.SetResult(result);
            });
            return cts.Task;
        }

        #endregion Body

        #region Upload

        /// <summary>
        /// 异步上传文件
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="files">文件信息</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="method">请求方法</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">header</param>
        /// <returns>Task</returns>
        public static Task<HttpResult> UploadTask(string url, NamedFileStream[] files, object parameters = null, HttpVerb method = HttpVerb.Post, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            var cts = new TaskCompletionSource<HttpResult>();
            Request(new HttpParam { URL = url, Parameters = parameters, Method = method, ContentType = contentType, Header = header }, files, (result) =>
            {
                if (result.IsFaulted)
                    cts.SetException(result.Exception);
                else if (result.IsCanceled)
                    cts.SetCanceled();
                else if (result.IsCompleted)
                    cts.SetResult(result);
            });
            return cts.Task;
        }

        #endregion Upload

        #region _TaskRq 提供一组供给 Get Head Post 等模板函数

        private static Task<HttpResult> _TaskRq(string url, HttpVerb method, string contentType, WebHeaderCollection header) {
            var cts = new TaskCompletionSource<HttpResult>();
            Request(new HttpParam { URL = url, Method = method, ContentType = contentType, Header = header }, (result) =>
            {
                if (result.IsFaulted)
                    cts.SetException(result.Exception);
                else if (result.IsCanceled)
                    cts.SetCanceled();
                else if (result.IsCompleted)
                    cts.SetResult(result);
            });
            return cts.Task;
        }

        private static Task<HttpResult> _TaskRq(string url, object parameters, HttpVerb method, string contentType, WebHeaderCollection header) {
            var cts = new TaskCompletionSource<HttpResult>();
            Request(new HttpParam { URL = url, Parameters = parameters, Method = method, ContentType = contentType, Header = header }, (result) =>
            {
                if (result.IsFaulted)
                    cts.SetException(result.Exception);
                else if (result.IsCanceled)
                    cts.SetCanceled();
                else if (result.IsCompleted)
                    cts.SetResult(result);
            });
            return cts.Task;
        }

        #endregion _AsyncRq 提供一组供给 Get Head Post 等模板函数

        #endregion

        #region 支持异步方式

        #region Get

        /// <summary>
        /// Http异步请求Get方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="callback">回调函数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        public static void Get(string url, Action<string> callback, string contentType = "", WebHeaderCollection header = null) {
            _AsyncRq(url, callback, HttpVerb.Get, contentType, header);
        }

        /// <summary>
        /// Http异步请求Get方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="callback">回调函数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        public static void Get(string url, object parameters, Action<string> callback, string contentType = "", WebHeaderCollection header = null) {
            _AsyncRq(url, parameters, callback, HttpVerb.Get, contentType, header);
        }

        /// <summary>
        /// Http异步请求Get方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="callback">回调函数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        public static void Get(string url, Action<byte[]> callback, string contentType = "", WebHeaderCollection header = null) {
            _AsyncRq(url, callback, HttpVerb.Get, contentType, header);
        }

        /// <summary>
        /// Http异步请求Get方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="callback">回调函数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        public static void Get(string url, object parameters, Action<byte[]> callback, string contentType = "", WebHeaderCollection header = null) {
            _AsyncRq(url, parameters, callback, HttpVerb.Get, contentType, header);
        }

        /// <summary>
        /// Http异步请求Get方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="callback">回调函数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        public static void Get(string url, Action<HttpResult> callback, string contentType = "", WebHeaderCollection header = null) {
            _AsyncRq(url, callback, HttpVerb.Get, contentType, header);
        }

        /// <summary>
        /// Http异步请求Get方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="callback">回调函数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        public static void Get(string url, object parameters, Action<HttpResult> callback, string contentType = "", WebHeaderCollection header = null) {
            _AsyncRq(url, parameters, callback, HttpVerb.Get, contentType, header);
        }

        #endregion Get

        #region Head

        /// <summary>
        /// Http异步请求Head方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="callback">回调函数</param>
        /// <param name="header"></param>
        public static void Head(string url, Action<HttpResult> callback, WebHeaderCollection header = null) {
            _AsyncRq(url, callback, HttpVerb.Head, string.Empty, header);
        }

        #endregion Head

        #region Post

        /// <summary>
        /// Http异步请求Post方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="callback">回调函数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        public static void Post(string url, object parameters, Action<string> callback, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            _AsyncRq(url, parameters, callback, HttpVerb.Post, contentType, header);
        }

        /// <summary>
        /// Http异步请求Post方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="callback">回调函数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        public static void Post(string url, object parameters, Action<byte[]> callback, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            _AsyncRq(url, parameters, callback, HttpVerb.Post, contentType, header);
        }

        /// <summary>
        /// Http异步请求Post方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="callback">回调函数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        public static void Post(string url, object parameters, Action<HttpResult> callback, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            _AsyncRq(url, parameters, callback, HttpVerb.Post, contentType, header);
        }

        #endregion Post

        #region Put

        /// <summary>
        /// Http异步请求Put方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="callback">回调函数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        public static void Put(string url, Action<string> callback, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            _AsyncRq(url, callback, HttpVerb.Put, contentType, header);
        }

        /// <summary>
        /// Http异步请求Put方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="callback">回调函数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        public static void Put(string url, object parameters, Action<string> callback, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            _AsyncRq(url, parameters, callback, HttpVerb.Put, contentType, header);
        }

        /// <summary>
        /// Http异步请求Put方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="callback">回调函数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        public static void Put(string url, Action<byte[]> callback, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            _AsyncRq(url, callback, HttpVerb.Put, contentType, header);
        }

        /// <summary>
        /// Http异步请求Put方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="callback">回调函数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        public static void Put(string url, object parameters, Action<byte[]> callback, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            _AsyncRq(url, parameters, callback, HttpVerb.Put, contentType, header);
        }

        /// <summary>
        /// Http异步请求Put方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="callback">回调函数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        public static void Put(string url, Action<HttpResult> callback, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            _AsyncRq(url, callback, HttpVerb.Put, contentType, header);
        }

        /// <summary>
        /// Http异步请求Put方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="callback">回调函数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        public static void Put(string url, object parameters, Action<HttpResult> callback, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            _AsyncRq(url, parameters, callback, HttpVerb.Put, contentType, header);
        }

        #endregion Put

        #region Delete

        /// <summary>
        /// Http异步请求Delete方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="callback">回调函数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        public static void Delete(string url, Action<string> callback, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            _AsyncRq(url, callback, HttpVerb.Delete, contentType, header);
        }

        /// <summary>
        /// Http异步请求Delete方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="callback">回调函数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        public static void Delete(string url, object parameters, Action<string> callback, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            _AsyncRq(url, parameters, callback, HttpVerb.Delete, contentType, header);
        }

        /// <summary>
        /// Http异步请求Delete方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="callback">回调函数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        public static void Delete(string url, Action<byte[]> callback, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            _AsyncRq(url, callback, HttpVerb.Delete, contentType, header);
        }

        /// <summary>
        /// Http异步请求Delete方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="callback">回调函数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        public static void Delete(string url, object parameters, Action<byte[]> callback, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            _AsyncRq(url, parameters, callback, HttpVerb.Delete, contentType, header);
        }

        /// <summary>
        /// Http异步请求Delete方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="callback">回调函数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        public static void Delete(string url, Action<HttpResult> callback, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            _AsyncRq(url, callback, HttpVerb.Delete, contentType, header);
        }

        /// <summary>
        /// Http异步请求Delete方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="callback">回调函数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        public static void Delete(string url, object parameters, Action<HttpResult> callback, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            _AsyncRq(url, parameters, callback, HttpVerb.Delete, contentType, header);
        }

        #endregion Delete

        #region Patch

        /// <summary>
        /// Http异步请求Patch方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="callback">回调函数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        public static void Patch(string url, Action<string> callback, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            _AsyncRq(url, callback, HttpVerb.Patch, contentType, header);
        }

        /// <summary>
        /// Http异步请求Patch方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="callback">回调函数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        public static void Patch(string url, object parameters, Action<string> callback, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            _AsyncRq(url, parameters, callback, HttpVerb.Patch, contentType, header);
        }

        /// <summary>
        /// Http异步请求Patch方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="callback">回调函数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        public static void Patch(string url, Action<byte[]> callback, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            _AsyncRq(url, callback, HttpVerb.Patch, contentType, header);
        }

        /// <summary>
        /// Http异步请求Patch方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="callback">回调函数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        public static void Patch(string url, object parameters, Action<byte[]> callback, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            _AsyncRq(url, parameters, callback, HttpVerb.Patch, contentType, header);
        }

        /// <summary>
        /// Http异步请求Patch方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="callback">回调函数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        public static void Patch(string url, Action<HttpResult> callback, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            _AsyncRq(url, callback, HttpVerb.Patch, contentType, header);
        }

        /// <summary>
        /// Http异步请求Patch方法
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="callback">回调函数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        public static void Patch(string url, object parameters, Action<HttpResult> callback, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            _AsyncRq(url, parameters, callback, HttpVerb.Patch, contentType, header);
        }

        #endregion Patch

        #region Body

        /// <summary>
        /// Http异步请求发送 Body
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="body">Body</param>
        /// <param name="callback">回调函数</param>
        /// <param name="method">请求方法</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        public static void Body(string url, Stream body, Action<HttpResult> callback, HttpVerb method = HttpVerb.Get, string contentType = "text/json", WebHeaderCollection header = null) {
            Request(new HttpParam { URL = url, Method = method, ContentType = contentType, Header = header }, body, callback);
        }

        /// <summary>
        /// Http异步请求发送 Body
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="body">Body</param>
        /// <param name="callback">回调函数</param>
        /// <param name="method">请求方法</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        public static void Body(string url, Stream body, Action<string> callback, HttpVerb method = HttpVerb.Get, string contentType = "text/json", WebHeaderCollection header = null) {
            Request(new HttpParam { URL = url, Method = method, ContentType = contentType, Header = header }, body, StreamToStringCallback(callback));
        }

        /// <summary>
        /// Http异步请求发送 Body
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="body">Body</param>
        /// <param name="callback">回调函数</param>
        /// <param name="method">请求方法</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header"></param>
        public static void Body(string url, Stream body, Action<byte[]> callback, HttpVerb method = HttpVerb.Get, string contentType = "text/json", WebHeaderCollection header = null) {
            Request(new HttpParam { URL = url, Method = method, ContentType = contentType, Header = header }, body, StreamToBytesCallback(callback));
        }

        #endregion Body

        #region Upload

        /// <summary>
        /// 异步上传文件
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="files">文件信息</param>
        /// <param name="callback">回调函数</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="method">请求方法</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">header</param>
        public static void Upload(string url, NamedFileStream[] files, Action<HttpResult> callback, object parameters = null, HttpVerb method = HttpVerb.Post, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            Request(new HttpParam { URL = url, Parameters = parameters, Method = method, ContentType = contentType, Header = header }, files, callback);
        }

        /// <summary>
        /// 异步上传文件
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="files">文件信息</param>
        /// <param name="callback">回调函数</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="method">请求方法</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">header</param>
        public static void Upload(string url, NamedFileStream[] files, Action<string> callback, object parameters = null, HttpVerb method = HttpVerb.Post, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            Request(new HttpParam { URL = url, Parameters = parameters, Method = method, ContentType = contentType, Header = header }, files, StreamToStringCallback(callback));
        }

        /// <summary>
        /// 异步上传文件
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="files">文件信息</param>
        /// <param name="callback">回调函数</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="method">请求方法</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">header</param>
        public static void Upload(string url, NamedFileStream[] files, Action<byte[]> callback, object parameters = null, HttpVerb method = HttpVerb.Post, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            Request(new HttpParam { URL = url, Parameters = parameters, Method = method, ContentType = contentType, Header = header }, files, StreamToBytesCallback(callback));
        }

        #endregion Upload

        #region _AsyncRq 提供一组供给 Get Head Post 等模板函数

        private static void _AsyncRq(string url, Action<string> callback, HttpVerb method, string contentType, WebHeaderCollection header) {
            Request(new HttpParam { URL = url, Method = method, ContentType = contentType, Header = header }, StreamToStringCallback(callback));
        }

        private static void _AsyncRq(string url, object parameters, Action<string> callback, HttpVerb method, string contentType, WebHeaderCollection header) {
            Request(new HttpParam { URL = url, Parameters = parameters, Method = method, ContentType = contentType, Header = header }, StreamToStringCallback(callback));
        }

        private static void _AsyncRq(string url, Action<byte[]> callback, HttpVerb method, string contentType, WebHeaderCollection header) {
            Request(new HttpParam { URL = url, Method = method, ContentType = contentType, Header = header }, StreamToBytesCallback(callback));
        }

        private static void _AsyncRq(string url, object parameters, Action<byte[]> callback, HttpVerb method, string contentType, WebHeaderCollection header) {
            Request(new HttpParam { URL = url, Parameters = parameters, Method = method, ContentType = contentType, Header = header }, StreamToBytesCallback(callback));
        }

        private static void _AsyncRq(string url, Action<HttpResult> callback, HttpVerb method, string contentType, WebHeaderCollection header) {
            Request(new HttpParam { URL = url, Method = method, ContentType = contentType, Header = header }, callback);
        }

        private static void _AsyncRq(string url, object parameters, Action<HttpResult> callback, HttpVerb method, string contentType, WebHeaderCollection header) {
            Request(new HttpParam { URL = url, Parameters = parameters, Method = method, ContentType = contentType, Header = header }, callback);
        }

        #endregion _AsyncRq 提供一组供给 Get Head Post 等模板函数

        #endregion

        #region Request

        /// <summary>
        /// Http异步请求发送
        /// </summary>
        /// <param name="httpParam">请求参数</param>
        /// <param name="files">文件上传的信息</param>
        /// <param name="callback">返回请求响应结果回调</param>
        /// <param name="userState">状态</param>
        public static void Request(HttpParam httpParam, NamedFileStream[] files, Action<HttpResult, object> callback, object userState) {
            Request(httpParam, files, (result) => callback(result, userState));
        }

        /// <summary>
        /// Http异步请求发送
        /// </summary>
        /// <param name="httpParam">请求参数</param>
        /// <param name="files">文件上传的信息</param>
        /// <param name="callback">返回请求响应结果回调</param>
        public static void Request(HttpParam httpParam, NamedFileStream[] files, Action<HttpResult> callback) {
            if (httpParam == null) {
                throw new ArgumentException("httpParam not null");
            }

            if (httpParam.Method != HttpVerb.Post && httpParam.Method != HttpVerb.Put) {
                throw new ArgumentException("Request method must be POST or PUT");
            }

            if (string.IsNullOrWhiteSpace(httpParam.URL)) {
                throw new ArgumentException("url not null");
            }

            //使用回调的方法进行证书验证。
            if (httpParam.RemoteCertificateValidationCallback != null)
                ServicePointManager.ServerCertificateValidationCallback = httpParam.RemoteCertificateValidationCallback;

            Encoding encoding = DefaultEncoding;

            if (httpParam.Encoding != null)
                encoding = httpParam.Encoding;

            if (files.Length == 0)
                throw new ArgumentException("files is empty");

            HttpWebRequest request = null;

            //设置分界线
            string boundary = RandomString(12);

            try {
                request = (HttpWebRequest)HttpWebRequest.Create(new Uri(httpParam.URL));

                SetRequest(request, httpParam);

                request.ContentType = "multipart/form-data; boundary=" + boundary;

                //开始异步请求
                request.BeginGetRequestStream(new AsyncCallback((callbackResult) =>
                {
                    HttpWebRequest _request = (HttpWebRequest)callbackResult.AsyncState;

                    var requestStream = _request.EndGetRequestStream(callbackResult);

                    //转化网络流对象进行直接射入，省内存
                    using (StreamWriter writer = new StreamWriter(requestStream, encoding)) {
                        try {
                            IDictionary postbody = SerializeQuery(httpParam.Parameters);

                            string newLine = "\r\n";

                            //处理form-data
                            if (postbody != null) {
                                foreach (string key in postbody.Keys) {
                                    if (postbody[key] != null) {
                                        writer.Write("--" + boundary + newLine);
                                        writer.Write("Content-Disposition: form-data; name=\"{0}\"{1}{1}", key, newLine);
                                        writer.Write(postbody[key] + newLine);
                                        writer.Flush();
                                    }
                                }
                            }

                            //处理文件流
                            foreach (var file in files) {
                                writer.Write("--" + boundary + newLine);
                                writer.Write(
                                    "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"{2}",
                                    file.Name,
                                    file.FileName,
                                    newLine
                                    );
                                writer.Write("Content-Type: application/octet-stream" + newLine + newLine);
                                writer.Flush();

                                //复制文件流到Body
                                CopyStream(file.Stream, requestStream);

                                writer.Write(newLine);
                                writer.Write("--" + boundary + newLine);
                                writer.Flush();
                            }
                        } catch (Exception ex) {
                            requestStream.Dispose();
                            ProcessFailCallback(callback, ex);
                            return;
                        } finally {
                            //使用完后释放
                            foreach (var file in files)
                                if (file.Stream != null)
                                    file.Stream.Dispose();
                        }
                    }

                    //异步接收响应，并且设置一个超时时间
                    IAsyncResult asyncResult = _request.BeginGetResponse(null, _request);
                    asyncResult.FromAsync((ia, isTimeout) =>
                    {
                        if (isTimeout) {
                            ProcessFailCallback(callback, new TimeoutException("Connection Timeout"));
                        } else {
                            ProcessCallback(ia, callback);
                        }
                    }, httpParam.Timeout);

                }), request);
            } catch (WebException exception) {
                //遇到异常时候再次释放一次，防止内存泄漏
                foreach (var file in files)
                    if (file.Stream != null)
                        file.Stream.Dispose();
                if (request != null)
                    request.Abort();
                ProcessFailCallback(callback, exception);
            }
        }

        /// <summary>
        /// Http异步请求发送
        /// </summary>
        /// <param name="httpParam">请求参数</param>
        /// <param name="callback">返回请求响应结果回调</param>
        /// <param name="userState">状态</param>
        public static void Request(HttpParam httpParam, Action<HttpResult, object> callback, object userState) {
            Request(httpParam, (result) => callback(result, userState));
        }

        /// <summary>
        /// Http异步请求发送
        /// </summary>
        /// <param name="httpParam">请求参数</param>
        /// <param name="callback">返回请求响应结果回调</param>
        public static void Request(HttpParam httpParam, Action<HttpResult> callback) {
            if (httpParam == null) {
                throw new ArgumentException("httpParam not null");
            }
            if (string.IsNullOrWhiteSpace(httpParam.URL)) {
                throw new ArgumentException("url not null");
            }

            //使用回调的方法进行证书验证。
            if (httpParam.RemoteCertificateValidationCallback != null)
                ServicePointManager.ServerCertificateValidationCallback = httpParam.RemoteCertificateValidationCallback;

            HttpWebRequest request = null;

            Encoding encoding = DefaultEncoding;

            if (httpParam.Encoding != null)
                encoding = httpParam.Encoding;

            try {
                if (httpParam.Method == HttpVerb.Delete || httpParam.Method == HttpVerb.Post || httpParam.Method == HttpVerb.Put || httpParam.Method == HttpVerb.Patch) {
                    request = (HttpWebRequest)HttpWebRequest.Create(new Uri(httpParam.URL));

                    SetRequest(request, httpParam);

                    //开始异步请求
                    request.BeginGetRequestStream(new AsyncCallback((callbackResult) =>
                    {
                        HttpWebRequest _request = (HttpWebRequest)callbackResult.AsyncState;
                        var requestStream = _request.EndGetRequestStream(callbackResult);

                        //转化网络流对象进行直接射入，省内存
                        using (StreamWriter writer = new StreamWriter(requestStream, encoding)) {
                            try {
                                string postbody = SerializeQueryString(httpParam.Parameters);
                                writer.Write(postbody);
                                writer.Flush();
                            } catch (Exception ex) {
                                writer.Dispose();
                                ProcessFailCallback(callback, ex);
                                return;
                            }
                        }

                        //异步接收响应，并且设置一个超时时间
                        IAsyncResult asyncResult = _request.BeginGetResponse(null, _request);
                        asyncResult.FromAsync((ia, isTimeout) =>
                        {
                            if (isTimeout) {
                                ProcessFailCallback(callback, new TimeoutException("Connection Timeout"));
                            } else {
                                ProcessCallback(ia, callback);
                            }
                        }, httpParam.Timeout);
                    }), request);
                } else {
                    //处理URL参数
                    if (httpParam.Parameters != null) {
                        UriBuilder b = new UriBuilder(httpParam.URL);
                        if (!string.IsNullOrWhiteSpace(b.Query)) {
                            b.Query = b.Query.Substring(1) + "&" + SerializeQueryString(httpParam.Parameters);
                        } else {
                            b.Query = SerializeQueryString(httpParam.Parameters);
                        }
                        httpParam.URL = b.Uri.ToString();
                    }
                    request = (HttpWebRequest)HttpWebRequest.Create(new Uri(httpParam.URL));
                    SetRequest(request, httpParam);
                    IAsyncResult asyncResult = request.BeginGetResponse(null, request);
                    asyncResult.FromAsync((ia, isTimeout) =>
                    {
                        if (isTimeout) {
                            ProcessFailCallback(callback, new TimeoutException("Connection Timeout"));
                        } else {
                            ProcessCallback(ia, callback);
                        }
                    }, httpParam.Timeout);
                }
            } catch (WebException exception) {
                if (request != null)
                    request.Abort();
                ProcessFailCallback(callback, exception);
            }
        }

        /// <summary>
        /// Http异步请求发送
        /// </summary>
        /// <param name="httpParam">请求参数</param>
        /// <param name="body">Http Body</param>
        /// <param name="callback">返回请求响应结果回调</param>
        /// <param name="userState">状态</param>
        public static void Request(HttpParam httpParam, Stream body, Action<HttpResult, object> callback, object userState) {
            Request(httpParam, body, (result) => callback(result, userState));
        }

        /// <summary>
        /// Http异步请求发送
        /// </summary>
        /// <param name="httpParam">请求参数</param>
        /// <param name="body">Http Body</param>
        /// <param name="callback">返回请求响应结果回调</param>
        public static void Request(HttpParam httpParam, Stream body, Action<HttpResult> callback) {
            if (httpParam == null) {
                throw new ArgumentException("httpParam not null");
            }
            if (string.IsNullOrWhiteSpace(httpParam.URL)) {
                throw new ArgumentException("url not null");
            }
            if (body == null || body == Stream.Null)
                throw new ArgumentException("body not null");

            //使用回调的方法进行证书验证。
            if (httpParam.RemoteCertificateValidationCallback != null)
                ServicePointManager.ServerCertificateValidationCallback = httpParam.RemoteCertificateValidationCallback;

            HttpWebRequest request = null;

            try {
                request = (HttpWebRequest)HttpWebRequest.Create(new Uri(httpParam.URL));

                SetRequest(request, httpParam);

                //开始异步请求
                request.BeginGetRequestStream(new AsyncCallback((callbackResult) =>
                {
                    HttpWebRequest _request = (HttpWebRequest)callbackResult.AsyncState;

                    Stream requestStream = _request.EndGetRequestStream(callbackResult);

                    CopyStream(body, requestStream);//写入Body数据

                    body.Close();

                    //异步接收响应，并且设置一个超时时间
                    IAsyncResult asyncResult = request.BeginGetResponse(null, request);
                    asyncResult.FromAsync((ia, isTimeout) =>
                    {
                        if (isTimeout) {
                            ProcessFailCallback(callback, new TimeoutException("Connection Timeout"));
                        } else {
                            ProcessCallback(ia, callback);
                        }
                    }, httpParam.Timeout);
                }), request);
            } catch (WebException exception) {
                if (request != null)
                    request.Abort();
                body.Close();
                ProcessFailCallback(callback, exception);
            }
        }

        #endregion Request

        #region Private Methods

        //回调参数转化为字节
        private static Action<HttpResult> StreamToBytesCallback(Action<byte[]> callback) {
            return (HttpResult result) =>
            {
                callback(result.ToBytesResult());
            };
        }

        //回调参数转化为字符串
        private static Action<HttpResult> StreamToStringCallback(Action<string> callback) {
            return (HttpResult result) =>
            {
                callback(result.ToStringResult());
            };
        }

        /// <summary>
        /// 处理请求回调
        /// </summary>
        /// <param name="callbackResult"></param>
        /// <param name="callback"></param>
        private static void ProcessCallback(IAsyncResult callbackResult, Action<HttpResult> callback) {
            HttpWebRequest myRequest = (HttpWebRequest)callbackResult.AsyncState;

            HttpWebResponse response = null;
            try {
                response = (HttpWebResponse)myRequest.EndGetResponse(callbackResult);
                if (callback != null) {
                    HttpResult result = new HttpResult();
                    result.StatusCode = response.StatusCode;
                    result.StatusDescription = response.StatusDescription;
                    result.Header = response.Headers;
                    result.ContentLength = response.ContentLength;
                    result.ContentType = response.ContentType;
                    result.IsMutuallyAuthenticated = response.IsMutuallyAuthenticated;
                    result.IsFromCache = response.IsFromCache;
                    result.LastModified = response.LastModified;
                    result.Method = response.Method;
                    result.ProtocolVersion = response.ProtocolVersion;
                    result.Server = response.Server;
                    result.CharacterSet = response.CharacterSet;
                    result.ContentEncoding = response.ContentEncoding;

                    //包装相应的流，同步时候因为Stream还没关闭，使用完后连同HttpWebResponse一起关闭
                    result.Result = new WrapperResponseStream((response.ContentEncoding != null && response.ContentEncoding.Equals("gzip", StringComparison.InvariantCultureIgnoreCase))
                    ? new GZipStream(response.GetResponseStream(), CompressionMode.Decompress) : response.GetResponseStream(), response);

                    if (response.Cookies != null) result.CookieCollection = response.Cookies;
                    if (response.Headers["set-cookie"] != null) result.Cookie = response.Headers["set-cookie"];

                    result.IsCompleted = true;
                    callback(result);
                } else {
                    response.Close();
                }
            } catch (WebException exception) {
                if (response != null)
                    response.Close();
                ProcessFailCallback(callback, exception);
            }
        }

        /// <summary>
        /// 处理失败的请求
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="ex"></param>
        private static void ProcessFailCallback(Action<HttpResult> callback, Exception ex) {
            //LogContext.GetLogger<HttpRequest>().Error(ex.Message, ex);
            if (callback != null)
                callback(new HttpResult { Exception = ex, IsFaulted = true, IsCanceled = ex is TimeoutException });
        }

        #endregion Private Methods
    }
}