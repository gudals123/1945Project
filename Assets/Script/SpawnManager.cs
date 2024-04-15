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
    [SerializeField]
    private GameObject monster2;
    [SerializeField]
    private GameObject boss;
    [SerializeField]
    private List<Transform> pos;

    bool swi = true;

    void Start()
    {
        StartCoroutine("Spawn");
        Invoke("Stop", SpawnStop);



    }
    IEnumerator Spawn()
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
        StopCoroutine("Spawn");

        //�ι�° ����
        StartCoroutine("Spawn2");
        Invoke("Stop2", SpawnStop + 10);

    }
    IEnumerator Spawn2()
    {
        yield return new WaitForSeconds(StartTime);
        StartCoroutine("MonsterSpawn");
        StartCoroutine("MonsterSpawn2");
    }

    IEnumerator MonsterSpawn()
    {
        yield return new WaitForSeconds(StartTime);
        GameObject clone = Instantiate(monster2, pos[0].position, Quaternion.Euler(0, 0, 180));
        clone.GetComponent<Monster2>().MonsterVector(Vector2.down + Vector2.left);
    }
    IEnumerator MonsterSpawn2()
    {
        yield return new WaitForSeconds(StartTime);
        GameObject clone = Instantiate(monster2, pos[1].position, Quaternion.Euler(0, 0, 180));
        clone.GetComponent<Monster2>().MonsterVector(Vector2.down + Vector2.right);
    }

    private void Stop2()
    {
        StopCoroutine("Spawn2");
        
        swi = true;
        StartCoroutine("Spawn");
        StartCoroutine("Spawn2");
        Invoke("Stop3", SpawnStop + 20);

        /*        StartCoroutine("Spawn3");
                Invoke("Stop3", SpawnStop+30);*/
    }

    private void Stop3()
    {
        swi = false;
        StopCoroutine("Spawn");
        StopCoroutine("Spawn2");

        Vector3 pos = new Vector3(0, 2.899f, 0);

        Instantiate(boss, pos, Quaternion.identity);
        //StartCoroutine("BossSpawn");
    }


    
}
