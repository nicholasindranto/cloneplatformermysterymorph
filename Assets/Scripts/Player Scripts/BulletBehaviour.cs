using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    // kecepatan bulletnya, damagenya, dan berapa lama buat dia ilang
    public float bulletSpeed, damage, destroyTime;

    private void Awake()
    {
        Destroy(gameObject, destroyTime); // bulletnya ilang setelah sekian detik
    }

    // Update is called once per frame
    void Update()
    {
        // gerak kekanan terus
        transform.Translate(Vector2.right * bulletSpeed * destroyTime * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // kalau kena wall atau kena enemy, maka bulletnya ilang
        if (other.CompareTag("enemy"))
        {
            // musuh kena damage
            // kenapa kok .transform.parent?
            // biar dia bisa ngereference ke script enemyhealth nya
            other.GetComponentInParent<EnemyHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (other.CompareTag("wall")) Destroy(gameObject);
    }
}
