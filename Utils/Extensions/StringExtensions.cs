using UnityEngine;

public static class StringExtensions
{
	/// <summary>
	/// Truncates a string to a specified maximum length.
	/// </summary>
	/// <param name="maxLength">The maximum length of the truncated string.</param>
	/// <returns>
	/// If the input string is null or empty, the method returns the input string.
	/// If the length of the input string is less than or equal to the specified maximum length,
	/// the method returns the input string.
	/// Otherwise, it returns a truncated version of the input string, preserving only the first
	/// maxLength characters.
	/// </returns>
	public static string Truncate(this string value, int maxLength)
	{
		if (string.IsNullOrEmpty(value))
			return value;
		if (value.Length <= maxLength)
			return value;

		return value.Substring(0, maxLength);
	}
}