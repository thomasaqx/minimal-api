using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace minimal_api.Domains.Entities
{
    public class Administrator
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int id { get; set; }
        [Required]
        [StringLength(255)]

        public string Email { get; set; } = default!;

        [StringLength(50)]

        public string Password { get; set; } = default!;

        [StringLength(12)]
        public string Profile { get; set; } = default!;

    }
}