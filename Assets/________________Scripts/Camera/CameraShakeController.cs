using Unity.Cinemachine;
using UnityEngine;

public class CameraShakeController : MonoBehaviour
{
    [SerializeField] private CinemachineBasicMultiChannelPerlin noise;

    [SerializeField] private float changeSpeed = 4f;

    private float targetAmplitude = 0f;
    private float targetFrequency = 0f;
    

    private void Update()
    {
        noise.AmplitudeGain = Mathf.MoveTowards(noise.AmplitudeGain, targetAmplitude, changeSpeed * Time.unscaledDeltaTime);
        noise.FrequencyGain = Mathf.MoveTowards(noise.FrequencyGain, targetFrequency, changeSpeed * Time.unscaledDeltaTime);
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
}