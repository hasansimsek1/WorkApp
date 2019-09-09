using System;

namespace WorkApp.Common.DTOs
{
    /// <summary>
    /// Data transfer object for the ToDo entity.
    /// <para/>
    /// 
    /// Inherits from : <see cref="DtoBase"/>
    /// 
    /// <para/>
    /// 
    /// Properties :
    /// <para/><see cref="DtoBase.Id"/> (Type = <see cref="int"/>) (default value = 0) (no attributes)
    /// <para/><see cref="DtoBase.AddedDate"/> (Type = <see cref="DateTime"/>) (default value = <see cref="DateTime.Now"/>) (no attributes)
    /// <para/><see cref="DtoBase.ModifiedDate"/> (Type = <see cref="DateTime"/>) (default value = <see cref="DateTime.Now"/>) (no attributes)
    /// <para/><see cref="DtoBase.IsDeleted"/> (Type = <see cref="bool"/>) (default value = <see cref="false"/>) (no attributes)
    /// 
    /// <para/><see cref="Text"/> (Type = <see cref="string"/>)  (no attribute)
    /// <para/><see cref="IsCompleted"/> (Type = <see cref="bool"/>)  (no attribute)
    /// <para/><see cref="UserId"/> (Type = <see cref="string"/>)  (no attribute)
    /// <para/><see cref="User"/> (Type = <see cref="ApplicationUserDto"/>)  (no attribute)
    /// 
    /// </summary>

    public class ToDoDto : DtoBase
    {
        /// <summary>
        /// Text of the todo.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Status of the todo that if it is completed or not.
        /// </summary>
        public bool IsCompleted { get; set; }

        /// <summary>
        /// Id of the application user of the todo.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// User of the todo.
        /// </summary>
        public ApplicationUserDto User { get; set; }
    }
}
