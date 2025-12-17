using System;
using Unity.Mathematics;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform player;
    public float cameraFollowSpeed = 6f;

    float ypos = 0.25f;
    public static float xoffset;
    void Start()
    {
        
    }

    // Update is called once per frames
    void Update()
    {
        Vector3 newPosition = new Vector3(player.position.x + xoffset, ypos, -10);
        transform.position = Vector3.Slerp(transform.position, newPosition, cameraFollowSpeed * Time.deltaTime);
    }
}
