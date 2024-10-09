using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Player;
    public float DampAmount;
    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        Vector3 CameraPos = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, -10);
        Vector3 PlayerPos = new Vector3(Player.transform.position.x, Player.transform.position.y, -10);

        transform.position = Vector3.SmoothDamp(CameraPos, PlayerPos, ref velocity, DampAmount);
    }
}
