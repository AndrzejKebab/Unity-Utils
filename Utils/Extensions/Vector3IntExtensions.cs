using UnityEngine;

public static class Vector3IntExtensions
{
	/// <summary>
	/// Deconstructs a Vector3Int into its x, y, and z axis.
	/// </summary>
	/// <param name="x">The x-axis of the Vector3Int.</param>
	/// <param name="y">The y-axis of the Vector3Int.</param>
	/// <param name="z">The z-axis of the Vector3Int.</param>
	public static void Deconstruct(in this Vector3Int vector, out int x, out int y, out int z)
	{
		x = vector.x;
		y = vector.y;
		z = vector.z;
	}

	/// <summary>
	/// Creates a new Vector3Int with optional modified x, y, and z axis.
	/// </summary>
	/// <param name="x">The new x-axis (optional).</param>
	/// <param name="y">The new y-axis (optional).</param>
	/// <param name="z">The new z-axis (optional).</param>
	/// <returns>A new Vector3Int with specified or original x, y, and z axis.</returns>
	public static Vector3Int With(in this Vector3Int vector, int? x = null, int? y = null, int? z = null)
	{
		var result = new Vector3Int(x ?? vector.x, y ?? vector.y, z ?? vector.z);
		return result;
	}
}