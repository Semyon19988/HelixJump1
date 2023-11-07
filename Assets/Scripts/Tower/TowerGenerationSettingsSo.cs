using System;
using Extensions;
using Platforms;
using Structures;
using UnityEngine;

namespace Tower
{
	[CreateAssetMenu(menuName = "ScriptableObjects/Tower/TowerGenerationSettings", fileName = "TowerGenerationSettings")]
	public class TowerGenerationSettingsSo : ScriptableObject
	{
		[SerializeField] [Min(0.0f)] private int _platformVariantCount;
		[SerializeField] [Min(0.0f)] private float _offsetBetweenPlatforms;

		[Header("Platform Rotation")] 
		[SerializeField] private FloatRange _rotationRange;

		[Header("Platform Prefabs")]
		[SerializeField] private Platform _startPlatformPrefab;
		[SerializeField] private Platform _finishPlatformPrefab;
		[SerializeField] private Platform[] _platformsVariantPrefab = Array.Empty<Platform>();

		public int PlatformVariantCount => _platformVariantCount;

		public float OffsetBetweenPlatforms => _offsetBetweenPlatforms;

		public Platform StartPlatformPrefab => _startPlatformPrefab;

		public Platform FinishPlatformPrefab => _finishPlatformPrefab;

		public Platform PlatformsVariantsPrefab => _platformsVariantPrefab.Random();

		public FloatRange RotationRange => _rotationRange;
	}
}