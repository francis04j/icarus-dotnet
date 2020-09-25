using System;
using System.Collections.Generic;
using System.Text;

namespace PodcastWebApi.Application.Common
{
    public class LRUcache
    {
        private Dictionary<char, Tuple<char, int>> Hashmap = new Dictionary<char, Tuple<char, int>>();
        private int count;
        private int size;

        public void Init(char [] values)
        {
            size = values.Length;
            foreach(var elem in values)
            {

                Hashmap.Add(elem, new Tuple<char, int>(elem, count));

            }
        }

        public char? Get(char key)
        {
            // var item = Hashmap[key];
            Tuple<char, int> value = null;
            if (!Hashmap.TryGetValue(key, out value))
            {
                // key does not exist
                return null;
            }

            // if(Hashmap.Contains(key))
            // {
            //
            //}
            Hashmap[key] = new Tuple<char, int>(key, count);
            ++count;

            return value.Item1;
        }

        public void Put(char value)
        {
            if (Hashmap.ContainsKey(value))
            {
                Hashmap.Remove(value);
            }

            //if FULL
            /*if len(self.hashmap) == self.size:
            stalest_key = None
            stalest_count = None
            for k, item in self.hashmap.items():
                if stalest_key is None or item[1] < stalest_count:
                    stalest_key = k
                    stalest_count = item[1]
            del self.hashmap[stalest_key]
            */
            if(Hashmap.Count == size)
            {
                char? stalest_key = null;
                int stalest_count = 0;
                foreach(var elem in Hashmap.Values)
                {
                    if(stalest_key == 0 && elem.Item2 < stalest_count)
                    {
                        stalest_key = value; //note value and key are the same
                        stalest_count = elem.Item2;
                    }
                }
                Hashmap.Remove(stalest_key.Value);
            }
           
            var item = new Tuple<char, int>(value, count);
            ++count;
            Hashmap[value] = item;
        }
    }
}
