using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SimpleInputPageManager : MonoBehaviour
{
    public Button continuer;
    public TMP_InputField field;

    public void EnableContinuer() {
        continuer.interactable = field.text.Length > 0;
    }

    public void EnableContinuerForToutou() {
        if (field.text.ToLower() == "pouki") {
            continuer.interactable = field.text.Length > 0;
        }
    }
}
