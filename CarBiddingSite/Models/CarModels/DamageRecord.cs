namespace CarBiddingSite.Models.CarModels
{
    public class DamageRecord
    {
        public int Id { get; set; }
        public required DamageType DamageType { get; set; }
        public string? Description { get; set; }
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
