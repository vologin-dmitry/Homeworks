using System;

namespace UniqueList
{
    /// <summary>
    /// Exception that throws, when you try to add an element, which already exists
    /// </summary>
    [Serializable]
    public class AddingExistingElementException : InvalidOperationException
    {
        public AddingExistingElementException() { }
        public AddingExistingElementException(string message) : base(message) { }
        public AddingExistingElementException(string message, Exception inner)
        : base(message, inner) { }
        protected AddingExistingElementException(
        System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context)
        : base(info, context) { }
    }
}