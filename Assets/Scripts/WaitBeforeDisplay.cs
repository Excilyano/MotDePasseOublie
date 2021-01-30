using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaitBeforeDisplay : MonoBehaviour
{
    public float delay;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(delay);
        GetComponent<Button>().interactable = true;
    }
}
