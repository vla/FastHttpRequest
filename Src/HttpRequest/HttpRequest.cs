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
 * Created:2014/4/17 17:41:36
 *
 * Class:HttpHelper
 *
 * Version:1.0
 *
 * Purpose:
 *
 * 提供简单快速的Http请求
 *
 * Edit Description
 *
 * ---------------------------------------------------------------------------
 * */

#endregion Description

using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace HttpRequest
{
    /// <summary>
    ///  Http连接操作帮助类
    /// </summary>
    public partial class HttpHelper
    {
        #region Fields

        internal static Encoding DefaultEncoding = new UTF8Encoding(false);

        #endregion Fields

        #region Get

        /// <summary>
        /// 请求发送 Get
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return string</returns>
        public static string GetString(string url, string contentType = "", WebHeaderCollection header = null) {
            return _Rq(url, HttpVerb.Get, contentType, header).ToStringResult();
        }

        /// <summary>
        /// 请求发送 Get
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return string</returns>
        public static string GetString(string url, object parameters, string contentType = "", WebHeaderCollection header = null) {
            return _Rq(url, parameters, HttpVerb.Get, contentType, header).ToStringResult();
        }

        /// <summary>
        /// 请求发送 Get
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return byte[]</returns>
        public static byte[] GetBytes(string url, string contentType = "", WebHeaderCollection header = null) {
            return _Rq(url, HttpVerb.Get, contentType, header).ToBytesResult();
        }

        /// <summary>
        /// 请求发送 Get
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return byte[]</returns>
        public static byte[] GetBytes(string url, object parameters, string contentType = "", WebHeaderCollection header = null) {
            return _Rq(url, parameters, HttpVerb.Get, contentType, header).ToBytesResult();
        }

        /// <summary>
        /// 请求发送 Get
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return HttpResult</returns>
        public static HttpResult Get(string url, string contentType = "", WebHeaderCollection header = null) {
            return _Rq(url, HttpVerb.Get, contentType, header);
        }

        /// <summary>
        /// 请求发送 Get
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return HttpResult</returns>
        public static HttpResult Get(string url, object parameters, string contentType = "", WebHeaderCollection header = null) {
            return _Rq(url, parameters, HttpVerb.Get, contentType, header);
        }

        #endregion Get

        #region Head

        /// <summary>
        /// 请求发送 Head
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return WebHeaderCollection</returns>
        public static WebHeaderCollection Head(string url, WebHeaderCollection header = null) {
            return _Rq(url, HttpVerb.Head, string.Empty, header).Header;
        }

        /// <summary>
        /// 请求发送 Head
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return HttpResult</returns>
        public static HttpResult HeadInfo(string url, WebHeaderCollection header = null) {
            return _Rq(url, HttpVerb.Head, string.Empty, header);
        }

        #endregion Head

        #region Post

        /// <summary>
        /// 请求发送 Post
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return string</returns>
        public static string PostToString(string url, object parameters, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            return _Rq(url, parameters, HttpVerb.Post, contentType, header).ToStringResult();
        }

        /// <summary>
        /// 请求发送 Post
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return byte[]</returns>
        public static byte[] PostToBytes(string url, object parameters, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            return _Rq(url, parameters, HttpVerb.Post, contentType, header).ToBytesResult();
        }

        /// <summary>
        /// 请求发送 Post
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return HttpResult</returns>
        public static HttpResult Post(string url, object parameters, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            return _Rq(url, parameters, HttpVerb.Post, contentType, header);
        }

        #endregion Post

        #region Put

        /// <summary>
        /// 请求发送 Put
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return string</returns>
        public static string PutToString(string url, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            return _Rq(url, HttpVerb.Put, contentType, header).ToStringResult();
        }

        /// <summary>
        /// 请求发送 Put
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return string</returns>
        public static string PutToString(string url, object parameters, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            return _Rq(url, parameters, HttpVerb.Put, contentType, header).ToStringResult();
        }

        /// <summary>
        /// 请求发送 Put
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return byte[]</returns>
        public static byte[] PutToBytes(string url, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            return _Rq(url, HttpVerb.Put, contentType, header).ToBytesResult();
        }

        /// <summary>
        /// 请求发送 Put
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return byte[]</returns>
        public static byte[] PutToBytes(string url, object parameters, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            return _Rq(url, parameters, HttpVerb.Put, contentType, header).ToBytesResult();
        }

        /// <summary>
        /// 请求发送 Put
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="contentType">contentType</param>
        ///<param name="header">WebHeaderCollection</param>
        /// <returns>return HttpResult</returns>
        public static HttpResult Put(string url, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            return _Rq(url, HttpVerb.Put, contentType, header);
        }

        /// <summary>
        /// 请求发送 Put
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return HttpResult</returns>
        public static HttpResult Put(string url, object parameters, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            return _Rq(url, parameters, HttpVerb.Put, contentType, header);
        }

        #endregion Put

        #region Delete

        /// <summary>
        /// 请求发送 Delete
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return string</returns>
        public static string DeleteToString(string url, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            return _Rq(url, HttpVerb.Delete, contentType, header).ToStringResult();
        }

        /// <summary>
        /// 请求发送 Delete
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return string</returns>
        public static string DeleteToString(string url, object parameters, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            return _Rq(url, parameters, HttpVerb.Delete, contentType, header).ToStringResult();
        }

        /// <summary>
        /// 请求发送 Delete
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return byte[]</returns>
        public static byte[] DeleteToBytes(string url, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            return _Rq(url, HttpVerb.Delete, contentType, header).ToBytesResult();
        }

        /// <summary>
        /// 请求发送 Delete
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return byte[]</returns>
        public static byte[] DeleteToBytes(string url, object parameters, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            return _Rq(url, parameters, HttpVerb.Delete, contentType, header).ToBytesResult();
        }

        /// <summary>
        /// 请求发送 Delete
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return HttpResult</returns>
        public static HttpResult Delete(string url, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            return _Rq(url, HttpVerb.Delete, contentType, header);
        }

        /// <summary>
        /// 请求发送 Delete
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return HttpResult</returns>
        public static HttpResult Delete(string url, object parameters, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            return _Rq(url, parameters, HttpVerb.Delete, contentType, header);
        }

        #endregion Delete

        #region Patch

        /// <summary>
        /// 请求发送 Patch
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return string</returns>
        public static string PatchToString(string url, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            return _Rq(url, HttpVerb.Patch, contentType, header).ToStringResult();
        }

        /// <summary>
        /// 请求发送 Patch
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return string</returns>
        public static string PatchToString(string url, object parameters, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            return _Rq(url, parameters, HttpVerb.Patch, contentType, header).ToStringResult();
        }

        /// <summary>
        /// 请求发送 Patch
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return byte[]</returns>
        public static byte[] PatchToBytes(string url, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            return _Rq(url, HttpVerb.Patch, contentType, header).ToBytesResult();
        }

        /// <summary>
        /// 请求发送 Patch
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return byte[]</returns>
        public static byte[] PatchToBytes(string url, object parameters, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            return _Rq(url, parameters, HttpVerb.Patch, contentType, header).ToBytesResult();
        }

        /// <summary>
        /// 请求发送 Patch
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return HttpResult</returns>
        public static HttpResult Patch(string url, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            return _Rq(url, HttpVerb.Patch, contentType, header);
        }

        /// <summary>
        /// 请求发送 Patch
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return HttpResult</returns>
        public static HttpResult Patch(string url, object parameters, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            return _Rq(url, parameters, HttpVerb.Patch, contentType, header);
        }

        #endregion Patch

        #region Body

        /// <summary>
        /// 请求发送 Body
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="body">body</param>
        /// <param name="method">请求方法</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return HttpResult</returns>
        public static HttpResult Body(string url, Stream body, HttpVerb method = HttpVerb.Get, string contentType = "text/json", WebHeaderCollection header = null) {
            return Request(new HttpParam { URL = url, Method = method, ContentType = contentType, Header = header }, body);
        }

        /// <summary>
        /// 请求发送 Body
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="body">body</param>
        /// <param name="method">请求方法</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return byte[]</returns>
        public static byte[] BodyToBytes(string url, Stream body, HttpVerb method = HttpVerb.Get, string contentType = "text/json", WebHeaderCollection header = null) {
            var result = Request(new HttpParam { URL = url, Method = method, ContentType = contentType, Header = header }, body);
            return result.ToBytesResult();
        }

        /// <summary>
        /// 请求发送 Body
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="body">body</param>
        /// <param name="method">请求方法</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return string</returns>
        public static string BodyToString(string url, Stream body, HttpVerb method = HttpVerb.Get, string contentType = "text/json", WebHeaderCollection header = null) {
            var result = Request(new HttpParam { URL = url, Method = method, ContentType = contentType, Header = header }, body);

            return result.ToStringResult();
        }

        #endregion Body

        #region Upload

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="files">文件信息</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="method">请求方法</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return HttpResult</returns>
        public static HttpResult Upload(string url, NamedFileStream[] files, object parameters = null, HttpVerb method = HttpVerb.Post, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            return Request(new HttpParam { URL = url, Parameters = parameters, Method = method, ContentType = contentType, Header = header }, files);
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="files">文件信息</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="method">请求方法</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return bytes[]</returns>
        public static byte[] UploadToBytes(string url, NamedFileStream[] files, object parameters = null, HttpVerb method = HttpVerb.Post, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            var result = Request(new HttpParam { URL = url, Parameters = parameters, Method = method, ContentType = contentType, Header = header }, files);
            return result.ToBytesResult();
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="url">url地址</param>
        /// <param name="files">文件信息</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="method">请求方法</param>
        /// <param name="contentType">contentType</param>
        /// <param name="header">WebHeaderCollection</param>
        /// <returns>return string</returns>
        public static string UploadToString(string url, NamedFileStream[] files, object parameters = null, HttpVerb method = HttpVerb.Post, string contentType = "application/x-www-form-urlencoded", WebHeaderCollection header = null) {
            var result = Request(new HttpParam { URL = url, Parameters = parameters, Method = method, ContentType = contentType, Header = header }, files);

            return result.ToStringResult();
        }

        #endregion Upload

        #region _Rq 提供一组供给 Get Head Post 等模板函数

        private static HttpResult _Rq(string url, HttpVerb method, string contentType, WebHeaderCollection header) {
            return Request(new HttpParam { URL = url, Method = method, ContentType = contentType, Header = header });
        }

        private static HttpResult _Rq(string url, object parameters, HttpVerb method, string contentType, WebHeaderCollection header) {
            return Request(new HttpParam { URL = url, Parameters = parameters, Method = method, ContentType = contentType, Header = header });
        }

        #endregion _Rq 提供一组供给 Get Head Post 等模板函数

        #region Request

        /// <summary>
        /// Http请求发送文件
        /// </summary>
        /// <param name="httpParam">请求参数</param>
        /// <param name="files">文件上传的信息</param>
        /// <returns>返回请求响应结果</returns>
        public static HttpResult Request(HttpParam httpParam, NamedFileStream[] files) {
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

                var requestStream = request.GetRequestStream();

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

                        //处理文件
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
                        //LogContext.GetLogger<HttpRequest>().Error(ex.Message, ex);
                        return new HttpResult { Exception = ex, IsFaulted = true };
                    } finally {
                        //使用完后释放
                        foreach (var file in files) {
                            if (file.Stream != null)
                                file.Stream.Dispose();
                        }
                    }
                }

                return Process((HttpWebResponse)request.GetResponse());
            } catch (WebException exception) {
                if (request != null)
                    request.Abort();
                //遇到异常时候再次释放一次，防止内存泄漏
                foreach (var file in files) {
                    if (file.Stream != null)
                        file.Stream.Dispose();
                }
                //LogContext.GetLogger<HttpRequest>().Error(exception.Message, exception);
                return new HttpResult { Exception = exception, IsFaulted = true };
            }
        }

        /// <summary>
        /// Http请求发送
        /// </summary>
        /// <param name="httpParam">请求参数</param>
        /// <returns>返回请求响应结果</returns>
        public static HttpResult Request(HttpParam httpParam) {
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

                    var requestStream = request.GetRequestStream();

                    //转化网络流对象进行直接射入，省内存
                    using (StreamWriter writer = new StreamWriter(requestStream, encoding)) {
                        try {
                            //序列化参数
                            string postbody = SerializeQueryString(httpParam.Parameters);
                            writer.Write(postbody);
                            writer.Flush();
                        } catch (Exception ex) {
                            writer.Dispose();
                            //LogContext.GetLogger<HttpRequest>().Error(ex.Message, ex);
                            return new HttpResult { Exception = ex, IsFaulted = true };
                        }
                    }

                    return Process((HttpWebResponse)request.GetResponse());
                } else {
                    if (httpParam.Parameters != null) {
                        //处理URL参数并接
                        //src index?id=1 dest index?id=1&age=21
                        //src index dest index?id=1

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

                    return Process((HttpWebResponse)request.GetResponse());
                }
            } catch (WebException exception) {
                if (request != null)
                    request.Abort();
                //LogContext.GetLogger<HttpRequest>().Error(exception.Message, exception);
                return new HttpResult { Exception = exception, IsFaulted = true };
            }
        }

        /// <summary>
        /// Http请求发送
        /// </summary>
        /// <param name="httpParam">请求参数</param>
        /// <param name="body">Http Body</param>
        /// <returns>返回请求响应结果</returns>
        public static HttpResult Request(HttpParam httpParam, Stream body) {
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

                var requestStream = request.GetRequestStream();

                //写入body
                CopyStream(body, requestStream);

                return Process((HttpWebResponse)request.GetResponse());
            } catch (WebException exception) {
                if (request != null)
                    request.Abort();
                //LogContext.GetLogger<HttpRequest>().Error(exception.Message, exception);
                return new HttpResult { Exception = exception, IsFaulted = true };
            } finally {
                body.Close();
            }
        }

        //处理请求响应结果
        private static HttpResult Process(HttpWebResponse response) {
            HttpResult result = new HttpResult();
            try {
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
            } catch (WebException exception) {
                if (response != null)
                    response.Close();
                result.Exception = exception;
                result.IsFaulted = true;
                //LogContext.GetLogger<HttpRequest>().Error(exception.Message, exception);
            }
            return result;
        }

        #endregion Request

        #region Helper

        /// <summary>
        /// 设置请求属性
        /// </summary>
        /// <param name="request">HttpWebRequest</param>
        /// <param name="httpParam">HttpParam</param>
        private static void SetRequest(HttpWebRequest request, HttpParam httpParam) {
            // 设置多个证书
            if (httpParam.ClentCertificates != null && httpParam.ClentCertificates.Count > 0)
                foreach (X509Certificate item in httpParam.ClentCertificates) {
                    request.ClientCertificates.Add(item);
                }

            //设置Header参数
            if (httpParam.Header != null && httpParam.Header.Count > 0)
                foreach (string item in httpParam.Header.AllKeys) {
                    request.Headers.Add(item, httpParam.Header[item]);
                }

            // 设置代理
            if (httpParam.Proxy != null) {
                request.Proxy = httpParam.Proxy;
                //设置安全凭证
                request.Credentials = CredentialCache.DefaultNetworkCredentials;
            }

            request.Method = httpParam.Method.ToString();
            if (!string.IsNullOrEmpty(httpParam.ContentType))
                request.ContentType = httpParam.ContentType;
            if (httpParam.Timeout.HasValue)
                request.Timeout = Convert.ToInt32(httpParam.Timeout.Value.TotalMilliseconds);

            //Accept
            request.Accept = httpParam.Accept;

            //UserAgent
            if (!string.IsNullOrEmpty(httpParam.UserAgent))
                request.UserAgent = httpParam.UserAgent;

            //Cookie
            if (httpParam.CookieCollection != null && httpParam.CookieCollection.Count > 0) {
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(httpParam.CookieCollection);
            }

            //来源地址
            if (!string.IsNullOrEmpty(httpParam.Referer))
                request.Referer = httpParam.Referer;
      
            request.AllowAutoRedirect = httpParam.AllowAutoRedirect;
            request.KeepAlive = false;
            //浏览器支持的语言分别是中文和简体中文，优先支持简体中文。
            request.Headers.Add("Accept-Language", "zh-CN");
        }

        //文件流复制
        private static long CopyStream(Stream source, Stream target, int blockSize = 4096) {
            if (source == null) {
                throw new ArgumentNullException("source");
            }
            if (target == null) {
                throw new ArgumentNullException("target");
            }
            if (blockSize < 1024) {
                throw new ArgumentException("Argument 'blockSize' value must be >= 1024.");
            }

            byte[] buffer = new byte[blockSize];
            int readedCount;
            long totalReaded = 0;
            while ((readedCount = source.Read(buffer, 0, buffer.Length)) != 0) {
                target.Write(buffer, 0, readedCount);
                totalReaded += blockSize;
            }
            return totalReaded;
        }

        //从response header 获取body的编码类型
        internal static string GetEncodingFromHeaders(WebHeaderCollection headers) {
            string encoding = null;
            string contentType = headers["Content-Type"];
            if (contentType != null) {
                int i = contentType.IndexOf("charset=");
                if (i != -1) {
                    encoding = contentType.Substring(i + 8);
                }
            }
            return encoding;
        }

        //对象序列化Dic
        private static IDictionary SerializeQuery(object parameters) {
            if (parameters == null)
                return null;

            var dic = parameters as IDictionary;

            if (dic != null) {
                return dic;//匹配字段直接返回
            } else if (parameters.GetType() != typeof(string)) {
                //属性方式转化
                dic = new HybridDictionary();
                foreach (PropertyInfo pi1 in parameters.GetType().GetProperties()) {
                    if (!pi1.CanRead) continue;
                    dic[pi1.Name] = pi1.GetValue(parameters, null);
                }
            } else if (parameters.GetType() == typeof(string)) {
                //querystring方式转化
                dic = new HybridDictionary();
                string urlParam = parameters.ToString();
                var array = urlParam.Split('&');
                if (array.Length > 0) {
                    for (int i=0; i < array.Length; i++) {
                        string[] p = array[i].Split('=');
                        if (p.Length == 2 && !string.IsNullOrEmpty(p[0])) {
                            dic[p[0]] = p[1];
                        }
                    }
                }
            }
            return dic;
        }

        //对象序列化QueryString
        private static string SerializeQueryString(object parameters) {
            var dic = parameters as IDictionary;
            var type = parameters.GetType();

            StringBuilder builder = new StringBuilder();
            if (dic != null) {
                foreach (var pair in dic.Keys) {
                    if (dic[pair] == null)
                        continue;
                    if (builder.Length > 0) {
                        builder.Append('&');
                    }
                    builder.Append(pair.ToString());
                    builder.Append('=');
                    builder.Append(UrlEncode(dic[pair].ToString()));
                }
            } else if (type != typeof(string)) {
                var properties = type.GetProperties();
                foreach (PropertyInfo prop in properties) {
                    if (!prop.CanRead) continue;
                    if (builder.Length > 0) {
                        builder.Append('&');
                    }
                    var val = prop.GetValue(parameters, null);
                    if (val == null) {
                        continue;
                    }
                    builder.Append(prop.Name + "=" + UrlEncode(val.ToString()));
                }
            } else if (type == typeof(string)) {
                return parameters.ToString();
            }

            return builder.ToString();
        }

        //随机字符
        private static string RandomString(int length) {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            char[] chars = new char[length];
            Random rd = new Random();

            for (int i = 0; i < length; i++) {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }

         /// <summary>
        /// Uri编码
        /// </summary>
        /// <param name="stringToEscape"></param>
        /// <returns></returns>
        private static string UrlEncode(string stringToEscape) {
            //继续使用微软提供的Uri.EscapeDataString作为Uri编码
            //分隔处理解决长度限制
            const int maxLength = 32766;
            if (stringToEscape == null)
                return null;

            if (stringToEscape.Length <= maxLength)
                return Uri.EscapeDataString(stringToEscape);

            StringBuilder sb = new StringBuilder(stringToEscape.Length * 2);
            int index = 0;
            while (index < stringToEscape.Length) {
                int length = Math.Min(stringToEscape.Length - index, maxLength);
                string subString = stringToEscape.Substring(index, length);
                sb.Append(Uri.EscapeDataString(subString));
                index += subString.Length;
            }

            return sb.ToString();
        }

        #endregion Helper

        #region WrapperResponseStream

        /// <summary>
        /// 包装GetResponseStream，释放时候连同HttpWebResponse一起释放
        /// </summary>
        private class WrapperResponseStream : Stream
        {
            private HttpWebResponse _response;
            private Stream _stream;

            public WrapperResponseStream(Stream stream, HttpWebResponse response) {
                _stream = stream;
                _response = response;
            }

            public override void Close() {
                _stream.Close();
                _response.Close();//HttpWebResponse同时关闭
            }

            public override bool CanRead {
                get { return _stream.CanRead; }
            }

            public override bool CanSeek {
                get { return _stream.CanSeek; }
            }

            public override bool CanWrite {
                get { return _stream.CanWrite; }
            }

            public override void Flush() {
                _stream.Flush();
            }

            public override long Length {
                get { return _stream.Length; }
            }

            public override long Position {
                get {
                    return _stream.Position;
                }
                set {
                    _stream.Position = value;
                }
            }

            public override int Read(byte[] buffer, int offset, int count) {
                return _stream.Read(buffer, offset, count);
            }

            public override long Seek(long offset, SeekOrigin origin) {
                return _stream.Seek(offset, origin);
            }

            public override void SetLength(long value) {
                _stream.SetLength(value);
            }

            public override void Write(byte[] buffer, int offset, int count) {
                _stream.Write(buffer, offset, count);
            }
        }

        #endregion WrapperResponseStream
    }
}