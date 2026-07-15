using UnityEngine;

public class KickerAnimaitonEvents : MonoBehaviour
{
    // references
    public ProjectileLauncher _projectileLauncher;
    


    [SerializeField]
    private Animator _animator;


    #region Animation Events
    public void KickBall()
    {
        _projectileLauncher.LaunchProjectile();

        
    }

    public void ResetKickAnimation()
    {
        if (_animator != null)
        {
            _animator.SetBool("kick_b", false);
        }
        else
        {
            Debug.LogWarning("Animator component is not assigned.");
        }
    }

    public void ResetCharacterPosition()
    {
        transform.position = new Vector3(17.1499996f, -3.23764992f, -36.3199997f);
    }

    
    #endregion
}
