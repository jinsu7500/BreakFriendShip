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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("트리거엔터");
        if (collision.tag == "Player")
        {
            bullet = GameObject.Find("Bullet").GetComponent<BulletScript>();

            bullet.BulletScriptTriiger = true;
        }
    }
}
