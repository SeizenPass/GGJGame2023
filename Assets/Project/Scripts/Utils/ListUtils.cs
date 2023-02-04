using System.Collections.Generic;

namespace Project.Utils
{
    public class ListUtils
    {
        public static bool Contains<T>(List<T> list, T element)
        {
            if (list == null) return false;
            foreach (var e in list)
            {
                if (e.Equals(element))
                {
                    return true;
                }
            }

            return false;
        }
    }
}