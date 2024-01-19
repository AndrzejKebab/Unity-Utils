using UnityEngine;

public static class RigidBodyExtensions
{
	#region Clear
	/// <summary>
	/// Clears the momentum of the Rigidbody by setting its velocity and angular velocity to zero.
	/// </summary>
	public static void ClearMomentum(this Rigidbody rigidbody)
	{
		rigidbody.velocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;
	}
	#endregion

	#region Position
	#region Set
	/// <summary>
	/// Sets the x-coordinate of the Rigidbody's position.
	/// </summary>
	/// <param name="x">The new x-coordinate.</param>
	public static void SetPositionX(this Rigidbody rigidbody, float x)
	{
		var position = rigidbody.position;
		position.x = x;
		rigidbody.position = position;
	}

	/// <summary>
	/// Sets the y-coordinate of the Rigidbody's position.
	/// </summary>
	/// <param name="y">The new y-coordinate.</param>
	public static void SetPositionY(this Rigidbody rigidbody, float y)
	{
		var position = rigidbody.position;
		position.y = y;
		rigidbody.position = position;
	}

	/// <summary>
	/// Sets the z-coordinate of the Rigidbody's position.
	/// </summary>
	/// <param name="z">The new z-coordinate.</param>
	public static void SetPositionZ(this Rigidbody rigidbody, float z)
	{
		var position = rigidbody.position;
		position.z = z;
		rigidbody.position = position;
	}
	#endregion

	#region Get
	/// <summary>
	/// Gets the x-coordinate of the Rigidbody's position.
	/// </summary>
	/// <returns>The x-coordinate of the position.</returns>
	public static float GetPositionX(this Rigidbody rigidbody)
	{
		return rigidbody.position.x;
	}

	/// <summary>
	/// Gets the y-coordinate of the Rigidbody's position.
	/// </summary>
	/// <returns>The y-coordinate of the position.</returns>
	public static float GetPositionY(this Rigidbody rigidbody)
	{
		return rigidbody.position.y;
	}

	/// <summary>
	/// Gets the z-coordinate of the Rigidbody's position.
	/// </summary>
	/// <returns>The z-coordinate of the position.</returns>
	public static float GetPositionZ(this Rigidbody rigidbody)
	{
		return rigidbody.position.z;
	}

	#endregion
	#endregion

	#region Rotation
	#region Get
	/// <summary>
	/// Gets the x-component of the rotation quaternion of the Rigidbody.
	/// </summary>
	/// <returns>The x-component of the rotation quaternion.</returns>
	public static float GetRotationX(this Rigidbody rigidbody)
	{
		return rigidbody.rotation.x;
	}

	/// <summary>
	/// Gets the y-component of the rotation quaternion of the Transform.
	/// </summary>
	/// <returns>The y-component of the rotation quaternion.</returns>
	public static float GetRotationY(this Transform rigidbody)
	{
		return rigidbody.rotation.y;
	}

	/// <summary>
	/// Gets the z-component of the rotation quaternion of the Rigidbody.
	/// </summary>
	/// <param name="rigidbody">The Rigidbody whose rotation to get.</param>
	/// <returns>The z-component of the rotation quaternion.</returns>
	public static float GetRotationZ(this Rigidbody rigidbody)
	{
		return rigidbody.rotation.z;
	}

	/// <summary>
	/// Gets the w-component of the rotation quaternion of the Rigidbody.
	/// </summary>
	/// <returns>The w-component of the rotation quaternion.</returns>
	public static float GetRotationW(this Rigidbody rigidbody)
	{
		return rigidbody.rotation.w;
	}
	#endregion

	#region Set
	/// <summary>
	/// Sets the x-component of the rotation quaternion of the Rigidbody.
	/// </summary>
	/// <param name="x">The new x-component of the rotation quaternion.</param>
	public static void SetRotationX(this Rigidbody rigidbody, float x)
	{
		var rotation = rigidbody.rotation;
		rotation.x = x;
		rigidbody.rotation = rotation;
	}

	/// <summary>
	/// Sets the y-component of the rotation quaternion of the Rigidbody.
	/// </summary>
	/// <param name="y">The new y-component of the rotation quaternion.</param>
	public static void SetRotationY(this Rigidbody rigidbody, float y)
	{
		var rotation = rigidbody.rotation;
		rotation.y = y;
		rigidbody.rotation = rotation;
	}

	/// <summary>
	/// Sets the z-component of the rotation quaternion of the Rigidbody.
	/// </summary>
	/// <param name="z">The new z-component of the rotation quaternion.</param>
	public static void SetRotationZ(this Rigidbody rigidbody, float z)
	{
		var rotation = rigidbody.rotation;
		rotation.z = z;
		rigidbody.rotation = rotation;
	}

	/// <summary>
	/// Sets the w-component of the rotation quaternion of the Rigidbody.
	/// </summary>
	/// <param name="w">The new w-component of the rotation quaternion.</param>
	public static void SetRotationW(this Rigidbody rigidbody, float w)
	{
		var rotation = rigidbody.rotation;
		rotation.w = w;
		rigidbody.rotation = rotation;
	}
	#endregion
	#endregion

	#region EulerAngles
	#region Set
	/// <summary>
	/// Sets the x-component of the rotation euler angles.
	/// </summary>
	/// <param name="x">The new x-component of the rotation euler angles.</param>
	public static void SetEulerAnglesX(this Rigidbody rigidbody, float x)
	{
		var eulerAngles = rigidbody.rotation.eulerAngles;
		eulerAngles.x = x;
		rigidbody.rotation = Quaternion.Euler(eulerAngles);
	}

	/// <summary>
	/// Sets the y-component of the rotation euler angles.
	/// </summary>
	/// <param name="y">The new y-component of the rotation euler angles.</param>
	public static void SetEulerAnglesY(this Rigidbody rigidbody, float y)
	{
		var eulerAngles = rigidbody.rotation.eulerAngles;
		eulerAngles.y = y;
		rigidbody.rotation = Quaternion.Euler(eulerAngles);
	}

	/// <summary>
	/// Sets the z-component of the rotation euler angles.
	/// </summary>
	/// <param name="z">The new z-component of the rotation euler angles.</param>
	public static void SetEulerAnglesZ(this Rigidbody rigidbody, float z)
	{
		var eulerAngles = rigidbody.rotation.eulerAngles;
		eulerAngles.z = z;
		rigidbody.rotation = Quaternion.Euler(eulerAngles);
	}
	#endregion

	#region Get
	/// <summary>
	/// Gets the x-component of the rotation euler angles.
	/// </summary>
	/// <returns>The x-component of the rotation euler angles.</returns>
	public static float GetEulerAnglesX(this Rigidbody rigidbody)
	{
		return rigidbody.rotation.eulerAngles.x;
	}

	/// <summary>
	/// Gets the y-component of the rotation euler angles.
	/// </summary>
	/// <returns>The y-component of the rotation euler angles.</returns>
	public static float GetEulerAnglesY(this Rigidbody rigidbody)
	{
		return rigidbody.rotation.eulerAngles.y;
	}

	/// <summary>
	/// Gets the z-component of the rotation euler angles.
	/// </summary>
	/// <returns>The z-component of the rotation euler angles.</returns>
	public static float GetEulerAnglesZ(this Rigidbody rigidbody)
	{
		return rigidbody.rotation.eulerAngles.z;
	}

	#endregion
	#endregion

	#region Velocity
	#region Set
	/// <summary>
	/// Changes the direction of a Rigidbody while maintaining its speed.
	/// </summary>
	/// <param name="direction">The new direction in which to set the Rigidbody's velocity.</param>
	public static void ChangeDirection(this Rigidbody rb, Vector3 direction)
	{
		rb.velocity = direction.normalized * rb.velocity.magnitude;
	}

	/// <summary>
	/// Normalizes the velocity of a Rigidbody to a specified magnitude.
	/// </summary>
	/// <param name="magnitude">The desired magnitude of the normalized velocity (default is 1).</param>
	public static void NormalizeVelocity(this Rigidbody rb, float magnitude = 1)
	{
		rb.velocity = rb.velocity.normalized * magnitude;
	}

	/// <summary>
	/// Sets the x-component of the Rigidbody's velocity.
	/// </summary>
	/// <param name="x">The new x-component of the velocity.</param>
	public static void SetVelocityX(this Rigidbody rigidbody, float x)
	{
		var velocity = rigidbody.velocity;
		velocity.x = x;
		rigidbody.velocity = velocity;
	}

	/// <summary>
	/// Sets the y-component of the Rigidbody's velocity.
	/// </summary>
	/// <param name="y">The new y-component of the velocity.</param>
	public static void SetVelocityY(this Rigidbody rigidbody, float y)
	{
		var velocity = rigidbody.velocity;
		velocity.y = y;
		rigidbody.velocity = velocity;
	}

	/// <summary>
	/// Sets the z-component of the Rigidbody's velocity.
	/// </summary>
	/// <param name="z">The new z-component of the velocity.</param>
	public static void SetVelocityZ(this Rigidbody rigidbody, float z)
	{
		var velocity = rigidbody.velocity;
		velocity.z = z;
		rigidbody.velocity = velocity;
	}
	#endregion

	#region Get
	/// <summary>
	/// Gets the x-component of the Rigidbody's velocity.
	/// </summary>
	/// <returns>The x-component of the velocity.</returns>
	public static float GetVelocityX(this Rigidbody rigidbody)
	{
		return rigidbody.velocity.x;
	}

	/// <summary>
	/// Gets the y-component of the Rigidbody's velocity.
	/// </summary>
	/// <returns>The y-component of the velocity.</returns>
	public static float GetVelocityY(this Rigidbody rigidbody)
	{
		return rigidbody.velocity.y;
	}

	/// <summary>
	/// Gets the z-component of the Rigidbody's velocity.
	/// </summary>
	/// <returns>The z-component of the velocity.</returns>
	public static float GetVelocityZ(this Rigidbody rigidbody)
	{
		return rigidbody.velocity.z;
	}
	#endregion

	#region Add
	/// <summary>
	/// Adds a value to the x-component of the Rigidbody's velocity.
	/// </summary>
	/// <param name="x">The value to add to the x-component of the velocity.</param>
	public static void AddVelocityX(this Rigidbody rigidbody, float x)
	{
		var velocity = rigidbody.velocity;
		velocity.x += x;
		rigidbody.velocity = velocity;
	}

	/// <summary>
	/// Adds a value to the y-component of the Rigidbody's velocity.
	/// </summary>
	/// <param name="y">The value to add to the y-component of the velocity.</param>
	public static void AddVelocityY(this Rigidbody rigidbody, float y)
	{
		var velocity = rigidbody.velocity;
		velocity.y += y;
		rigidbody.velocity = velocity;
	}

	/// <summary>
	/// Adds a value to the z-component of the Rigidbody's velocity.
	/// </summary>
	/// <param name="z">The value to add to the z-component of the velocity.</param>
	public static void AddVelocityZ(this Rigidbody rigidbody, float z)
	{
		var velocity = rigidbody.velocity;
		velocity.z += z;
		rigidbody.velocity = velocity;
	}
	#endregion
	#endregion

	#region AngularVelocity
	#region Set
	/// <summary>
	/// Sets the x-component of the Rigidbody's angular velocity.
	/// </summary>
	/// <param name="x">The new x-component of the angular velocity.</param>
	public static void SetAngularVelocityX(this Rigidbody rigidbody, float x)
	{
		var angularVelocity = rigidbody.angularVelocity;
		angularVelocity.x = x;
		rigidbody.angularVelocity = angularVelocity;
	}

	/// <summary>
	/// Sets the y-component of the Rigidbody's angular velocity.
	/// </summary>
	/// <param name="y">The new y-component of the angular velocity.</param>
	public static void SetAngularVelocityY(this Rigidbody rigidbody, float y)
	{
		var angularVelocity = rigidbody.angularVelocity;
		angularVelocity.y = y;
		rigidbody.angularVelocity = angularVelocity;
	}

	/// <summary>
	/// Sets the z-component of the Rigidbody's angular velocity.
	/// </summary>
	/// <param name="z">The new z-component of the angular velocity.</param>
	public static void SetAngularVelocityZ(this Rigidbody rigidbody, float z)
	{
		var angularVelocity = rigidbody.angularVelocity;
		angularVelocity.z = z;
		rigidbody.angularVelocity = angularVelocity;
	}
	#endregion

	#region Get
	/// <summary>
	/// Gets the x-component of the Rigidbody's angular velocity.
	/// </summary>
	/// <returns>The x-component of the angular velocity.</returns>
	public static float GetAngularVelocityX(this Rigidbody rigidbody)
	{
		return rigidbody.angularVelocity.x;
	}

	/// <summary>
	/// Gets the y-component of the Rigidbody's angular velocity.
	/// </summary>
	/// <returns>The y-component of the angular velocity.</returns>
	public static float GetAngularVelocityY(this Rigidbody rigidbody)
	{
		return rigidbody.angularVelocity.y;
	}

	/// <summary>
	/// Gets the z-component of the Rigidbody's angular velocity.
	/// </summary>
	/// <returns>The z-component of the angular velocity.</returns>
	public static float GetAngularVelocityZ(this Rigidbody rigidbody)
	{
		return rigidbody.angularVelocity.z;
	}
	#endregion

	#region Add
	/// <summary>
	/// Adds a value to the x-component of the Rigidbody's angular velocity.
	/// </summary>
	/// <param name="x">The value to add to the x-component of the angular velocity.</param>
	public static void AddAngularVelocityX(this Rigidbody rigidbody, float x)
	{
		var angularVelocity = rigidbody.angularVelocity;
		angularVelocity.x += x;
		rigidbody.angularVelocity = angularVelocity;
	}

	/// <summary>
	/// Adds a value to the y-component of the Rigidbody's angular velocity.
	/// </summary>
	/// <param name="y">The value to add to the y-component of the angular velocity.</param>
	public static void AddAngularVelocityY(this Rigidbody rigidbody, float y)
	{
		var angularVelocity = rigidbody.angularVelocity;
		angularVelocity.y += y;
		rigidbody.angularVelocity = angularVelocity;
	}

	/// <summary>
	/// Adds a value to the z-component of the Rigidbody's angular velocity.
	/// </summary>
	/// <param name="z">The value to add to the z-component of the angular velocity.</param>
	public static void AddAngularVelocityZ(this Rigidbody rigidbody, float z)
	{
		var angularVelocity = rigidbody.angularVelocity;
		angularVelocity.z += z;
		rigidbody.angularVelocity = angularVelocity;
	}
	#endregion
	#endregion
}