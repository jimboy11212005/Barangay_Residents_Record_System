using System.Text.Json;

namespace BRRAPI.Models
{
    public class DataService
    {
        private string filePath = "barangay_data.json";

        // 💾 SAVE DATA
        public void SaveData(List<Resident> residents, List<Household> households)
        {
            var data = new BarangayData
            {
                Residents = residents,
                Households = households
            };

            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, json);
        }

        // 📥 LOAD DATA
        public (List<Resident>, List<Household>) LoadData()
        {
            if (!File.Exists(filePath))
                return (new List<Resident>(), new List<Household>());

            string json = File.ReadAllText(filePath);

            var data = JsonSerializer.Deserialize<BarangayData>(json);

            if (data == null)
                return (new List<Resident>(), new List<Household>());

            return (
                data.Residents ?? new List<Resident>(),
                data.Households ?? new List<Household>()
            );
        }

        // 🧠 JSON STRUCTURE CLASS
        private class BarangayData
        {
            public List<Resident> Residents { get; set; }
            public List<Household> Households { get; set; }
        }
    }
}
