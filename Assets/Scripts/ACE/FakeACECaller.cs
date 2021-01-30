using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeACECaller : MonoBehaviour
{
    [Header("Game Events")]
    public GameEvent callACE;


    string[] texts = new string[] {
        "Des actrices effilent les journalistes.",
        "Des inconnus complotaient.",
        "Je m'installerai sur la paille.",
        "Ces gamines croient habiller un tordu...",
        "Des dizaines de communistes érigent la caméra."
    };

    public void CallRandomACE()
    {
        Dictionary<string, object> data = new Dictionary<string, object>();

        data.Add("text", texts[Random.Range(0, texts.Length)]);
        data.Add("isWritingDelay", Random.Range(0.5f, 2f));
        data.Add("expression", (ACEExpression) Random.Range(0, 4));

        callACE.Invoke(data);
    }
}
