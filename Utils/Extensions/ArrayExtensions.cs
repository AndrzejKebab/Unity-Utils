using System;

public static class ArrayExtensions
{
	#region First / Last
	/// <summary>
	/// Returns the first element of the array.
	/// </summary>
	/// <typeparam name="T">The type of elements in the array.</typeparam>
	/// <returns>The first element of the array if it's not empty; otherwise, the default value of the type.</returns>
	public static T First<T>(this T[] array)
	{
		if (array.Length == 0) return default(T);
		return array[0];
	}

	/// <summary>
	/// Returns the first element of the array that satisfies the given predicate.
	/// </summary>
	/// <typeparam name="T">The type of elements in the array.</typeparam>
	/// <param name="predicate">The predicate that defines the conditions of the element to search for.</param>
	/// <returns>The first element that satisfies the predicate; otherwise, the default value of the type.</returns>
	public static T First<T>(this T[] array, Predicate<T> predicate)
	{
		for (var i = 0; i < array.Length; i++)
		{
			var item = array[i];
			if (predicate(item))
			{
				return item;
			}
		}

		return default(T);
	}

	/// <summary>
	/// Returns the last element of the array.
	/// </summary>
	/// <typeparam name="T">The type of elements in the array.</typeparam>
	/// <returns>The last element of the array if it's not empty; otherwise, the default value of the type.</returns>
	public static T Last<T>(this T[] array)
	{
		if (array.Length == 0) return default(T);
		return array[array.Length - 1];
	}

	/// <summary>
	/// Returns the last element of the array that satisfies the given predicate.
	/// </summary>
	/// <typeparam name="T">The type of elements in the array.</typeparam>
	/// <param name="predicate">The predicate that defines the conditions of the element to search for.</param>
	/// <returns>The last element that satisfies the predicate; otherwise, the default value of the type.</returns>
	public static T Last<T>(this T[] array, Predicate<T> predicate)
	{
		for (var i = array.Length - 1; i >= 0; i--)
		{
			var item = array[i];
			if (predicate(item))
			{
				return item;
			}
		}

		return default(T);
	}
	#endregion

	#region Contains
	/// <summary>
	/// Determines whether the array contains a specific element.
	/// </summary>
	/// <typeparam name="T">The type of elements in the array.</typeparam>
	/// <param name="item">The object to locate in the array.</param>
	/// <returns>True if the element is found in the array; otherwise, false.</returns>
	public static bool Contains<T>(this T[] array, T item)
	{
		for (var i = 0; i < array.Length; i++)
		{
			var temp = array[i];
			if (temp.Equals(item)) return true;
		}

		return false;
	}

	/// <summary>
	/// Determines whether the array contains an element that satisfies the given predicate.
	/// </summary>
	/// <typeparam name="T">The type of elements in the array.</typeparam>
	/// <param name="predicate">The predicate that defines the conditions of the element to check for.</param>
	/// <returns>True if an element satisfying the predicate is found in the array; otherwise, false.</returns>
	public static bool Contains<T>(this T[] array, Predicate<T> predicate)
	{
		for (var i = 0; i < array.Length; i++)
		{
			var temp = array[i];
			if (predicate(temp)) return true;
		}

		return false;
	}
	#endregion
}