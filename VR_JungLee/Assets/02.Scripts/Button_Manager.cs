using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Oculus.Platform;
using Oculus.Platform.Models;
public class Button_Manager : MonoBehaviour
{
    public GameObject mic_Color;
    public Text current_time_KR;
    public GameObject main_Screen;
    public GameObject canvas;
    public GameObject windows;
    public GameObject home_windows;
    public GameObject avartar_windows;
    public GameObject show_windows;
    public GameObject eventRoom_windows;
    public GameObject player;
    public GameObject Pop_Window;
    public GameObject avartar_title;
    public Sprite[] title = new Sprite[3];
    public int avartar_window_num = 0;
    public Text sex_Trans_Button_text;
    public void Mic()
    {
        if(mic_Color.GetComponent<Image>().color.a == 1)
        {
            mic_Color.GetComponent<Image>().color = new Color(1,1,1,0.5f);
        }
        else
        {
            mic_Color.GetComponent<Image>().color = new Color(1,1,1,1);
        }

    }
    public void Home()
    {
        main_Screen.SetActive(false);
        windows.SetActive(true);
        home_windows.SetActive(true);

    }
    public void Avartar()
    {
        main_Screen.SetActive(false);
        windows.SetActive(true);
        avartar_windows.SetActive(true);
    }
    public void Show()
    {
        main_Screen.SetActive(false);
        windows.SetActive(true);
        show_windows.SetActive(true);
    }
    public void EventRoom()
    {
        main_Screen.SetActive(false);
        windows.SetActive(true);
        eventRoom_windows.SetActive(true);
    }
    public void Female()
    {
        sex_Trans_Button_text.text = "여자";
    }
    public void Male()
    {
        sex_Trans_Button_text.text = "남자";
    }
    public void Current_Time()
    {
        
        if(DateTime.Now.Hour > 11)
        {
            current_time_KR.text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + " PM";
        }
        else
        {
            current_time_KR.text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + " AM"; ;
        }
    }
    public void Pop_Yes()
    {
        if(avartar_window_num == 0)
        {
            avartar_title.GetComponent<Image>().sprite = title[1];
            avartar_windows.transform.GetChild(avartar_window_num).gameObject.SetActive(false);
            avartar_window_num += 1;
            avartar_windows.transform.GetChild(avartar_window_num).gameObject.SetActive(true);
        }
        else if(avartar_window_num == 1)
        {
            avartar_title.GetComponent<Image>().sprite = title[2];
            avartar_windows.transform.GetChild(avartar_window_num).gameObject.SetActive(false);
            avartar_window_num += 1;
            avartar_windows.transform.GetChild(avartar_window_num).gameObject.SetActive(true);
        }
        else
        {
            avartar_title.GetComponent<Image>().sprite = title[0];
            avartar_windows.transform.GetChild(avartar_window_num).gameObject.SetActive(false);
            avartar_window_num = 0;
            avartar_windows.transform.GetChild(avartar_window_num).gameObject.SetActive(true);
            avartar_windows.SetActive(false);
            main_Screen.SetActive(true);
        }

        if (Pop_Window.activeSelf)
            Pop_Window.SetActive(false);

    }
    public void Avartar_Select()
    {
        if(!Pop_Window.activeSelf)
            Pop_Window.SetActive(true);
    }
    public void Pop_No()
    {
        Pop_Window.SetActive(false);
    }
    private void Update()
    {
        Current_Time();


        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            if (canvas.activeSelf)
            {
                avartar_windows.transform.GetChild(avartar_window_num).gameObject.SetActive(false);
                avartar_window_num = 0;
                avartar_title.GetComponent<Image>().sprite = title[0];
                avartar_windows.transform.GetChild(avartar_window_num).gameObject.SetActive(true);
                canvas.SetActive(false);
                for (int i = 0; i < windows.transform.childCount; i++)
                {
                    if(windows.transform.GetChild(i).gameObject.activeSelf)
                        windows.transform.GetChild(i).gameObject.SetActive(false);
                }
                if (windows.activeSelf)
                    windows.SetActive(false);
            }
            else
            {
                canvas.SetActive(true);
                main_Screen.SetActive(true);
                canvas.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 0.2f, player.transform.position.z) + player.transform.forward * 1.5f;
                canvas.transform.LookAt(player.transform, Vector3.up);

            }
        }
    }
}
