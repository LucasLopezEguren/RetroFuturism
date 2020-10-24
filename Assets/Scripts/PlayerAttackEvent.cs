﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackEvent : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;
    public int damage = 5;

    public void PlayerAttack()
    {
        Collider[] hitColliders = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider hitEnemy in hitColliders)
        {
            Debug.Log(hitEnemy);
            try
            {
                hitEnemy.GetComponent<EnemyController>().TakeDamage(damage);
                
            }
            catch (System.Exception)
            {
                hitEnemy.GetComponent<FlyingEnemyController>().TakeDamage(damage);
            }
            
        }
    }
}
