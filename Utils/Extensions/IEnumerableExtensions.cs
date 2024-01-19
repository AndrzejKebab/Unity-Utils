using System;
using System.Collections.Generic;

public static class IEnumerableExtensions
{
	#region Any
	/// <summary>
	/// Determines whether any element exists in the sequence.
	/// </summary>
	/// <typeparam name="T">The type of elements in the sequence.</typeparam>
	/// <returns>True if the sequence contains any elements; otherwise, false.</returns>
	public static bool Any<T>(this IEnumerable<T> source)
	{
		if (source == null) return false;
		using (var enumerator = source.GetEnumerator())
		{
			return enumerator.MoveNext();
		}
	}

	/// <summary>
	/// Determines whether any element in the sequence satisfies a condition.
	/// </summary>
	/// <typeparam name="T">The type of elements in the sequence.</typeparam>
	/// <param name="predicate">A function to test each element for a condition.</param>
	/// <returns>True if any element satisfies the condition; otherwise, false.</returns>
	public static bool Any<T>(this IEnumerable<T> source, Predicate<T> predicate)
	{
		if (source == null) return false;
		foreach (var item in source)
		{
			if (predicate(item)) return true;
		}

		return false;
	}
	#endregion

	#region Min / Max
	/// <summary>
	/// Returns the minimum element of the sequence based on a key extracted using a specified function.
	/// </summary>
	/// <typeparam name="T">The type of elements in the sequence.</typeparam>
	/// <typeparam name="TValue">The type of the key.</typeparam>
	/// <param name="keyGetter">A function to extract a key from an element.</param>
	/// <param name="minValue">When this method returns, contains the minimum value.</param>
	/// <returns>The element with the minimum key value.</returns>
	public static T Min<T, TValue>(this IEnumerable<T> source, Func<T, TValue> keyGetter, out TValue minValue)
		where TValue : IComparable
	{
		T minItem = default;
		minValue = default(TValue);
		foreach (var item in source)
		{
			if (item == null) continue;
			var itemValue = keyGetter(item);
			if ((minItem != null) && (itemValue.CompareTo(minValue) >= 0)) continue;
			minValue = itemValue;
			minItem = item;
		}

		return minItem;
	}

	/// <summary>
	/// Returns the minimum element of the sequence based on a key extracted using a specified function.
	/// </summary>
	/// <typeparam name="T">The type of elements in the sequence.</typeparam>
	/// <typeparam name="TValue">The type of the key.</typeparam>
	/// <param name="selector">A function to extract a key from an element.</param>
	/// <returns>The element with the minimum key value.</returns>
	public static T Min<T, TValue>(this IEnumerable<T> source, Func<T, TValue> selector)
		where TValue : IComparable
	{
		var result = source.Min(selector, out _);
		return result;
	}

	/// <summary>
	/// Returns the maximum element of the sequence based on a key extracted using a specified function.
	/// </summary>
	/// <typeparam name="T">The type of elements in the sequence.</typeparam>
	/// <typeparam name="TValue">The type of the key.</typeparam>
	/// <param name="keyGetter">A function to extract a key from an element.</param>
	/// <param name="maxValue">When this method returns, contains the maximum value.</param>
	/// <returns>The element with the maximum key value.</returns>
	public static T Max<T, TValue>(this IEnumerable<T> source, Func<T, TValue> keyGetter, out TValue maxValue)
		where TValue : IComparable<TValue>
	{
		T maxItem = default;
		maxValue = default(TValue);
		foreach (var item in source)
		{
			if (item == null) continue;
			var itemValue = keyGetter(item);
			if ((maxItem != null) && (itemValue.CompareTo(maxValue) <= 0)) continue;
			maxValue = itemValue;
			maxItem = item;
		}

		return maxItem;
	}

	/// <summary>
	/// Returns the maximum element of the sequence based on a key extracted using a specified function.
	/// </summary>
	/// <typeparam name="T">The type of elements in the sequence.</typeparam>
	/// <typeparam name="TValue">The type of the key.</typeparam>
	/// <param name="keyGetter">A function to extract a key from an element.</param>
	/// <returns>The element with the maximum key value.</returns>
	public static T Max<T, TValue>(this IEnumerable<T> source, Func<T, TValue> keyGetter)
		where TValue : IComparable<TValue>
	{
		var result = source.Max(keyGetter, out _);
		return result;
	}
	#endregion

	#region Select
	/// <summary>
	/// Projects each element of the sequence into a new form, optionally excluding null values.
	/// </summary>
	/// <typeparam name="T">The type of elements in the sequence.</typeparam>
	/// <typeparam name="TResult">The type of the result elements.</typeparam>
	/// <param name="selector">A transform function to apply to each element.</param>
	/// <param name="allowNull">If true, includes null values in the result; otherwise, excludes them.</param>
	/// <returns>An IEnumerable&lt;TResult&gt; whose elements are the result of invoking the transform function on each element of source.</returns>
	public static IEnumerable<TResult> Select<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector, bool allowNull = true)
	{
		foreach (var item in source)
		{
			var select = selector(item);
			if (allowNull || !Equals(select, default(T)))
			{
				yield return select;
			}
		}
	}
	#endregion

	#region First / Last
	/// <summary>
	/// Returns the first element of the sequence.
	/// </summary>
	/// <typeparam name="T">The type of elements in the sequence.</typeparam>
	/// <returns>The first element of the sequence if it's not empty; otherwise, the default value of the type.</returns>
	public static T First<T>(this IEnumerable<T> source)
	{
		if (source == null) return default(T);
		foreach (var item in source)
		{
			return item;
		}

		return default(T);
	}

	/// <summary>
	/// Returns the first 'count' elements of the sequence as a list.
	/// </summary>
	/// <typeparam name="T">The type of elements in the sequence.</typeparam>
	/// <param name="count">The number of elements to return.</param>
	/// <returns>A list containing the first 'count' elements of the sequence.</returns>
	public static IList<T> First<T>(this IEnumerable<T> source, int count)
	{
		if (source == null) return null;
		var result = new List<T>();
		var counter = 0;
		foreach (var item in source)
		{
			result.Add(item);
			counter++;
			if (counter >= count) break;
		}

		return result;
	}

	/// <summary>
	/// Returns the last element of the sequence.
	/// </summary>
	/// <typeparam name="T">The type of elements in the sequence.</typeparam>
	/// <returns>The last element of the sequence if it's not empty; otherwise, the default value of the type.</returns>
	public static T Last<T>(this IEnumerable<T> source)
	{
		if (source == null) return default(T);
		var result = default(T);
		foreach (var item in source)
		{
			result = item;
		}

		return result;
	}

	/// <summary>
	/// Returns the last 'count' elements of the sequence as a list.
	/// </summary>
	/// <typeparam name="T">The type of elements in the sequence.</typeparam>
	/// <param name="count">The number of elements to return.</param>
	/// <returns>A list containing the last 'count' elements of the sequence.</returns>
	public static IList<T> Last<T>(this IEnumerable<T> source, int count)
	{
		if (source == null) return null;
		var result = new List<T>();
		var sum = 0;
		foreach (var _ in source)
		{
			sum++;
		}

		var counter = 0;
		foreach (var item in source)
		{
			counter++;
			if (counter > sum - count)
			{
				result.Add(item);
			}
		}

		return result;
	}
	#endregion

	#region To Array
	/// <summary>
	/// Converts the sequence to an array.
	/// </summary>
	/// <typeparam name="T">The type of elements in the sequence.</typeparam>
	/// <returns>An array containing the elements of the sequence.</returns>
	public static T[] ToArray<T>(this IEnumerable<T> source)
	{
		var list = new List<T>();
		foreach (var item in source)
		{
			list.Add(item);
		}

		return list.ToArray();
	}

	/// <summary>
	/// Converts the sequence to an array of a different type using a selector function.
	/// </summary>
	/// <typeparam name="T">The type of elements in the source sequence.</typeparam>
	/// <typeparam name="TResult">The type of elements in the resulting array.</typeparam>
	/// <param name="selector">A function to apply to each element in the sequence.</param>
	/// <returns>An array containing the elements of the sequence after applying the selector function.</returns>
	public static TResult[] ToArray<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector)
	{
		var list = new List<TResult>();
		foreach (var item in source)
		{
			list.Add(selector(item));
		}

		return list.ToArray();
	}
	#endregion

	#region To List
	/// <summary>
	/// Converts the sequence to a list.
	/// </summary>
	/// <typeparam name="T">The type of elements in the sequence.</typeparam>
	/// <returns>A list containing the elements of the sequence.</returns>
	public static List<T> ToList<T>(this IEnumerable<T> source)
	{
		var list = new List<T>();
		foreach (var item in source)
		{
			list.Add(item);
		}

		return list;
	}

	/// <summary>
	/// Converts the sequence to a list of a different type using a selector function.
	/// </summary>
	/// <typeparam name="T">The type of elements in the source sequence.</typeparam>
	/// <typeparam name="TResult">The type of elements in the resulting list.</typeparam>
	/// <param name="selector">A function to apply to each element in the sequence.</param>
	/// <returns>A list containing the elements of the sequence after applying the selector function.</returns>
	public static List<TResult> ToList<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector)
	{
		var list = new List<TResult>();
		foreach (var item in source)
		{
			list.Add(selector(item));
		}

		return list;
	}
	#endregion
}