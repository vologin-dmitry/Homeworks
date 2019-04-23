using System;

namespace UniqueList
{
    /// <summary>
    /// Exception that throws, when you try to delete an element, which does not exists in the list
    /// </summary>
    [Serializable]
    public class DeletionOfNotExistingElement : InvalidOperationException
    {
        public DeletionOfNotExistingElement() { }
        public DeletionOfNotExistingElement(string message) : base(message) { }
        public DeletionOfNotExistingElement(string message, Exception inner)
        : base(message, inner) { }
        protected DeletionOfNotExistingElement(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
        : base(info, context) { }
    }
}