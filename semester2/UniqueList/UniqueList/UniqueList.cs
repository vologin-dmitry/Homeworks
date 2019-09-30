using System;

namespace UniqueList
{
    /// <summary>
    /// List, which throws an exception, when you try to add an element, 
    /// which already exists in list or delete element, which does not exist in list
    /// </summary>
    public class UniqueList : LinkedList.List
    {
        /// <summary>
        /// Adds an element to list. If element, you want to add already exists in this list, throws an exception
        /// </summary>
        /// <param name="data">Value, you want to add</param>
        /// <param name="position">The position to which you want to put the value</param>
        /// <returns>True if the addition was successful, false if the value was not added</returns>
        public override bool Add(string data, int position)
        {
            if (GetPosition(data) != -1)
            {
                throw new AddingExistingElementException("This element is already in the list");
            }
            return base.Add(data, position);
        }

        /// <summary>
        /// Removes an element from list. If element, you want to remove does not exists in this list, throws an exception
        /// </summary>
        /// <param name="position">The position of the element, you want to remove</param>
        /// <returns>True if the deletion was successful, false if the value was not deleted</returns>
        public override bool Delete(int position)
        {
            if (!base.Delete(position))
            {
                throw new DeletionOfNotExistingElement("You are trying to delete a non-existent element");
            }
            return true;
        }

        /// <summary>
        ///Changes the string in the specified position, throws an exception if the value to which you want to change already exists
        /// </summary>
        /// <param name="data">The string to which you want to change the string at a given position</param>
        /// <param name="position">Position of a string, you want to change</param>
        /// <returns>True, if operation was successful, false otherwise</returns>
        public override bool SetDataOn(string data, int position)
        {
            int alreadyExistsOn = GetPosition(data);
            if (alreadyExistsOn != position && alreadyExistsOn != -1)
            {
                throw new AddingExistingElementException("This element is already in the list");
            }
            return base.SetDataOn(data, position);
        }
    }
}
