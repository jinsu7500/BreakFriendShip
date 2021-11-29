using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class GhostScript : MonoBehaviourPunCallbacks
{
    //int FruitCount = 0;
    public float speed;
    public float distance;
    public GameObject player;
    public PhotonView PV;
    public Rigidbody2D RB;

    public bool isTrigger = false;

    private string name = "";
    void Start()
    {

    }
    void Update()
    {

    }

    public void GhostMove()
    {
        int i = 0;
        if (isTrigger)
        {
            for (i = 0; i < player.transform.childCount; i++)
            {
                if (player.transform.GetChild(i).transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text == name) break;
            }

            float x = player.transform.GetChild(i).position.x;
            float y = player.transform.GetChild(i).position.y;
            Vector2 vec = new Vector2(x, y);
            transform.position = Vector2.MoveTowards(transform.position, vec, 0.015f);
        }
        PV.RPC("Syn_update_move", RpcTarget.All);
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Ãæµ¹");

        if (collision.tag == "Player")
        {
            Debug.Log(collision.gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text);
            isTrigger = true;
            name = collision.gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text;
            //PlayerPosition = collision.transform.position;
            //FruitCount++;
        }

    }

    [PunRPC]
    public void Syn_update_move()
    {
        int i = 0;
        if (isTrigger)
        {
            for (i = 0; i < player.transform.childCount; i++)
            {
                if (player.transform.GetChild(i).transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text == name) break;
            }
            float x = player.transform.GetChild(i).position.x;
            float y = player.transform.GetChild(i).position.y;
            Vector2 vec = new Vector2(x, y);
            transform.position = Vector2.MoveTowards(transform.position, vec, 0.015f);

        }
        //Debug.Log(name);
    }


}
