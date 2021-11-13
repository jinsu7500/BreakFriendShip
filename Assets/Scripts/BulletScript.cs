using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

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
            bullet.transform.Translate(new Vector3(-24.66317f, 0, 0));
        }
        bullet.transform.Translate(Vector3.right * 7 * Time.deltaTime);

    }

}
