using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace Linq2ObjectBenchmark.Items
{
    [CoreJob]
    [MedianColumn, MinColumn, MaxColumn, MemoryDiagnoser, RankColumn]
    public class ForEachOptimizedBenchmark
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
        public void TestList()
        {
            var typeName = typeof(Entity).FullName;
            foreach (var item in list)
            {
                if (item.GetType().FullName == typeName)
                {

                }
            }
        }

        [Benchmark(Description = "HashSet")]
        public void TestSet()
        {
            var typeName = typeof(Entity).FullName;
            foreach (var item in set)
            {
                if (item.GetType().FullName == typeName)
                {

                }
            }
        }

        [Benchmark(Description = "Array")]
        public void TestArray()
        {
            var typeName = typeof(Entity).FullName;
            foreach (var item in array)
            {
                if (item.GetType().FullName == typeName)
                {

                }
            }
        }
    }
}