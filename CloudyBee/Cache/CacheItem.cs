using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudyBee.Cache
{
    public class CacheItem<T>
    {
        public T Item { get; set; }
        public string Name { get; set; }
    }
}
