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

    [HideInInspector] public string comment;

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

        

        if (angle <= 5f)
        {
            comment = "PERFECT!";
            commentaryText.color = Color.green;
        }
        else if (angle <= 10f)
        {
            comment = "GREAT!";
            commentaryText.color = Color.cyan;
        }
        else if (angle <= 15f)
        {
            comment = "GOOD!";
            commentaryText.color = Color.yellow;
        }
        else if (angle <= 20f)
        {
            comment = "NICE!";
            commentaryText.color = new Color32(255, 165, 0, 255); // Orange
        }
        else if (angle <= 25f)
        {
            comment = "OKAY!";
            commentaryText.color = Color.white;
        }
        else
        {
            comment = "OOPS!";
            commentaryText.color = Color.red;
        }

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