using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace Linq2ObjectBenchmark.Items
{
    [CoreJob]
    [MinColumn, MaxColumn, MemoryDiagnoser, RankColumn]
    public class AnyWithLambdaOptimizedBenchmark
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
        public bool TestList()
        {
            var result = false;
            foreach (var item in list)
            {
                if (item.GetType() == typeof(Entity))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        [Benchmark(Description = "HashSet")]
        public bool TestSet()
        {
            var result = false;
            foreach (var item in set)
            {
                if (item.GetType() == typeof(Entity))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        [Benchmark(Description = "Array")]
        public bool TestArray()
        {
            var result = false;
            foreach (var item in array)
            {
                if (item.GetType() == typeof(Entity))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
    }
}