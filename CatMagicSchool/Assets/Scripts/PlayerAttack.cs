using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform pos;
    public float cooltime;  // bullet�� ��Ÿ�� ����
    private float curtime;  // ���� �ð�

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

            curtime = cooltime;  // �ʱ�ȭ
        }

        curtime -= Time.deltaTime;
    }
}
