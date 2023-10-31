using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Formats.Alembic.Importer;

public class AlembicPlayController : MonoBehaviour
{
    public AlembicStreamPlayer streamPlayer;                   //AlembicStream 플레이어 가져오기
   
    void Start()
    {
        Application.targetFrameRate = 60;                       //FPS 설정
        QualitySettings.vSyncCount = 0;                         //vSync 옵션 설정 (0 비활성화, 1 활성화 <기본값> ,2 더블 버퍼링)

        streamPlayer = GetComponent<AlembicStreamPlayer>();     //AlembicStreamPlayer 컴퍼넌트 접근
    }
    
    void FixedUpdate()
    {
        streamPlayer.CurrentTime += Time.deltaTime;             //프레임 시간 갱신
    }
}
