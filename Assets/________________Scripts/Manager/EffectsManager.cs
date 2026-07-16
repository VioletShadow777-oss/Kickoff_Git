using System.Collections;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    public static EffectsManager Instance { get; private set; }
    // References
    [SerializeField]
    private Animator _animator;

    // Scripts
    [SerializeField]
    private ProjectileCommentary _projectileCommentry;
    [SerializeField]
    private CameraShakeController _cameraShakeController;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    public void PerfectHitEffect()
    {
        if(_projectileCommentry.comment == "PERFECT!")
        {
           StartCoroutine(PerfectHitSlowMotion());

            // Increase the camera shake intensity for a more dramatic effect
            _cameraShakeController.IncreaseShake(0.5f, 8f);

            // Increase the camera Fov
            _cameraShakeController.IncreaseFOV(3f);
        }



    }

    public IEnumerator PerfectHitSlowMotion()
    {
        Time.timeScale = 0.2f;

        yield return new WaitForSecondsRealtime(1f);

        

        Time.timeScale = 1f;
    }
}
