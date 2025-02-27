using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableCheck : MonoBehaviour
{
    public GameObject target { get; set; }
    private Enemy enemy;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");

        enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == target)
        {
            enemy.SetAttackable(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == target)
        {
            enemy.SetAttackable(false);
        }
    }
}
