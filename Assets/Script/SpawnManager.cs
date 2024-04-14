using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float ss = -2; //몬스터 생성 x값 처음
    public float es = 2;  //x값 끝
    public float StartTime = 1; //시작
    public float SpawnStop = 10; //생성끝나는 시간
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
            //1초마다
            yield return new WaitForSeconds(StartTime);
            //x값 랜덤
            float x = Random.Range(ss, es);
            //x값 랜덤 y값은 자기자신값
            Vector2 r = new Vector2(x, transform.position.y);
            //Quaternionnew Quaternion(0, 0, 180);
            //몬스터 생성
            Instantiate(monster, r, Quaternion.Euler(0,0,180));
            //Instantiate(monster, r, Quaternion.identity);
        }
    }
    private void Stop()
    {
        swi = false;
        StopCoroutine("RandomSpawn");

        //두번째 몬스터
        //StartCoroutine("RandomSpawn2");
        //Invoke("Stop2", SpawnStop+20);

    }



}
