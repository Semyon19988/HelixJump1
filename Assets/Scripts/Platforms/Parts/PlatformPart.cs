using Extensions;
using Physics.Ejection;
using UnityEngine;

namespace Platforms.Parts
{
	public abstract class PlatformPart : MonoBehaviour
	{
		public void UnhookByEjection(EjectionSo ejection, Vector3 centerOfPlatform)
		{
			Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
			transform.ClearParent();
			rigidbody.detectCollisions = false;
			ejection.PushOut(rigidbody, centerOfPlatform);
		}
	}
}