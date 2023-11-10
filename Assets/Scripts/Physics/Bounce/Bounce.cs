using UnityEngine;

namespace Physics
{
	public class Bounce
	{
		private readonly Rigidbody _rigidbody;
		private readonly BounceData _data;

		public Bounce(Rigidbody rigidbody, BounceData data)
		{
			_rigidbody = rigidbody;
			_data = data;
		}

		public void BounceOff(Vector3 direction) =>
			_rigidbody.AddForce(direction * _data.Force, ForceMode.VelocityChange);

		public void ClampHeight()
		{
			Vector3 velocity = _rigidbody.velocity;

			_rigidbody.velocity = velocity.y >= 0.0f
				? Vector3.ClampMagnitude(velocity, _data.MaxHeight)
				: velocity;
		}
	}
}