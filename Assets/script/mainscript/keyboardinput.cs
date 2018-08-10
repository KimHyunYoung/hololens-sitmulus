using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class keyboardinput : MonoBehaviour {
    int counter = 0;
    int selectmenu = 1;
    int BlinkTime_Load = 200;
    int Wide_Load = 10;
    int RPT_Load = 10;
    int RPTO_Load = 40;
    public Renderer[] times;
    public Renderer[] size;
    public Renderer[] rp_p_tr;
    public Renderer[] rp_t;
    public Renderer[] buttons;
    public Renderer[] selectmenubutton;
    public Renderer[] ar_or_light;
    public Renderer[] blink_or_spin;
    public Material[] buttonmaterial;
    public Material[] buttonmaterial_reverse;
    public int[] time;
    public int[] size1;
    public int[] repeat_test;
    public int[] repeat_total;
    int inputnext = 0;
    int light_ar = 1;
    // Use this for initialization
    void Start()
    {
        BlinkTime_Load = (int)(StaticClass.blinktime * 1000);
        time[0] = BlinkTime_Load / 100;
        time[1] = (BlinkTime_Load / 10) - time[0] * 10;
        time[2] = BlinkTime_Load - time[0]*100 - time[1] * 10;
        Wide_Load = (int)(StaticClass.wide * 10);
        size1[0] = Wide_Load / 10;
        size1[1] = Wide_Load - size1[0] * 10;
        RPT_Load = StaticClass.repeat_test;
       // Debug.Log(RPT_Load);
        repeat_test[0] = RPT_Load / 10;
        repeat_test[1] = RPT_Load - repeat_test[0] * 10;
        RPTO_Load = StaticClass.repeat_total;
        repeat_total[0] = RPTO_Load / 10;
        repeat_total[1] = RPTO_Load - repeat_total[0] * 10  ;
        represent();
    }
	// Update is called once per frame
	void Update () {
        counter++;
        if(counter > 50)
        {
            Totalcolorreset();
        }
	}
    void calculate()
    {
        switch (selectmenu)
        {
            case 1:
                time[0] = time[1];
                time[1] = time[2];
                time[2] = inputnext;
                StaticClass.blinktime = (float)time[0] * 0.1F + (float)time[1] * 0.01F + (float)time[2] * 0.001F;
                if (StaticClass.blinktime < 0.1F) StaticClass.blinktime = 0.1F;
                break;
            case 2:
                size1[0] = size1[1];
                size1[1] = inputnext;
                StaticClass.wide = (float)size1[0] + (float)size1[1] * 0.1F;
                break;
            case 3:
                repeat_test[0] = repeat_test[1];
                repeat_test[1] = inputnext;
                StaticClass.repeat_test = repeat_test[0] * 10 + repeat_test[1];
                break;
            case 4:
                repeat_total[0] = repeat_total[1];
                repeat_total[1] = inputnext;
                StaticClass.repeat_total = repeat_total[0] * 10 + repeat_total[1];
                break;
        }
        represent();
    }
    void represent()
    {
        for(int i = 0; i < 3; i++)
        {
            times[i].sharedMaterial = buttonmaterial[time[i]];
          
        }
        for(int i = 0; i < 2; i++)
        {
            size[i].sharedMaterial = buttonmaterial[size1[i]];
            rp_p_tr[i].sharedMaterial = buttonmaterial[repeat_test[i]];
            rp_t[i].sharedMaterial = buttonmaterial[repeat_total[i]];
        }
            
    }
    void Onepush()
    {
        Totalcolorreset();
        buttons[1].sharedMaterial = buttonmaterial_reverse[1];
        inputnext = 1;
        counter = 0;
        calculate();
    }
    void Twopush()
    {
        Totalcolorreset();
        buttons[2].sharedMaterial = buttonmaterial_reverse[2];
        inputnext = 2;
        counter = 0;
        calculate();
    }
    void Threepush()
    {
        Totalcolorreset();
        buttons[3].sharedMaterial = buttonmaterial_reverse[3];
        inputnext = 3;
        counter = 0;
        calculate();
    }
    void Fourpush()
    {
        Totalcolorreset();
        buttons[4].sharedMaterial = buttonmaterial_reverse[4];
        inputnext = 4;
        counter = 0;
        calculate();
    }
    void Fivepush()
    {
        Totalcolorreset();
        buttons[5].sharedMaterial = buttonmaterial_reverse[5];
        inputnext = 5;
        counter = 0;
        calculate();
    }
    void Sixpush()
    {
        Totalcolorreset();
        buttons[6].sharedMaterial = buttonmaterial_reverse[6];
        inputnext = 6;
        counter = 0;
        calculate();
    }
    void Sevenpush()
    {
        Totalcolorreset();
        buttons[7].sharedMaterial = buttonmaterial_reverse[7];
        inputnext = 7;
        counter = 0;
        calculate();
    }
    void Eightpush()
    {
        Totalcolorreset();
        buttons[8].sharedMaterial = buttonmaterial_reverse[8];
        inputnext = 8;
        counter = 0;
        calculate();
    }
    void Ninepush()
    {
        Totalcolorreset();
        buttons[9].sharedMaterial = buttonmaterial_reverse[9];
        inputnext = 9;
        counter = 0;
        calculate();
    }
    void Zeropush()
    {
        Totalcolorreset();
        buttons[0].sharedMaterial = buttonmaterial_reverse[0];
        inputnext = 0;
        counter = 0;
        calculate();
    }
    void Dotpush()
    {
        Totalcolorreset();
        buttons[10].sharedMaterial = buttonmaterial_reverse[10];
        inputnext = -2;
        counter = 0;
    }
    void Backspacepush()
    {
        Totalcolorreset();
        buttons[11].sharedMaterial = buttonmaterial_reverse[11];
        inputnext = -1;
        counter = 0;
    }
    void Totalcolorreset()
    {
        for(int i = 0; i < 12; i++)
        {
            buttons[i].sharedMaterial = buttonmaterial[i];
        }
    }
    void Next()
    {
        if(StaticClass.repeat_per_trial == 0)
        {
            StaticClass.repeat_per_trial = 1;
        }
        if(StaticClass.repeat_total == 0)
        {
            StaticClass.repeat_total = 1;
        }
        switch (light_ar)
        {
            case 1:
                SceneManager.LoadScene("colorstimuls");
                break;
            case 2:
                SceneManager.LoadScene("hexagon");
                break;
        }
    }
    void Time()
    {
        selectmenu = 1;
        selectmenubutton[0].sharedMaterial = buttonmaterial_reverse[12];
        selectmenubutton[1].sharedMaterial = buttonmaterial[12];
        selectmenubutton[2].sharedMaterial = buttonmaterial[12];
        selectmenubutton[3].sharedMaterial = buttonmaterial[12];
    }
    void Size()
    {
        selectmenu = 2;
        selectmenubutton[0].sharedMaterial = buttonmaterial[12];
        selectmenubutton[1].sharedMaterial = buttonmaterial_reverse[12];
        selectmenubutton[2].sharedMaterial = buttonmaterial[12];
        selectmenubutton[3].sharedMaterial = buttonmaterial[12];
    }
    void Per_trial()
    {
        selectmenu = 3;
        selectmenubutton[0].sharedMaterial = buttonmaterial[12];
        selectmenubutton[1].sharedMaterial = buttonmaterial[12];
        selectmenubutton[2].sharedMaterial = buttonmaterial_reverse[12];
        selectmenubutton[3].sharedMaterial = buttonmaterial[12];
    }
    void Rp_total()
    {
        selectmenu = 4;
        selectmenubutton[0].sharedMaterial = buttonmaterial[12];
        selectmenubutton[1].sharedMaterial = buttonmaterial[12];
        selectmenubutton[2].sharedMaterial = buttonmaterial[12];
        selectmenubutton[3].sharedMaterial = buttonmaterial_reverse[12];
    }
    void Setblink()
    {
        StaticClass.type = 1;
        blink_or_spin[0].sharedMaterial = buttonmaterial_reverse[12];
        blink_or_spin[1].sharedMaterial = buttonmaterial[12];
        Debug.Log("blink");
    }
    void Setspin()
    {
        StaticClass.type = 2;
        blink_or_spin[0].sharedMaterial = buttonmaterial[12];
        blink_or_spin[1].sharedMaterial = buttonmaterial_reverse[12];
        Debug.Log("spin");
    }
    void Setlight()
    {
        light_ar = 1;
        ar_or_light[0].sharedMaterial = buttonmaterial_reverse[12];
        ar_or_light[1].sharedMaterial = buttonmaterial[12];
    }
    void Setar()
    {
        light_ar = 2;
        ar_or_light[0].sharedMaterial = buttonmaterial[12];
        ar_or_light[1].sharedMaterial = buttonmaterial_reverse[12];
    }
}
