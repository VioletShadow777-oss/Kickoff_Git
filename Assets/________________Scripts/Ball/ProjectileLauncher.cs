using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileLauncher : MonoBehaviour
{
    // References
    private Rigidbody _rb;
    private ProjectileLaunchAngleOscilation projectileLaunchAngleOscilation;
    private BallStopDetector _ballStopDetector;
    private ProjectileCommentary _projectileCommentary;

    [Header("Launch Settings")]
    [SerializeField] private GameObject _launchPosition;
    



    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        projectileLaunchAngleOscilation = GetComponent<ProjectileLaunchAngleOscilation>();
        _ballStopDetector = GetComponent<BallStopDetector>();
        _projectileCommentary = GetComponent<ProjectileCommentary>();
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
        float launchForce = UpgradeManager.Instance.CurrentKickForce;

        if (_rb != null && _launchPosition != null)
        {
            Vector3 forward = Quaternion.Euler(0, projectileLaunchAngleOscilation.horizontalAngle, 0) * transform.forward;
            Vector3 launchDirection = (forward + (Vector3.up * 0.5f)).normalized;

            _rb.linearVelocity = launchDirection * launchForce;


        }

        // Disable the launch angle oscillation after launching the projectile
        projectileLaunchAngleOscilation.enabled = false;

        // Start detecting when the ball stops moving
        _ballStopDetector.StartDetection();

        // Show commentary for the kick
        _projectileCommentary.ShowKickComment();

        // Hide the oscillation UI since the projectile has been launched
        UIManager.Instance.HideOscilationUI();

        // Hide the UI elements that should not be visible while the projectile is in motion
        UIManager.Instance.HideUIWhileProjectileInMotion();

        Debug.Log("Launchforce: " + launchForce);
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

        // Reset the ball stop detector for the next launch
        _ballStopDetector.ResetDetection();

        // hide the reset UI after resetting the ball
        UIManager.Instance.HideResetUI();
    }
}
