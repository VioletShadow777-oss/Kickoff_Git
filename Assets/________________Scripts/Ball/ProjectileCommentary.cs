using TMPro;
using UnityEngine;

public class ProjectileCommentary : MonoBehaviour
{
    // References
    private ProjectileLaunchAngleOscilation angleOscillation;

    [Header("UI settings")]
    [SerializeField] private GameObject commentaryPanel;
    [SerializeField] private TMP_Text commentaryText;

    [Header("Display Settings")]
    [SerializeField] private float displayTime = 1.5f;

    private void Start()
    {
        angleOscillation = GetComponent<ProjectileLaunchAngleOscilation>();
    }

    /// <summary>
    /// Call this immediately after the player kicks the ball.
    /// </summary>
    public void ShowKickComment()
    {
        float angle = Mathf.Abs(angleOscillation.horizontalAngle);

        string comment;

        if (angle <= 5f)
            comment = "PERFECT!";
        else if (angle <= 10f)
            comment = "GREAT!";
        else if (angle <= 15f)
            comment = "GOOD!";
        else if (angle <= 20f)
            comment = "NICE!";
        else if (angle <= 25f)
            comment = "OKAY!";
        else
            comment = "OOPS!";

        commentaryText.text = comment;

        commentaryPanel.SetActive(true);

        CancelInvoke(nameof(HideComment));
        Invoke(nameof(HideComment), displayTime);
    }

    private void HideComment()
    {
        commentaryPanel.SetActive(false);
    }
}