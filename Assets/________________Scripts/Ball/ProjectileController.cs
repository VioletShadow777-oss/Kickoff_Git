using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileController : MonoBehaviour
{
    // References
    private Rigidbody _rb;

    [SerializeField] private float _steerForce = 1f;

    private float _steerInput;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        SteerBall();
    }

    private void SteerBall()
    {
        _rb.AddForce(Vector3.right * _steerInput * _steerForce, ForceMode.Force);
    }
    

    public void SetSteerInput(InputAction.CallbackContext context)
    {
        _steerInput = context.ReadValue<float>();
    }

    // Collision detection to stop steering when the ball is in contact with another object
    private void OnCollisionStay(Collision collision)
    {
        _steerForce = 0f;
        _rb.linearDamping = 1f; // Increase linear damping to slow down the ball when in contact
    }

    // Reset the steering force when the ball is no longer in contact with another object
    private void OnCollisionExit(Collision collision)
    {
        _steerForce = 1f;
        _rb.linearDamping = 0f; // Reset linear damping to default value
    }
}
