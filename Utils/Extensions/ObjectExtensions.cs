using UnityEngine;
using Type = System.Type;

public static class ObjectExtensions
{
	/// <summary>
	/// Finds all objects of a specified type in the scene.
	/// </summary>
	/// <returns>An array of objects of the specified type.</returns>
	public static Object[] FindObjects(Type type)
	{
#if UNITY_2023_1_OR_NEWER
		return Object.FindObjectsByType(type, FindObjectsSortMode.None);
#else
		return Object.FindObjectsOfType(type);
#endif
	}

	/// <summary>
	/// Finds all objects of a specified type in the scene.
	/// </summary>
	/// <returns>An array of objects of the specified type.</returns>
	public static T[] FindObjects<T>() where T : Object
	{
#if UNITY_2023_1_OR_NEWER
		return Object.FindObjectsByType<T>(FindObjectsSortMode.None);
#else
		return Object.FindObjectsOfType<T>();
#endif
	}

	/// <summary>
	/// Destroys the object. Uses <see cref="Object.Destroy"/> in play mode or build, and <see cref="Object.DestroyImmediate"/> in edit mode.
	/// </summary>
	/// <param name="obj">The object to destroy.</param>
	public static void Destroy(this Object obj)
	{
		if (Application.isPlaying)
		{
			Object.Destroy(obj);
		}			
		else
		{
			Object.DestroyImmediate(obj);
		}
	}

	/// <summary>
	/// Destroys the object immediately using <see cref="Object.DestroyImmediate"/>.
	/// </summary>
	/// <param name="obj">The object to destroy immediately.</param>
	public static void DestroyImmediate(this Object obj) => Object.DestroyImmediate(obj);
}