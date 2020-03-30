using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PriorityQueue
{
    public class PriorityQueue
    {
        readonly int[] values = null;

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="source"></param>
        /// <remarks>
        /// 二叉堆并不使用树状结构存储，而是使用数组，数组表示二叉堆的分层遍历结果
        /// 左孩子在数组中的下标LeftIndex = 父节点下标ParentIndex * 2 + 1
        /// 右孩子在数组中的下标RightIndex = 父节点下标ParentIndex * 2 + 2
        /// </remarks>
        public PriorityQueue(IEnumerable<int> source)
        {
            values = source.ToArray();

            // 首次调整，让每个父节点倒序下沉
            for (int parentIndex = (values.Length - 2) / 2; parentIndex >= 0; parentIndex--)
            {
                DownAdjust(parentIndex);
            }
        }

        /// <summary>
        /// 上浮调整
        /// </summary>
        /// <remarks>
        /// 将完全二叉树最后一个叶子节点的值向上浮起
        /// </remarks>
        private void UpAdjust()
        {
            int childIndex = values.Length - 1;
            int parentIndex = (childIndex - 1) / 2;
            int childValue = values[childIndex];
            while (childIndex > 0 &&
                childValue < values[parentIndex])
            {
                // 比较父节点并上浮
                values[childIndex] = values[parentIndex];
                childIndex = parentIndex;
                parentIndex = (childIndex - 1) / 2;
            }
            values[childIndex] = childValue;
        }

        /// <summary>
        /// 下沉调整
        /// </summary>
        /// <param name="parentIndex"></param>
        /// <remarks>
        /// 将完全二叉树根节点向下沉降
        /// </remarks>
        private void DownAdjust(int parentIndex)
        {
            int parentValue = values[parentIndex];
            int childIndex = parentIndex * 2 + 1;
            while (childIndex < values.Length)
            {
                if (childIndex + 1 < values.Length &&
                    values[childIndex + 1] < values[childIndex])
                {
                    childIndex++;
                }

                if (parentValue <= values[childIndex])
                {
                    break;
                }

                values[parentIndex] = values[childIndex];
                parentIndex = childIndex;
                childIndex = parentIndex * 2 + 1;
            }

            values[parentIndex] = parentValue;
        }

        public int GetTop() => values.FirstOrDefault();
    }
}
