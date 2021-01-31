using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetWhenWallCollide : MonoBehaviour
{
    Vector2 startPosition;

    void Start()
    {
        startPosition = transform.localPosition;
        GetComponent<DragAndDropBehaviour>().sensibility = 50f;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("LabyrinthWall"))
        {
            transform.localPosition = startPosition;
            GetComponent<DragAndDropBehaviour>().enabled = false;
            StartCoroutine(ReenableDragAndDrop());
        }
    }

    IEnumerator ReenableDragAndDrop() {
        yield return new WaitForSeconds(1f);
        GetComponent<DragAndDropBehaviour>().enabled = true;
    }
}
