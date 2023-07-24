using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform pos;
    public float cooltime;  // bullet의 쿨타임 변수
    private float curtime;  // 현재 시간

    public int damage = 1;

    void Start()
    {
        
    }

    void Update()
    {
        if (curtime <= 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Instantiate(bullet, pos.position, transform.rotation);
            }

            curtime = cooltime;  // 초기화
        }

        curtime -= Time.deltaTime;
    }
}
