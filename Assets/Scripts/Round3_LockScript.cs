using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class Round3_LockScript : MonoBehaviour
{
    public Sprite spr;
    public GameObject fruit;
    public GameObject Round3BreakTile;

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
            Round3BreakTile.gameObject.SetActive(false);
            GameObject.Find("TextEffect").GetComponent<Typingeffect>().Stop_Func();
        }
    }
}