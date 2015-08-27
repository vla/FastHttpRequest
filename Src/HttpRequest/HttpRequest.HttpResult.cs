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
 * Created:2014/4/18 14:16:31
 *
 * Class:HttpHelper.HttpHelper
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
using System.IO;
using System.Net;
using System.Text;

namespace HttpRequest
{
    /// <summary>
    /// 扩展HttpRequest
    /// </summary>
    public static class HttpRequestExtensions
    {
        /// <summary>
        ///  结果返回字符串
        /// </summary>
        /// <param name="result">HttpResult</param>
        /// <returns>string</returns>
        public static string ToStringResult(this HttpHelper.HttpResult result) {
            string encodingName = HttpHelper.GetEncodingFromHeaders(result.Header);

            Encoding encoding;

            if (encodingName == null)
                encoding = HttpHelper.DefaultEncoding;
            else {
                try {
                    encoding = Encoding.GetEncoding(encodingName);
                } catch (ArgumentException) {
                    encoding = Encoding.UTF8;
                }
            }
            string rtlString = string.Empty;
            using (result.Result) {
                using (StreamReader reader = new StreamReader(result.Result, encoding)) {
                    rtlString = reader.ReadToEnd();
                }
            }
            return rtlString;
        }

        /// <summary>
        /// 结果返回字节
        /// </summary>
        /// <param name="result">HttpResult</param>
        /// <returns>byte[]</returns>
        public static byte[] ToBytesResult(this HttpHelper.HttpResult result) {
            byte[] bytes = new byte[result.ContentLength];
            using (result.Result) {
                result.Result.Read(bytes, 0, bytes.Length);
            }
            return bytes;
        }
    }

    /// <summary>
    ///  Http连接操作帮助类
    /// </summary>
    public partial class HttpHelper
    {
        /// <summary>
        /// 请求响应结果
        /// </summary>
        public class HttpResult
        {
            /// <summary>
            /// Http请求返回的Cookie
            /// </summary>
            public string Cookie { get; set; }

            /// <summary>
            /// 获取响应的字符集
            /// </summary>
            public string CharacterSet { get; set; }

            /// <summary>
            /// 获取用于对响应体进行编码的方法
            /// </summary>
            public string ContentEncoding { get; set; }

            /// <summary>
            /// Cookie对象集合
            /// </summary>
            public CookieCollection CookieCollection { get; set; }

            /// <summary>
            /// 返回的网络数据库，请注意部分属于不能读取。比如Length
            /// </summary>
            public Stream Result { get; set; }

            /// <summary>
            /// 获取请求返回的内容的长度。
            /// </summary>
            public long ContentLength { get; set; }

            /// <summary>
            /// 获取或设置 Content-type HTTP 标头的值。
            /// </summary>
            public string ContentType { get; set; }

            /// <summary>
            /// 客户端和服务器是否都已经过身份验证
            /// </summary>
            public bool IsMutuallyAuthenticated { get; set; }

            /// <summary>
            /// 此响应是否为从缓存中获取的
            /// </summary>
            public bool IsFromCache { get; set; }

            /// <summary>
            /// 获取最后一次修改响应内容的日期和时间
            /// </summary>
            public DateTime LastModified { get; set; }

            /// <summary>
            /// Http Verb
            /// </summary>
            public string Method { get; set; }

            /// <summary>
            /// Http 协议版本
            /// </summary>
            public Version ProtocolVersion { get; set; }

            /// <summary>
            /// 响应的服务器的名称
            /// </summary>
            public string Server { get; set; }

            /// <summary>
            /// header对象
            /// </summary>
            public WebHeaderCollection Header { get; set; }

            /// <summary>
            /// 返回状态说明
            /// </summary>
            public string StatusDescription { get; set; }

            /// <summary>
            /// 返回状态码,默认为OK
            /// </summary>
            public HttpStatusCode StatusCode { get; set; }

            /// <summary>
            /// 异常
            /// </summary>
            public Exception Exception { get; set; }

            /// <summary>
            /// 是否已被停止或者超时停止
            /// </summary>
            public bool IsCanceled { get; set; }

            /// <summary>
            /// 是否已完成
            /// </summary>
            public bool IsCompleted { get; set; }

            /// <summary>
            /// 是否由于未经处理异常的原因而完成
            /// </summary>
            public bool IsFaulted { get; set; }
        }
    }
}