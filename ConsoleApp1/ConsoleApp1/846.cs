using System;
using System.Collections.Generic;



namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //ListNode l1 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9)))))));
            //ListNode l2 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))));
            //Solution solution = new Solution();
            //ListNode l3 = solution.AddTwoNumbers(l1, l2);
            //while(l3.next != null)
            //{
            //    Console.WriteLine(l3.val);
            //    l3 = l3.next;
            //}
            //int[] nums1 = { }, nums2 = {2,3 };
            //Solution solution = new Solution();
            //double s = solution.FindMedianSortedArrays(nums1, nums2);
            //Console.WriteLine(s);
        }
    }
    public class Solution
    {
        #region 846题
#if false
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
#if false
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
        public bool CheckPerfectNumber(int num)
        {
            if (num == 1)
                return false;
            int sum = 1;
            for(int i = 2; i * i <=num; i++)
            {
                if (num % i == 0)
                {
                    sum = sum +  i + (num / i);
                }
            }
            return sum == num;
        }
#endif
        #endregion
        #region 2题
        /*
 2. 两数相加

给你两个 非空 的链表，表示两个非负的整数。它们每位数字都是按照 逆序 的方式存储的，并且每个节点只能存储 一位 数字。
请你将两个数相加，并以相同形式返回一个表示和的链表。
你可以假设除了数字 0 之外，这两个数都不会以 0 开头。

2->4->3
5->6->4
------------
7->0->8

示例 1：
输入：l1 = [2,4,3], l2 = [5,6,4]
输出：[7,0,8]
解释：342 + 465 = 807.

示例 2：
输入：l1 = [0], l2 = [0]
输出：[0]

示例 3：
输入：l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
输出：[8,9,9,9,0,0,0,1]

 */
#if false
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int val = 0; // 进位
            ListNode returnListNode = new ListNode(0);
            ListNode tempListNode = returnListNode;
            while (l1 != null || l2 != null || val != 0)
            {
                int sum = (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val) + val;
                val = (sum) / 10;
                int j = (sum) % 10;
                tempListNode.next = new ListNode(j);
                tempListNode = tempListNode.next;
                l1 = l1 != null ? l1.next : null;
                l2 = l2 != null ? l2.next : null;
            }
            return returnListNode.next;
        }
#endif
        #endregion
        #region 4题
#if false
        /*
         4. 寻找两个正序数组的中位数  困难
        给定两个大小分别为 m 和 n 的正序（从小到大）数组 nums1 和 nums2。请你找出并返回这两个正序数组的 中位数 。

算法的时间复杂度应该为 O(log (m+n)) 。

 

示例 1：

输入：nums1 = [1,3], nums2 = [2]
输出：2.00000
解释：合并数组 = [1,2,3] ，中位数 2
示例 2：

输入：nums1 = [1,2], nums2 = [3,4]
输出：2.50000
解释：合并数组 = [1,2,3,4] ，中位数 (2 + 3) / 2 = 2.5
示例 3：

输入：nums1 = [0,0], nums2 = [0,0]
输出：0.00000
示例 4：

输入：nums1 = [], nums2 = [1]
输出：1.00000
示例 5：

输入：nums1 = [2], nums2 = []
输出：2.00000
 

提示：

nums1.length == m
nums2.length == n
0 <= m <= 1000
0 <= n <= 1000
1 <= m + n <= 2000
-10^6 <= nums1[i], nums2[i] <= 10^6
         */
        public double FindMedianSortedArrays(int[] A, int[] B)
        {
            int m = A.Length;
            int n = B.Length;
            if (m > n) return FindMedianSortedArrays(B, A);
            //正在寻找的范围为 [ A[iMin],A[iMax] ) , 左闭右开。二分查找取i=(iMin+iMax)/2
            int iMin = 0, iMax = m;
            while (iMin <= iMax)
            {
                int i = (iMin + iMax) / 2;
                int j = (m + n + 1) / 2 - i;
                if (j != 0 && i != m && B[j - 1] > A[i])
                { // i 需要增大
                    iMin = i + 1;
                }
                else if (i != 0 && j != n && A[i - 1] > B[j])
                { // i 需要减小
                    iMax = i - 1;
                }
                else
                { // 达到要求，并且将边界条件列出来单独考虑
                    int maxLeft = 0;
                    if (i == 0) { maxLeft = B[j - 1]; }
                    else if (j == 0) { maxLeft = A[i - 1]; }
                    else { maxLeft = Math.Max(A[i - 1], B[j - 1]); }
                    if ((m + n) % 2 == 1) { return maxLeft; } // 奇数的话不需要考虑右半部分

                    int minRight = 0;
                    if (i == m) { minRight = B[j]; }
                    else if (j == n) { minRight = A[i]; }
                    else { minRight = Math.Min(B[j], A[i]); }

                    return (maxLeft + minRight) / 2.0; //如果是偶数的话返回结果
                }
            }
            return 0.0;
        }
#endif
        #endregion
        #region 5题
#if true
        //给你一个字符串 s，找到 s 中最长的回文子串。
        /*
        
        示例 1：
        输入：s = "babad"
        输出："bab"
        解释："aba" 同样是符合题意的答案。
       
        示例 2：
        输入：s = "cbbd"
        输出："bb"

        提示：

        1 <= s.length <= 1000
        s 仅由数字和英文字母组成
         */
        //public string LongestPalindrome(string s)
        //{
        //    // 思路 找一个中间值 往两边增长 看看是否是回文串  有2种中心 一种单个 一种双个
        //    //char[] array = s.ToCharArray();
        //    if (s == null)
        //        return "";
        //    int count = s.Length - 1;
        //    int resultCenterIndex = 1;
        //    int resultLength = 1;
        //    for(int centerIndex = 1; centerIndex < (s.Length + 1) / 2; centerIndex++)
        //    {
        //        int len = 1;
        //        while ((centerIndex + (len + 1) / 2) <= count && s[centerIndex - (len + 1) / 2] == s[centerIndex + (len + 1) / 2])
        //        {
        //            len = len + 2;
        //        }
        //        if(len > resultLength)
        //        {
        //            resultLength = len;
        //            resultCenterIndex = centerIndex;
        //        }
        //    }
        //    for (int centerIndex = 1; centerIndex <= (s.Length + 1) / 2; centerIndex++)
        //    {
        //        int len = 2;
        //        while ((centerIndex + (len + 1) / 2) <= count && s[centerIndex - (len + 1) / 2] == s[centerIndex + (len + 2) / 2])
        //        {
        //            len = len + 2;
        //        }
        //        if (len > resultLength)
        //        {
        //            resultLength = len;
        //            resultCenterIndex = centerIndex;
        //        }
        //    }
        //    string resultString = "";
        //    if(resultLength % 2 == 0)
        //    {
        //        resultString = string.Format("{0}{1}", s[resultCenterIndex], s[resultCenterIndex + 1]); 
        //        for(int i = 1; i <= (resultLength - 2) / 2; i++)
        //        {
        //            resultString = string.Format("{0}{1}{2}", s[resultCenterIndex - i], resultString, s[resultCenterIndex + 1 + i]);
        //        }
        //    } else
        //    {
        //        resultString = string.Format("{0}", s[resultCenterIndex]);
        //        for (int i = 1; i <= (resultLength - 1) / 2; i++)
        //        {
        //            resultString = string.Format("{0}{1}{2}", s[resultCenterIndex - i], resultString, s[resultCenterIndex + i]);
        //        }
        //    }
        //    return resultString;

        //}
        public string PreProcess(string s)
        {
            string t = "^";
            int n = s.Length;
            if (n == 0) return "^$";
            for (int i = 0; i < n; i++)
            {
                t += "#" + s[i];
            }
            t += "#$";
            return t;
        }

        // 方法四：马拉车算法 108ms,26.4M
        public string LongestPalindrome(string s)
        {
            string t = PreProcess(s);
            int n = t.Length;
            int[] p = new int[n];
            int c = 0, r = 0;
            //计算P
            for (int i = 1; i < n - 1; i++)
            {
                int j = 2 * c - i;
                //情况2和3可以总结为 p[i]= min(r - i + 1, p[j]) ,情况1为 p[i]=1;
                p[i] = r > i ? Math.Min(r - i + 1, p[j]) : 1;
                //对于情况4和1，直接扩展即可；
                //对于情况2和3，也可以直接扩展；虽然一定扩展不了，但是这样的计算过程比“判断是情况2或3”的计算量还要小，仔细品味
                while (t[i - p[i]] == t[i + p[i]])
                {
                    p[i]++;
                }
                if (i + p[i] > r)
                {
                    //找到了更长的回文串，更新c和r
                    c = i;
                    r = i + p[i] - 1;
                }
            }
            // 找出 P 的最大值
            int maxLen = 0;
            int centerIndex = 0;
            for (int i = 1; i < n - 1; i++)
            {
                int len = p[i] - 1;
                if (len > maxLen)
                {
                    maxLen = len;
                    centerIndex = i;
                }
            }
            int start = (centerIndex - maxLen) / 2;
            return s.Substring(start, maxLen);
        }
#endif
        #endregion
    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
