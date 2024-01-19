using UnityEngine;

public static class MatrixExtensions
{
	/// <summary>
	/// Deconstructs a Matrix4x4 into its column vectors.
	/// </summary>
	/// <param name="column0">The first column vector of the Matrix4x4.</param>
	/// <param name="column1">The second column vector of the Matrix4x4.</param>
	/// <param name="column2">The third column vector of the Matrix4x4.</param>
	/// <param name="column3">The fourth column vector of the Matrix4x4.</param>
	public static void Deconstruct(this Matrix4x4 matrix,
								   out Vector4 column0, out Vector4 column1,
								   out Vector4 column2, out Vector4 column3)
	{
		column0 = matrix.GetColumn(0); column1 = matrix.GetColumn(1);
		column2 = matrix.GetColumn(2); column3 = matrix.GetColumn(3);
	}

	/// <summary>
	/// Deconstructs a Matrix4x4 into its individual elements.
	/// </summary>
	/// <param name="m00">The value at position (0,0) of the Matrix4x4.</param>
	/// <param name="m01">The value at position (0,1) of the Matrix4x4.</param>
	/// <param name="m02">The value at position (0,2) of the Matrix4x4.</param>
	/// <param name="m03">The value at position (0,3) of the Matrix4x4.</param>
	/// <param name="m10">The value at position (1,0) of the Matrix4x4.</param>
	/// <param name="m11">The value at position (1,1) of the Matrix4x4.</param>
	/// <param name="m12">The value at position (1,2) of the Matrix4x4.</param>
	/// <param name="m13">The value at position (1,3) of the Matrix4x4.</param>
	/// <param name="m20">The value at position (2,0) of the Matrix4x4.</param>
	/// <param name="m21">The value at position (2,1) of the Matrix4x4.</param>
	/// <param name="m22">The value at position (2,2) of the Matrix4x4.</param>
	/// <param name="m23">The value at position (2,3) of the Matrix4x4.</param>
	/// <param name="m30">The value at position (3,0) of the Matrix4x4.</param>
	/// <param name="m31">The value at position (3,1) of the Matrix4x4.</param>
	/// <param name="m32">The value at position (3,2) of the Matrix4x4.</param>
	/// <param name="m33">The value at position (3,3) of the Matrix4x4.</param>
	public static void Deconstruct(in this Matrix4x4 matrix,
								   out float m00, out float m01, out float m02, out float m03,
								   out float m10, out float m11, out float m12, out float m13,
								   out float m20, out float m21, out float m22, out float m23,
								   out float m30, out float m31, out float m32, out float m33)
	{
		m00 = matrix.m00; m01 = matrix.m01; m02 = matrix.m02; m03 = matrix.m03;
		m10 = matrix.m10; m11 = matrix.m11; m12 = matrix.m12; m13 = matrix.m13;
		m20 = matrix.m20; m21 = matrix.m21; m22 = matrix.m22; m23 = matrix.m23;
		m30 = matrix.m30; m31 = matrix.m31; m32 = matrix.m32; m33 = matrix.m33;
	}

	/// <summary>
	/// Creates a new Matrix4x4 with specified columns.
	/// </summary>
	/// <param name="column0">The new value for column 0 (default is null, uses the original column).</param>
	/// <param name="column1">The new value for column 1 (default is null, uses the original column).</param>
	/// <param name="column2">The new value for column 2 (default is null, uses the original column).</param>
	/// <param name="column3">The new value for column 3 (default is null, uses the original column).</param>
	/// <returns>A new Matrix4x4 with specified columns.</returns>
	public static Matrix4x4 With(this Matrix4x4 matrix,
								 in Vector4? column0 = null, in Vector4? column1 = null,
								 in Vector4? column2 = null, in Vector4? column3 = null)
	{
		var result = new Matrix4x4(
			column0 ?? matrix.GetColumn(0), column1 ?? matrix.GetColumn(1),
			column2 ?? matrix.GetColumn(2), column3 ?? matrix.GetColumn(3)
		);
		return result;
	}

	/// <summary>
	/// Creates a new Matrix4x4 with specified elements.
	/// </summary>
	/// <param name="m00">The new value for element (0,0) (default is null, uses the original value).</param>
	/// <param name="m01">The new value for element (0,1) (default is null, uses the original value).</param>
	/// <param name="m02">The new value for element (0,2) (default is null, uses the original value).</param>
	/// <param name="m03">The new value for element (0,3) (default is null, uses the original value).</param>
	/// <param name="m10">The new value for element (1,0) (default is null, uses the original value).</param>
	/// <param name="m11">The new value for element (1,1) (default is null, uses the original value).</param>
	/// <param name="m12">The new value for element (1,2) (default is null, uses the original value).</param>
	/// <param name="m13">The new value for element (1,3) (default is null, uses the original value).</param>
	/// <param name="m20">The new value for element (2,0) (default is null, uses the original value).</param>
	/// <param name="m21">The new value for element (2,1) (default is null, uses the original value).</param>
	/// <param name="m22">The new value for element (2,2) (default is null, uses the original value).</param>
	/// <param name="m23">The new value for element (2,3) (default is null, uses the original value).</param>
	/// <param name="m30">The new value for element (3,0) (default is null, uses the original value).</param>
	/// <param name="m31">The new value for element (3,1) (default is null, uses the original value).</param>
	/// <param name="m32">The new value for element (3,2) (default is null, uses the original value).</param>
	/// <param name="m33">The new value for element (3,3) (default is null, uses the original value).</param>
	/// <returns>A new Matrix4x4 with specified elements.</returns>
	public static Matrix4x4 With(in this Matrix4x4 matrix,
								 float? m00 = null, float? m01 = null, float? m02 = null, float? m03 = null,
								 float? m10 = null, float? m11 = null, float? m12 = null, float? m13 = null,
								 float? m20 = null, float? m21 = null, float? m22 = null, float? m23 = null,
								 float? m30 = null, float? m31 = null, float? m32 = null, float? m33 = null)
	{
		var result = new Matrix4x4
		{
			m00 = m00 ?? matrix.m00,
			m01 = m01 ?? matrix.m01,
			m02 = m02 ?? matrix.m02,
			m03 = m03 ?? matrix.m03,
			m10 = m10 ?? matrix.m10,
			m11 = m11 ?? matrix.m11,
			m12 = m12 ?? matrix.m12,
			m13 = m13 ?? matrix.m13,
			m20 = m20 ?? matrix.m20,
			m21 = m21 ?? matrix.m21,
			m22 = m22 ?? matrix.m22,
			m23 = m23 ?? matrix.m23,
			m30 = m30 ?? matrix.m30,
			m31 = m31 ?? matrix.m31,
			m32 = m32 ?? matrix.m32,
			m33 = m33 ?? matrix.m33
		};
		return result;
	}
}