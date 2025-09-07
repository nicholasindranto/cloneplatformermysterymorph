using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    private string enemyTag = "enemy";
    public GameObject[] healthUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void TakeDamage()
    {
        health--;
        // kenapa kok dikurangi dulu?
        // karna index start from 0. misal dari 3 kena damage, maka 2, maka
        // index kedua nya gak aktif
        healthUI[health].SetActive(false);
        if (health <= 0)
        {
            health = 0;
            // kalau mati maka restart gamenya
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(enemyTag))
        {
            TakeDamage();
        }
    }
}
