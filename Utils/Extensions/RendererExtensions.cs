using UnityEngine;

public static class RendererExtensions 
{
	/// <summary>
	/// Checks if the Renderer is currently visible from a specified Camera.
	/// </summary>
	/// <param name="camera">The Camera to check visibility against.</param>
	/// <returns>True if the Renderer is visible, false otherwise.</returns>
	public static bool IsVisible(this Renderer renderer, Camera camera)
	{
		var planes = GeometryUtility.CalculateFrustumPlanes(camera);
		return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
	}

	/// <summary>
	/// Gets the combined bounding box that encapsulates the Renderer and its children.
	/// </summary>
	/// <param name="includeChildren">Include children Renderers in the calculation.</param>
	/// <returns>The combined bounding box.</returns>
	public static Bounds GetBounds(this Renderer renderer, bool includeChildren = true)
	{
		if (includeChildren)
		{
			var center = renderer.transform.position;
			var bounds = new Bounds(center, Vector3.zero);
			var rendererList = renderer.gameObject.GetComponentsInChildren<Renderer>();
			if (rendererList.Length == 0) return bounds;
			foreach (var r in rendererList)
			{
				bounds.Encapsulate(r.bounds);
			}
			return bounds;
		}
		else
		{
			return renderer.bounds;
		}
	}

	/// <summary>
	/// Gets the Material at the specified index from the Renderer.
	/// </summary>
	/// <param name="materialIndex">The index of the Material.</param>
	/// <returns>The Material at the specified index, or null if the index is out of bounds.</returns>
	public static Material GetMaterial(this Renderer renderer, int materialIndex)
	{
		if (materialIndex < 0 || materialIndex >= renderer.sharedMaterials.Length) return null;
		return Application.isPlaying ? renderer.materials[materialIndex] : renderer.sharedMaterials[materialIndex];
	}

	/// <summary>
	/// Enables ZWrite for materials in this Renderer that have a '_Color' property. This will allow the materials 
	/// to write to the Z buffer, which could be used to affect how subsequent rendering is handled, 
	/// for instance, ensuring correct layering of transparent objects.
	/// </summary>    
	public static void EnableZWrite(this Renderer renderer) 
	{
		foreach (Material material in renderer.materials) 
		{
			if (material.HasProperty("_Color")) 
			{
				material.SetInt("_ZWrite", 1);
				material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
			}
		}
	}
	
	/// <summary>
	/// Disables ZWrite for materials in this Renderer that have a '_Color' property. This would stop 
	/// the materials from writing to the Z buffer, which may be desirable in some cases to prevent subsequent 
	/// rendering from being occluded, like in rendering of semi-transparent or layered objects.
	/// </summary>
	public static void DisableZWrite(this Renderer renderer) 
	{
		foreach (Material material in renderer.materials) 
		{
			if (material.HasProperty("_Color")) 
			{
				material.SetInt("_ZWrite", 0);
				material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent + 100;
			}
		}
	}
}