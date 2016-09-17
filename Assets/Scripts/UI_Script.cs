using UnityEngine;
using System.Collections;

public class UI_Script : MonoBehaviour {
    public Upgrade_Menu um;
    private GameObject created_conveyor;
    private float x, y;

    public void Open_Window()
    {
        um.enabled = !um.enabled;
    }

    public void Create_Conveyor(GameObject conveyor_prefab)
    {
        created_conveyor = (GameObject) Instantiate(conveyor_prefab);

    }

    void Update()
    {
        if (created_conveyor != null)
        {
            Vector3 mouselocation = Camera.current.ScreenToWorldPoint(Input.mousePosition);
            created_conveyor.transform.position = new Vector3(mouselocation.x,mouselocation.y,0);
        }
    }
}
