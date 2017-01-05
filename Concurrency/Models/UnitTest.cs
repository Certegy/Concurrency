using System.ComponentModel.DataAnnotations.Schema;

namespace Concurrency.Models
{
    /// <summary>
    /// This table is used for CCP Unit Testing, specifically DataAccessCore
    /// </summary>
    [Table("ZZ_UNIT_TEST")]
    public class UnitTest : Entity
    {
        [Column("NAME")]
        public string Name { get; set; }

        [Column("REFERENCE_NUMBER")]
        public int? ReferenceNumber { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Name} - {ReferenceNumber} - {RowVersion}";
        }
    }
}
