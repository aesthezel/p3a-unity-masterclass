using Game.Selectables;
using UnityEngine;

public class JackpotEntity : SelectableEntity
{
    [SerializeField] 
    private Animator animator;
    
    private readonly int _idleAnimation = Animator.StringToHash("Jackpot@Idle");
    private readonly int _interactAnimation = Animator.StringToHash("Jackpot@WinCoin");
    
    public override void Select()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            animator.Play(_idleAnimation);
        if(CanInteractable) animator.Play(_interactAnimation);
    }

    public override void UnSelect()
    {
        animator.Play(_idleAnimation);
    }
}
