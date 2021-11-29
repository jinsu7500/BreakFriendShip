using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class R2_Trigger1_Enter : MonoBehaviour
{
    public BulletScript bullet;
    static string[] player_Elevator = { "0", "0", "0", "0" };
    string[] player_name = new string[4];
    public PhotonView PV;
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    bullet = GameObject.Find("Bullet").GetComponent<BulletScript>();

    //    bullet.BulletScriptTriiger = true;

    //}

    // 트리거 엔터에 들어왔을 때 실행
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*진수코드 start
        Debug.Log("트리거엔터");
        if (collision.tag == "Player")
        {
            //bullet = GameObject.Find("Bullet").GetComponent<BulletScript>();
            //bullet = GameObject.Find("Bullet").GetComponent<BulletScript>();

            bullet.BulletScriptTriiger = true;
        }
        진수코드 end*/


        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        string[] name_and_isIn = new string[2]; // 이름, 플레이어가 층에 있는지 없는지 저장 변수
        string LocalPlayer = collision.gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text; // 현재 자기자신 플레이어 닉네임

        //만약 자기 자신이면 게임 플레이 하고있는 플레이어 인덱스 위치 찾고 그 인덱스 위치에 0저장
        if (LocalPlayer == PhotonNetwork.LocalPlayer.NickName)
        {
            for (int i = 0; i < player.Length; i++)
            {
                if (player_name[i] == LocalPlayer)
                {
                    player_Elevator[i] = "1"; // 1은 그 층에 있고 0은 그 층에 없음
                    name_and_isIn[0] = LocalPlayer;
                    name_and_isIn[1] = player_Elevator[i];
                    PV.RPC("ElevatorOutRPC", RpcTarget.All, name_and_isIn);
                    break;
                }
            }
        }


        //int k = 0;
        //for (k = 0; k < player.Length; k++)
        //{
        //    if (player_jump[k] == "0")
        //    {
        //        break;
        //    }
        //}
        //if (k == player.Length)
        //{
        //    GameObject.Find("R4_Clear").transform.GetChild(0).GetComponent<Together_Move>().Move_to_Up();
        //    //동시점프되었을때 실행함수
        //}
    }

    // 트리거 엔터에 나왔을 때 실행
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        string[] name_and_isIn = new string[2]; // 이름, 플레이어가 층에 있는지 없는지 저장 변수
        string LocalPlayer = collision.gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text; // 현재 자기자신 플레이어 닉네임

        //만약 자기 자신이면 게임 플레이 하고있는 플레이어 인덱스 위치 찾고 그 인덱스 위치에 0저장
        if (LocalPlayer == PhotonNetwork.LocalPlayer.NickName)
        {
            for (int i = 0; i < player.Length; i++)
            {
                if (player_name[i] == LocalPlayer)
                {
                    player_Elevator[i] = "0"; // 1은 그 층에 있고 0은 그 층에 없음
                    name_and_isIn[0] = LocalPlayer;
                    name_and_isIn[1] = player_Elevator[i];
                    PV.RPC("ElevatorOutRPC", RpcTarget.All, name_and_isIn);
                    break;
                }
            }
        }
    }
}
