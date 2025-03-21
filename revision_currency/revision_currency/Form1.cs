namespace revision_currency
{
    public partial class Form1 : Form
    {
        private Dictionary<string, double> exchangeRates = new Dictionary<string, double>()
        {
            { "USD_TO_EUR", 0.85 },
            { "EUR_TO_USD", 1.18 },
            { "USD_TO_GBP", 0.75 },
            { "GBP_TO_USD", 1.33 },
            { "EUR_TO_GBP", 0.88 },
            { "GBP_TO_EUR", 1.14 }
        };

        public Form1()
        {
            InitializeComponent();
            LoadCurrencies();
        }

        private void LoadCurrencies()
        {
            comboBox1.Items.AddRange(new string[] { "USD", "EUR", "GBP" });
            comboBox2.Items.AddRange(new string[] { "USD", "EUR", "GBP" });
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double amount) && amount >= 0)
            {
                string fromCurrency = comboBox1.SelectedItem.ToString();
                string toCurrency = comboBox2.SelectedItem.ToString();
                string key = $"{fromCurrency}_TO_{toCurrency}";

                if (fromCurrency == toCurrency)
                {
                    label2.Text = $"Converted Amount: {amount:F2} {toCurrency}";
                }
                else if (exchangeRates.ContainsKey(key))
                {
                    double convertedAmount = amount * exchangeRates[key];
                    label2.Text = $"Converted Amount: {convertedAmount:F2} {toCurrency}";
                }
                else
                {
                    label2.Text = "Exchange rate not available.";
                }
            }
            else
            {
                label2.Text = "Please enter a valid amount.";
            }
        }
    }
}
