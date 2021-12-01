using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2021Day1
{
    public class Depths
    {
        List<int> DepthsList { get; }
        public Depths(List<int> depthsList)
        {
            DepthsList = depthsList;
        }

        public int CountDepthIncrement()
        {
            var count = 0;
            for (int i = 1; i < DepthsList.Count; i++)
            {
                if (DepthIncreased(DepthsList[i], DepthsList[i-1]))
                    count++;
            }
            return count;
        }
        private bool DepthIncreased(int currentDepth, int previousDepth)
        {
            return previousDepth < currentDepth;
        }

        public int CountDepthIncrementWithThreeMeasurementWindow()
        {
            var count = 0;
            if (DepthsList.Count < 3)
                return 0;

            var previousSum = DepthsList[0] + DepthsList[1] + DepthsList[2]; 
            for (int i = 1;i < DepthsList.Count;i++)
            {
                if (i > DepthsList.Count - 3)
                    return count;

                var sum = DepthsList[i] + DepthsList[i + 1] + DepthsList[i + 2];
                if (DepthIncreased(sum, previousSum))
                    count++;

                previousSum = sum;
            }

            return count;
        }
    }
}
