using Ball;
using UnityEngine;

namespace Platforms
{
	[RequireComponent(typeof(Collider))]
	public class PlatformPassTrigger : MonoBehaviour
	{
		private Platform _parentPlatform;

		private void OnValidate() => GetComponent<Collider>().isTrigger = true;

		private void Start() => _parentPlatform = GetComponentInParent<Platform>();

		private void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent(out BallCollisions _) == false)
				return;
			
			_parentPlatform.UnhookAllParts();
			Destroy(gameObject);
		}
	}
}