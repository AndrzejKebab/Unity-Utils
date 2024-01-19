using System;
using UnityEngine;

public static class QuaternionExtensions
{
	/// <summary>
	/// Deconstructs a Quaternion into its components.
	/// </summary>
	/// <param name="x">The x component of the Quaternion.</param>
	/// <param name="y">The y component of the Quaternion.</param>
	/// <param name="z">The z component of the Quaternion.</param>
	/// <param name="w">The w component of the Quaternion.</param>
	public static void Deconstruct(in this Quaternion quaternion, out float x, out float y, out float z, out float w)
	{
		x = quaternion.x;
		y = quaternion.y;
		z = quaternion.z;
		w = quaternion.w;
	}

	/// <summary>
	/// Creates a new Quaternion with optional modified components.
	/// </summary>
	/// <param name="x">The new x component (optional).</param>
	/// <param name="y">The new y component (optional).</param>
	/// <param name="z">The new z component (optional).</param>
	/// <param name="w">The new w component (optional).</param>
	/// <returns>A new Quaternion with specified or original components.</returns>
	public static Quaternion With(in this Quaternion quaternion, float? x = null, float? y = null, float? z = null, float? w = null)
	{
		var result = new Quaternion(x ?? quaternion.x, y ?? quaternion.y, z ?? quaternion.z, w ?? quaternion.w);
		return result;
	}

	/// <summary>
	/// Creates a new Quaternion with optional modified Euler angles.
	/// </summary>
	/// <param name="x">The new x Euler angle (optional).</param>
	/// <param name="y">The new y Euler angle (optional).</param>
	/// <param name="z">The new z Euler angle (optional).</param>
	/// <returns>A new Quaternion with specified or original Euler angles.</returns>
	public static Quaternion WithEuler(this Quaternion quaternion, float? x = null, float? y = null, float? z = null)
	{
		var e = quaternion.eulerAngles;
		var result = Quaternion.Euler(x ?? e.x, y ?? e.y, z ?? e.z);
		return result;
	}

	/// <summary>
	/// Creates a new Quaternion by rotating around an axis at a given angle.
	/// </summary>
	/// <param name="angle">The new rotation angle (optional).</param>
	/// <param name="axis">The new rotation axis (optional).</param>
	/// <returns>A new Quaternion with the specified or original rotation.</returns>
	public static Quaternion WithAngleAxis(this Quaternion quaternion, float? angle = null, in Vector3? axis = null)
	{
		quaternion.ToAngleAxis(out var selfAngle, out var selfAxis);
		var result = Quaternion.AngleAxis(angle ?? selfAngle, axis ?? selfAxis);
		return result;
	}
}