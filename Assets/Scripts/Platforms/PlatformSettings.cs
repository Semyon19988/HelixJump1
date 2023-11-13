using UnityEngine;

namespace Platforms
{
	[CreateAssetMenu(fileName = "PlatformSettings", menuName = "ScriptableObjects/Platforms/PlatformSettings")]
	public class PlatformSettings : ScriptableObject
	{
		[SerializeField] [Min(0.0f)] private float _destroyDelayAfterUnhooking;

		public float DestroyDelayAfterUnhooking => _destroyDelayAfterUnhooking;
	}
}