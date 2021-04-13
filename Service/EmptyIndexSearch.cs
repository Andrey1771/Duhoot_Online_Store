using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopDuhootWeb.Service
{
    public static class EmptyIndexSearch
    {
        public static int Search(IEnumerable<int> ts)
        {
            var producersIdEnum = ts.GetEnumerator();
            producersIdEnum.MoveNext();
            var firstId = producersIdEnum.Current;

            while (producersIdEnum.MoveNext())//O(n)
            {
                if (producersIdEnum.Current - firstId != 1)
                {
                    return firstId + 1;
                }
                firstId = producersIdEnum.Current;

            }
            if (firstId < int.MaxValue)
                return firstId + 1;
            return -1;
        }
    }
}
