using UnityEngine;

public class SkinManager : MonoBehaviour
{
    [SerializeField] private MeshRenderer _ballMeshRenderer;
 


    public void ChangeMaterial(Material newMaterial)
    {
        _ballMeshRenderer.material = newMaterial;
    }


}
