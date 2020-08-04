using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructuresHashTable
{

    public class HashTable
    {
        public int size;
        public int step;
        public string[] slots;

        public HashTable(int sz, int stp)
        {
            size = sz;
            step = stp;
            slots = new string[size];
            for (int i = 0; i < size; i++) slots[i] = null;
        }

        public int HashFun(string value)
        {
            int charTableCodesSum = 0;
            for (int i = 0; i < value.Length; i++)
            {
                charTableCodesSum += value[i];
            }

            return charTableCodesSum % size;
        }

        public int SeekSlot(string value)
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

        public int Put(string value)
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

        public int Find(string value)
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
    }

}