using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class LockScript : MonoBehaviour
{
    public Sprite spr;
    public GameObject fruit;
    public Tilemap Round1BreakTile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fruit")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spr;
            fruit.gameObject.SetActive(false);
            //collision.gameObject.SetActive(false);
            Round1BreakTile.gameObject.SetActive(false);
        }
    }
}
