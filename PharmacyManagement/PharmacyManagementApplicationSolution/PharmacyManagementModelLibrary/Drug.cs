namespace PharmacyManagementModelLibrary
{
    public class Drug
    {
        public int DrugId { get; set; }
        public string DrugName { get; set; }
        public string BrandName { get; set; }
        public string DosageForm { get; set; }
        public int Strength { get; set; }
        public int StockQuantity { get; set; }
        public DateTime ExpiryDate { get; set; }
        public double Price { get; set; }

        /// <summary>
        /// Default Constructor for Drug class
        /// </summary>
        public Drug()
        {
            DrugId = 0;
            DrugName = string.Empty;
            BrandName = string.Empty;
            DosageForm = string.Empty;
            Strength = 0;
            StockQuantity = 0;
            ExpiryDate = new DateTime();
            Price = 0;
        }

        /// <summary>
        /// Parameterised constructor for Drug class
        /// </summary>
        /// <param name="drugName">Name of the drug as a string</param>
        /// <param name="brandName">Brand of the drug as a string</param>
        /// <param name="dosageForm">Doasge form of the drug as string</param>
        /// <param name="strength">Strength of the drug as integer</param>
        /// <param name="stockQuantity">Quantity of the drug in stock as integer</param>
        /// <param name="expiryDate">Expiry Date of the drug as Date</param>
        /// <param name="price">Price of the drug as double</param>
        public Drug(string drugName, string brandName, string dosageForm, int strength, int stockQuantity, DateTime expiryDate, double price)
        {
            DrugName = drugName;
            BrandName = brandName;
            DosageForm = dosageForm;
            Strength = strength;
            StockQuantity = stockQuantity;
            ExpiryDate = expiryDate;
            Price = price;
        }

        /// <summary>
        /// Build a Drug Object from the console using user inputs
        /// </summary>
        public void BuildDrugFromConsole()
        {
            Console.WriteLine("Enter the name of the drug:");
            DrugName = Console.ReadLine() ?? "";
            Console.WriteLine("Enter the brand name of the drug:");
            BrandName = Console.ReadLine() ?? "";
            Console.WriteLine("Enter the dosage form of the drug:");
            DosageForm = Console.ReadLine() ?? "";
            Console.WriteLine("Enter the strength of the drug:");
            Strength = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the quantity of drug in stock:");
            StockQuantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Expiry Date of the drug:");
            ExpiryDate = Convert.ToDateTime(Console.ReadLine());
        }

        /// <summary>
        /// Override of the ToString method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Drug ID: " + DrugId
                + "\nDrug Name: " + DrugName
                + "\nBrand Name: " + BrandName
                + "\nDosage Form: " + DosageForm
                + "\nStrength: " + Strength
                + "\nStock Quantity: " + StockQuantity
                + "\nExpiry Date: " + ExpiryDate;
        }

        /// <summary>
        /// Override of the Equals method
        /// </summary>
        /// <param name="obj">Drug object to compared</param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            Drug d1, d2;
            d1 = this;
            Drug? drug = obj as Drug;
            d2 = drug;
            return d1.DrugId.Equals(d2.DrugId);
        }
    }
}
