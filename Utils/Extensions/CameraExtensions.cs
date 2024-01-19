using UnityEngine;

public static class CameraExtensions 
{
	#region Viewport
	/// <summary>
	/// Calculates and returns viewport extents with an optional margin. Useful for calculating a frustum for culling.
	/// </summary>
	/// <param name="camera">The camera object this method extends.</param>
	/// <param name="viewportMargin">Optional margin to be applied to viewport extents. Default is 0.2, 0.2.</param>
	/// <returns>Viewport extents as a Vector2 after applying the margin.</returns>
	public static Vector2 GetViewportExtentsWithMargin(this Camera camera, Vector2? viewportMargin = null) 
	{
		Vector2 margin = viewportMargin ?? new Vector2(0.2f, 0.2f);

		Vector2 result;
		float halfFieldOfView = camera.fieldOfView * 0.5f * Mathf.Deg2Rad;
		result.y = camera.nearClipPlane * Mathf.Tan(halfFieldOfView);
		result.x = result.y * camera.aspect + margin.x;
		result.y += margin.y;
		return result;
	}
	#endregion

	#region Coordinate

	/// <summary>
	/// Converts screen coordinates to world coordinates, ignoring the Z component.
	/// </summary>
	/// <param name="camera">The Camera to use.</param>
	/// <param name="position">The screen coordinates (X, Y).</param>
	/// <returns>World coordinates with the Z component ignored.</returns>
	public static Vector3 ScreenToWorldPointIgnoreDeep(this Camera camera, Vector3 position)
	{
		var deep = camera.transform.position.z;
		var result = camera.ScreenToWorldPoint(new Vector3(position.x, position.y, deep));
		return result;
	}

	#endregion

	#region Meter / Pixel

	/// <summary>
	/// Calculates the meters per pixel for an orthographic camera.
	/// </summary>
	/// <returns>Meters per pixel value.</returns>
	public static float MetersPerPixel(this Camera orthographicCamera)
	{
		var result = orthographicCamera.orthographicSize * 2 / Screen.height;
		return result;
	}

	/// <summary>
	/// Calculates the pixels per meter for an orthographic camera.
	/// </summary>
	/// <returns>Pixels per meter value.</returns>
	public static float PixelsPerMeter(this Camera orthographicCamera)
	{
		var result = Screen.height * 0.5f / orthographicCamera.orthographicSize;
		return result;
	}

	#endregion

	#region Capture

	/// <summary>
	/// Captures a screenshot of the camera's view.
	/// </summary>
	/// <returns>The captured screenshot as a Texture2D.</returns>
	public static Texture2D Capture(this Camera camera)
	{
		var texture = camera.Capture(new Rect(0, 0, Screen.width, Screen.height));
		return texture;
	}

	/// <summary>
	/// Captures a screenshot of the camera's view within the specified rect.
	/// </summary>
	/// <param name="rect">The rectangular area to capture.</param>
	/// <returns>The captured screenshot as a Texture2D.</returns>
	public static Texture2D Capture(this Camera camera, Rect rect)
	{
		var renderTexture = new RenderTexture(Screen.width, Screen.height, 0);
		camera.targetTexture = renderTexture;
		camera.Render();
		RenderTexture.active = renderTexture;
		var screenShot = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGB24, false);
		screenShot.ReadPixels(rect, 0, 0);
		screenShot.Apply();
		camera.targetTexture = null;
		RenderTexture.active = null;
		Object.Destroy(renderTexture);

		return screenShot;
	}

	#endregion

	#region Size

	/// <summary>
	/// Converts pixel size to world size based on the camera's orthographic or perspective settings.
	/// </summary>
	/// <param name="pixelSize">The size in pixels.</param>
	/// <param name="clipPlane">The clip plane distance.</param>
	/// <returns>World size.</returns>
	public static float ScreenToWorldSize(this Camera camera, float pixelSize, float clipPlane)
	{
		float result;
		if (camera.orthographic)
		{
			result = pixelSize * camera.orthographicSize * 2f / camera.pixelHeight;
		}
		else
		{
			result = pixelSize * clipPlane * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad) * 2f / camera.pixelHeight;
		}

		return result;
	}

	/// <summary>
	/// Converts world size to screen size based on the camera's orthographic or perspective settings.
	/// </summary>
	/// <param name="worldSize">The size in world units.</param>
	/// <param name="clipPlane">The clip plane distance.</param>
	/// <returns>Screen size.</returns>
	public static float WorldToScreenSize(this Camera camera, float worldSize, float clipPlane)
	{
		float result;
		if (camera.orthographic)
		{
			result = worldSize * camera.pixelHeight * 0.5f / camera.orthographicSize;
		}
		else
		{
			result = worldSize * camera.pixelHeight * 0.5f / (clipPlane * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad));
		}

		return result;
	}

	#endregion

	#region Clip Plane

	/// <summary>
	/// Gets the clip plane parameters for a specified point and normal in world space.
	/// </summary>
	/// <param name="point">The point in world space.</param>
	/// <param name="normal">The normal vector in world space.</param>
	/// <returns>Clip plane parameters.</returns>
	public static Vector4 GetClipPlane(this Camera camera, Vector3 point, Vector3 normal)
	{
		var wtoc = camera.worldToCameraMatrix;
		point = wtoc.MultiplyPoint(point);
		normal = wtoc.MultiplyVector(normal).normalized;
		var result = new Vector4(normal.x, normal.y, normal.z, -Vector3.Dot(point, normal));
		return result;
	}

	#endregion

	#region ZBuffer

	/// <summary>
	/// Gets the Z-buffer parameters for the camera.
	/// </summary>
	/// <returns>Z-buffer parameters.</returns>
	public static Vector4 GetZBufferParams(this Camera camera)
	{
		double f = camera.farClipPlane;
		double n = camera.nearClipPlane;

		var rn = 1f / n;
		var rf = 1f / f;
		var fpn = f / n;

		var result = SystemInfo.usesReversedZBuffer
			? new Vector4((float)(fpn - 1.0), 1f, (float)(rn - rf), (float)rf)
			: new Vector4((float)(1.0 - fpn), (float)fpn, (float)(rf - rn), (float)rn);
		return result;
	}

	#endregion
}