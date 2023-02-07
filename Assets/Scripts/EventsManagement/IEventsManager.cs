using System;
using Interfaces;

namespace EventsManagement
{
    public interface IEventsManager : IManager
    {
        void Fire<T>(Action<T> subscribers) where T : class, IEventsManagerSubscriber;
        void Subscribe<S>(S subscriber, int priority = 0) where S : IEventsManagerSubscriber;
        void UnSubscribe<S>(S suscriber) where S : IEventsManagerSubscriber;
    }
}