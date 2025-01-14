﻿using UnityEngine;
using System.Collections;

#if ENABLED_UNITY_MATHEMATICS
using Unity.Mathematics;
#endif

public static class NumberExtensions
{
	public static float PercentageOf(this int part, int whole)
	{
		if (whole == 0) return 0; // Handling division by zero
		return (float)part / whole;
	}

	public static int AtLeast(this int value, int min) => Mathf.Max(value, min);
	public static int AtMost(this int value, int max) => Mathf.Min(value, max);

#if ENABLED_UNITY_MATHEMATICS
	public static half AtLeast(this half value, half max) => MathfExtensions.Max(value, max);
	public static half AtMost(this half value, half max) => MathfExtensions.Min(value, max);
#endif

	public static float AtLeast(this float value, float min) => Mathf.Max(value, min);
	public static float AtMost(this float value, float max) => Mathf.Min(value, max);

	public static double AtLeast(this double value, double min) => MathfExtensions.Max(value, min);
	public static double AtMost(this double value, double min) => MathfExtensions.Min(value, min);

	public static bool IsOdd(this int i) => i % 2 == 1;
	public static bool IsEven(this int i) => i % 2 == 0;

	public static bool Approx(this float f1, float f2) => Mathf.Approximately(f1, f2);

	/// <summary>
	/// Determines whether an integer is within a specified range (inclusive).
	/// </summary>
	/// <param name="a">The lower bound of the range.</param>
	/// <param name="b">The upper bound of the range.</param>
	/// <returns>True if the integer is within the specified range (inclusive); otherwise, false.</returns>
	public static bool IsInRange(this int i, int a, int b) => i >= a && i <= b;

	/// <summary>
	/// Determines whether an integer is within the valid index range of a list.
	/// </summary>
	/// <param name="list">The list for which to check the index range.</param>
	/// <returns>True if the integer is within the valid index range of the list; otherwise, false.</returns>
	public static bool IsInRangeOf(this int i, IList list) => i.IsInRange(0, list.Count - 1);

	/// <summary>
	/// Determines whether a floating-point number is within a specified range (inclusive).
	/// </summary>
	/// <param name="a">The lower bound of the range.</param>
	/// <param name="b">The upper bound of the range.</param>
	/// <returns>True if the floating-point number is within the specified range (inclusive); otherwise, false.</returns>
	public static bool IsInRange(this float i, float a, float b) => i >= a && i <= b;
}