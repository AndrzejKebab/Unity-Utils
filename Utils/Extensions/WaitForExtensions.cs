using System.Collections.Generic;
using UnityEngine;

public static class WaitForExtensions
{
	public class WaitForSecondsCache
	{
		private Dictionary<float, WaitForSeconds> cache = new Dictionary<float, WaitForSeconds>();
		public WaitForSeconds this[float time] => cache.TryGetValue(time, out var wait)
			? wait
			: cache[time] = new WaitForSeconds(time);
	}
	public class WaitForSecondsRealtimeCache
	{
		private Dictionary<float, WaitForSecondsRealtime> cache = new Dictionary<float, WaitForSecondsRealtime>();
		public WaitForSecondsRealtime this[float time] => cache.TryGetValue(time, out var wait)
			? wait : cache[time] = new WaitForSecondsRealtime(time);
	}

	public static readonly WaitForFixedUpdate forFixedUpdate = new();
	public static readonly WaitForEndOfFrame forEndOfFrame = new();
	public static readonly WaitForSecondsCache forSeconds = new();
	public static readonly WaitForSecondsRealtimeCache forSecondsRealtime = new();
}
