using System;

namespace com.GhostHunter.BaseSystems
{
    public interface IEventSystemService
    {
        void AddListener(string eventName, Action<object[]> listener);
        void RemoveListener(string eventName, Action<object[]> listener);
        void DispatchEvent(string eventName, params object[] data);
    }
}