namespace WeatherWardrobe.Model
{
    public class Cloths
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int MinTemp { get; set; }
        public int MaxTemp { get; set; }
        public string WeatherCondition { get; set; }
        public string ImagePath { get; set; }

        public string Color { get; set; }
        // algoritme için önemli
        public bool IsHooded { get; set; }


    }
}
