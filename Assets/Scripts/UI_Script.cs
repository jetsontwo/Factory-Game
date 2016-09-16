using UnityEngine;
using System.Collections;

public class UI_Script : MonoBehaviour {
    public Upgrade_Menu um;

    public void Open_Window()
    {
        um.enabled = true;
    }
}
