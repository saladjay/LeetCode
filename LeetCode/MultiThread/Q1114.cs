﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LeetCode.MultiThread
{
    /*
        我们提供了一个类：  

        public class Foo {
          public void first() { print("first"); }
          public void second() { print("second"); }
          public void third() { print("third"); }
        }
        三个不同的线程将会共用一个 Foo 实例。

        线程 A 将会调用 first() 方法
        线程 B 将会调用 second() 方法
        线程 C 将会调用 third() 方法
        请设计修改程序，以确保 second() 方法在 first() 方法之后被执行，third() 方法在 second() 方法之后被执行。

        示例 1:

        输入: [1,2,3]
        输出: "firstsecondthird"
        解释: 
        有三个线程会被异步启动。
        输入 [1,2,3] 表示线程 A 将会调用 first() 方法，线程 B 将会调用 second() 方法，线程 C 将会调用 third() 方法。
        正确的输出是 "firstsecondthird"。
        示例 2:

        输入: [1,3,2]
        输出: "firstsecondthird"
        解释: 
        输入 [1,3,2] 表示线程 A 将会调用 first() 方法，线程 B 将会调用 third() 方法，线程 C 将会调用 second() 方法。
        正确的输出是 "firstsecondthird"。
 

        提示：

        尽管输入中的数字似乎暗示了顺序，但是我们并不保证线程在操作系统中的调度顺序。
        你看到的输入格式主要是为了确保测试的全面性。

        来源：力扣（LeetCode）
        链接：https://leetcode-cn.com/problems/print-in-order
        著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
         */
    public class Q1114 : IExecuteTest
    {
        public bool Test()
        {
            var foo1 = new Foo();
            var foo2 = new Foo();
            var foo3 = new Foo();
            return true;
        }
    }

    public class Foo
    {
        private AutoResetEvent _second = new AutoResetEvent(false);
        private AutoResetEvent _third = new AutoResetEvent(false);

        public Foo()
        {    
               _second.WaitOne()
        }

        public void First(Action printFirst)
        {

            // printFirst() outputs "first". Do not change or remove this line.
            printFirst();
            _second.Set();
        }

        public void Second(Action printSecond)
        {
            _second.WaitOne();
            // printSecond() outputs "second". Do not change or remove this line.
            printSecond();
            _third.Set();
        }

        public void Third(Action printThird)
        {
            _third.WaitOne();
            // printThird() outputs "third". Do not change or remove this line.
            printThird();

        }
    }
}
