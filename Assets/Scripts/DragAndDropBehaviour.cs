using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropBehaviour : MonoBehaviour, IDragHandler
{
    [Tooltip("La fenetre qui doit etre drag lors du clic sur cet element")]
    public GameObject windowToDrag;
    
    // Le Vector2 représentant la position du curseur à l'instant t-1
    // pour calculer le vecteur de translation
    private Vector2 prevPosition = Vector2.zero;

    void OnEnable() {
        prevPosition = Vector2.zero;
    }


    public void OnDrag(PointerEventData eventData)
    {
        Vector2 diff = eventData.position - prevPosition;
        if (prevPosition != Vector2.zero && diff.magnitude < 250) {
            windowToDrag.transform.Translate(diff);
        }
        prevPosition = eventData.position;
    }
}
