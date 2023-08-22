using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EkartEF.Models
{
    [Table("OrderStatus")]
    public class OrderStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderStatusId { get; set; }

        [Column("StatusType")]
        [MaxLength(50)]
        public String OrderStatusType { get; set; }
        
        [MaxLength(250)]
        public String Description { get; set; }
    }
}
