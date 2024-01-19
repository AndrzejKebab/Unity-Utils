using UnityEngine;

public static class Vector3Extensions 
{
	/// <summary>
	/// Deconstructs a Vector3 into its x, y, and z axis.
	/// </summary>
	/// <param name="vector">The Vector3 to be deconstructed.</param>
	/// <param name="x">The x-axis of the Vector3.</param>
	/// <param name="y">The y-axis of the Vector3.</param>
	/// <param name="z">The z-axis of the Vector3.</param>
	public static void Deconstruct(in this Vector3 vector, out float x, out float y, out float z)
	{
		x = vector.x;
		y = vector.y;
		z = vector.z;
	}

	/// <summary>
	/// Sets any x y z values of a Vector3
	/// </summary>
	public static Vector3 With(this Vector3 vector, float? x = null, float? y = null, float? z = null) 
	{
		return new Vector3(x ?? vector.x, y ?? vector.y, z ?? vector.z);
	}

	/// <summary>
	/// Adds to any x y z values of a Vector3
	/// </summary>
	public static Vector3 Add(this Vector3 vector, float x = 0, float y = 0, float z = 0) 
	{
		return new Vector3(vector.x + x, vector.y + y, vector.z + z);
	}

	/// <summary>
	/// Returns a Boolean indicating whether the current Vector3 is in a given range from another Vector3
	/// </summary>
	/// <param name="target">The Vector3 position to compare against</param>
	/// <param name="range">The range value to compare against</param>
	/// <returns>True if the current Vector3 is in the given range from the target Vector3, false otherwise</returns>
	public static bool InRangeOf(this Vector3 current, Vector3 target, float range) 
	{
		return (current - target).sqrMagnitude <= range * range;
	}

	/// <summary>
	/// Converts a Vector3 to a Vector3Int by rounding down each axis to the nearest integer.
	/// </summary>
	/// <returns>A new Vector3Int with axis rounded down to the nearest integer.</returns>
	public static Vector3Int ToVector3Int(this Vector3 current)
	{
		return Vector3Int.FloorToInt(current);
	}

	/// <summary>
	/// Swaps the axis of two Vector3 instances using ref parameters.
	/// </summary>
	/// <param name="target">The Vector3 with whose axis will be swapped.</param>
	public static void Swap(ref this Vector3 current, ref Vector3 target)
	{
		(current.x, target.x) = (target.x, current.x);
		(current.y, target.y) = (target.y, current.y);
		(current.z, target.z) = (target.z, current.z);
	}

	/// <summary>
	/// Rotates a point around a specified pivot point by the given euler angles.
	/// </summary>
	/// <param name="pivot">The pivot point around which the rotation occurs.</param>
	/// <param name="eulerAngles">The euler angles representing the rotation.</param>
	/// <returns>The rotated point.</returns>
	public static Vector3 RotateAroundPivot(this Vector3 point, Vector3 pivot, Vector3 eulerAngles)
	{
		var dir = point - pivot;
		dir = Quaternion.Euler(eulerAngles) * dir;

		return dir + pivot;
	}

	/// <summary>
	/// Rotates a point around a specified pivot point by the given quaternion rotation.
	/// </summary>
	/// <param name="pivot">The pivot point around which the rotation occurs.</param>
	/// <param name="rotation">The quaternion representing the rotation.</param>
	/// <returns>The rotated point.</returns>
	public static Vector3 RotateAroundPivot(this Vector3 point, Vector3 pivot, Quaternion rotation)
	{
		var dir = point - pivot;
		dir = rotation * dir;

		return dir + pivot;
	}

	/// <summary>
	/// Clamps each axis of the Vector3 to the range [0, 1].
	/// </summary>
	/// <returns>A new Vector3 with each axis clamped to the range [0, 1].</returns>
	public static Vector3 Clamp01(this Vector3 vector)
	{
		vector = vector.Clamp(0f, 1f);
		return vector;
	}

	/// <summary>
	/// Clamps each axis of the Vector3 to the specified range [min, max].
	/// </summary>
	/// <param name="min">The minimum value for each axis.</param>
	/// <param name="max">The maximum value for each axis.</param>
	/// <returns>A new Vector3 with each axis clamped to the specified range [min, max].</returns>
	public static Vector3 Clamp(this Vector3 vector, float min, float max)
	{
		vector.x = Mathf.Clamp(vector.x, min, max);
		vector.y = Mathf.Clamp(vector.y, min, max);
		vector.z = Mathf.Clamp(vector.z, min, max);
		return vector;
	}

	/// <summary>
	/// Clamps each axis of the Vector3 independently to the specified range [min, max].
	/// </summary>
	/// <param name="min">The minimum values for each axis.</param>
	/// <param name="max">The maximum values for each axis.</param>
	/// <returns>A new Vector3 with each axis clamped to the specified range [min, max].</returns>
	public static Vector3 Clamp(this Vector3 vector, Vector3 min, Vector3 max)
	{
		vector.x = Mathf.Clamp(vector.x, min.x, max.x);
		vector.y = Mathf.Clamp(vector.y, min.y, max.y);
		vector.z = Mathf.Clamp(vector.z, min.z, max.z);
		return vector;
	}

	/// <summary>
	/// Negates each component of the Vector3.
	/// </summary>
	/// <returns>A new Vector3 with each component negated.</returns>
	public static Vector3 Flip(this Vector3 vector)
	{
		vector = -vector;
		return vector;
	}

	/// <summary>
	/// Negates the x-axis of the Vector3.
	/// </summary>
	/// <returns>A new Vector3 with the x-axis negated.</returns>
	public static Vector3 FlipX(this Vector3 vector)
	{
		vector.x = -vector.x;
		return vector;
	}

	/// <summary>
	/// Negates the y-axis of the Vector3.
	/// </summary>
	/// <returns>A new Vector3 with the y-axis negated.</returns>
	public static Vector3 FlipY(this Vector3 vector)
	{
		vector.y = -vector.y;
		return vector;
	}

	/// <summary>
	/// Negates the z-axis of the Vector3.
	/// </summary>
	/// <returns>A new Vector3 with the z-axis negated.</returns>
	public static Vector3 FlipZ(this Vector3 vector)
	{
		vector.z = -vector.z;
		return vector;
	}
}