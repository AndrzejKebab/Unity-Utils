using UnityEngine;

public static class ColorExtensions
{
	/// <summary>
	/// Deconstructs a Color into its RGB components.
	/// </summary>
	/// <param name="r">The red component of the Color.</param>
	/// <param name="g">The green component of the Color.</param>
	/// <param name="b">The blue component of the Color.</param>
	public static void Deconstruct(in this Color color, out float r, out float g, out float b)
	{
		r = color.r;
		g = color.g;
		b = color.b;
	}

	/// <summary>
	/// Deconstructs a Color into its RGBA components.
	/// </summary>
	/// <param name="r">The red component of the Color.</param>
	/// <param name="g">The green component of the Color.</param>
	/// <param name="b">The blue component of the Color.</param>
	/// <param name="a">The alpha component of the Color.</param>
	public static void Deconstruct(in this Color color, out float r, out float g, out float b, out float a)
	{
		r = color.r;
		g = color.g;
		b = color.b;
		a = color.a;
	}

	/// <summary>
	/// Deconstructs a Color32 into its RGB components.
	/// </summary>
	/// <param name="r">The red component of the Color32.</param>
	/// <param name="g">The green component of the Color32.</param>
	/// <param name="b">The blue component of the Color32.</param>
	public static void Deconstruct(in this Color32 color, out byte r, out byte g, out byte b)
	{
		r = color.r;
		g = color.g;
		b = color.b;
	}

	/// <summary>
	/// Deconstructs a Color32 into its RGBA components.
	/// </summary>
	/// <param name="r">The red component of the Color32.</param>
	/// <param name="g">The green component of the Color32.</param>
	/// <param name="b">The blue component of the Color32.</param>
	/// <param name="a">The alpha component of the Color32.</param>
	public static void Deconstruct(in this Color32 color, out byte r, out byte g, out byte b, out byte a)
	{
		r = color.r;
		g = color.g;
		b = color.b;
		a = color.a;
	}

	/// <summary>
	/// Creates a new Color with optional modified components.
	/// </summary>
	/// <param name="r">The new red component (optional).</param>
	/// <param name="g">The new green component (optional).</param>
	/// <param name="b">The new blue component (optional).</param>
	/// <param name="a">The new alpha component (optional).</param>
	/// <returns>A new Color with specified or original components.</returns>
	public static Color With(in this Color color, float? r = null, float? g = null, float? b = null, float? a = null)
	{
		// Create a new Color with optional modified components
		var result = new Color(r ?? color.r, g ?? color.g, b ?? color.b, a ?? color.a);
		return result;
	}

	/// <summary>
	/// Creates a new Color32 with optional modified components.
	/// </summary>
	/// <param name="r">The new red component (optional).</param>
	/// <param name="g">The new green component (optional).</param>
	/// <param name="b">The new blue component (optional).</param>
	/// <param name="a">The new alpha component (optional).</param>
	/// <returns>A new Color32 with specified or original components.</returns>
	public static Color32 With(in this Color32 color, byte? r = null, byte? g = null, byte? b = null, byte? a = null)
	{
		// Create a new Color32 with optional modified components
		var result = new Color32(r ?? color.r, g ?? color.g, b ?? color.b, a ?? color.a);
		return result;
	}

	/// <summary>
	/// Normalizes the RGB components of the Color.
	/// </summary>
	/// <returns>The normalized Color.</returns>
	public static Color Normalize(this ref Color color)
	{
		var vector = new Vector3(color.r, color.g, color.b).normalized;

		color.r = vector.x;
		color.g = vector.y;
		color.b = vector.z;

		return color;
	}

	/// <summary>
	/// Converts HSL (Hue, Saturation, Lightness) color representation to RGB (Red, Green, Blue) color.
	/// </summary>
	/// <param name="h">The hue value (ranging from 0 to 1).</param>
	/// <param name="s">The saturation value (ranging from 0 to 1).</param>
	/// <param name="l">The lightness value (ranging from 0 to 1).</param>
	/// <returns>The resulting RGB color.</returns>
	public static Color HSLToRGB(float h, float s, float l)
	{
		float hue2Rgb(float v1, float v2, float vH)
		{
			if (vH < 0f)
				vH += 1f;

			if (vH > 1f)
				vH -= 1f;

			if (6f * vH < 1f)
				return v1 + (v2 - v1) * 6f * vH;

			if (2f * vH < 1f)
				return v2;

			if (3f * vH < 2f)
				return v1 + (v2 - v1) * (2f / 3f - vH) * 6f;

			return v1;
		}

		// If saturation is approximately 0, the color is a shade of gray
		if (s.Approx(0)) return new Color(l, l, l);

		float k1;

		// Calculate k1 based on lightness value
		if (l < .5f)
			k1 = l * (1f + s);
		else
			k1 = l + s - s * l;

		// Calculate k2
		var k2 = 2f * l - k1;

		float r, g, b;

		// Calculate RGB values using the internal helper function
		r = hue2Rgb(k2, k1, h + 1f / 3);
		g = hue2Rgb(k2, k1, h);
		b = hue2Rgb(k2, k1, h - 1f / 3);

		// Return the resulting RGB color
		return new Color(r, g, b);
	}
}