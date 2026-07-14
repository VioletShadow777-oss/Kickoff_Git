using UnityEngine;

public class ProjectileLaunchAngleOscilation : MonoBehaviour
{
    [SerializeField] private RectTransform _angleIndicator; // Reference to the UI element that indicates the angle

    [Tooltip("Horizontal angle in degrees for the launch direction. Range: -30 to +30 degrees.")]
    [Range(-30f, 30f)]
    public float horizontalAngle = 0f;

    private float _minValue = -30f;
    private float _maxValue = 30f;
    public float speed = 2f;


  

    private void Update()
    {
        Oscilation();
    }

    private void Oscilation()
    {
        // 1. Calculate the midpoint and amplitude dynamically
        float midpoint = (_maxValue + _minValue) / 2f;
        float amplitude = (_maxValue - _minValue) / 2f;

        // 2. Calculate the sine wave value
        // Time.time keeps the wave progressing, * speed adjusts how fast it oscillates
        float sinValue = Mathf.Sin(Time.time * speed);

        // 3. Map the -1 to 1 sine wave to the custom minSize to maxSize range
        float currentValue = midpoint + (amplitude * sinValue);

        _angleIndicator.localRotation = Quaternion.Euler(0, 0, currentValue); // Rotate the UI element based on the current value

        horizontalAngle = -1 * currentValue; // Update the horizontal angle for the launch direction
    }
}
