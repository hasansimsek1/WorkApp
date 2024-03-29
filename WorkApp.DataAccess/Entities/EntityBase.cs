﻿using System;
using WorkApp.DataAccess.Interfaces;

namespace WorkApp.DataAccess.Entities
{
    /// <summary>
    /// Base class for the common properties of the entities.
    /// 
    /// <para/>
    /// 
    /// Implements : <see cref="IEntityWithCommonProperties"/>
    /// <para/>
    /// 
    /// Properties :
    /// <para/><see cref="Id"/> <see cref="int"/> (no attributes) (default value = 0)
    /// <para/><see cref="IsDeleted"/> <see cref="bool"/> (no attributes) (default value = <see cref="false"/>)
    /// <para/><see cref="AddedDate"/> <see cref="DateTime"/> (no attributes) (default value = <see cref="DateTime.Now"/>)
    /// <para/><see cref="ModifiedDate"/> <see cref="DateTime"/> (no attributes) (default value = <see cref="DateTime.Now"/>)
    /// 
    /// </summary>

    public class EntityBase : IEntityWithCommonProperties
    {
        /// <summary>
        /// Id of the entity. Initialized with auto-property initializer with value of 0
        /// </summary>
        public int Id { get; set; } = 0;

        /// <summary>
        /// Creation date of the entity. Initialized with auto-property initializer with value of <see cref="DateTime.Now"/>
        /// </summary>
        public DateTime AddedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Modification date of the entity. Initialized with auto-property initializer with value of <see cref="DateTime.Now"/>
        /// </summary>
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Soft-delete operation status of the entity. Initialized with auto-property initializer with value of <see cref="false"/>
        /// </summary>
        public bool IsDeleted { get; set; } = false;
    }
}
