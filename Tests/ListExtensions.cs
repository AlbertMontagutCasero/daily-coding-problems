using System.Collections.Generic;
using System.Linq;

namespace DailyCodingProblem1091.Test
{
    public static class ListExtensions
    {
        public static bool AllElementsEquals(
            this List<List<int>> list,
            List<List<int>> other)
        {
            if (list.Count != other.Count)
            {
                return false;
            }

            var found = false;
            var i = 0;

            while (!found && i < list.Count)
            {
                var listCurrentPosition = list[i];
                var otherCurrentPosition = other[i];

                if (otherCurrentPosition.SequenceEqual(
                        listCurrentPosition))
                {
                    found = true;
                }

                i++;
            }

            return found;
        }
    }
}
