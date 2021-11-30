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

    // Ʈ���� ���Ϳ� ������ �� ����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*�����ڵ� start
        Debug.Log("Ʈ���ſ���");
        if (collision.tag == "Player")
        {
            //bullet = GameObject.Find("Bullet").GetComponent<BulletScript>();
            //bullet = GameObject.Find("Bullet").GetComponent<BulletScript>();

            bullet.BulletScriptTriiger = true;
        }
        �����ڵ� end*/


        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        string[] name_and_isIn = new string[2]; // �̸�, �÷��̾ ���� �ִ��� ������ ���� ����
        string LocalPlayer = collision.gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text; // ���� �ڱ��ڽ� �÷��̾� �г���

        //���� �ڱ� �ڽ��̸� ���� �÷��� �ϰ��ִ� �÷��̾� �ε��� ��ġ ã�� �� �ε��� ��ġ�� 0����
        if (LocalPlayer == PhotonNetwork.LocalPlayer.NickName)
        {
            for (int i = 0; i < player.Length; i++)
            {
                if (player_name[i] == LocalPlayer)
                {
                    player_Elevator[i] = "1"; // 1�� �� ���� �ְ� 0�� �� ���� ����
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
        //    //���������Ǿ����� �����Լ�
        //}
    }

    // Ʈ���� ���Ϳ� ������ �� ����
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        string[] name_and_isIn = new string[2]; // �̸�, �÷��̾ ���� �ִ��� ������ ���� ����
        string LocalPlayer = collision.gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text; // ���� �ڱ��ڽ� �÷��̾� �г���

        //���� �ڱ� �ڽ��̸� ���� �÷��� �ϰ��ִ� �÷��̾� �ε��� ��ġ ã�� �� �ε��� ��ġ�� 0����
        if (LocalPlayer == PhotonNetwork.LocalPlayer.NickName)
        {
            for (int i = 0; i < player.Length; i++)
            {
                if (player_name[i] == LocalPlayer)
                {
                    player_Elevator[i] = "0"; // 1�� �� ���� �ְ� 0�� �� ���� ����
                    name_and_isIn[0] = LocalPlayer;
                    name_and_isIn[1] = player_Elevator[i];
                    PV.RPC("ElevatorOutRPC", RpcTarget.All, name_and_isIn);
                    break;
                }
            }
        }
    }
}
