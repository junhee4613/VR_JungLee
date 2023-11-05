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
    public Sprite[] custom_Avartar = new Sprite[9];
    public Sprite[] custom_bodys = new Sprite[4];
    public Sprite[] custom_faces = new Sprite[10];
    public Sprite[] custom_cloths = new Sprite[13];
    public Image[] sex_avartar_Change = new Image[4];
    public Image player_avartar;
    [Header("나중에 이걸로 UI 높이 조절하면 됨 0이 기본세팅")]
    public float ui_height = 0;
    #region 메인UI버튼들
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
    #endregion
    public void Female()
    {
        sex_avartar_Change[0].sprite = custom_bodys[2];
        sex_avartar_Change[1].sprite = custom_bodys[3];
        sex_avartar_Change[2].sprite = custom_bodys[1];
        sex_avartar_Change[3].sprite = custom_bodys[0];
    }
    public void Male()
    {
        sex_avartar_Change[0].sprite = custom_bodys[0];
        sex_avartar_Change[1].sprite = custom_bodys[1];
        sex_avartar_Change[2].sprite = custom_bodys[2];
        sex_avartar_Change[3].sprite = custom_bodys[3];
    }
    
    
    public void Avartar_Select()
    {
        if(!Pop_Window.activeSelf)
            Pop_Window.SetActive(true);

        player_avartar.sprite = custom_Avartar[UnityEngine.Random.Range(0, 8)];
            
    }
    #region 팝업창
    public void Pop_No()
    {
        Pop_Window.SetActive(false);
    }
    public void Pop_Yes()
    {
        if (avartar_window_num == 0)
        {
            avartar_title.GetComponent<Image>().sprite = title[1];
            avartar_windows.transform.GetChild(avartar_window_num).gameObject.SetActive(false);
            avartar_window_num += 1;
            avartar_windows.transform.GetChild(avartar_window_num).gameObject.SetActive(true);
        }
        else if (avartar_window_num == 1)
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
    #endregion
    private void Update()
    {
        Debug.Log(player.transform.forward);

        Current_Time();
        // A, X 버튼 감지
        if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            if (mic_Color.GetComponent<Image>().color.a == 1)
            {
                mic_Color.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            }
            else
            {
                mic_Color.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }

        // Y,B 버튼 감지
        if (Input.GetKeyDown(KeyCode.JoystickButton3) || Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            Debug.Log(new Vector3(player.transform.position.x, canvas.transform.position.y, player.transform.position.z) + player.transform.forward * 1.5f);

            if (canvas.activeSelf)
            {
                avartar_windows.transform.GetChild(avartar_window_num).gameObject.SetActive(false);
                avartar_window_num = 0;
                avartar_title.GetComponent<Image>().sprite = title[0];
                avartar_windows.transform.GetChild(avartar_window_num).gameObject.SetActive(true);
                canvas.SetActive(false);
                for (int i = 0; i < windows.transform.childCount; i++)
                {
                    if (windows.transform.GetChild(i).gameObject.activeSelf)
                        windows.transform.GetChild(i).gameObject.SetActive(false);
                }
                if (windows.activeSelf)
                    windows.SetActive(false);
            }
            else
            {
                canvas.SetActive(true);
                main_Screen.SetActive(true);
                Vector3 tempPOs = new Vector3(player.transform.position.x, canvas.transform.position.y, player.transform.position.z) + player.transform.forward * 1.5f;
                canvas.transform.position = new Vector3(tempPOs.x, player.transform.position.y + ui_height, tempPOs.z);
                canvas.transform.LookAt(player.transform, Vector3.up);

            }
        }
    }
    public void Current_Time()
    {

        if (DateTime.Now.Hour > 11)
        {
            current_time_KR.text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + " PM";
        }
        else
        {
            current_time_KR.text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + " AM"; ;
        }
    }
}
