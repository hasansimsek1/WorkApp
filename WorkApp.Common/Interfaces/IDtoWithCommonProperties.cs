using System;

namespace WorkApp.Common.Interfaces
{
    public interface IDtoWithCommonProperties : IDto
    {
        /// <summary>
        /// Id of the related entity.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Creation date of the related entity.
        /// </summary>
        DateTime AddedDate { get; set; }

        /// <summary>
        /// Modified date of the related entity.
        /// </summary>
        DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Soft-delete status of the related entity.
        /// </summary>
        bool IsDeleted { get; set; }
    }
}
