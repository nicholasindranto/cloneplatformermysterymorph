using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    // healthnya berapa
    public float health;
    // maxhealth nya berapa
    private float maxHealth;
    // reference ke image health bar nya
    public Image hpBarImage;

    private void Start()
    {
        maxHealth = health;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        hpBarImage.fillAmount = health / maxHealth;
        if (health <= 0) Destroy(gameObject);
    }
}
