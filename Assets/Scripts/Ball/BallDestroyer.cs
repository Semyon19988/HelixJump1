using Cinemachine;
using UnityEngine;

namespace Ball
{
	public class BallDestroyer : MonoBehaviour
	{
		[SerializeField] private Transform _ball;
		[SerializeField] private BallParticles _particles;
		[SerializeField] private CinemachineImpulseSource _impulseSource;

		public void Destroy()
		{
			_particles.EmitDestroyParticles(_ball.position);
			_impulseSource.GenerateImpulse();
			
			Destroy(_ball.gameObject);
		}

	}
}