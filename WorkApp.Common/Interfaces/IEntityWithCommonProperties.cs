using System;

namespace WorkApp.Common.Interfaces
{
    /// <summary>
    /// Definitions of this interface are being used in ICrudRepository implementations to be able to set common properties automatically (like AddedDate, ModifiedDate etc).
    /// </summary>
    public interface IEntityWithCommonProperties : IEntity
    {
        /// <summary>
        /// Id of the entity.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Creation date of the entity.
        /// </summary>
        DateTime AddedDate { get; set; }

        /// <summary>
        /// Modified date of the entity.
        /// </summary>
        DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Soft-delete status of the entity.
        /// </summary>
        bool IsDeleted { get; set; }
    }
}
