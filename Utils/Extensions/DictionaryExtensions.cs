using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class DictionaryExtensions
{

	/// <summary>
	/// Merges multiple dictionaries into a single dictionary. If keys are duplicated,
	/// values from later dictionaries override values from earlier dictionaries.
	/// </summary>
	/// <typeparam name="T1">The type of keys in the dictionaries.</typeparam>
	/// <typeparam name="T2">The type of values in the dictionaries.</typeparam>
	/// <param name="dicts">An enumerable collection of dictionaries to be merged.</param>
	/// <returns>A merged dictionary containing all key-value pairs from the input dictionaries.</returns>
	public static Dictionary<T1, T2> MergeDictionaries<T1, T2>(IEnumerable<Dictionary<T1, T2>> dicts)
	{
		// If there are no dictionaries to merge, return null
		if (dicts.Count() == 0) return null;

		// If there is only one dictionary, return it
		if (dicts.Count() == 1) return dicts.First();

		// Create a new dictionary with the contents of the first dictionary
		var mergedDict = new Dictionary<T1, T2>(dicts.First());

		// Iterate through the remaining dictionaries
		foreach (var dict in dicts.Skip(1))
		{
			// Merge key-value pairs from each dictionary into the merged dictionary
			foreach (var pair in dict)
			{
				// If the key is not already present, add it; otherwise, update the value
				if (!mergedDict.ContainsKey(pair.Key))
					mergedDict.Add(pair.Key, pair.Value);
				else
					mergedDict[pair.Key] = pair.Value;
			}
		}

		// Return the merged dictionary
		return mergedDict;
	}
}