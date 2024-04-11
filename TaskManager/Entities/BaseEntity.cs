using System;

namespace TaskManager.Entities
{
    public abstract class BaseEntity
    {
        /// <summary>
        /// Идентификатор записи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата создания записи
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Дата изменения записи
        /// </summary>
        public DateTime UpdatedDate { get; set; }
    }
}