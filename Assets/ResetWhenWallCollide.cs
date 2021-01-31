using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetWhenWallCollide : MonoBehaviour
{
    Vector2 startPosition;

    void Start()
    {
        startPosition = transform.localPosition;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("LabyrinthWall"))
        {
            transform.localPosition = startPosition;
        }
    }
}
