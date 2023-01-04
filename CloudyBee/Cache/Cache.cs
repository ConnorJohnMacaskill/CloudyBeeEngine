using System.Collections.Generic;

namespace CloudyBeeEngine.Cache
{
    public class Cache<T>
    {
        private Dictionary<string, T> cacheItems;
        private T missingItem;

        public Cache(T missingItem)
        {
            this.missingItem = missingItem;
            cacheItems = new Dictionary<string, T>();
        }

        internal T MissingItem
        {
            get
            {
                return missingItem;
            }
        }

        public bool AddItem(string itemName, T item)
        {
            if (!cacheItems.TryGetValue(itemName, out T value))
            {
                cacheItems.Add(itemName, item);
                return true;
            }

            return false;
        }

        public bool GetItem(string itemName, out T item)
        {
            bool result = cacheItems.TryGetValue(itemName, out item);

            return result;
        }
    }
}