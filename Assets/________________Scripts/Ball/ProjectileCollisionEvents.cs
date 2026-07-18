using UnityEngine;

public class ProjectileCollisionEvents : MonoBehaviour
{
    // References
    private Rigidbody _rb;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Breakable"))
        {
            CurrencyManager.Instance.AddMoney(100);
            EffectsManager.Instance.ShowAddCurrencyEffect(100);
            SoundManager.instance.PlayCoinSound();
        }
            SoundManager.instance.PlayBounceSound(1);
    }

    // Collision detection to stop steering when the ball is in contact with another object
    private void OnCollisionStay(Collision collision)
    {
        _rb.linearDamping = 1.5f; // Increase linear damping to slow down the ball when in contact
    }

    // Reset the steering force when the ball is no longer in contact with another object
    private void OnCollisionExit(Collision collision)
    {
        _rb.linearDamping = 0f; // Reset linear damping to default value
    }
}
