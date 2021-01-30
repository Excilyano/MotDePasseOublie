using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventNotifier : MonoBehaviour
{
    [Header("Les événements du jeu")]
    public GameEvent OnTrialSucceed;
    public GameEvent OnTrialFailed;
    public GameEvent OnNextPage;

    public void TriggerTrialSuccess() {
        OnTrialSucceed.Invoke();
    }

    public void TriggerTrialFailure() {
        OnTrialFailed.Invoke();
    }

    public void TriggerNextPage() {
        OnNextPage.Invoke();
    }
}
