using System.Collections.Generic;

namespace OnlineShopDuhootWeb.Service
{
    public static class EmptyIndexSearch
    {
        /// <summary>
        /// Осуществляет поиск свободных ячеек коллекции, возвращает индекс первой свободной, если свободных нет, вернет -1
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static int Search(IEnumerable<int> ts)
        {
            var producersIdEnum = ts.GetEnumerator();
            producersIdEnum.MoveNext();
            var firstId = producersIdEnum.Current;

            while (producersIdEnum.MoveNext())// O(n)
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
