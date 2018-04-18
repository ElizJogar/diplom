﻿using System;
using KnapsackProblem;

namespace Algorithm
{
    public class ExhaustiveSearchAlgorithm
    {
        private IData m_data;
        public ExhaustiveSearchAlgorithm (IData data)
        {
            m_data = data;
        }
        public int Run()
        {
            int itemsCount = m_data.WEIGHT.Length;
            int limit = m_data.CAPACITY;
            int[,] K = new int[itemsCount + 1, limit + 1];

            for (int i = 0; i <= itemsCount; ++i)
            {
                for (int w = 0; w <= limit; ++w)
                {
                    if (i == 0 || w == 0)
                        K[i, w] = 0;
                    else if (m_data.WEIGHT[i - 1] <= w)
                        K[i, w] = Math.Max(m_data.COST[i - 1] + K[i - 1, w - m_data.WEIGHT[i - 1]], K[i - 1, w]);
                    else
                        K[i, w] = K[i - 1, w];
                }
            }

            return K[itemsCount, m_data.CAPACITY];
        }
    }
}
