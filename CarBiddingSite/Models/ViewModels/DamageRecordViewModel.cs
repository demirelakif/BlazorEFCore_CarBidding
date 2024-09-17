using System;
using System.ComponentModel.DataAnnotations;

namespace CarBiddingSite.Models.ViewModels
{
    public class DamageRecordViewModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide the damage type")]
        public required DamageType DamageType { get; set; }

        public string? Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? Time { get; set; }
    }

    public enum DamageType
    {
        Dent,        // Vuruk
        Crack,       // Kırık
        Scratch,     // Çizik
        Rust,        // Pas
        BrokenGlass, // Cam Kırığı
        PaintDamage  // Boya Hasarı
    }
}
