using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallStopDetector : MonoBehaviour
{
    private Rigidbody rb;
    private ProjectileDistance _projectileDistance;

    [Header("Detection Settings")]
    [Tooltip("Velocity below this value is considered stopped.")]
    [SerializeField] private float stopVelocityThreshold = 0.2f;

    [Tooltip("How long the ball must remain slow before it's considered stopped.")]
    [SerializeField] private float stopTime = 1f;

    private float stopTimer = 0f;
    private bool hasLaunched = false;
    private bool hasStopped = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _projectileDistance = GetComponent<ProjectileDistance>();
    }

    private void Update()
    {
        // Don't check before the ball has been launched
        if (!hasLaunched || hasStopped)
            return;

        // Check if the ball is moving slowly
        if (rb.linearVelocity.magnitude <= stopVelocityThreshold)
        {
            stopTimer += Time.deltaTime;

            if (stopTimer >= stopTime)
            {
                hasStopped = true;
                Debug.Log("Ball has stopped.");

                // Show reset UI
                UIManager.Instance.ShowResetUI();

                // Reward the player with money for stopping the ball
                CurrencyManager.Instance.AddMoney(Mathf.RoundToInt(_projectileDistance._distance));
            }
        }
        else
        {
            // Ball moved again, reset the timer
            stopTimer = 0f;
        }
    }

    /// <summary>
    /// Call this when the ball is launched.
    /// </summary>
    public void StartDetection()
    {
        hasLaunched = true;
        hasStopped = false;
        stopTimer = 0f;
    }

    /// <summary>
    /// Call this when resetting the ball.
    /// </summary>
    public void ResetDetection()
    {
        hasLaunched = false;
        hasStopped = false;
        stopTimer = 0f;
    }
}