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
        mic_Color.SetActive(false);
        windows.SetActive(true);
        main_Screen.SetActive(false);
        home_windows.SetActive(true);
    }
    public void Avartar()
    {
        mic_Color.SetActive(false);
        windows.SetActive(true);
        main_Screen.SetActive(false);
        avartar_windows.SetActive(true);
    }
    public void Show()
    {
        mic_Color.SetActive(false);
        windows.SetActive(true);
        main_Screen.SetActive(false);
        show_windows.SetActive(true);
    }
    public void EventRoom()
    {
        mic_Color.SetActive(false);
        windows.SetActive(true);
        main_Screen.SetActive(false);
        eventRoom_windows.SetActive(true);
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
            avartar_window_num += 1;
        }
        else if(avartar_window_num == 1)
        {
            avartar_title.GetComponent<Image>().sprite = title[2];
            avartar_window_num += 1;
        }
        else
        {

        }
        
        //다음 장면으로 넘어가기
    }
    public void Avartar_Select()
    {
        if(Pop_Window.activeSelf)
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
                avartar_window_num = 0;
                avartar_title.GetComponent<Image>().sprite = title[0];
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
                mic_Color.SetActive(true);
                main_Screen.SetActive(true);
                canvas.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 0.2f, player.transform.position.z) + player.transform.forward * 1.5f;
                canvas.transform.LookAt(player.transform, Vector3.up);

            }
        }
    }
}
