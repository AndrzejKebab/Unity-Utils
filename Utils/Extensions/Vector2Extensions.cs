using UnityEngine;

public static class Vector2Extensions
{
	/// <summary>
	/// Adds to any x y values of a Vector2
	/// </summary>
	public static Vector2 Add(this Vector2 vector2, float x = 0, float y = 0)
	{
		return new Vector2(vector2.x + x, vector2.y + y);
	}

	/// <summary>
	/// Sets any x y values of a Vector2
	/// </summary>
	public static Vector2 With(this Vector2 vector2, float? x = null, float? y = null)
	{
		return new Vector2(x ?? vector2.x, y ?? vector2.y);
	}

	/// <summary>
	/// Returns a Boolean indicating whether the current Vector2 is in a given range from another Vector2
	/// </summary>
	/// <param name="current">The current Vector2 position</param>
	/// <param name="target">The Vector2 position to compare against</param>
	/// <param name="range">The range value to compare against</param>
	/// <returns>True if the current Vector2 is in the given range from the target Vector2, false otherwise</returns>
	public static bool InRangeOf(this Vector2 current, Vector2 target, float range)
	{
		return (current - target).sqrMagnitude <= range * range;
	}

	/// <summary>
	/// Swaps the components of two Vector2 instances using ref parameters.
	/// </summary>
	/// <param name="target">The Vector2 with whose components will be swapped.</param>
	public static void Swap(ref this Vector2 current, ref Vector2 target)
	{
		(current.x, target.x) = (target.x, current.x);
		(current.y, target.y) = (target.y, current.y);
	}

	// <summary>
	/// Rotates a point in 2D space around a specified axis by a given angle.
	/// </summary>
	/// <param name="point">The point to be rotated.</param>
	/// <param name="axis">The axis of rotation.</param>
	/// <param name="angle">The angle of rotation in degrees.</param>
	/// <returns>The rotated point.</returns>
	public static Vector3 Rotate(this Vector2 origin, Vector2 point, Vector2 axis, float angle)
	{
		var quaternion = Quaternion.AngleAxis(angle, axis);

		var offset = origin - point;

		offset = quaternion * offset;

		var result = point + offset;

		return result;
	}

	/// <summary>
	/// Clamps the axis of the Vector2 between 0 and 1.
	/// </summary>
	/// <returns>A new Vector2 with axis clamped between 0 and 1.</returns>
	public static Vector2 Clamp01(this Vector2 vector)
	{
		vector = vector.Clamp(0f, 1f);
		return vector;
	}

	/// <summary>
	/// Clamps the axis of the Vector2 between specified minimum and maximum values.
	/// </summary>
	/// <param name="min">The minimum value for each axis.</param>
	/// <param name="max">The maximum value for each axis.</param>
	/// <returns>A new Vector2 with axis clamped between specified minimum and maximum values.</returns>
	public static Vector2 Clamp(this Vector2 vector, float min, float max)
	{
		vector.x = Mathf.Clamp(vector.x, min, max);
		vector.y = Mathf.Clamp(vector.y, min, max);
		return vector;
	}

	/// <summary>
	/// Clamps the axis of the Vector2 between specified minimum and maximum vectors.
	/// </summary>
	/// <param name="min">The minimum vector for each axis.</param>
	/// <param name="max">The maximum vector for each axis.</param>
	/// <returns>A new Vector2 with axis clamped between specified minimum and maximum vectors.</returns>
	public static Vector2 Clamp(this Vector2 vector, Vector2 min, Vector2 max)
	{
		vector.x = Mathf.Clamp(vector.x, min.x, max.x);
		vector.y = Mathf.Clamp(vector.y, min.y, max.y);
		return vector;
	}

	/// <summary>
	/// Flips the direction of the Vector2.
	/// </summary>
	/// <returns>A new Vector2 with reversed direction.</returns>
	public static Vector2 Flip(this Vector2 vector)
	{
		return -vector;
	}

	/// <summary>
	/// Flips the x-axis of the Vector2.
	/// </summary>
	/// <returns>A new Vector2 with the x-axis reversed.</returns>
	public static Vector2 FlipX(this Vector2 vector)
	{
		vector.x = -vector.x;
		return vector;
	}

	/// <summary>
	/// Flips the y-axis of the Vector2.
	/// </summary>
	/// <returns>A new Vector2 with the y-axis reversed.</returns>
	public static Vector2 FlipY(this Vector2 vector)
	{
		vector.y = -vector.y;
		return vector;
	}

}