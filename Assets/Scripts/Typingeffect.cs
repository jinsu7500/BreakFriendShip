using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Typingeffect : MonoBehaviour
{

    public Text tx;
    public GameObject PlayerObj;
    public Image deathImg;
    public PhotonView PV;
    private string m_text = "¹«±ÃÈ­ ²ÉÀÌ ÇÇ¾ú½À´Ï´Ù";
    // Start is called before the first frame update
    void Start()
    {
        
        

    }
    public void text_start()
    {
        if (NetworkManager.RoomMaster == PhotonNetwork.LocalPlayer.NickName)
        {
            float[] random_array = new float[m_text.Length+1];
            for (int i = 0; i <= m_text.Length; i++)
            {
                float random = Random.Range(0.1f, 0.8f);
                random_array[i] = random;
                Debug.Log(random_array[i]);
            }
            
            PV.RPC("Text_Syn_RPC", RpcTarget.All, random_array);
        }
        
    }

    public void test()
    {
        PV.RPC("Show_deathImg", RpcTarget.All);
    }


    [PunRPC]
    public void Text_Syn_RPC(float[] random)
    {
        StartCoroutine(countTime(random));
    }

IEnumerator countTime(float[] random)
    {
        string name = PlayerObj.transform.GetChild(0).name;
        PlayerScript PS = GameObject.Find(name).GetComponent<PlayerScript>();

        for (int i = 0; i<= m_text.Length; i++)
        {
            
            tx.text = m_text.Substring(0, i);
            
            if(i == m_text.Length)
            {
                Debug.Log("hh");
                bool isRun = PS.isRun;
                bool isGround = PS.isGround;
                if (isRun || !isGround)
                {
                    Debug.Log("Á×À½");
                    test();
                }
            }
            yield return new WaitForSeconds(random[i]);

        }
        
        Invoke("text_start", 0.5f);
    }

    
    [PunRPC]

    public void Show_deathImg()
    {
        deathImg.gameObject.SetActive(true);
    }
}
