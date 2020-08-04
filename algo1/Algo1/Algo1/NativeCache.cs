using System;

namespace AlgorithmsDataStructuresNativeCache
{
    public class NativeCache<T>
    {
        public int size;
        public String[] slots;
        public T[] values;
        public int[] hits;

        private int step = 3;


        public NativeCache(int sz)
        {
            size = sz;
            slots = new string[size];
            values = new T[size];
            hits = new int[size];
        }

        public int HashFun(string key)
        {
            // всегда возвращает корректный индекс слота
            int charTableCodesSum = 0;
            for (int i = 0; i < key.Length; i++)
            {
                charTableCodesSum += key[i];
            }

            return charTableCodesSum % size;
        }

        public bool IsKey(string key)
        {
            // возвращает true если ключ имеется,
            // иначе false
            var index = Find(key);
            return index != -1;
        }

        public void Put(string key, T value)
        {
            // гарантированно записываем 
            // значение value по ключу key
            var keyIndex = Put(key);
            if (keyIndex != -1)
            {
                values[keyIndex] = value;
                return;
            }

            var indexWithMinHits = GetIndexWithMinHits();
            if (indexWithMinHits != -1)
            {
                slots[indexWithMinHits] = key;
                values[indexWithMinHits] = value;
                hits[indexWithMinHits] = 0;
            }
        }

        public T Get(string key)
        {
            // возвращает value для key, 
            // или null если ключ не найден
            var index = Find(key);
            if (index == -1)
            {
                return default(T);
            }

            hits[index]++;
            return values[index];
        }

        private int SeekSlot(string value)
        {
            var slot0 = HashFun(value);
            if (slots[slot0] == null)
            {
                return slot0;
            }

            if (size % step == 0)
            {
                var curStep = step;
                while (curStep > 0)
                {
                    var stepsCount = size / curStep;
                    for (int i = 1; i < stepsCount; i++)
                    {
                        int slot = (slot0 + i * curStep) % size;
                        if (slots[slot] == null)
                        {
                            return slot;
                        }
                    }
                    curStep--;
                }
            }
            else
            {
                var curIndex = slot0;
                do
                {
                    curIndex = (curIndex + step) % size;
                    if (slots[curIndex] == null)
                    {
                        return curIndex;
                    }
                }
                while (curIndex != slot0);
            }

            return -1;
        }

        private int Put(string value)
        {
            // записываем значение по хэш-функции

            // возвращается индекс слота или -1
            // если из-за коллизий элемент не удаётся разместить 
            var index = SeekSlot(value);
            if (index != -1)
            {
                slots[index] = value;
            }

            return index;
        }

        private int Find(string value)
        {
            // находит индекс слота со значением, или -1
            var slot0 = HashFun(value);
            if (slots[slot0] == null)
            {
                return -1;
            }
            else if (slots[slot0] == value)
            {
                return slot0;
            }


            if (size % step == 0)
            {
                var curStep = step;
                while (curStep > 0)
                {
                    var stepsCount = size / curStep;
                    for (int i = 1; i < stepsCount; i++)
                    {
                        int slot = (slot0 + i * curStep) % size;
                        if (slots[slot] == null)
                        {
                            return -1;
                        }
                        else if (slots[slot] == value)
                        {
                            return slot;
                        }
                    }
                    curStep--;
                }
            }
            else
            {
                var curIndex = slot0;
                do
                {
                    curIndex = (curIndex + step) % size;
                    if (slots[curIndex] == null)
                    {
                        return -1;
                    }
                    else if (slots[curIndex] == value)
                    {
                        return curIndex;
                    }
                }
                while (curIndex != slot0);
            }

            return -1;
        }

        private int GetIndexWithMinHits()
        {
            var currentMinHitsValue = int.MaxValue;
            var currentMinHitsIndex = -1;
            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i] < currentMinHitsValue)
                {
                    currentMinHitsValue = hits[i];
                    currentMinHitsIndex = i;
                }
            }
            return currentMinHitsIndex;
        }
    }
}