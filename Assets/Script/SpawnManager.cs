using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float ss = -2; //���� ���� x�� ó��
    public float es = 2;  //x�� ��
    public float StartTime = 1; //����
    public float SpawnStop = 10; //���������� �ð�
    [SerializeField]
    private GameObject monster;

    bool swi = true;

    void Start()
    {
        StartCoroutine("RandomSpawn");
        Invoke("Stop", SpawnStop);

    }
    IEnumerator RandomSpawn()
    {
        while (swi)
        {
            //1�ʸ���
            yield return new WaitForSeconds(StartTime);
            //x�� ����
            float x = Random.Range(ss, es);
            //x�� ���� y���� �ڱ��ڽŰ�
            Vector2 r = new Vector2(x, transform.position.y);
            //Quaternionnew Quaternion(0, 0, 180);
            //���� ����
            Instantiate(monster, r, Quaternion.Euler(0,0,180));
            //Instantiate(monster, r, Quaternion.identity);
        }
    }
    private void Stop()
    {
        swi = false;
        StopCoroutine("RandomSpawn");

        //�ι�° ����
        //StartCoroutine("RandomSpawn2");
        //Invoke("Stop2", SpawnStop+20);

    }



}
