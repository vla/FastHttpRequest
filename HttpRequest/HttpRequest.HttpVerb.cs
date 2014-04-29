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
 * Created:2014/4/18 14:40:08
 *
 * Class:HttpHelper.HttpVerb
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

namespace HttpRequest
{
    /// <summary>
    ///  Http连接操作帮助类
    /// </summary>
    public partial class HttpHelper
    {
        /// <summary>
        /// HttpVerb
        /// </summary>
        public enum HttpVerb
        {
            /// <summary>
            /// Get
            /// </summary>
            Get,
            /// <summary>
            /// Head
            /// </summary>
            Head,
            /// <summary>
            /// Post
            /// </summary>
            Post,
            /// <summary>
            /// Put
            /// </summary>
            Put,
            /// <summary>
            /// Delete
            /// </summary>
            Delete,
            /// <summary>
            /// Patch
            /// </summary>
            Patch
        }
    }
}