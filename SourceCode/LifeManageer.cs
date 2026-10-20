using System.Collections.Generic;
using UnityEngine;

public class LifeManageer : MonoBehaviour
{
    public static LifeManageer instance;
    [SerializeField] List<GameObject> _lifes = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }
    
    public void OffLife(int life)
    {
        _lifes[life].SetActive(false);
        //Destroy(_lifes[life]);
    }

    public void OnLife(int life)
    {
        _lifes[life].SetActive(true);
    }
}
