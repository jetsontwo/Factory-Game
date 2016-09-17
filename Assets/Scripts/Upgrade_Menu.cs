using UnityEngine;
using System.Collections;

public class Upgrade_Menu : MonoBehaviour {

    private float middle_width ,middle_height;
    private int cur_bgp_index = 0;
    private int[] better_goods_price = new int[8];
    public Drop_Off do1;
    public Box_Spawn bs;
    private int money;
    public int color_mod;

    void Start()
    {
        middle_width = Screen.width/2;
        middle_height = Screen.height/2;
        better_goods_price[0] = 10 * color_mod;
        better_goods_price[1] = 50 * color_mod;
        better_goods_price[2] = 750 * color_mod;
        better_goods_price[3] = 5000 * color_mod;
        better_goods_price[4] = 75000 * color_mod;
        better_goods_price[5] = 500000 * color_mod;
        better_goods_price[6] = 10000000 * color_mod;
        better_goods_price[7] = 500000000 * color_mod;

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
            if (bs.boxes_per_second < 20)
            {
                print(bs.boxes_per_second + 1);
                bs.boxes_per_second += 1;
            }
        }
    }
}
