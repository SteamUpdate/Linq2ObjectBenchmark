using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Linq2ObjectBenchmark.Items;

namespace Linq2ObjectBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            // BenchmarkRunner.Run<TestBenchmark>();
//            BenchmarkRunner.Run<CountPropertyBenchmark>();
//            BenchmarkRunner.Run<CountFunctionBenchmark>();
//            BenchmarkRunner.Run<AnyBenchmark>();
//            BenchmarkRunner.Run<CountWithLambdaBenchmark>();
//            BenchmarkRunner.Run<CountWithLambdaOptimizedBenchmark>();
            BenchmarkRunner.Run<ForEachBenchmark>();
            BenchmarkRunner.Run<ForEachOptimizedBenchmark>();

//            var list = new HashSet<IEntity>();
//            for (var i = 0; i < 10; i++)
//            {
//                list.Add(new Entity { SomeStr = i.ToString()});
//            }
//
//            var result = "";
//
//            foreach (var item in list.OfType<Entity>().Where(q => q.SomeStr == "7"))
//            {
//                result = item.SomeStr;
//            }
//            
//            Console.WriteLine(result);
        }
    }

    [CoreJob]
    [MinColumn, MaxColumn, MemoryDiagnoser, RankColumn]
    public class TestBenchmark
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

        [Benchmark]
        public List<Entity> Test1()
        {
            return list
                .Where(q => q is Entity entity && ((Entity)q).SomeStr == "7")
                .Where(q => q is Entity)
                .ToList();
        }
        
        [Benchmark]
        public List<Entity> Test2()
        {
            return list
                .Where(q => q is Entity)
                .Where(q => q is Entity entity && ((Entity)q).SomeStr == "7")
                .ToList();
        }


        // [Benchmark]
        // public List<Entity> Test1()
        // {
        //     return list
        //         .OfType<Entity>()
        //         .Where(q => q.SomeStr == "7")
        //         .ToList();
        // }
        
        // [Benchmark]
        // public List<Entity> Test2()
        // {
        //     return list
        //         .Where(q => q is Entity && q.SomeStr == "7")
        //         .OfType<Entity>()
        //         .ToList();
        // }


//        [Benchmark]
//        public List<Entity> Test3()
//        {
//            var list1 = new List<Entity>();
//            foreach (var item in list.OfType<Entity>().Where(q => q.SomeStr == "7"))
//            {
//                list1.Add(item);
//            }
//
//            return list1;
//        }

//        [Benchmark]
//        public string Test1()
//        {
//            var item = set.FirstOrDefault();
//            return item != null ? item.SomeStr : string.Empty;
//        }
//
//        [Benchmark]
//        public string Test2()
//        {
//            return set.Select(q => q.SomeStr).FirstOrDefault();
//        }
        
        
        
//        [Benchmark(Description = "Array1")]
//        public int TestArray1()
//        {
//            return array.Count(q => q.GetType() == typeof(Entity));
//        }
//        
//        [Benchmark(Description = "Array2")]
//        public int TestArray2()
//        {
//            var count = 0;
//            foreach (var item in array)
//            {
//                if (item.GetType() == typeof(Entity))
//                {
//                    count++;
//                }
//            }
//            return count;
//        }
//        
//        [Benchmark(Description = "Array3")]
//        public int TestArray3()
//        {
//            var count = 0;
//            for (var i = 0; i < array.Length; i++)
//            {
//                var item = array[i];
//                if (item.GetType() == typeof(Entity))
//                {
//                    count++;
//                }
//            }
//            return count;
//        }

//        [Benchmark]
//        public Entity ListIndex()
//        {
//            return list[0];
//        }
//
//        [Benchmark]
//        public Entity ListFirst()
//        {
//            return list.First();
//        }
//
//        [Benchmark]
//        public Entity ArrayIndex()
//        {
//            return array[0];
//        }
//
//        [Benchmark]
//        public Entity ArrayFirst()
//        {
//            return array.First();
//        }
    }
}