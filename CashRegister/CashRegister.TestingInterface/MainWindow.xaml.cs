using CashRegister.FileProcessing.Services.Interfaces;
using Microsoft.Win32;
using System.Windows;

namespace CashRegister.TestingInterface
{
    public partial class MainWindow : Window
    {
        private IFileProcessingService _fileProcessingService;
        public MainWindow(IFileProcessingService fileProcessingService)
        {
            _fileProcessingService = fileProcessingService;
            InitializeComponent();
        }
        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = ".csv";
            fileDialog.Filter = "CSV File (.csv)|*.csv";

            if (fileDialog.ShowDialog() ?? false)
            {
                txtFilename.Text = fileDialog.FileName;
                btnSubmit.IsEnabled = true;
            }
            else
            {
                txtFilename.Text = string.Empty;
                btnSubmit.IsEnabled = false;
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (txtFilename.Text.Length == 0)
                return;

            var sr = new System.IO.StreamReader(txtFilename.Text);
            var result = _fileProcessingService.ProcessFile(sr.BaseStream);
            txtOutput.Text = result?.ToString() ?? string.Empty;
            
        }
    }
}