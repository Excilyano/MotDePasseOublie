using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayACESequence : MonoBehaviour
{
    [Header("Sequence")]
    public List<ACESequenceItem> sequence;

    [Header("References")]
    public GameEvent callACE;

    [System.Serializable]
    public struct ACESequenceItem
    {
        public float delayAfterStart;

        public float isWritingDelay;

        [TextArea]
        public string content;

        public ACEExpression expression;
    }

    void Start()
    {
        foreach (ACESequenceItem item in sequence)
        {
            StartCoroutine(StartSequenceItem(item));
        }
    }

    IEnumerator StartSequenceItem(ACESequenceItem item)
    {
        yield return new WaitForSeconds(item.delayAfterStart);

        Dictionary<string, object> data = new Dictionary<string, object>();
        data.Add("text", item.content);
        data.Add("isWritingDelay", item.isWritingDelay);
        data.Add("expression", item.expression);

        callACE.Invoke(data);
    }
}
