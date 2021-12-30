using System;
using System.Collections.Generic;
/*
 * 846. 一手顺子
 Alice 手中有一把牌，她想要重新排列这些牌，分成若干组，使每一组的牌数都是 groupSize ，并且由 groupSize 张连续的牌组成。

给你一个整数数组 hand 其中 hand[i] 是写在第 i 张牌，和一个整数 groupSize 。如果她可能重新排列这些牌，返回 true ；否则，返回 false 。

 

示例 1：

输入：hand = [1,2,3,6,2,3,4,7,8], groupSize = 3
输出：true
解释：Alice 手中的牌可以被重新排列为 [1,2,3]，[2,3,4]，[6,7,8]。
示例 2：

输入：hand = [1,2,3,4,5], groupSize = 4
输出：false
解释：Alice 手中的牌无法被重新排列成几个大小为 4 的组。
 

提示：

1 <= hand.length <= 10^4
0 <= hand[i] <= 10^9
1 <= groupSize <= hand.length

 */
/*
 507. 完美数
对于一个 正整数，如果它和除了它自身以外的所有 正因子 之和相等，我们称它为 「完美数」。

给定一个 整数 n， 如果是完美数，返回 true，否则返回 false

 

示例 1：

输入：num = 28
输出：true
解释：28 = 1 + 2 + 4 + 7 + 14
1, 2, 4, 7, 和 14 是 28 的所有正因子。
示例 2：

输入：num = 6
输出：true
示例 3：

输入：num = 496
输出：true
示例 4：

输入：num = 8128
输出：true
示例 5：

输入：num = 2
输出：false
 

提示：

1 <= num <= 10^8
 */
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            /*
             * 846
            int[] hand = { 1, 2, 3, 6, 2, 3, 4, 7, 8 };
            int groupSize = 3;
            Solution solution = new Solution();
            bool isTure = solution.IsNStraightHand(hand, groupSize);
            Console.WriteLine(isTure);
            */

        }
    }
    public class Solution
    {
        #region 846题
#if false
        public bool IsNStraightHand(int[] hand, int groupSize)
        {
            int n = hand.Length;
            if (n % groupSize != 0)
            {
                return false;
            }
            // 排序
            Array.Sort(hand);
            Dictionary<int, int> cnt = new Dictionary<int, int>();
            // 记录下每个数字在数组中出现的次数
            foreach (int x in hand)
            {
                if (!cnt.ContainsKey(x))
                {
                    cnt.Add(x, 0);
                }
                cnt[x]++;
            }
            // 遍历数组
            foreach (int x in hand)
            {
                // 如果map中不包含 这个key了 跳过 相当于从最小的数开始往大了找循环数
                if (!cnt.ContainsKey(x))
                {
                    continue;
                }
                // 如果map中包含这个key 则 循环 长度次
                for (int j = 0; j < groupSize; j++)
                {
                    // 值 为 当前值 加上 第几位 相当于 N  N+1  N+2  N+groupsize-1
                    int num = x + j;
                    if (!cnt.ContainsKey(num))
                    {
                        // 相当于找不到循序值 就直接抛出该循环不正确
                        return false;
                    }
                    // 如果能找到 把对应的count - 1
                    cnt[num]--;
                    // 如果对应的count 为0了 从map中移除该key
                    if (cnt[num] == 0)
                    {
                        cnt.Remove(num);
                    }
                }
            }
            return true;
        }
        public bool IsMy(int[] hand, int groupSize)
        {
            if (hand.Length % groupSize != 0)
                return false;
            Array.Sort(hand);
            Dictionary<int, int> handCountMap = new Dictionary<int, int>();
            foreach(int key in hand)
            {
                if (!handCountMap.ContainsKey(key))
                {
                    handCountMap.Add(key, 1);
                } else
                {
                    handCountMap[key]++;
                }
            }
            foreach (int key in hand)
            {
                if (!handCountMap.ContainsKey(key))
                    continue;
                for(int i = 0; i < groupSize; i++)
                {
                    int num = key + i;
                    if (!handCountMap.ContainsKey(num))
                        return false;
                    handCountMap[num]--;
                    if (handCountMap[num] == 0)
                        handCountMap.Remove(num);
                }
            }
            return true;
        }
#endif
        #endregion
        #region 507题
#if true
        public bool CheckPerfectNumber(int num)
        {
            if (num == 1)
            {
                return false;
            }

            int sum = 1;
            for (int d = 2; d * d <= num; ++d)
            {
                if (num % d == 0)
                {
                    sum += d;
                    if (d * d < num)
                    {
                        sum += num / d;
                    }
                }
            }
            return sum == num;
        }
#endif
        #endregion
    }
}
