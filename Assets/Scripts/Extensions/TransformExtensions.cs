using UnityEngine;

namespace Extensions
{
	public static class TransformExtensions
	{
		public static void ClearParent(this Transform transform) =>
			transform.SetParent(null);
	}
}