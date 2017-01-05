using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Concurrency.Models
{
    public class Entity : Entity<int>, IEntity
    {
    }

    public class Entity<T> : IEntity<T>
    {
        [Key, Column("ID")]
        public T Id { get; set; }

        [Column("CREATED_DATETIME")]
        public DateTime? CreatedDateTime { get; set; }

        [Column("CREATED_BY")]
        public string CreatedBy { get; set; }

        [Column("MODIFIED_DATETIME")]
        public DateTime? ModifiedDateTime { get; set; }

        [Column("MODIFIED_BY")]
        public string ModifiedBy { get; set; }

        [Column("ROW_VERSION"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int? RowVersion { get; set; }

        [Timestamp, Column("TIMESTAMP"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public byte[] Timestamp { get; set; }

        [Column("ROWID"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string RowIdentifier { get; set; }

        [Column("IS_DELETED")]
        public int? IsDeleted { get; set; }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var item = obj as Entity;
            return item != null && Id.Equals(item.Id);
        }
    }
}
