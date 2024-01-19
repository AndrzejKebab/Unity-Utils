using UnityEngine;

public static class Vector4Extensions
{
	/// <summary>
	/// Deconstructs a Vector4 into its individual axes.
	/// </summary>
	/// <param name="x">The x-axis value of the vector.</param>
	/// <param name="y">The y-axis value of the vector.</param>
	/// <param name="z">The z-axis value of the vector.</param>
	/// <param name="w">The w-axis value of the vector.</param>
	public static void Deconstruct(in this Vector4 vector, out float x, out float y, out float z, out float w)
	{
		x = vector.x;
		y = vector.y;
		z = vector.z;
		w = vector.w;
	}

	/// <summary>
	/// Creates a new Vector4 with optional axis values, using the values from the original vector if not specified.
	/// </summary>
	/// <param name="x">The new x-axis value (if specified).</param>
	/// <param name="y">The new y-axis value (if specified).</param>
	/// <param name="z">The new z-axis value (if specified).</param>
	/// <param name="w">The new w-axis value (if specified).</param>
	/// <returns>The new Vector4.</returns>
	public static Vector4 With(in this Vector4 vector, float? x = null, float? y = null, float? z = null, float? w = null)
	{
		var result = new Vector4(x ?? vector.x, y ?? vector.y, z ?? vector.z, w ?? vector.w);
		return result;
	}
}