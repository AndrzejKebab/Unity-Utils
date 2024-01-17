using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class ListExtensions 
{
	/// <summary>
	/// Determines whether a collection is null or has no elements
	/// without having to enumerate the entire collection to get a count.
	///
	/// Uses LINQ's Any() method to determine if the collection is empty,
	/// so there is some GC overhead.
	/// </summary>
	/// <param name="list">List to evaluate</param>
	public static bool IsNullOrEmpty<T>(this IList<T> list) 
	{
		return list == null || !list.Any();
	}

	/// <summary>
	/// Creates a new list that is a copy of the original list.
	/// </summary>
	/// <param name="list">The original list to be copied.</param>
	/// <returns>A new list that is a copy of the original list.</returns>
	public static List<T> Clone<T>(this IList<T> list)
	{
		List<T> newList = new List<T>();
		foreach (T item in list) {
			newList.Add(item);
		}

		return newList;
	}

	/// <summary>
	/// Swaps two elements in the list at the specified indices.
	/// </summary>
	/// <param name="list">The list.</param>
	/// <param name="indexA">The index of the first element.</param>
	/// <param name="indexB">The index of the second element.</param>
	public static void Swap<T>(this IList<T> list, int indexA, int indexB)
	{
		(list[indexA], list[indexB]) = (list[indexB], list[indexA]);
	}

	/// <summary>
	/// Adds an element to the specified index of the list. If the index is out of bounds,
	/// the element is added to the end of the list.
	/// </summary>
	/// <param name="list">The list to which the element is added.</param>
	/// <param name="index">The index at which the element should be added.</param>
	/// <param name="element">The element to add to the list.</param>
	public static void AddAt<T>(this IList<T> list, int index, T element)
	{
		// If the index is out of bounds, add the element to the end of the list
		if (index < 0 || index >= list.Count)
		{
			list.Add(element);
		}
		else
		{
			// Insert the element at the specified index
			list.Insert(index, element);
		}
	}

	/// <summary>
	/// Removes the last element from the list if the list is not empty.
	/// </summary>
	public static void RemoveLast<T>(this IList<T> list)
	{
		// Check if the list is empty before attempting to remove the last element
		if (list.IsNullOrEmpty()) return;

		// Remove the last element from the list
		list.RemoveAt(list.Count - 1);
	}

	/// <summary>
	/// Sorts the elements of a list based on a specified key selector.
	/// </summary>
	/// <typeparam name="T">The type of elements in the list.</typeparam>
	/// <typeparam name="T2">The type of the key used for sorting, must implement <see cref="IComparable"/>.</typeparam>
	/// <param name="list">The list to be sorted.</param>
	/// <param name="keySelector">A function that extracts a key from an element for sorting.</param>
	public static void SortBy<T, T2>(this List<T> list, Func<T, T2> keySelector) where T2 : IComparable
	{
		// Use the List<T>.Sort method with a custom comparison function based on the key selector
		list.Sort((q, w) => keySelector(q).CompareTo(keySelector(w)));
	}

	public static int LastIndex<T>(this List<T> l) => l.Count - 1;

	/// <summary>
	/// Retrieves the element at the specified index in a list, with wrapping for out-of-bounds indices.
	/// </summary>
	/// <typeparam name="T">The type of elements in the list.</typeparam>
	/// <param name="list">The list from which to retrieve the element.</param>
	/// <param name="index">The index at which to retrieve the element. Negative indices wrap around from the end of the list.</param>
	/// <returns>The element at the specified index with wrapping for out-of-bounds indices.</returns>
	public static T GetAtWrapped<T>(this List<T> list, int index)
	{
		// Wrap around negative indices from the end of the list
		while (index < 0) index += list.Count;

		// Wrap around indices that exceed the list length
		while (index >= list.Count) index -= list.Count;

		// Return the element at the wrapped index
		return list[index];
	}

	/// <summary>
	/// Determines whether an integer is within the valid index range of a list.
	/// </summary>
	/// <param name="list">The list for which to check the index range.</param>
	/// <returns>True if the integer is within the valid index range of the list; otherwise, false.</returns>
	public static bool IsInRangeOf(this int i, IList list) => i.IsInRange(0, list.Count - 1);
}