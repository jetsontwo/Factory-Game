﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Upgrade_Menu : MonoBehaviour {

    private float middle_width ,middle_height;
    private int cur_bgp_index = 0;
    private int[] better_goods_price = new int[8];
    public Drop_Off do1;
    public Box_Spawn bs;
    private int money, drop1_mult_count;
    public float color_mod;
    public Text drop1_mult;

    void Start()
    {
        middle_width = Screen.width/2;
        middle_height = Screen.height/2;
        better_goods_price[0] = (int)(10 * color_mod);
        better_goods_price[1] = (int)(50 * color_mod);
        better_goods_price[2] = (int)(750 * color_mod);
        better_goods_price[3] = (int)(5000 * color_mod);
        better_goods_price[4] = (int)(75000 * color_mod);
        better_goods_price[5] = (int)(500000 * color_mod);
        better_goods_price[6] = (int)(10000000 * color_mod);
        better_goods_price[7] = (int)(500000000 * color_mod);
        drop1_mult_count = 0;
        drop1_mult.text = "x" + drop1_mult_count;
    }
	void OnGUI()
    {
        money = PlayerPrefs.GetInt("money");   
        if(GUI.Button(new Rect(middle_width-300, middle_height, 200, 50), "Better Goods: $" + better_goods_price[cur_bgp_index]) && cur_bgp_index < better_goods_price.Length && better_goods_price[cur_bgp_index] < money)
        {
            do1.price_per_box += 1;
            PlayerPrefs.SetInt("money", money - better_goods_price[cur_bgp_index]);
            cur_bgp_index++;
        }
        if (GUI.Button(new Rect(middle_width+100, middle_height, 200, 50), "Auto Drop: $100"))
        {
            if (bs.boxes_per_second < 10)
            {
                print(bs.boxes_per_second + 1);
                bs.boxes_per_second += 1;
                drop1_mult_count++;
                drop1_mult.text = "x" + drop1_mult_count;
            }
        }
    }
}
