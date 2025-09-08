using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // kecepatan gerak
    public float moveSpeed;
    // hadap kanan?
    public bool isFacingRight;
    // reference ke HP bar nya
    public Transform healthBarHUD;

    // Update is called once per frame
    void Update()
    {
        // gerak kekanan terus menerus
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }
}
