using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private int damage;

    public void Setup(int damage)
    {
        this.damage = damage;
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
    
    void OnTriggerEnter(Collider enemy){
        if(enemy != null){
            GameObject enemyObj = enemy.gameObject;

            Enemy enemyComponent = enemyObj.GetComponent<Enemy>();

            if(enemyComponent != null){
                enemyComponent.TakeDamage(damage);
            }
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other != null)
        {
            Destroy(gameObject);
        }   
    }

}
