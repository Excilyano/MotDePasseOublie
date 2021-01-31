using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropBehaviour : MonoBehaviour, IDragHandler
{
    [Tooltip("La fenetre qui doit etre drag lors du clic sur cet element")]
    public GameObject windowToDrag;
    
    // Le Vector2 représentant la position du curseur à l'instant t-1
    // pour calculer le vecteur de translation
    [HideInInspector]
    public Vector2 prevPosition = Vector2.zero;
    [HideInInspector]
    public Vector2 diff;

    [HideInInspector]
    public float sensibility = 250f;

    void OnEnable() {
        prevPosition = Vector2.zero;
    }


    public void OnDrag(PointerEventData eventData)
    {
        diff = eventData.position - prevPosition;
        if (prevPosition != Vector2.zero && diff.magnitude < sensibility) {
            windowToDrag.transform.Translate(diff);
        }
        prevPosition = eventData.position;
    }
}
