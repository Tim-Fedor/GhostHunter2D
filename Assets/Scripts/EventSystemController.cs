using System;
using System.Collections.Generic;
using UnityEngine;

public class EventSystemController : MonoBehaviour
{
    public static EventSystemController Instance;
    private Dictionary<string, List<Action>> _events;


    public void Awake()
    {
        Instance = this;
        _events = new Dictionary<string, List<Action>>();
    }

    public void AddListener(string eventName, Action listener)
    {
        if (!_events.ContainsKey(eventName))
        {
            CreateNewPair(eventName);
        }
        AddActionToListeners(eventName, listener);
    }
    
    public void RemoveListener(string eventName, Action listener)
    {
        if (!_events.ContainsKey(eventName))
        {
            return;
        }
        RemoveActionFromListeners(eventName, listener);
    }    
    
    public void DispatchEvent(string eventName)
    {
        if (!_events.ContainsKey(eventName))
        {
            return;
        }
        List<Action> allActions;
        _events.TryGetValue(eventName, out allActions);
        if (allActions == null)
        { 
            return;
        }

        foreach (var action in allActions)
        {
            action?.Invoke();
        }
    }
    
    private void CreateNewPair(string eventName)
    {
        List<Action> value = new List<Action>();
        _events.Add(eventName, value);
    }
    
    private void AddActionToListeners(string eventName, Action newListener)
    {
        List<Action> allActions;
        _events.TryGetValue(eventName, out allActions);
        if (allActions == null)
        {
            Debug.LogWarning($"Can`t get ActionList from {eventName}");
            allActions = new List<Action>();
        }

        if (allActions.Contains(newListener))
        {
            Debug.LogWarning($"Already have listener in {eventName}");
            return;
        }
        allActions.Add(newListener);
    }    
    
    private void RemoveActionFromListeners(string eventName, Action listener)
    {
        List<Action> allActions;
        _events.TryGetValue(eventName, out allActions);
        if (allActions == null)
        {
            Debug.LogWarning($" ActionList from {eventName} is null");
            return;
        }

        if (!allActions.Contains(listener))
        {
            Debug.LogWarning($"Listener in {eventName} is already removed");
            return;
        }
        allActions.Remove(listener);
    }
}
