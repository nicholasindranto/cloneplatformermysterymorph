using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // reference ke posisi player
    public Transform playerPos;
    // reference ke batas cameranya
    public Vector3 offset;
    // kecepatan kamera
    public float cameraSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,
            playerPos.position + offset, cameraSpeed * Time.deltaTime);
    }
}
