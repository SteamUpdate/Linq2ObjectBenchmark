using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace Linq2ObjectBenchmark.Items
{
    [CoreJob]
    [MedianColumn, MinColumn, MaxColumn, MemoryDiagnoser, RankColumn]
    public class SelectOptimizedBenchmark
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
        public List<string> TestList()
        {
            var result = new List<string>(list.Count);
            foreach (var item in list)
            {
                result.Add(item.SomeStr);
            }
            return result;
        }

        [Benchmark(Description = "HashSet")]
        public List<string> TestSet()
        {
            var result = new List<string>(set.Count);
            foreach (var item in set)
            {
                result.Add(item.SomeStr);
            }
            return result;
        }

        [Benchmark(Description = "Array")]
        public List<string> TestArray()
        {
            var result = new List<string>(array.Length);
            foreach (var item in array)
            {
                result.Add(item.SomeStr);
            }
            return result;
        }
    }
}