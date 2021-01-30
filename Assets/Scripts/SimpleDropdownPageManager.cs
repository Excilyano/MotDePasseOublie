using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SimpleDropdownPageManager : MonoBehaviour
{
    public Button continuer;

    public void EnableContinuer() {
        continuer.interactable = true;
    }
}
