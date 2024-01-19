using UnityEngine;

public static class Vector2IntExtensions
{
	/// <summary>
	/// Deconstructs a Vector2Int into its x and y axis.
	/// </summary>
	/// <param name="x">The x-axis of the Vector2Int.</param>
	/// <param name="y">The y-axis of the Vector2Int.</param>
	public static void Deconstruct(in this Vector2Int vector, out int x, out int y)
	{
		x = vector.x;
		y = vector.y;
	}

	/// <summary>
	/// Creates a new Vector2Int with optional modified x and y axis.
	/// </summary>
	/// <param name="x">The new x-axis (optional).</param>
	/// <param name="y">The new y-axis (optional).</param>
	/// <returns>A new Vector2Int with specified or original x and y axis.</returns>
	public static Vector2Int With(in this Vector2Int vector, int? x = null, int? y = null)
	{
		var result = new Vector2Int(x ?? vector.x, y ?? vector.y);
		return result;
	}
}
