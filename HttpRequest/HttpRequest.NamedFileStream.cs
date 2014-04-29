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
 * Created:2014/4/18 14:39:28
 *
 * Class:HttpHelper.NamedFileStream
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

using System.IO;

namespace HttpRequest
{
    /// <summary>
    ///  Http连接操作帮助类
    /// </summary>
    public partial class HttpHelper
    {
        /// <summary>
        /// 提供文件上传的信息
        /// </summary>
        public class NamedFileStream
        {
            /// <summary>
            /// 文件名称
            /// </summary>
            public string FileName { get; set; }

            /// <summary>
            /// 文件上传字段 类似 input name='field'
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// 字节
            /// </summary>
            public Stream Stream { get; set; }

            /// <summary>
            /// 参数构造函数
            /// </summary>
            /// <param name="name">field</param>
            /// <param name="filename">文件名称</param>
            /// <param name="stream">文件流</param>
            public NamedFileStream(string name, string filename, Stream stream) {
                Name = name;
                FileName = filename;
                Stream = stream;
            }
        }
    }
}