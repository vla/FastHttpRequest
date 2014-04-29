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
 * Created:2014/4/17 22:32:48
 *
 * Class:TestExcute
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
using System.Text;

namespace ConsoleTest
{
    public abstract class TestExcute
    {
        public abstract void Execute();

        public virtual bool Off {
            get {
                return false;
            }
        }

        public static void RunTest(Type t) {
            System.Reflection.Assembly dataAccess = System.Reflection.Assembly.GetAssembly(t);

            foreach (var type in dataAccess.GetTypes()) {
                if (!type.IsAbstract && typeof(TestExcute).IsAssignableFrom(type)) {
                    TestExcute exe = Activator.CreateInstance(type) as TestExcute;
                    if (!exe.Off) {
                        lrTag("Class Name : " + type.Name, "*", 10);
                        Console.Write(Environment.NewLine);
                        exe.Execute();
                    }
                }
            }
        }

        public readonly static string SPACE = "  ";

        public static void lrTag(string view, string tag, int size) {
            StringBuilder sb = new StringBuilder();

            for (int i=0; i < size; i++) {
                sb.Append(tag);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(sb + SPACE + view + SPACE + sb);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}