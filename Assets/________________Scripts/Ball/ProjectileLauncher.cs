using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    // References
    private Rigidbody _rb;

    [Header("Launch Settings")]
    [SerializeField] private GameObject _launchPosition;
    public float _launchForce = 10f;



    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void LaunchProjectile()
    {

        if (_rb != null && _launchPosition != null)
        {
            Vector3 launchDirection = (Vector3.forward + Vector3.up).normalized;

            _rb.linearVelocity = launchDirection * _launchForce;


        }
    }
}
