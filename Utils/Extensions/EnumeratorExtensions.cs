using System.Collections.Generic;
using System.Linq;

public static class EnumeratorExtensions
{
	/// <summary>
	/// Converts an IEnumerator<T> to an IEnumerable<T>.
	/// </summary>
	/// <param name="e">An instance of IEnumerator<T>.</param>
	/// <returns>An IEnumerable<T> with the same elements as the input instance.</returns>    
	public static IEnumerable<T> ToEnumerable<T>(this IEnumerator<T> e) 
	{
		while (e.MoveNext()) 
		{
			yield return e.Current;
		}
	}

	/// <summary>
	/// Inserts an element at the beginning of an enumerable collection.
	/// </summary>
	/// <param name="collection">The enumerable collection to which the element is added.</param>
	/// <param name="element">The element to insert at the beginning.</param>
	/// <returns>A new enumerable collection with the specified element inserted at the beginning.</returns>
	public static IEnumerable<T> InsertFirst<T>(this IEnumerable<T> collection, T element) => new[] { element }.Concat(collection);

	/// <summary>
	/// Retrieves the element in the sequence that is immediately after a specified element.
	/// </summary>
	/// <param name="collection">The sequence of elements.</param>
	/// <param name="element">The specified element.</param>
	/// <returns>The element that is immediately after the specified element, or default(T) if not found.</returns>
	public static T NextTo<T>(this IEnumerable<T> collection, T element) => collection.SkipWhile(r => !EqualityComparer<T>.Default.Equals(r, element)).Skip(1).FirstOrDefault();

	/// <summary>
	/// Retrieves the element in the sequence that is immediately before a specified element.
	/// </summary>
	/// <param name="collection">The sequence of elements.</param>
	/// <param name="element">The specified element.</param>
	/// <returns>The element that is immediately before the specified element, or default(T) if not found.</returns>
	public static T PreviousTo<T>(this IEnumerable<T> collection, T element) => collection.Reverse().SkipWhile(r => !EqualityComparer<T>.Default.Equals(r, element)).Skip(1).FirstOrDefault();
}