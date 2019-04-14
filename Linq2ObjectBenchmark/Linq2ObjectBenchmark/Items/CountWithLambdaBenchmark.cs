using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace Linq2ObjectBenchmark.Items
{
    [CoreJob]
    [MinColumn, MaxColumn, MemoryDiagnoser, RankColumn]
    public class CountWithLambdaBenchmark
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
            return list.Count(q => q.GetType() == typeof(Entity));
        }

        [Benchmark(Description = "HashSet")]
        public int TestSet()
        {
            return set.Count(q => q.GetType() == typeof(Entity));
        }

        [Benchmark(Description = "Array")]
        public int TestArray()
        {
            return array.Count(q => q.GetType() == typeof(Entity));
        }
        
    }
}