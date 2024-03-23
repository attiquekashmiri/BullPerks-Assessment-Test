using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BullPerks.DAL.Models
{
    public class TokenData
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        /// <summary>
        /// As value might exceeds the range of a 64-bit signed integer, that's why it's in string
        /// </summary>
        public required string TotalSupply { get; set; }
        /// <summary>
        /// As value might exceeds the range of a 64-bit signed integer, that's why it's in string
        /// </summary>
        public required string CirculatingSupply { get; set; }
        public required DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeprecatedDate { get; set; }
    }
}
