using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Classe représentant la charge utile
/// d'un évènement.
/// </summary>
public class GameEventPayload
{   
    /// <summary>
    /// Charge utile de l'évènement.
    /// </summary>
    private Dictionary<string, System.Object> payload;

    /// <summary>
    /// Constructeur de charge utile d'évènement.
    /// </summary>
    /// <param name="o">Contenu de la charge utile</param>
    public GameEventPayload(Dictionary<string, System.Object> o) {
        payload = o;
    }

    /// <summary>
    /// Méthode permettant de récupérer une
    /// valeur du payload sous forme d'un objet
    /// donné en paramètre
    /// </summary>
    public T Get<T>(string key) {
        return (T) payload[key];
    }
}

/// <summary>
/// Classe permettant d'utiliser les Unity Events
/// avec un paramètre.
/// </summary>
/// <typeparam name="GameEventPayload"></typeparam>
[System.Serializable]
public class CustomUnityEvent : UnityEvent<GameEventPayload> {}

/// <summary>
/// Classe encapsulant un UnityEvent dans un Scriptable Object.
/// </summary>
[CreateAssetMenu(menuName = "MdpOublie/Game Event", fileName = "New Game Event")]
public class GameEvent : ScriptableObject
{
    [HideInInspector]
    public CustomUnityEvent Event;

    /// <summary>
    /// Liste des évènements parents devant être invoqués lorsque cet
    /// évènement est invoqué.
    /// </summary>
    [Tooltip("Quels évènements doivent-être également invoqués lorsque cet évènement est invoqué ?")]
    public List<GameEvent> parentsEvent;

    /// <summary>
    /// Méthode permettant l'invocation de l'évènement actuel et de ses parents
    /// </summary>
    public void Invoke(Dictionary<string, System.Object> o = null) {

        GameEventPayload p = new GameEventPayload(o);

        Event.Invoke(p);

        foreach (GameEvent parent in parentsEvent)
        {
            parent.Invoke(p);
        }
    }

    /// <summary>
    /// Méthode permettant l'invocation de l'évènement actuel et de ses parents
    /// </summary>
    public void Invoke(GameEventPayload o) {

        Event.Invoke(o);

        foreach (GameEvent parent in parentsEvent)
        {
            parent.Invoke(o);
        }
    }

    /// <summary>
    /// Méthode permettant d'ajouter un listener appelé lorsque cet évènement est invoqué
    /// </summary>
    /// <param name="call">Action à effectuer lors de l'invoquation de l'évènement</param>
    public void AddListener(UnityAction<GameEventPayload> call) {
        Event.AddListener(call);
    }

    public void RemoveAllListeners() {
        Event.RemoveAllListeners();
    }
}