using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace Linq2ObjectBenchmark.Items
{
    [CoreJob]
    [MedianColumn, MinColumn, MaxColumn, MemoryDiagnoser, RankColumn]
    public class WhereBenchmark
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
            return list.Where(q => q.SomeStr == "456").ToList();
        }

        [Benchmark(Description = "HashSet")]
        public List<Entity> TestSet()
        {
            return set.Where(q => q.SomeStr == "456").ToList();
        }

        [Benchmark(Description = "Array")]
        public List<Entity> TestArray()
        {
            return array.Where(q => q.SomeStr == "456").ToList();
        }
    }
}