using System.Collections.Generic;
using Platforms;
using Structures;
using UnityEngine;

namespace Tower
{
   public class TowerGeneration : MonoBehaviour
   {
      [SerializeField] private TowerGenerationSettingsSo _generationSettings;

      [Header("Tower")] 
      [SerializeField] private Transform _tower;

      private FloatRange RotationRange => _generationSettings.RotationRange;

      public void Start() => Generate(_generationSettings, _tower);

      private void Generate(TowerGenerationSettingsSo generationSettingsSo, Transform tower)
      {
         List<Platform> spawnedPlatforms = SpawnPlatforms(generationSettingsSo, out float offsetFromTop);
         FitTowerHeight(tower, offsetFromTop);
         spawnedPlatforms.ForEach(platform => platform.transform.SetParent(tower));
      }

      private Vector3 GetRandomYRotation(FloatRange rotationRange) => 
         Vector3.up * rotationRange.Random;

      private Platform Create(Platform platformPrefab, FloatRange rotationRange, ref float offsetFromTop)
      {
         Platform createdPlatform = Instantiate(platformPrefab);

         Transform platformTransform = createdPlatform.transform;

         platformTransform.position = Vector3.down * offsetFromTop;
         platformTransform.eulerAngles = GetRandomYRotation(rotationRange);

         offsetFromTop += platformTransform.localScale.y + _generationSettings.OffsetBetweenPlatforms;

         return createdPlatform;
      }

      private List<Platform> SpawnPlatforms(TowerGenerationSettingsSo generationSettings, out float offsetFromTop)
      {
         offsetFromTop = generationSettings.OffsetBetweenPlatforms;
         const int startAndFinishPlatforms = 2;
         var spawnedPlatforms = new List<Platform>(generationSettings.PlatformVariantCount + startAndFinishPlatforms);

         Platform startPlatform = Create(generationSettings.StartPlatformPrefab, RotationRange, ref offsetFromTop);
         spawnedPlatforms.Add(startPlatform);

         for (int i = 0; i < generationSettings.PlatformVariantCount; i++)
         {
            Platform platform = Create(generationSettings.PlatformsVariantsPrefab, RotationRange, ref offsetFromTop);
            spawnedPlatforms.Add(platform);
         }

         Platform finishPlatform = Create(generationSettings.FinishPlatformPrefab, RotationRange, ref offsetFromTop);
         spawnedPlatforms.Add(finishPlatform);
         return spawnedPlatforms;
      }

      private void FitTowerHeight(Transform tower, float height)
      {
         Vector3 originalSize = tower.localScale;
         float towerHeight = height / 2.0f;
         tower.localScale = new Vector3(originalSize.x, towerHeight, originalSize.z);
         tower.localPosition -= Vector3.up * towerHeight;
      }
   }
}
