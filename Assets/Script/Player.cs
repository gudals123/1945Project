using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Info")]
    [SerializeField]
    private float moveSpeed = 5.0f;
    [SerializeField]
    private List<GameObject> bullets = new List<GameObject>();
    [SerializeField]
    private Transform pos;

    private bool shootCheck =true;
    private int power = 0;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    { 
        PlayerMove();

        if (Input.GetKey(KeyCode.Space) && shootCheck)
        {
            // 프리팹 위치 방향 생성
            shootCheck = false;
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        // 프리팹 위치 방향 생성
        yield return new WaitForSeconds(0.05f);
        Instantiate(bullets[power], pos.position, Quaternion.identity);
        shootCheck = true;
    }

    private void PlayerMove()
    {
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        if (Input.GetAxis("Horizontal") <= -0.5)
            anim.SetBool("isMoveLeft", true);
        else
            anim.SetBool("isMoveLeft", false);

        if (Input.GetAxis("Horizontal") >= 0.5)
            anim.SetBool("isMoveRight", true);
        else
            anim.SetBool("isMoveRight", false);

        if (Input.GetAxis("Vertical") >= 0.5)
            anim.SetBool("isMoveUp", true);
        else
            anim.SetBool("isMoveUp", false);

        transform.Translate(moveX, moveY, 0);


        //캐릭터의 월드 좌표를 뷰포트 좌표계로 변환해준다.
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x); //x값을 0이상, 1이하로 제한한다.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y값을 0이상, 1이하로 제한한다.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);//다시월드좌표로 변환
        transform.position = worldPos; //좌표를 적용한다.
    }
}
