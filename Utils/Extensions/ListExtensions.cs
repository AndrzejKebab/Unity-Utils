using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

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
		if (index < 0 || index >= list.Count)
		{
			list.Add(element);
		}
		else
		{
			list.Insert(index, element);
		}
	}

	/// <summary>
	/// Removes the last element from the list if the list is not empty.
	/// </summary>
	public static void RemoveLast<T>(this IList<T> list)
	{
		if (list.IsNullOrEmpty()) return;
		list.RemoveAt(list.Count - 1);
	}

	/// <summary>
	/// Sorts the elements of a list based on a specified key selector.
	/// </summary>
	/// <typeparam name="T">The type of elements in the list.</typeparam>
	/// <typeparam name="T2">The type of the key used for sorting, must implement <see cref="IComparable"/>.</typeparam>
	/// <param name="keySelector">A function that extracts a key from an element for sorting.</param>
	public static void SortBy<T, T2>(this List<T> list, Func<T, T2> keySelector) where T2 : IComparable
	{
		list.Sort((q, w) => keySelector(q).CompareTo(keySelector(w)));
	}

	public static int LastIndex<T>(this List<T> l) => l.Count - 1;

	/// <summary>
	/// Retrieves the element at the specified index in a list, with wrapping for out-of-bounds indices.
	/// </summary>
	/// <typeparam name="T">The type of elements in the list.</typeparam>
	/// <param name="index">The index at which to retrieve the element. Negative indices wrap around from the end of the list.</param>
	/// <returns>The element at the specified index with wrapping for out-of-bounds indices.</returns>
	public static T GetAtWrapped<T>(this List<T> list, int index)
	{
		while (index < 0) index += list.Count;
		while (index >= list.Count) index -= list.Count;

		return list[index];
	}

	/// <summary>
	/// Retrieves a random element from a list.
	/// </summary>
	/// <param name="list">The list from which to retrieve a random element.</param>
	/// <returns>A random element from the list.</returns>
	public static T GetRandomItem<T>(this IList<T> list)
	{
		int randomIndex = Random.Range(0, list.Count);
		return list[randomIndex];
	}

	/// <summary>
	/// Removes a random element from a list and returns it.
	/// </summary>
	/// <typeparam name="T">The type of elements in the list.</typeparam>
	/// <param name="list">The list from which to remove a random element.</param>
	/// <returns>The removed random element.</returns>
	/// <exception cref="System.IndexOutOfRangeException">Thrown if the list is empty.</exception>
	public static T RemoveRandomItem<T>(this IList<T> list)
	{
		if (list.Count == 0) throw new IndexOutOfRangeException("Cannot remove a random item from an empty list");

		int index = Random.Range(0, list.Count);
		T item = list[index];
		list.RemoveAt(index);

		return item;
	}

	/// <summary>
	/// Shuffles the elements of a list using the Fisher-Yates algorithm.
	/// </summary>
	/// <param name="list">The list to be shuffled.</param>
	public static void Shuffle<T>(this IList<T> list)
	{
		// Use the Fisher-Yates algorithm to shuffle the elements in the list
		for (var i = list.Count - 1; i > 0; i--)
		{
			// Generate a random index within the remaining unshuffled elements
			var j = Random.Range(0, i + 1);

			// Swap the elements at indices i and j
			var value = list[j];
			list[j] = list[i];
			list[i] = value;
		}
	}
}