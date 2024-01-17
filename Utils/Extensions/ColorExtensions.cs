using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorExtensions
{
	/// <summary>
	/// Converts HSL (Hue, Saturation, Lightness) color representation to RGB (Red, Green, Blue) color.
	/// </summary>
	/// <param name="h">The hue value (ranging from 0 to 1).</param>
	/// <param name="s">The saturation value (ranging from 0 to 1).</param>
	/// <param name="l">The lightness value (ranging from 0 to 1).</param>
	/// <returns>The resulting RGB color.</returns>
	public static Color HSLToRGB(float h, float s, float l)
	{
		// Internal helper function to convert hue to RGB
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