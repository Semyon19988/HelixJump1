using UnityEngine;

namespace Ball
{
   public class BallParticles : MonoBehaviour
   {
      private const float SurfaceYOffset = 0.06f;
    
      [SerializeField] private ParticleSystem _collisionParticlePrefab;
      [SerializeField] private ParticleSystem _spotParticlePrefab;
      [SerializeField] private ParticleSystem _destroyParticlePrefab;

      private ParticleSystem _collisionParticles;
      private void Start() => _collisionParticles = Instantiate(_collisionParticlePrefab);

   
      public void EmitGroundCollisionParticles(Collision other)
      {
         Vector3 collisionPosition = other.contacts[0].point;
         _collisionParticles.transform.position = collisionPosition;
         _collisionParticles.Play();
      }

      public void EmitSpotParticles(Collision collision)
      {
         Vector3 collisionPosition = collision.contacts[0].point + Vector3.up * SurfaceYOffset;
         Instantiate(_spotParticlePrefab, collisionPosition, Quaternion.identity, collision.transform);
      }

      public void EmitDestroyParticles(Vector3 position)
      {
         Instantiate(_destroyParticlePrefab, position, Quaternion.identity);
      }
   }
}
