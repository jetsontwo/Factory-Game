using UnityEngine;
using System.Collections;

public class Upgrade_Menu : MonoBehaviour {

    private float middle_width ,middle_height;
    private int cur_bgp_index = 0;
    private int[] better_goods_price = new int[10];
    public Drop_Off do1;
    public Box_Spawn bs;

    void Start()
    {
        middle_width = Screen.width/2;
        middle_height = Screen.height/2;
        better_goods_price[0] = 10;
        better_goods_price[1] = 25;
        better_goods_price[2] = 100;
        better_goods_price[3] = 5000;
        better_goods_price[4] = 100000;
    }
	void OnGUI()
    {
        if(GUI.Button(new Rect(middle_width-100, middle_height, 100, 50), "Better Goods: $" + better_goods_price[cur_bgp_index]))
        {
            do1.price_per_box += 1;
            cur_bgp_index++;
        }
        if (GUI.Button(new Rect(middle_width+100, middle_height, 100, 50), "Auto Drop: $100"))
        {
            if (bs.boxes_per_second < 20)
            {
                bs.boxes_per_second += 1;
            }
        }
    }
}
