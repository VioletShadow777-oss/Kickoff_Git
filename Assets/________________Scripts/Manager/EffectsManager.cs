using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EffectsManager : MonoBehaviour
{
    public static EffectsManager Instance { get; private set; }
    // References
    [SerializeField]
    public Transform _ballTransform;
    private Animator _animator;
    [Header("Ball Effects")]
    [SerializeField] private ParticleSystem _upgradeAndChange;
    [SerializeField] private float _upgradeAndChangeYOffset;
    [SerializeField] private ParticleSystem _energyUp;
    [SerializeField] GameObject _commonTrail;
    [SerializeField] GameObject _firetrail;


    [Header("Add Currency Effect")]
    [SerializeField] private Animator _addAnimator;
    [SerializeField] private TMP_Text _addCurrencyText;

    [Space]
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
            _cameraShakeController.IncreaseFOV(5f);

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
        _upgradeAndChange.transform.position = new Vector3(_ballTransform.position.x,
                                                            _ballTransform.position.y + _upgradeAndChangeYOffset,
                                                            _ballTransform.position.z);
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




    public void ShowAddCurrencyEffect(int amount)
    {
        _addCurrencyText.text = "+" + amount.ToString();
        _addAnimator?.SetTrigger("add_t");
    }

}
