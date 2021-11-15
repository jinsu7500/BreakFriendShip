using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class BulletScript : MonoBehaviourPunCallbacks
{
    public PhotonView PV;
    public GameObject bullet;
    public GameObject Player;

    //-85.54383
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.childCount > 0)
        {
            moveBullet();
        }
    }
    
    
    void moveBullet()
    {
        if (bullet.transform.position.x > -85.544 )
        {
            PV.RPC("moveBulletRPC", RpcTarget.AllBuffered);
        }
        bullet.transform.Translate(Vector3.right * 5 * Time.deltaTime);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground" || collision.tag == "Player" || collision.tag == "Box")
        {
            PV.RPC("moveBulletRPC", RpcTarget.AllBuffered);
        }
        
    }

    [PunRPC]
    void moveBulletRPC()
    {
        bullet.transform.position = new Vector3(-110.207f, -18.395f, 0);
    }

}


