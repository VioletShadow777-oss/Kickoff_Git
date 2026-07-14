using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileLauncher : MonoBehaviour
{
    // References
    private Rigidbody _rb;
    private ProjectileLaunchAngleOscilation projectileLaunchAngleOscilation;

    [Header("Launch Settings")]
    [SerializeField] private GameObject _launchPosition;
    
    public float _launchForce = 10f;



    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        projectileLaunchAngleOscilation = GetComponent<ProjectileLaunchAngleOscilation>();
    }

    public void LaunchInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            LaunchProjectile(); // Later this method will replaced with a 3d models kicking animation event that will trigger the launch of the projectile
        }
    }

    public void LaunchProjectile()
    {
        
        if (_rb != null && _launchPosition != null)
        {
            Vector3 forward = Quaternion.Euler(0, projectileLaunchAngleOscilation.horizontalAngle, 0) * transform.forward;
            Vector3 launchDirection = (forward + (Vector3.up * 0.5f)).normalized;

            _rb.linearVelocity = launchDirection * _launchForce;


        }

        projectileLaunchAngleOscilation.enabled = false;
        UIManager.Instance.HideOscilationUI();
    }

    public void ResetBall()
    {
        _rb.linearVelocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.position = _launchPosition.transform.position;

        // Re-enable the launch angle oscillation for the next launch
        projectileLaunchAngleOscilation.enabled = true;

        // Show the oscillation UI again for the next launch
        UIManager.Instance.ShowOscilationUI();
    }
}
