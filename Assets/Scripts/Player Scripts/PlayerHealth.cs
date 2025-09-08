using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    private string enemyTag = "enemy";
    private string spikeTag = "spike";
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
        if (collision.CompareTag(enemyTag)) TakeDamage();
        else if (collision.CompareTag(spikeTag))
        {
            // die immediately
            for (int i = health - 1; i >= 0; i--)
            {
                healthUI[i].SetActive(false);
            }
            health = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } 
    }
}
