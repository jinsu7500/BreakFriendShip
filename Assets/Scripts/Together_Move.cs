using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Together_Move : MonoBehaviour
{
    public GameObject apple;
    public PhotonView PV;

    public void Move_to_Right()
    {
        float x = apple.transform.position.x + 0.01f;
        float y = apple.transform.position.y;
        Vector2 vec = new Vector2(x, y);
        transform.position = Vector2.MoveTowards(transform.position, vec, 0.3f);
        PV.RPC("Right_Update", RpcTarget.Others);

    }
    public void Move_to_Left()
    {
        float x = apple.transform.position.x - 0.01f;
        float y = apple.transform.position.y;
        Vector2 vec = new Vector2(x, y);
        transform.position = Vector2.MoveTowards(transform.position, vec, 0.3f);
        PV.RPC("Left_Update", RpcTarget.Others);
    }
    public void Move_to_Up()
    {
        float x = apple.transform.position.x;
        float y = apple.transform.position.y + 0.001f;
        Vector2 vec = new Vector2(x, y);
        transform.position = Vector2.MoveTowards(transform.position, vec, 0.3f);
        PV.RPC("UP_Update", RpcTarget.Others);
    }

    [PunRPC]
    void Right_Update()
    {
        float x = apple.transform.position.x + 0.01f;
        float y = apple.transform.position.y;
        Vector2 vec = new Vector2(x, y);
        transform.position = Vector2.MoveTowards(transform.position, vec, 0.3f);
    }

    [PunRPC]
    void Left_Update()
    {
        float x = apple.transform.position.x - 0.01f;
        float y = apple.transform.position.y;
        Vector2 vec = new Vector2(x, y);
        transform.position = Vector2.MoveTowards(transform.position, vec, 0.3f);
    }

    [PunRPC]
    void UP_Update()
    {
        float x = apple.transform.position.x;
        float y = apple.transform.position.y + 0.001f;
        Vector2 vec = new Vector2(x, y);
        transform.position = Vector2.MoveTowards(transform.position, vec, 0.3f);
    }

}
