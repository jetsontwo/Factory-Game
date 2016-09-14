using UnityEngine;
using System.Collections;

public class Box_Spawn : MonoBehaviour {

    public GameObject box;

    public void Send_Box()
    {
        Instantiate(box, transform);
    }
}
