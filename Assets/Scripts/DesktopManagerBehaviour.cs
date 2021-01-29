using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopManagerBehaviour : MonoBehaviour
{
    [Tooltip("La fenêtre de l'application principale")]
    public GameObject mainWindow;

    [Tooltip("Le footer en bas de page pour l'app principale")]
    public GameObject mainWindowFooter;

    private float clickTime;
    private int nbClicks;
    private float doubleClickDelay;

    public void OnEnable() {
        clickTime = float.MinValue;
        nbClicks = 0;
        doubleClickDelay = .8f;
    }

    public void MainAppClicked() {
        if (nbClicks == 0 || (nbClicks == 1 && clickTime + doubleClickDelay < Time.time)) {
            clickTime = Time.time;
            nbClicks = 1;
        } else {
            mainWindow.SetActive(true);
            mainWindowFooter.SetActive(true);
            nbClicks = 0;
        }
    }

    public void HideOrShowMainApp() {
        mainWindow.SetActive(!mainWindow.activeInHierarchy);
    }

    public void CloseMainApp() {
        mainWindow.SetActive(false);
        mainWindowFooter.SetActive(false);
    }

    public void MenuClicked() {
        Debug.Log("Wesh t'as cliqué sur le menu");
    }
}
