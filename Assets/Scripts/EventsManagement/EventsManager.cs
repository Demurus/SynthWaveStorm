using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EventsManagement
{
    public class EventsManager : MonoBehaviour, IEventsManager
    {
        private Dictionary<RuntimeTypeHandle, List<PrioritySubscriber>> SubscribersByType = new Dictionary<RuntimeTypeHandle, List<PrioritySubscriber>>();

        public void Fire<T>(Action<T> action) where T : class, IEventsManagerSubscriber
        {
            Type type = typeof(T);
            RuntimeTypeHandle handle = type.TypeHandle;
            if (SubscribersByType.ContainsKey(handle))
            {
                List<PrioritySubscriber> eventsSubs = SubscribersByType[handle];
                List<PrioritySubscriber> copySubs = new List<PrioritySubscriber>();
                copySubs.AddRange(eventsSubs);
                
                copySubs = copySubs.OrderBy(sub => sub.Priority).ToList();
                for (int i = 0; i < copySubs.Count; i++)
                {
                    if (copySubs[i].Subscriber == null)
                    {
                        Debug.LogError($"We lose a subscriber for the {type} event");
                    }
                    action.Invoke(copySubs[i].Subscriber as T);
                }

                //foreach (PrioritySubscriber prioritySub in copySubs)
                //{
                //    action.Invoke(prioritySub.Subscriber as T);
                //}
               
                //Debug.Log(action.ToString());
            }
        }

        public int SubsNumber()
        {
            return SubscribersByType.Count;
        }

        public void Subscribe<S>(S subscriber, int prioity = 0) where S : IEventsManagerSubscriber
        {
            Type type = typeof(S);
            RuntimeTypeHandle handle = type.TypeHandle;
            if (SubscribersByType.ContainsKey(handle))
            {
                //if (SubscribersByType[handle].Contains(subscriber))
                if (SubscribersByType[handle].Any(s => s.Subscriber.GetHashCode() == subscriber.GetHashCode()))
                {
                    Debug.LogWarning($"Object of type->{type.Name} try to subscribe twice");
                    return;
                }
                SubscribersByType[handle].Add(new PrioritySubscriber
                {
                    Subscriber = subscriber,
                    Priority = prioity
                });
                SubscribersByType[handle] = SubscribersByType[handle].OrderBy(s => s.Priority).ToList();

                //Debug.Log(subscriber.ToString());
            }
            else
            {
                SubscribersByType.Add(handle, new List<PrioritySubscriber>
                {
                    new PrioritySubscriber
                    {
                        Subscriber = subscriber,
                        Priority = prioity
                    }
                });

                //Debug.Log(subscriber.ToString());
            }
        }

        public void UnSubscribe<S>(S subscriber) where S : IEventsManagerSubscriber
        {
            Type type = typeof(S);
            RuntimeTypeHandle handle = type.TypeHandle;
            if (SubscribersByType.ContainsKey(handle))
            {
                var sub = SubscribersByType[handle].FirstOrDefault(s => s.Subscriber.GetHashCode() == subscriber.GetHashCode());
                if (sub != null)
                {
                    SubscribersByType[handle].Remove(sub);
                }
            }
        }

        private class PrioritySubscriber
        {
            public IEventsManagerSubscriber Subscriber;
            public int Priority;
        }

        public void Init()
        {
            
        }
    }
}