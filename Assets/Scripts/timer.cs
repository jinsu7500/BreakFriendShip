using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class timer : MonoBehaviour
{

    [SerializeField] float setTime = 4.0f;
    [SerializeField] Text countdownText;
    public GameObject round1;
    public GameObject RoomPanel;
    public GameObject RobbyPanel;
    public GameObject time;
    public GameObject Canvas;

    public Image Title_BG;
    public Image Title_Name;
    public Button UI_Btn_Start;
    public Button UI_Btn_End;
    public Text TypingText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (setTime > 0)
            setTime -= Time.deltaTime;
        else if (setTime <= 0)
            Time.timeScale = 0.0f;


        if (Mathf.Round(setTime).ToString() == "0")
        {
            time.SetActive(false);
            
            RoomPanel.SetActive(false);
            RobbyPanel.SetActive(false);
            Title_BG.gameObject.SetActive(false);
            Title_Name.gameObject.SetActive(false);
            UI_Btn_Start.gameObject.SetActive(false);
            UI_Btn_End.gameObject.SetActive(false);
            //TypingText.gameObject.SetActive(true);

            //GameObject.Find("TextEffect").GetComponent<Typingeffect>().text_start();
        }
        countdownText.text = (Mathf.Round(setTime)).ToString();
    }
}
