using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public int hp = 3;
    public int maxHP = 3;

    public Vector2 direction;
    public PlayerAttack playerAttack;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("bullet"))
        {
            hp -= playerAttack.damage;
            Debug.Log("적의 현재 체력 : " + hp);
        }
    }

    void Update()
    {
        if (hp == 0)
            Destroy(gameObject);
    }
}