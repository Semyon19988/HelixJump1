using Platforms.Parts;
using UnityEngine;

namespace Ball
{
	public class BallCollisions : MonoBehaviour
	{
		[SerializeField] private BallBounce _bounce;
		[SerializeField] private BallParticles _particles;
		[SerializeField] private BallDestroyer _destroyer;

		private bool _collided;

		private void OnCollisionEnter(Collision other)
		{
			if (other.gameObject.TryGetComponent(out PlatformObstacle _))
			{
				_destroyer.Destroy();
				return;
			}
			if (_collided)
				return;
			_collided = true;

			_bounce.BounceOff(Vector3.up);
			_particles.EmitSpotParticles(other);
			_particles.EmitGroundCollisionParticles(other);
		}

		private void OnCollisionExit(Collision other) => _collided = false;
	}
}