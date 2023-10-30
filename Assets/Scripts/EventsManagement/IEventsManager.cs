using System;
using Interfaces;

namespace EventsManagement
{
    public interface IEventsManager : IManager
    {
        void Fire<T>(Action<T> subscribers) where T : class, IEventsManagerSubscriber;
        void Subscribe<TS>(TS subscriber, int priority = 0) where TS : IEventsManagerSubscriber;
        void UnSubscribe<TS>(TS subscriber) where TS : IEventsManagerSubscriber;
    }
}