using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace Linq2ObjectBenchmark.Items
{
    [CoreJob]
    [MinColumn, MaxColumn, MemoryDiagnoser, RankColumn]
    public class FirstOrDefaultOptimizedBenchmark
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
            Entity entity = null;
            foreach (var item in list)
            {
                entity = item;
                break;
            }
            return entity != null;
        }

        [Benchmark(Description = "HashSet")]
        public bool TestSet()
        {
            Entity entity = null;
            foreach (var item in set)
            {
                entity = item;
                break;
            }
            return entity != null;
        }

        [Benchmark(Description = "Array")]
        public bool TestArray()
        {
            Entity entity = null;
            foreach (var item in array)
            {
                entity = item;
                break;
            }
            return entity != null;
        }
    }
}