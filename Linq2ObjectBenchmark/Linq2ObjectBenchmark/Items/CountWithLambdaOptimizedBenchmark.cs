using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace Linq2ObjectBenchmark.Items
{
    [CoreJob]
    [MinColumn, MaxColumn, MemoryDiagnoser, RankColumn]
    public class CountWithLambdaOptimizedBenchmark
    {
        private List<Entity> list;
        private HashSet<Entity> set;
        private Entity[] array;
        
        [Params(1000)]
        public int N { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            SetupHelper.GlobalSetup(N, out list, out set, out array);
        }

        [Benchmark(Description = "List")]
        public int TestList()
        {
            var count = 0;
            foreach (var item in list)
            {
                if (item.GetType() == typeof(Entity))
                {
                    count++;
                }
            }
            return count;
        }

        [Benchmark(Description = "HashSet")]
        public int TestSet()
        {
            var count = 0;
            foreach (var item in set)
            {
                if (item.GetType() == typeof(Entity))
                {
                    count++;
                }
            }
            return count;
        }

        [Benchmark(Description = "Array")]
        public int TestArray()
        {
            var count = 0;
            foreach (var item in array)
            {
                if (item.GetType() == typeof(Entity))
                {
                    count++;
                }
            }
            return count;
        }
        
    }
}