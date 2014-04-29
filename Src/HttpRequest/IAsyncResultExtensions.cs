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
 * Created:2014/4/17 22:19:18
 * 
 * Class:IAsyncResultExtensions
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
using System.Linq;
using System.Text;
using System.Threading;

namespace HttpRequest
{
    /// <summary>
    /// IAsyncResultExtensions
    /// </summary>
    public static class IAsyncResultExtensions
    {
        /// <summary>
        /// 异步编程带超时
        /// </summary>
        /// <param name="asyncResult">IAsyncResult</param>
        /// <param name="endMethod">回调函数</param>
        /// <param name="timeout">超时</param>
        public static void FromAsync(this IAsyncResult asyncResult, Action<IAsyncResult, bool> endMethod, TimeSpan? timeout) {
            int timeoutValue = -1;
            if (timeout.HasValue) {
                timeoutValue = Convert.ToInt32(timeout.Value.TotalMilliseconds);
            }

            //向线程池添加一个可以定时执行的方法
            ThreadPool.RegisterWaitForSingleObject(asyncResult.AsyncWaitHandle,
                (s, isTimedout) => endMethod(asyncResult, isTimedout), null,
                timeoutValue, true);
        }

    }
}
