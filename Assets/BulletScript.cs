using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class BulletScript : MonoBehaviourPunCallbacks
{
    public PhotonView PV;
    float dir;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3.5f);


    }

    // Update is called once per frame
    void Update()
    {
        MakeBullet();
    }
    
    
    void moveBullet()
    {
        transform.Translate(Vector3.right * 7 * Time.deltaTime);
    }
    void MakeBullet()
    {
        PhotonNetwork.Instantiate("Bullet", new Vector3(-110f, -18.395f, 0f), Quaternion.identity);
    }
}
