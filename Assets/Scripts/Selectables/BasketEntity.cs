using System;
using Cinemachine;
using Operators;
using UnityEngine;

namespace Selectables
{
    public class BasketEntity : SelectableEntity
    {
        public event Action<int> OnScoreChanged;
        public event Action<bool> OnSelectionChanged;
        
        [SerializeField] 
        private CinemachineVirtualCamera focusCamera;
        
        [SerializeField] 
        private Animator animator;

        private int _counter;
    
        private readonly int _idleAnimation = Animator.StringToHash("Bastketball@Idle");
        private readonly int _playAnimation = Animator.StringToHash("Bastketball@Play");
        private readonly int _launchAnimation = Animator.StringToHash("Bastketball@Launch");

        public override void Select()
        {
            if (IsSelected) return;
            IsSelected = true;
            
            animator.Play(_playAnimation);
            focusCamera.Priority = CameraOperator.MaximumPriority;
            
            OnSelectionChanged?.Invoke(IsSelected); // TRUE
        }

        public override void UnSelect()
        {
            IsSelected = false;
            animator.Play(_idleAnimation);
            focusCamera.Priority = CameraOperator.MinimumPriority;
            
            OnSelectionChanged?.Invoke(IsSelected); // FALSE
        }

        private void Update()
        {
            if (!IsSelected) return;
            
            if (Input.GetKeyDown(KeyCode.Space)) LaunchBall();
        }

        public void LaunchBall()
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
                animator.Play(_idleAnimation);
            
            animator.Play(_launchAnimation);
        }

        public void UpPoints()
        {
            _counter++;
            OnScoreChanged?.Invoke(_counter);
        }
    }
}
