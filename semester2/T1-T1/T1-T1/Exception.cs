using System;

namespace PriorutyQueueNamespace
{
    /// <summary>
    /// Exception which throws when you try to revove an element of empty queue
    /// </summary>
    [Serializable]
    public class RemovingElementOfEmptyQueue : Exception
    {
        public RemovingElementOfEmptyQueue() { }
        public RemovingElementOfEmptyQueue(string message) : base(message) { }
        public RemovingElementOfEmptyQueue (string message, Exception inner)
            : base(message, inner) { }
        protected RemovingElementOfEmptyQueue(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
