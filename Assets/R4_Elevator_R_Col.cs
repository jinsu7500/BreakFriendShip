using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R4_Elevator_R_Col : MonoBehaviour
{
    [SerializeField]
    private GameObject RightWall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            RightWall.SetActive(true);
        }
    }
}
