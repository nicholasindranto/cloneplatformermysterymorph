using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // kecepatan gerak
    public float moveSpeed;
    // hadap kanan?
    [SerializeField] private bool isFacingRight;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // gerak kekanan terus menerus
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("wall"))
        {
            // menghadap ke arah sebaliknya
            isFacingRight = !isFacingRight;
            // kalau hadap kiri maka rotation y nya dibikin 180
            if (!isFacingRight) transform.eulerAngles = Vector2.up * 180;
            else if (isFacingRight) transform.eulerAngles = Vector2.zero;
        }
    }
}
