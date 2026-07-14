using UnityEngine;

public class ProjectileDistance : MonoBehaviour
{
    
    [SerializeField]
    private Transform _launchPosition; // Reference to the launch position of the projectile

    [HideInInspector] public float _distance;


    private void Update()
    {
        CalculateDistance();
    }

    private void CalculateDistance()
    {
        if (_launchPosition != null)
        {
            _distance = Vector3.Distance(_launchPosition.position, transform.position);
            UIManager.Instance.ShowDistanceText(_distance);
        }
    }
}
