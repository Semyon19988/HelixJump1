using Physics.Ejection;
using Platforms.Parts;
using UnityEngine;

namespace Platforms
{
	public class Platform : MonoBehaviour
	{
		[SerializeField] private EjectionSo _ejection;
		[SerializeField] private PlatformSettings _settings;

		private PlatformPart[] _parts;

		private void Start() =>
			_parts = GetComponentsInChildren<PlatformPart>();

		public void UnhookAllParts()
		{
			foreach (PlatformPart platformPart in _parts)
			{
				platformPart.UnhookByEjection(_ejection, transform.position);
				Destroy(platformPart.gameObject, _settings.DestroyDelayAfterUnhooking);
			}
			
			Destroy(gameObject, _settings.DestroyDelayAfterUnhooking);
		}
	}
}