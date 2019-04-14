using System.Collections.Generic;

namespace Linq2ObjectBenchmark
{
    public static class SetupHelper
    {   
        public static void GlobalSetup(int n, out List<Entity> list, out HashSet<Entity> set, out Entity[] array)
        {
            list = new List<Entity>(n);
            set = new HashSet<Entity>(n);
            array = new Entity[n];
            for (var i = 0; i < n; i++)
            {
                var entity = new Entity
                {
                    SomeStr = i.ToString()
                };
                list.Add(entity);
                set.Add(entity);
                array[i] = entity;
            }
        }
        
        public static void GlobalSetup2(int n, out List<IEntity> list, out HashSet<IEntity> set, out IEntity[] array)
        {
            list = new List<IEntity>(n);
            set = new HashSet<IEntity>(n);
            array = new IEntity[n];
            for (var i = 0; i < n; i++)
            {
                var entity = new Entity
                {
                    SomeStr = i.ToString()
                };
                list.Add(entity);
                set.Add(entity);
                array[i] = entity;
            }
        }
    }
}