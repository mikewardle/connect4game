using System;
using System.Collections.Generic;

namespace Games.Core
{
	public static class IEnumerableExtensionMethods
	{
		///<summary>Finds the index of the first item matching an expression in an enumerable.</summary>
		///<param name="items">The enumerable to search.</param>
		///<param name="predicate">The expression to test the items against.</param>
		///<returns>The index of the first matching item, or -1 if no items match.</returns>
		public static int FindIndex<T>(this IEnumerable<T> items, Func<T, bool> predicate)
		{
			if (items == null) throw new ArgumentNullException("items");
			if (predicate == null) throw new ArgumentNullException("predicate");

			int retVal = 0;
			foreach (var item in items)
			{
				if (predicate(item)) return retVal;
				retVal++;
			}
			return -1;
		}
		///<summary>Finds the index of the first occurence of an item in an enumerable.</summary>
		///<param name="items">The enumerable to search.</param>
		///<param name="item">The item to find.</param>
		///<returns>The index of the first matching item, or -1 if the item was not found.</returns>
		public static int IndexOf<T>(this IEnumerable<T> items, T item) { return items.FindIndex(i => EqualityComparer<T>.Default.Equals(item, i)); }

		public static int Get4InRowFromEnumerable(this IEnumerable<int> enumerable)
		{
			//find if there are four of the same int in a row in the collection
			Queue<int> all = new Queue<int>(enumerable);
			var first = all.Dequeue();
			int count = 1;
			while (all.Count > 0)
			{
				var next = all.Dequeue();
				if (next.Equals(first))
				{
					count++;
					if (count == 4)
						return next;
				}
				else
				{
					count = 1;
					first = next;
				}
			}
			return 0;
		}
	}
}