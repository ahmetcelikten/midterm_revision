using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace revision_eventScheduler
{
    public partial class Form1 : Form
    {

        private string savedEventDetails = "";
        public Form1()
        {
            InitializeComponent();
            btnSave.Click += (s, e) => SaveEvent();
            btnPrint.Click += (s, e) => PrintEvent();
            printDocument1.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
        }

        private void SaveEvent()
        {
            string eventDate = dateTimePicker.Value.ToString("dd/MM/yyyy HH:mm");
            string eventDescription = txtDescription.Text;

            if (string.IsNullOrWhiteSpace(eventDescription))
            {
                MessageBox.Show("Lütfen etkinlik açıklamasını girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            savedEventDetails = $"Etkinlik Tarihi: {eventDate}\nAçıklama: {eventDescription}";

            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "event.txt");
            File.WriteAllText(filePath, savedEventDetails);

            File.WriteAllText("event.txt", savedEventDetails);
            MessageBox.Show($"Dosya kaydedildi: {filePath}");

            MessageBox.Show("Etkinlik başarıyla kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PrintEvent()
        {
            if (string.IsNullOrWhiteSpace(savedEventDetails))
            {
                MessageBox.Show("Önce bir etkinlik kaydedin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(savedEventDetails))
            {
                e.Graphics.DrawString(savedEventDetails, new Font("Arial", 12), Brushes.Black, new PointF(100, 100));
            }
        }
    }

}
