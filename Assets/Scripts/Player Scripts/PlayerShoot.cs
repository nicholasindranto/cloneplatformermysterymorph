using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // reference ke object bullet nya
    public GameObject bullet;
    // reference ke posisi shoot bullet nya
    public Transform shootPoint;

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // teken tombol z maka shoot
            // spawn bulletnya di lokasi shoot dan arah si playernya
            Instantiate(bullet, shootPoint.position, transform.rotation);
        }
    }
}
