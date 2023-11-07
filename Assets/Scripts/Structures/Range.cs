using UnityEngine;

namespace Structures
{
	public class Range<T> : ScriptableObject
	{
		[SerializeField] private T _min;
		[SerializeField] private T _max;
		
		public T Min => _min;
		public T Max => _max;
	}
}