using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace mhsApp1.Models
{
    public partial class NilaiMhss
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string NameMhs { get; set; }
        public string Matkul { get; set; }
        public int Nilai { get; set; }
        public string Catatan { get; set; }
    }
}
