using UnityEngine;
using System.Collections;

public class Box_Spawn : MonoBehaviour {

    public GameObject box;

    void Start()
    {
        PlayerPrefs.SetInt("money", 0);
    }
    public void Send_Box()
    {
        Instantiate(box, transform);
    }
}
