using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Лаба_15
{
    internal class HashNode<K, V>
    {
        public K key;
        public V value;
        public int hashCode;
        public HashNode<K, V> next;
        public HashNode(K key, V value, int HashCode)
        {
            this.key = key;
            this.value = value;
            this.hashCode = HashCode;
        }
    }

    internal class Map<K, V>
    {
        private List<HashNode<K, V>> bucketArray;
        private int size;
        private int numBuckets;

        public Map(int numBuckets = 5)
        {
            this.bucketArray = new List<HashNode<K, V>>(numBuckets);
            this.numBuckets = numBuckets;
            this.size = 0;
            for (int i = 0; i < numBuckets; i++)
            {
                bucketArray.Add(null);
            }
        }

        public int Size() { return size; }
        public bool isEmpty() { return Size() == 0; }

        private int hashCode(K key)
        {
            return key.GetHashCode();
        }
        private int getBucketIndex(K key)
        {
            int hashCode = key.GetHashCode();
            int index = hashCode % 10;
            index = index < 0 ? index * (-1) : index;
            return index;
        }
        public V remove(K key)
        {
            int bucketIndex = getBucketIndex(key);
            HashNode<K, V> headNode = bucketArray[bucketIndex];
            HashNode<K, V> prevNode = null;

            while (headNode != null)
            {
                if (headNode.key.Equals(key))
                {
                    break;
                }
                prevNode = headNode;
                headNode = headNode.next;
            }

            if (headNode == null)
            {
                return default(V);
            }

            size--;

            if (prevNode != null)
            {
                prevNode.next = headNode.next;
            }
            else
            {
                bucketArray[bucketIndex] = headNode.next;
            }

            return headNode.value;
        }
        public void Add(K key, V value)
        {
            int bucketIndex = getBucketIndex(key);
            int hashCode = key.GetHashCode();
            HashNode<K, V> head = bucketArray[bucketIndex];
            while (head != null)
            {
                if (head.key.Equals(key))
                {
                    head.value = value;
                    return;
                }
                head = head.next;
            }
            size++;
            head = bucketArray[bucketIndex];
            HashNode<K, V> newNode
                = new HashNode<K, V>(key, value, hashCode);
            newNode.next = head;
            bucketArray[bucketIndex] = newNode;


        }
        public override string ToString()
        {
            var str = new StringBuilder();
            for (int i = 0; i < numBuckets; ++i)
            {
                str.Append(i + ": ");
                var temp = bucketArray[i];
                while (temp != null)
                {

                    str.Append(temp.ToString() + " ");
                    temp = temp.next;
                }
                str.AppendLine();
            }
            return str.ToString();
        }
    }
}