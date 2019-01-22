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
 * Created:2014/4/18 14:16:17
 *
 * Class:HttpHelper.HttpParam
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
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace HttpRequest
{
    /// <summary>
    ///  Http连接操作帮助类
    /// </summary>
    public partial class HttpHelper
    {
        /// <summary>
        /// 请求参数
        /// </summary>
        public class HttpParam
        {
            private HttpVerb _httpVerb = HttpVerb.Get;
            private string _accpet;
            private string  _userAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/29.0.1547.22 Safari/537.36";
            private bool _allowAutoRedirect = true;

            /// <summary>
            /// 请求URL
            /// </summary>
            public string URL { get; set; }

            /// <summary>
            /// 请求参数
            /// </summary>
            public object Parameters { get; set; }

            /// <summary>
            /// HttpVerb
            /// </summary>
            public HttpVerb Method {
                get { return _httpVerb; }
                set { _httpVerb = value; }
            }

            /// <summary>
            /// 设置或获取Post参数编码,默认UTF8Encoding(false)
            /// </summary>
            public Encoding Encoding { get; set; }

            /// <summary>
            /// 设置509证书集合
            /// </summary>
            public X509CertificateCollection ClentCertificates { get; set; }

            /// <summary>
            /// 默认请求超时时间
            /// </summary>
            public TimeSpan? Timeout { get; set; }

            /// <summary>
            /// 获取或设置 Accept HTTP 标头的值。
            /// </summary>
            public string Accept {
                get { return _accpet; }
                set { _accpet = value; }
            }

            /// <summary>
            /// 获取或设置 Content-type HTTP 标头的值。
            /// </summary>
            public string ContentType { get; set; }

            /// <summary>
            /// 获取或设置 Referer HTTP 标头的值。
            /// </summary>
            public string Referer { get; set; }

            /// <summary>
            /// 获取或设置请求的代理信息
            /// </summary>
            public IWebProxy Proxy { get; set; }

            /// <summary>
            /// 获取或设置 User-agent HTTP 标头的值。
            /// </summary>
            public string UserAgent {
                get { return _userAgent; }
                set { _userAgent = value; }
            }

            /// <summary>
            /// 获取或设置一个值，该值指示请求是否应跟随重定向响应。
            /// </summary>
            public bool AllowAutoRedirect {
                get { return _allowAutoRedirect; }
                set { _allowAutoRedirect = value; }
            }

            /// <summary>
            /// Cookie对象集合
            /// </summary>
            public CookieCollection CookieCollection { get; set; }

            /// <summary>
            /// header对象
            /// </summary>
            public WebHeaderCollection Header { get; set; }

            /// <summary>
            /// 回调验证
            /// </summary>
            public RemoteCertificateValidationCallback RemoteCertificateValidationCallback { get; set; }
        }
    }
}