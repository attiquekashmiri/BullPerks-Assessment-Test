using BullPerks.DAL.Models;
using System.Linq.Expressions;

namespace BullPerks.Dtos
{
    public class TokenDataDto
    {
        public required string Name { get; set; }
        /// <summary>
        /// As value might exceeds the range of a 64-bit signed integer, that's why it's in string
        /// </summary>
        public required string TotalSupply { get; set; }
        /// <summary>
        /// As value might exceeds the range of a 64-bit signed integer, that's why it's in string
        /// </summary>
        public required string CirculatingSupply { get; set; }
        public DateTime CreatedDate { get; set; }

        public static Expression<Func<TokenData, TokenDataDto>> Projection
        {
            get
            {
                return x => new TokenDataDto()
                {
                    Name = x.Name,
                    TotalSupply = x.TotalSupply,
                    CirculatingSupply = x.CirculatingSupply,
                    CreatedDate = x.CreatedDate
                };
            }
        }
    }
}
