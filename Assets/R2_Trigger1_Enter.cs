using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R2_Trigger1_Enter : MonoBehaviour
{
    public BulletScript bullet;

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    bullet = GameObject.Find("Bullet").GetComponent<BulletScript>();

    //    bullet.BulletScriptTriiger = true;

    //}

    private void OnTriggerEnter2D(Collision other)
    {    
        Debug.Log("트리거엔터");
        bullet = GameObject.Find("Bullet").GetComponent<BulletScript>();

        bullet.BulletScriptTriiger = true;
        
    }
}
