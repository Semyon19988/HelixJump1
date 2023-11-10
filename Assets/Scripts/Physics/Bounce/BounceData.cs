using UnityEngine;

namespace Physics
{
	[System.Serializable]
	public class BounceData
	{
		[SerializeField] private float _force;
		[SerializeField] private float _maxHeight;

		public float Force => _force;

		public float MaxHeight => _maxHeight;
	}
}