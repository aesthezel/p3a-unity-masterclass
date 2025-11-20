using Cinemachine;
using UnityEngine;

namespace Operators
{
    public class CameraOperator : MonoBehaviour
    {
        public const byte MaximumPriority = byte.MaxValue;
        public const byte MinimumPriority = byte.MinValue;
        
        [SerializeField] 
        private CinemachineVirtualCamera baseVirtualCamera;
        
        private void Awake()
        {
            FocusBaseCamera();
        }
        
        public void FocusBaseCamera() => baseVirtualCamera.Priority = MaximumPriority;
        public void UnFocusBaseCamera() => baseVirtualCamera.Priority = MinimumPriority;
    }
}