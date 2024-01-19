using UnityEngine;

public static class Ray2DExtensions
{
	/// <summary>
	/// Deconstructs a Ray2D into its origin and direction vectors.
	/// </summary>
	/// <param name="origin">The origin vector of the Ray2D.</param>
	/// <param name="direction">The direction vector of the Ray2D.</param>
	public static void Deconstruct(this Ray2D ray, out Vector3 origin, out Vector3 direction)
	{
		origin = ray.origin;
		direction = ray.direction;
	}

	/// <summary>
	/// Creates a new Ray2D with optional modified origin and direction vectors.
	/// </summary>
	/// <param name="origin">The new origin vector (optional).</param>
	/// <param name="direction">The new direction vector (optional).</param>
	/// <returns>A new Ray2D with specified or original origin and direction vectors.</returns>
	public static Ray2D With(this Ray2D ray, in Vector3? origin = null, in Vector3? direction = null)
	{
		var result = new Ray2D(origin ?? ray.origin, direction ?? ray.direction);
		return result;
	}
}