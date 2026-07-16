using UnityEngine;

public class SkinManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _balls;
 


    public void ChangeMaterial(int ballNumber)
    {
        foreach (GameObject item in _balls)
        {
            item.SetActive(false);
        }

        _balls[ballNumber].SetActive(true);
    }


}
