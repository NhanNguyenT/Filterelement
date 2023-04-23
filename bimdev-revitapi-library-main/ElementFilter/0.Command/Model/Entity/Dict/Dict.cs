using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class Dict<T> : IList<T>
    {
        public List<T> Items { get; set; } = new List<T>();

        public T this[int index] 
        { 
          get => this.Items[index]; 
          set => this.Items[index]=value; 
        }

        public int Count => this.Items.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
           this.Items.Add(item);
        }

        public void Clear()
        {
           this.Items.Clear();
        }

        public bool Contains(T item)
        {
            return this.Items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
           this.Items.CopyTo(array,arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.Items.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return this.Items.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            this.Items.Insert(index,item);
        }

        public bool Remove(T item)
        {
           return this.Items.Remove(item);
        }

        public void RemoveAt(int index)
        {
           this.Items.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Items.GetEnumerator();
        }
    }
}
