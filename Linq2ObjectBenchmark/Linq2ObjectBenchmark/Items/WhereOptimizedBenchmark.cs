using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace Linq2ObjectBenchmark.Items
{
    [CoreJob]
    [MedianColumn, MinColumn, MaxColumn, MemoryDiagnoser, RankColumn]
    public class WhereOptimizedBenchmark
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
        public List<Entity> TestList()
        {
            var result = new List<Entity>();
            foreach (var item in list)
            {
                if (item.SomeStr == "456")
                {
                    result.Add(item);
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
                if (item.SomeStr == "456")
                {
                    result.Add(item);
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
                if (item.SomeStr == "456")
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}