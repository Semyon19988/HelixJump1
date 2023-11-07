using UnityEngine;

namespace Structures
{
	[CreateAssetMenu(menuName = "ScriptableObjects/Structures/FloatRange", fileName = "FloatRange")]
	public class FloatRange : Range<float>
	{
		public float Random => UnityEngine.Random.Range(Min, Max);
	}
}