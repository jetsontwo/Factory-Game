using UnityEngine;
using System.Collections;

public class Map_Position : MonoBehaviour {

    public string object_in_position;

    public void set_object(string object_name)
    {
        object_in_position = object_name;
    }
}
