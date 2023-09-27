using UnityEngine;
using Cinemachine;

namespace GallFuys
{
    public class CameraController : MonoBehaviour
    {

        public float sensitivity = 2.0f;  // Mouse sensitivity for camera rotation.
        private CinemachineVirtualCamera virtualCamera;

        void Start()
        {
            virtualCamera = GetComponent<CinemachineVirtualCamera>();
        }

        void Update()
        {
            // Get the mouse input.
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            // Rotate the follow target (your player character) based on mouse input.
            Transform followTarget = virtualCamera.Follow;
            if (followTarget != null)
            {
                followTarget.Rotate(Vector3.up * mouseX * sensitivity);
            }

            // Rotate the look-at target (camera's point of interest) based on mouse input.
            Transform lookAtTarget = virtualCamera.LookAt;
            if (lookAtTarget != null)
            {
                lookAtTarget.Rotate(Vector3.right * -mouseY * sensitivity);
                // Clamp the rotation to prevent flipping.
                Vector3 lookAtRotation = lookAtTarget.localEulerAngles;
                lookAtRotation.x = Mathf.Clamp(lookAtRotation.x, -90, 90);
                lookAtTarget.localEulerAngles = lookAtRotation;
            }
        }
    }
}
