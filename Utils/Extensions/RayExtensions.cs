using UnityEngine;

public static class RayExtensions
{
	/// <summary>
	/// Deconstructs a Ray into its origin and direction vectors.
	/// </summary>
	/// <param name="origin">The origin vector of the Ray.</param>
	/// <param name="direction">The direction vector of the Ray.</param>
	public static void Deconstruct(this Ray ray, out Vector3 origin, out Vector3 direction)
	{
		origin = ray.origin;
		direction = ray.direction;
	}

	/// <summary>
	/// Creates a new Ray with optional modified origin and direction vectors.
	/// </summary>
	/// <param name="origin">The new origin vector (optional).</param>
	/// <param name="direction">The new direction vector (optional).</param>
	/// <returns>A new Ray with specified or original origin and direction vectors.</returns>
	public static Ray With(this Ray ray, in Vector3? origin = null, in Vector3? direction = null)
	{
		var result = new Ray(origin ?? ray.origin, direction ?? ray.direction);
		return result;
	}
}