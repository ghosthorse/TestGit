using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gitHelloworld
{
	class Program
	{
		static void Main(string[] args)
		{


			Console.WriteLine(2 << 2);
			//Console.WriteLine(FibonacciTailWraper(100));

			//1:a=10,b=15，在不用第三方变量的前提下，把a,b的值互换

			//2:已知数组int[] max={6,5,2,9,7,4,0};用快速排序算法按降序对其进行排列，并返回数组

			//3：请简述面向对象的多态的特性及意义！
			//Answer: 
			//		同一类事物，不同展现形态.   家禽类, 鸡鸭鹅。雌性都会下蛋，
			//		但是蛋的大小就不一样. 鸡下蛋后会打鸣，会叫，但是鸭子，和鹅就比较不会打鸣

			//4:session喜欢丢值且占内存，Cookis不安全，请问用什么办法代替这两种原始的方法
			//ViewState/Profile/server端Cache

			//5:对数据的并发采用什么办法进行处理较好。
			//1.使用事务对象
			//2.lock() unlock()
			//3.使用时间戳 使用timetamp类型

			//6：已知Oracle数据库有GD和ZS两个数据库，GD数据库v_s表有数据写入时，
			//  从v_s表中提取最新数据到ZS数据库的D_E表中。请问用什么办法解决这一问题？如果又碰到不能互访的问题时，又用什么办法解决？

			//AnSwer: 1.触发器 
			//		  2.不能互访时，肯定权限出了问题，可以对V_S表赋予D_E表的操作权限

		}

		private static void Sort(int[] numbers, int left, int right)
		{
			//左边索引小于右边，则还未排序完成 
			if (left < right)
			{
				//取中间的元素作为比较基准，小于他的往左边移，大于他的往右边移 
				int middle = numbers[(left + right) / 2];
				int i = left - 1;
				int j = right + 1;
				while (true)
				{
					while (numbers[++i] < middle && i < right) ;
					while (numbers[--j] > middle && j > 0) ;
					if (i >= j)
						break;
					Swap(numbers, i, j);
				}
				Sort(numbers, left, i - 1);
				Sort(numbers, j + 1, right);
			}
		}
		private static void Swap(int[] numbers, int i, int j)
		{
			int number = numbers[i];
			numbers[i] = numbers[j];
			numbers[j] = number;
		}

		//1.写一个递归算法
		#region 常规递归

		/// <summary>
		/// 简单递归
		/// </summary>
		/// <remarks>
		/// http://zh.wikipedia.org/wiki/递归/
		/// Fib(0) = 0 [基本情况]
		/// Fib(1) = 1 [基本情况]
		/// 对所有n > 1的整数：Fib(n) = (Fib(n-1) + Fib(n-2)) [递归定义]
		/// </remarks>
		/// <param name="n"></param>
		/// <returns></returns>
		public static int RecursionSimple(int n)
		{
			if (n == 0)
				return 0;
			if (n == 1)
				return 1;
			if (n > 1)
				return RecursionSimple(n - 1) + RecursionSimple(n - 2);
			else
				throw new ArgumentException("n < 0 is inValid");
		}

		/// <summary>
		/// 循环写法
		/// </summary>
		/// <param name="n"></param>
		/// <returns></returns>
		public static long RecursionToLoop(int n)
		{
			if (n < 0)
				throw new ArgumentException("n < 0 is inValid");

			long firstItem = 0;
			long secondItem = 1;
			long temp;
			while (n > 1)
			{
				temp = secondItem;
				secondItem += firstItem;
				firstItem = temp;
				n--;
			}

			return secondItem;
		}
		#endregion

		#region 尾递归 的斐波数列

		private static long FibonacciTailWraper(int n)
		{
			if (n < 0)
				throw new ArgumentException("n < 0 is inValid");

			return FibonacciTailRecursively(n, 0, 1);
		}

		private static long FibonacciTailRecursively(int n, long acc1, long acc2)
		{
			if (n == 0) return acc1;
			return FibonacciTailRecursively(n - 1, acc2, acc1 + acc2);
		}
		#endregion

		#region 尾递归 的阶乘数列
		public static int FactorialWraper(int n)
		{
			if (n < 0)
				throw new ArgumentException("n < 0 is inValid");
			return FactorialTailRecursion(n, 0);
		}

		private static int FactorialTailRecursion(int n, int acc)
		{
			if (n == 0) return acc;
			return FactorialTailRecursion(n - 1, acc * n);
		}
		#endregion
	}
}
