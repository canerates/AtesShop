using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtesShop.Entities
{
    public class Wishlist
    {
        public int Id { get; set; }

        [Index("IX_UserIdAndProductId", 1, IsUnique = true)]
        public Guid UserId { get; set; }

        [ForeignKey("Product")]
        [Index("IX_UserIdAndProductId", 2, IsUnique = true)]
        public int ProductId { get; set; }

        public Product Product { get; set; }

    }
}
