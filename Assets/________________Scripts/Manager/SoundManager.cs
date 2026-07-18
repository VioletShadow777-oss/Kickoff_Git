using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance {  get; private set; }

    [SerializeField] private AudioSource _audioSource;
    [Space]
    [Header("UI Sounds")]
    [SerializeField] private AudioClip _commonUIClick;
    [SerializeField] private AudioClip _playClick;
    [SerializeField] private AudioClip _upgradeClick;
    [Space]
    [Header("Ball Sounds")]
    [SerializeField] private AudioClip _kickSound;
    [SerializeField] private AudioClip _bounceSound;
    [SerializeField] private AudioClip _dramaticSound;
    [SerializeField] private AudioClip _cannotUpgradeSound;
    [Space]
    [Header("Coin Sounds")]
    [SerializeField] private AudioClip _coinSound;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    #region UI Sounds Methods
    public void PlayCommonUISound()
    {
        _audioSource?.PlayOneShot(_commonUIClick);
    }
    public void PlayPlaySound()
    {
        _audioSource?.PlayOneShot(_playClick);
    }
    public void PlayUpgradeSound()
    {
        _audioSource?.PlayOneShot(_upgradeClick);
    }
    #endregion

    #region Ball Sound
    public void PlayPerfectKickSound(float newVolume)
    {
        _audioSource.volume = newVolume;
        _audioSource?.PlayOneShot(_kickSound);

    }

    public void PlayKickSound(float newVolume)
    {
        _audioSource.volume = newVolume;
        _audioSource?.PlayOneShot(_kickSound);
        
    }

    public void PlayBounceSound(float newVolume)
    {
        _audioSource.volume = newVolume;
        _audioSource?.PlayOneShot(_bounceSound);
    }

    public void PlayDramaticSound()
    {
        _audioSource.volume = 0.7f;
        _audioSource.clip = _dramaticSound;
        _audioSource.PlayDelayed(0.5f);
    }
    public void CannotUpgradeSound()
    {
        _audioSource.PlayOneShot(_cannotUpgradeSound);
    }
    #endregion

    #region Coin Sound Method
    public void PlayCoinSound()
    {
        _audioSource.PlayOneShot(_coinSound);
    }
    #endregion


}
