using System;
using Unity.Mathematics;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform player;
    public float cameraFollowSpeed = 10f;

    private float yoffset = 2.4f;
    private float xoffset = 2.8f;
    void Start()
    {
        
    }

    // Update is called once per frames
    void Update()
    {
        Vector3 newPosition = new Vector3(player.position.x + xoffset, player.position.y + yoffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPosition, cameraFollowSpeed * Time.deltaTime);
    }
}
