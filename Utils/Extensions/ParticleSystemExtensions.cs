using UnityEngine;

public static class ParticleSystemExtensions
{
	/// <summary>
	/// Enables or disables the emission of particles in a ParticleSystem.
	/// </summary>
	/// <param name="enabled">True to enable emission, false to disable.</param>
	public static void EnableEmission(this ParticleSystem particleSystem, bool enabled)
	{
		var emission = particleSystem.emission;
		emission.enabled = enabled;
	}

	/// <summary>
	/// Gets the constant maximum emission rate of particles in a ParticleSystem.
	/// </summary>
	/// <returns>The constant maximum emission rate of particles.</returns>
	public static float GetEmissionRate(this ParticleSystem particleSystem)
	{
		return particleSystem.emission.rateOverTime.constantMax;
	}

	/// <summary>
	/// Sets the constant maximum emission rate of particles in a ParticleSystem.
	/// </summary>
	/// <param name="emissionRate">The new constant maximum emission rate of particles.</param>
	public static void SetEmissionRate(this ParticleSystem particleSystem, float emissionRate)
	{
		var emission = particleSystem.emission;
		var rate = emission.rateOverTime;
		rate.constantMax = emissionRate;
		emission.rateOverTime = rate;
	}
}