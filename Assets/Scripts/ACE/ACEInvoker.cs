using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACEInvoker : MonoBehaviour
{
    public GameEvent OnACEInvoked;
    void OnEnable() {
        OnACEInvoked.Invoke();
    }
}
