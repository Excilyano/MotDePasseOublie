using UnityEngine;
using UnityEngine.UI;

public class SuccessWhenEndCollide : MonoBehaviour
{
    public Button continueButton;

    void Start()
    {
        continueButton.interactable = false;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("LabyrinthExit"))
        {
            continueButton.interactable = true;
        }
    }
}
