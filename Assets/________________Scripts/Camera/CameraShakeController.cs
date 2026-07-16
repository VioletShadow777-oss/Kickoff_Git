using Unity.Cinemachine;
using UnityEngine;

public class CameraShakeController : MonoBehaviour
{
    [SerializeField] private CinemachineBasicMultiChannelPerlin noise;

    [SerializeField] private float changeSpeed = 4f;

    [Header("FOV Settings")]
    [SerializeField] private CinemachineCamera cinemachineCamera;

    [SerializeField] private float fovChangeSpeed = 20f;

    private float defaultVerticalFOV;
    private float targetVerticalFOV;

    private float targetAmplitude = 0f;
    private float targetFrequency = 0f;

    private void Start()
    {
        defaultVerticalFOV = cinemachineCamera.Lens.FieldOfView;
        targetVerticalFOV = defaultVerticalFOV;
    }

    private void Update()
    {
        noise.AmplitudeGain = Mathf.MoveTowards(noise.AmplitudeGain, targetAmplitude, changeSpeed * Time.unscaledDeltaTime);
        noise.FrequencyGain = Mathf.MoveTowards(noise.FrequencyGain, targetFrequency, changeSpeed * Time.unscaledDeltaTime);

        cinemachineCamera.Lens.FieldOfView = Mathf.MoveTowards(cinemachineCamera.Lens.FieldOfView, targetVerticalFOV, fovChangeSpeed * Time.unscaledDeltaTime);
    }

    public void IncreaseShake(float amplitude, float frequency)
    {
        targetAmplitude = amplitude;
        targetFrequency = frequency;

    }

    public void StopShake()
    {
        targetAmplitude = 0f;
        targetFrequency = 0f;
    }

    public void IncreaseFOV(float amount)
    {
        targetVerticalFOV = defaultVerticalFOV + amount;
    }

    public void ResetFOV()
    {
        targetVerticalFOV = defaultVerticalFOV;
    }
}