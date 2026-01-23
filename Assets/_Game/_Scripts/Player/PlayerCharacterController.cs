using KinematicCharacterController;
using UnityEngine;

namespace BoomerShooter
{
    public class PlayerCharacterController : MonoBehaviour, ICharacterController
    {
        [Header("Referências")]
        [SerializeField] private KinematicCharacterMotor _motor;
        [SerializeField] private Transform _cameraTarget;

        [Header("Configurações")]
        [SerializeField] private float _moveSpeed;

        private Quaternion _requestedRotation;
        private Vector3 _requestedMovement;

        public void Initialize()
        {
            _motor.CharacterController = this;
        }

        public void UpdateInput(CharacterInput input)
        {
            _requestedRotation = input.Rotation;

            _requestedMovement = new Vector3(input.Move.x, 0f, input.Move.y);
            _requestedMovement = Vector3.ClampMagnitude(_requestedMovement, 1f);

            // Mantendo o vetor de movimentacao relativo a direcao de orientacao atual
            _requestedMovement = input.Rotation * _requestedMovement;
        }

        public void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
        {
            Vector3 groundedMovement = _motor.GetDirectionTangentToSurface(_requestedMovement, _motor.GroundingStatus.GroundNormal);
            groundedMovement *= _requestedMovement.magnitude;
            currentVelocity = groundedMovement * _moveSpeed;
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