using System;

namespace GhostHunter
{
    public interface IEventSystemService
    {
        void AddListener(string eventName, Action listener);
        void RemoveListener(string eventName, Action listener);
        void DispatchEvent(string eventName);
    }
}