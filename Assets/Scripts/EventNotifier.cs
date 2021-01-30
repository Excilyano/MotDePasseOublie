using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class EventNotifier : MonoBehaviour
{
    [Header("Les événements du jeu")]
    public GameEvent OnTrialSucceed;
    public GameEvent OnTrialFailed;
    public GameEvent OnNextPage;
    public Button buttonToEnable;

    public void TriggerTrialSuccess() {
        OnTrialSucceed.Invoke();
    }

    public void TriggerTrialFailure() {
        OnTrialFailed.Invoke();
    }

    public void TriggerNextPage() {
        OnNextPage.Invoke();
    }

    public void TriggerHuman() {
        Dictionary<string, object> dico = new Dictionary<string, object>();
        buttonToEnable.interactable = gameObject.GetComponent<Toggle>().isOn;
        dico.Add("isHuman", gameObject.GetComponent<Toggle>().isOn);
    }
}
