using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace Linq2ObjectBenchmark.Items
{
    [CoreJob]
    [MedianColumn, MinColumn, MaxColumn, MemoryDiagnoser, RankColumn]
    public class SelectBenchmark
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
            return list.Select(q => q.SomeStr).ToList();
        }

        [Benchmark(Description = "HashSet")]
        public List<string> TestSet()
        {
            return set.Select(q => q.SomeStr).ToList();
        }

        [Benchmark(Description = "Array")]
        public List<string> TestArray()
        {
            return array.Select(q => q.SomeStr).ToList();
        }
    }
}