using Cinemachine;
using Game.Operators;
using UnityEngine;

namespace Game.Selectables
{
    public class FreezerEntity : SelectableEntity
    {
        [SerializeField] 
        private CinemachineVirtualCamera focusCamera;

        [SerializeField] 
        private Transform spawnPoint;
        [SerializeField]
        private GameObject[] spawnObjects;

        [SerializeField, Range(1, 100)] 
        private int maxForce;
        
        public override void Select()
        {
            if (!CanInteractable && !IsSelected)
            {
                CanInteractable = true;
                IsSelected = true;
                focusCamera.Priority = CameraOperator.MaximumPriority;
            }
            
            SpawnFood();
        }

        public override void UnSelect()
        {
            IsSelected = false;
            focusCamera.Priority = CameraOperator.MinimumPriority;
        }

        private void SpawnFood()
        {
            var randomIndex = Random.Range(0, spawnObjects.Length);
            var food = Instantiate(spawnObjects[randomIndex], spawnPoint.position, spawnPoint.rotation);

            if (!food.TryGetComponent<Rigidbody>(out var foodRigidBody)) return;
            var randomForce = Random.Range(0, maxForce);
            foodRigidBody.AddForce(Vector3.forward * randomForce);
        }
    }
}