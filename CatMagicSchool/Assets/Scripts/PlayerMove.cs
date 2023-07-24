using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int hp = 100;  // �ִ�ü��
    public int maxHP = 100;  // ü��
    public float jumpPower = 50.0f;

    public float maxSpeed = 3.0f;

    Rigidbody2D rigid;  // ���� �̵��� ���� ���� ����
    bool isJumping = false;  // ���� ���¸� ��Ÿ���� �ο� ���� > �� ������ �� ��... ��ü ��???


    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }
    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed)  // ������ �̵�, �ִ� �ӷ� ����
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);  // �ش� ������Ʈ�� �ӷ��� maxSpeed

        else if (rigid.velocity.x < maxSpeed * (-1))  // �������� �̵� (-)
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)  // �浹 ����
    {
        if (collision.gameObject.tag == "Ground")
            isJumping = false;
    }
}