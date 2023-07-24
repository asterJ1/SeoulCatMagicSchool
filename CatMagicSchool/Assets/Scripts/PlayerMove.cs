using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int hp = 100;  // 최대체력
    public int maxHP = 100;  // 체력
    public float jumpPower = 50.0f;

    public float maxSpeed = 3.0f;

    Rigidbody2D rigid;  // 물리 이동을 위한 변수 선언
    bool isJumping = false;  // 점프 상태를 나타내는 부울 변수 > 제 역할을 못 함... 대체 왜???


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

        if (rigid.velocity.x > maxSpeed)  // 오른쪽 이동, 최대 속력 넣음
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);  // 해당 오브젝트의 속력은 maxSpeed

        else if (rigid.velocity.x < maxSpeed * (-1))  // 왼쪽으로 이동 (-)
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)  // 충돌 감지
    {
        if (collision.gameObject.tag == "Ground")
            isJumping = false;
    }
}