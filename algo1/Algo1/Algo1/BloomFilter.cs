using System.Collections;

namespace AlgorithmsDataStructuresBloomFilter
{
    public class BloomFilter
    {
        public int filter_len;

        private BitArray _bitArray;

        public BloomFilter(int f_len)
        {
            filter_len = f_len;
            _bitArray = new BitArray(f_len);
        }

        // хэш-функции
        public int Hash1(string str1)
        {
            // 17
            var randomValue = 17;
            decimal result = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                var code = (int)(str1[i]);
                result = result * randomValue + (int)(str1[i]);
            }
            // реализация ...
            return (int)(result % filter_len);
        }
        public int Hash2(string str1)
        {
            // 223
            // реализация ...
            var randomValue = 223;
            decimal result = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                result = result * randomValue + (int)str1[i];
            }
            // реализация ...
            return (int)(result % filter_len);
        }

        public void Add(string str1)
        {
            var pos1 = Hash1(str1);
            var pos2 = Hash2(str1);

            _bitArray.Set(pos1, true);
            _bitArray.Set(pos2, true);
        }

        public bool IsValue(string str1)
        {
            // проверка, имеется ли строка str1 в фильтре
            var pos1 = Hash1(str1);
            var pos2 = Hash2(str1);

            if (_bitArray.Get(pos1) && _bitArray.Get(pos2))
            {
                return true;
            }
            return false;
        }
    }
}