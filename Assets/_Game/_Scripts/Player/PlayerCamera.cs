using UnityEngine;

namespace BoomerShooter
{
    public class PlayerCamera : MonoBehaviour
    {
        // Inspector
        [Header("Configurações")]
        [SerializeField] private float _sensitivity = 1.2f;

        // Não serializadas
        private Vector3 _eulerAngles;

        public void Initialize(Transform target)
        {
            transform.position = target.position;
            transform.rotation = target.rotation;

            _eulerAngles = target.eulerAngles;
            transform.eulerAngles = _eulerAngles;

            Cursor.lockState = CursorLockMode.Locked;
        }

        public void UpdatePosition(Transform target)
        {
            transform.position = target.position;
        }

        public void UpdateRotation(CameraInput input)
        {
            _eulerAngles += new Vector3(-input.Look.y, input.Look.x) * _sensitivity * Time.deltaTime;
            transform.eulerAngles = _eulerAngles;            
        }
    }
}

