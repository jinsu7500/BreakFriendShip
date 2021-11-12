using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using Cinemachine;

public class PlayerScript : MonoBehaviourPunCallbacks, IPunObservable
{
    public Rigidbody2D RB;
    public Animator AN;
    public SpriteRenderer SR;
    public PhotonView PV;
    public Text NickNameText;

    bool isGround;
    Vector3 curPos;
    int jumpCount = 0;

    void Awake()
    {
        // �г��� ǥ��
        NickNameText.text = PV.IsMine ? PhotonNetwork.NickName : PV.Owner.NickName;

        //�ڱ� �÷��̾ ����ٴϴ� ī�޶� ����
        //CM�� �ó׸ӽ� ī�޶� ����
        //������ ����
        if (PV.IsMine)
        {
            var CM = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
            CM.Follow = transform;
            CM.LookAt = transform;
        }
    }

    void Update()
    {
        
        if (PV.IsMine)
        {
            // <-(-1 ��ȯ), ->(1 ��ȯ) �̵�, �ȴ����� 0 ��ȯ
            float axis = Input.GetAxisRaw("Horizontal");
            // transform���� �ϰԵǸ� ���� �ε�ĥ ��� ���� �հ� ������ ��
            RB.velocity = new Vector2(4 * axis, RB.velocity.y);

            if (axis != 0)
            {
                AN.SetBool("isRun", true);
                PV.RPC("FilpXRPC", RpcTarget.AllBuffered, axis);// �����ӽ� FilpX�� ����ȭ���ֱ� ���ؼ� AllBuffered
            }
            else
            {
                AN.SetBool("isRun", false);
            }

            // ����, �ٴ�üũ
            isGround = Physics2D.OverlapCircle((Vector2)transform.position + new Vector2(0, -0.5f), 0.07f, 1 << LayerMask.NameToLayer("Ground"));
            
          
            AN.SetBool("isJump", !isGround);
            if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 1)
            {
                Debug.Log(jumpCount);
                PV.RPC("JumpRPC", RpcTarget.All, isGround);
                
                jumpCount++;

                AN.SetBool("isDoubleJump", !isGround);
                PV.RPC("DoubleJumpRPC", RpcTarget.All, isGround);
                Debug.Log(jumpCount);
            }
            if (isGround)
            {
                jumpCount = 0;
                AN.SetBool("isDoubleJump", false);
            }
            
            
           
        }

        //IsMine�� �ƴ� �͵��� �ε巴�� ��ġ ����ȭ
        else if ((transform.position - curPos).sqrMagnitude >= 100) transform.position = curPos;
        else transform.position = Vector3.Lerp(transform.position, curPos, Time.deltaTime * 10);
    }

    [PunRPC]
    void FilpXRPC(float axis) => SR.flipX = axis == -1;// ���� Ű�� ���� ��� True ��ȯ ������ Ű�� ������ ��� False ��ȯ

    [PunRPC]
    void JumpRPC(bool isGround)
    {
        AN.SetBool("isJump", !isGround);
        RB.velocity = Vector2.zero;
        RB.AddForce(Vector2.up * 300);
    }

    [PunRPC]
    void DoubleJumpRPC(bool isGround)
    {
        AN.SetBool("isDoubleJump", !isGround);
        RB.velocity = Vector2.zero;
        RB.AddForce(Vector2.up * 300);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
        }
        else
        {
            curPos = (Vector3)stream.ReceiveNext();
        }
    }
}
