using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileLauncher : MonoBehaviour
{
    // References
    private Rigidbody _rb;

    [Header("Launch Settings")]
    [SerializeField] private GameObject _launchPosition;
    [Tooltip("Horizontal angle in degrees for the launch direction. Range: -30 to +30 degrees.")]
    [Range(-30f, 30f)]
    [SerializeField] private float horizontalAngle = 0f;
    public float _launchForce = 10f;



    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
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
            Vector3 forward = Quaternion.Euler(0, horizontalAngle, 0) * transform.forward;
            Vector3 launchDirection = (forward + (Vector3.up * 0.5f)).normalized;

            _rb.linearVelocity = launchDirection * _launchForce;


        }
    }

    public void ResetBall()
    {
        _rb.linearVelocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.identity;
        transform.position = _launchPosition.transform.position;
    }
}
