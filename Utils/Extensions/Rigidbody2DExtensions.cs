using UnityEngine;

public static class Rigidbody2DExtensions
{
	#region Clear
	/// <summary>
	/// Clears the momentum of the Rigidbody2D by setting its velocity and angular velocity to zero.
	/// </summary>
	public static void ClearMomentum(this Rigidbody2D rigidbody)
	{
		rigidbody.velocity = Vector2.zero;
		rigidbody.angularVelocity = 0f;
	}
	#endregion

	#region Position
	#region Set
	/// <summary>
	/// Sets the x-coordinate of the Rigidbody2D's position.
	/// </summary>
	/// <param name="x">The new x-coordinate of the position.</param>
	public static void SetPositionX(this Rigidbody2D rigidbody, float x)
	{
		var position = rigidbody.position;
		position.x = x;
		rigidbody.position = position;
	}

	/// <summary>
	/// Sets the y-coordinate of the Rigidbody2D's position.
	/// </summary>
	/// <param name="y">The new y-coordinate of the position.</param>
	public static void SetPositionY(this Rigidbody2D rigidbody, float y)
	{
		var position = rigidbody.position;
		position.y = y;
		rigidbody.position = position;
	}
	#endregion

	#region Get
	/// <summary>
	/// Gets the x-coordinate of the Rigidbody2D's position.
	/// </summary>
	/// <returns>The x-coordinate of the position.</returns>
	public static float GetPositionX(this Rigidbody2D rigidbody)
	{
		return rigidbody.position.x;
	}

	/// <summary>
	/// Gets the y-coordinate of the Rigidbody2D's position.
	/// </summary>
	/// <returns>The y-coordinate of the position.</returns>
	public static float GetPositionY(this Rigidbody2D rigidbody)
	{
		return rigidbody.position.y;
	}
	#endregion
	#endregion

	#region Velocity
	#region Set

	/// <summary>
	/// Changes the direction of a Rigidbody while maintaining its speed.
	/// </summary>
	/// <param name="direction">The new direction in which to set the Rigidbody's velocity.</param>
	public static void ChangeDirection(this Rigidbody2D rb, Vector2 direction)
	{
		rb.velocity = direction.normalized * rb.velocity.magnitude;
	}

	/// <summary>
	/// Normalizes the velocity of a Rigidbody to a specified magnitude.
	/// </summary>
	/// <param name="magnitude">The desired magnitude of the normalized velocity (default is 1).</param>
	public static void NormalizeVelocity(this Rigidbody2D rb, float magnitude = 1)
	{
		rb.velocity = rb.velocity.normalized * magnitude;
	}

	/// <summary>
	/// Sets the x-component of the Rigidbody2D's velocity.
	/// </summary>
	/// <param name="x">The new x-component of the velocity.</param>
	public static void SetVelocityX(this Rigidbody2D rigidbody, float x)
	{
		var velocity = rigidbody.velocity;
		velocity.x = x;
		rigidbody.velocity = velocity;
	}

	/// <summary>
	/// Sets the y-component of the Rigidbody2D's velocity.
	/// </summary>
	/// <param name="y">The new y-component of the velocity.</param>
	public static void SetVelocityY(this Rigidbody2D rigidbody, float y)
	{
		var velocity = rigidbody.velocity;
		velocity.y = y;
		rigidbody.velocity = velocity;
	}
	#endregion

	#region Get
	/// <summary>
	/// Gets the x-component of the Rigidbody2D's velocity.
	/// </summary>
	/// <returns>The x-component of the velocity.</returns>
	public static float GetVelocityX(this Rigidbody2D rigidbody)
	{
		return rigidbody.velocity.x;
	}

	/// <summary>
	/// Gets the y-component of the Rigidbody2D's velocity.
	/// </summary>
	/// <returns>The y-component of the velocity.</returns>
	public static float GetVelocityY(this Rigidbody2D rigidbody)
	{
		return rigidbody.velocity.y;
	}
	#endregion

	#region Add
	/// <summary>
	/// Adds a value to the x-component of the Rigidbody2D's velocity.
	/// </summary>
	/// <param name="x">The value to add to the x-component of the velocity.</param>
	public static void AddVelocityX(this Rigidbody2D rigidbody, float x)
	{
		var velocity = rigidbody.velocity;
		velocity.x += x;
		rigidbody.velocity = velocity;
	}

	/// <summary>
	/// Adds a value to the y-component of the Rigidbody2D's velocity.
	/// </summary>
	/// <param name="y">The value to add to the y-component of the velocity.</param>
	public static void AddVelocityY(this Rigidbody2D rigidbody, float y)
	{
		var velocity = rigidbody.velocity;
		velocity.y += y;
		rigidbody.velocity = velocity;
	}
	#endregion
	#endregion
}