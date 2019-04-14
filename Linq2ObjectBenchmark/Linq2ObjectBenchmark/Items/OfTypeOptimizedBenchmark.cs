using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace Linq2ObjectBenchmark.Items
{
    [CoreJob]
    [MedianColumn, MinColumn, MaxColumn, MemoryDiagnoser, RankColumn]
    public class OfTypeOptimizedBenchmark
    {
        private List<IEntity> list;
        private HashSet<IEntity> set;
        private IEntity[] array;

        [Params(1000)]
        public int N { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            SetupHelper.GlobalSetup2(N, out list, out set, out array);
        }

        [Benchmark(Description = "List")]
        public List<Entity> TestList()
        {
            var result = new List<Entity>();
            foreach (var item in list)
            {
                if (item is Entity)
                {
                    result.Add((Entity)item);
                }
            }
            return result;
        }

        [Benchmark(Description = "HashSet")]
        public List<Entity> TestSet()
        {
            var result = new List<Entity>();
            foreach (var item in set)
            {
                if (item is Entity)
                {
                    result.Add((Entity)item);
                }
            }
            return result;
        }

        [Benchmark(Description = "Array")]
        public List<Entity> TestArray()
        {
            var result = new List<Entity>();
            foreach (var item in array)
            {
                if (item is Entity)
                {
                    result.Add((Entity)item);
                }
            }
            return result;
        }
    }
}