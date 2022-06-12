using System;

namespace GhostHunter
{
    public interface IEventSystemController
    {
        void AddListener(string eventName, Action listener);
        void RemoveListener(string eventName, Action listener);
        void DispatchEvent(string eventName);
    }
}