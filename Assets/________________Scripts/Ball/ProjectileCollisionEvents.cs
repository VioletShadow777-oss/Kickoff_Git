using UnityEngine;

public class ProjectileCollisionEvents : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Breakable"))
        {
            SoundManager.instance.PlayBounceSound(1);
        }
    }
}
