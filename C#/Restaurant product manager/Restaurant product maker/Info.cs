using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_product_maker
{
    internal class Info
    {
        public Dictionary<string, float> Nutritional_info { get; set; }
        public float Price { get; set; }
        public int Prep_time { get; set; }
        public int Parallel_time { get; set; }
        public int Batch_time { get; set; }
        public List<string> Ingredients { get; set; }
        public List<string> Alergens{ get; set; }
        public List<string> Warnings { get; set; }
        public List<string> Tags { get; set; }

        public Info()
        {
            Nutritional_info = new Dictionary<string, float>();
            Nutritional_info.Add("Calories",0);
            Nutritional_info.Add("Total_fat",0);
            Nutritional_info.Add("Saturated_fat",0);
            Nutritional_info.Add("Sugars",0);
            Nutritional_info.Add("Salt",0);

            Ingredients = new List<string>();
            Alergens = new List<string>();
            Warnings = new List<string>();
            Tags = new List<string>();
        }
    }
}
