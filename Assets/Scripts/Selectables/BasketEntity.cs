using Cinemachine;
using Game.Operators;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Selectables
{
    public class BasketEntity : SelectableEntity
    {
        [SerializeField] 
        private Canvas canvas;
        [SerializeField] 
        private CinemachineVirtualCamera focusCamera;
        
        [SerializeField] 
        private Animator animator;
        [SerializeField] 
        private TMP_Text counterText;
        [SerializeField] 
        private Button playButton;

        private int _counter;
    
        private readonly int _idleAnimation = Animator.StringToHash("Bastketball@Idle");
        private readonly int _playAnimation = Animator.StringToHash("Bastketball@Play");
        private readonly int _launchAnimation = Animator.StringToHash("Bastketball@Launch");

        private void Start()
        {
            canvas.worldCamera = Camera.main;
            canvas.enabled = IsSelected;
            counterText.text = _counter.ToString();
            playButton.onClick.AddListener(LaunchBall);
        }

        public override void Select()
        {
            if (IsSelected) return;
            IsSelected = true;
            canvas.enabled = true;
            animator.Play(_playAnimation);
            focusCamera.Priority = CameraOperator.MaximumPriority;
        }

        public override void UnSelect()
        {
            IsSelected = false;
            canvas.enabled = false;
            animator.Play(_idleAnimation);
            focusCamera.Priority = CameraOperator.MinimumPriority;
        }

        private void LaunchBall()
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
                animator.Play(_idleAnimation);
            
            animator.Play(_launchAnimation);
        }

        public void UpPoints()
        {
            _counter++;
            counterText.text = _counter.ToString();
        }

        private void OnDestroy()
        {
            playButton.onClick.RemoveAllListeners();
        }
    }
}
