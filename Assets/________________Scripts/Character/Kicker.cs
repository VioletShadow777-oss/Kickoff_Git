using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Kicker : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private ProjectileLaunchAngleOscilation projectileLaunchAngleOscilation;
    [SerializeField]
    private ProjectileCommentary _projectileCommentary;


    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Start Kick Animation
    public void StartKickAnimation(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if (_animator != null)
            {
                // Show commentary for the kick
                _projectileCommentary.ShowKickComment();

                // Show Perfect Hit Effect
                EffectsManager.Instance.PerfectHitEffect();

                _animator.SetBool("kick_b", true);

                // Disable the launch angle oscillation after launching the projectile
                projectileLaunchAngleOscilation.enabled = false;

                // Hide the oscillation UI since the projectile has been launched
                UIManager.Instance.HideOscilationUI();

                

                // Hide the UI elements that should not be visible while the projectile is in motion
                UIManager.Instance.HideUIWhileProjectileInMotion();


            }
            else
            {
                Debug.LogWarning("Animator component is not assigned.");
            }

            
        }
        
    }
}
