using UnityEngine;
using static InputActions;

namespace BoomerShooter
{
    public class Player : MonoBehaviour
    {
        [Header("Referências")]
        [SerializeField] private PlayerCharacterController _playerCharacterController;
        [SerializeField] private PlayerCamera _playerCamera;

        // Não serializadas
        private InputActions _inputActions;

        private void Start()
        {
            _inputActions = new InputActions();
            _inputActions.Enable();
            _playerCharacterController.Initialize();
            _playerCamera.Initialize(_playerCharacterController.GetCameraTarget());
        }

        private void Update()
        {
            GameplayActions inputMap = _inputActions.Gameplay;

            // Rotacionando a camera a partir do Look Input
            CameraInput cameraInput = new CameraInput 
            { 
                Look = inputMap.Look.ReadValue<Vector2>() 
            };
            _playerCamera.UpdateRotation(cameraInput);

            // Atualizando orientação do Character Controller
            CharacterInput characterInput = new CharacterInput
            {
                Rotation = _playerCamera.transform.rotation,
                Move = inputMap.Move.ReadValue<Vector2>()
            };
            _playerCharacterController.UpdateInput(characterInput);
        }

        private void LateUpdate()
        {
            _playerCamera.UpdatePosition(_playerCharacterController.GetCameraTarget());
        }

        private void OnDestroy() => _inputActions.Dispose();
    }
}