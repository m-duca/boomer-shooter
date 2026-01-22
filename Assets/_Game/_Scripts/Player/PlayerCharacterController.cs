using KinematicCharacterController;
using UnityEngine;

namespace BoomerShooter
{
    public class PlayerCharacterController : MonoBehaviour, ICharacterController
    {
        [Header("Referências")]
        [SerializeField] private KinematicCharacterMotor _motor;
        [SerializeField] private Transform _cameraTarget;

        private Quaternion _requestedRotation;

        public void Initialize()
        {
            _motor.CharacterController = this;
        }

        public void UpdateInput(CharacterInput input)
        {
            _requestedRotation = input.Rotation;
        }

        public void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
        {
        }

        public void UpdateRotation(ref Quaternion currentRotation, float deltaTime)
        {
            Vector3 forward = Vector3.ProjectOnPlane(_requestedRotation * Vector3.forward, _motor.CharacterUp);

            currentRotation = Quaternion.LookRotation(forward, _motor.CharacterUp);
        }

        public void AfterCharacterUpdate(float deltaTime)
        {
        }

        public void BeforeCharacterUpdate(float deltaTime)
        {
        }

        public bool IsColliderValidForCollisions(Collider coll)
        {
            throw new System.NotImplementedException();
        }

        public void OnDiscreteCollisionDetected(Collider hitCollider)
        {
        }

        public void OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
        {
        }

        public void OnMovementHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
        {
        }

        public void PostGroundingUpdate(float deltaTime)
        {
        }

        public void ProcessHitStabilityReport(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, Vector3 atCharacterPosition, Quaternion atCharacterRotation, ref HitStabilityReport hitStabilityReport)
        {
        }

        public Transform GetCameraTarget() => _cameraTarget;
    }
}