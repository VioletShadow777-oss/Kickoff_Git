using System.Collections;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    public static EffectsManager Instance { get; private set; }
    // References
    [SerializeField]
    private Animator _animator;
    [Header("Ball Effects")]
    [SerializeField] private ParticleSystem _upgradeAndChange;
    [SerializeField] private ParticleSystem _energyUp;
    [SerializeField] GameObject _commonTrail;
    [SerializeField] GameObject _firetrail;

    // Scripts
    [SerializeField]
    private ProjectileCommentary _projectileCommentry;
    [SerializeField]
    private CameraShakeController _cameraShakeController;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    public void PerfectHitEffect()
    {
        if (_projectileCommentry.comment == "PERFECT!")
        {
            // Play Energy Up Effect
            _energyUp.Play();


            StartCoroutine(PerfectHitSlowMotion());

            // Increase the camera shake intensity for a more dramatic effect
            _cameraShakeController.IncreaseShake(0.5f, 8f);

            // Increase the camera Fov
            _cameraShakeController.IncreaseFOV(3f);

            // Show Fire Trail
            ShowFireTrail();

            // Play dramatic sound
            SoundManager.instance.PlayDramaticSound();
        }

        else
        {
            ShowCommonTrail();
        }
    }

    // Ball Upgrade and change Effect
    public void BallUpgradeAndChangeEffect()
    {
        _upgradeAndChange.Play();
    }

    // Ball trails
    private void ShowCommonTrail()
    {
        _commonTrail.gameObject.SetActive(true);
        _firetrail.gameObject.SetActive(false);
    }

    private void ShowFireTrail()
    {
        _commonTrail.gameObject.SetActive(false);
        _firetrail.gameObject.SetActive(true);
    }
    public IEnumerator PerfectHitSlowMotion()
    {
        Time.timeScale = 0.2f;

        yield return new WaitForSecondsRealtime(1f);



        Time.timeScale = 1f;
    }


}
