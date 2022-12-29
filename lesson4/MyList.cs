using System;

namespace lesson4
{
    public class MyList<T>
    {
        private int _Count = 0;
        public int Count
        {
            get => _Count;
        }
        T[] Elems = new T[0];
        public T this[int Index]
        {
            get => Elems[Index];
            set => Elems[Index] = value;
        }

        public void Add(T Item)
        {
            if(Elems.Length == _Count)
            {
                Array.Resize(ref Elems, Elems.Length + 1);
                Elems[_Count] = Item;
                _Count++;
            }
        }
        public void DeleteByIndex(int Index)
        {
            if (Index >= 0 && Index < Elems.Length)
            {
                T[] Arr = new T[Elems.Length - 1];
                int IndexForNewArr = 0;
                int IndexForOldArr = 0;
                while (true)
                {
                    if (IndexForOldArr != Index)
                    {
                        Arr[IndexForNewArr] = Elems[IndexForOldArr];
                        IndexForNewArr++;
                    }
                    IndexForOldArr++;
                    if(IndexForOldArr > Elems.Length - 1)
                    {
                        break;
                    }
                }
                Array.Clear(Elems, 0, Elems.Length);
                Array.Resize(ref Elems, Arr.Length);
                Arr.CopyTo(Elems, 0);
                _Count--;
            }
        }
        public void DeleteByElement(T Item)
        {
            int Index = Array.IndexOf(Elems, Item);
            if (Index != -1)
            {
                T[] Arr = new T[Elems.Length - 1];
                int IndexForNewArr = 0;
                int IndexForOldArr = 0;
                while (true)
                {
                    if (IndexForOldArr != Index)
                    {
                        Arr[IndexForNewArr] = Elems[IndexForOldArr];
                        IndexForNewArr++;
                    }
                    IndexForOldArr++;
                    if (IndexForOldArr > Elems.Length - 1)
                    {
                        break;
                    }
                }
                Array.Clear(Elems, 0, Elems.Length);
                Array.Resize(ref Elems, Arr.Length);
                Arr.CopyTo(Elems, 0);
                _Count--;
            }
        }
    }
}
