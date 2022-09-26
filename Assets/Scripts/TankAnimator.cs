using UnityEngine;

public class TankAnimator : MonoBehaviour
{
    SpriteAnimator animator;

    void Start()
    {
        animator = GetComponent<SpriteAnimator>();
    }

    public void SwitchAnimation(bool on)
    {
        if (animator.isAnimating != on)
        {
            if (animator.isAnimating) animator.StopAnimation(); 
            else animator.PlayDefaultAnimation();
        }
    }
}
