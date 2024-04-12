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
            // ������ ��ġ ���� ����
            shootCheck = false;
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        // ������ ��ġ ���� ����
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


        //ĳ������ ���� ��ǥ�� ����Ʈ ��ǥ��� ��ȯ���ش�.
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x); //x���� 0�̻�, 1���Ϸ� �����Ѵ�.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y���� 0�̻�, 1���Ϸ� �����Ѵ�.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);//�ٽÿ�����ǥ�� ��ȯ
        transform.position = worldPos; //��ǥ�� �����Ѵ�.
    }
}
