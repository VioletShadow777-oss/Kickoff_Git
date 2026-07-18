using System.Collections.Generic;
using UnityEngine;

public class ScatteredLineSpawner : MonoBehaviour
{
    [Header("Spawn Points")]
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;

    [Header("Objects")]
    [SerializeField] private List<GameObject> prefabs = new();

    [Header("Spawn Settings")]
    [SerializeField] private int objectCount = 30;

    [Tooltip("Maximum distance an object can move left or right from the line.")]
    [SerializeField] private float maxHorizontalOffset = 2f;

    [SerializeField] private bool randomRotation = true;

    [ContextMenu("Spawn Objects")]

    private void Start()
    {
        SpawnObjects();
    }
    public void SpawnObjects()
    {
        if (prefabs.Count == 0)
        {
            Debug.LogWarning("No prefabs assigned.");
            return;
        }

        Vector3 direction = (endPoint.position - startPoint.position).normalized;

        // Perpendicular direction on the XZ plane
        Vector3 perpendicular = Vector3.Cross(Vector3.up, direction);

        for (int i = 0; i < objectCount; i++)
        {
            float t = objectCount == 1 ? 0 : (float)i / (objectCount - 1);

            Vector3 position = Vector3.Lerp(
                startPoint.position,
                endPoint.position,
                t);

            float offset = Random.Range(-maxHorizontalOffset, maxHorizontalOffset);

            position += perpendicular * offset;

            GameObject prefab = prefabs[Random.Range(0, prefabs.Count)];

            GameObject obj = Instantiate(prefab, position, Quaternion.identity, transform);

            if (randomRotation)
            {
                obj.transform.Rotate(0, Random.Range(0f, 360f), 0);
            }
        }
    }
}