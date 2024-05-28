using System;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;

namespace YE.Control.Demo
{
    public partial class MainViewModel : ObservableObject
    {
        private System.Threading.Timer timer;

        public MainViewModel()
        {
            timer = new System.Threading.Timer(
                (obj) =>
                {
                    if (ServerLEDColor == Brushes.Green)
                    {
                        ServerLEDColor = Brushes.Red;
                    }
                    else if (ServerLEDColor == Brushes.Red)
                    {
                        ServerLEDColor = Brushes.Green;
                    }

                    if (ClientLEDColor == Brushes.Green)
                    {
                        ClientLEDColor = Brushes.Red;
                    }
                    else if (ClientLEDColor == Brushes.Red)
                    {
                        ClientLEDColor = Brushes.Green;
                    }
                },
                null,
                5_000,
                5_000
            );
        }

        [ObservableProperty]
        private string serverIP = "192.168.0.5";

        [ObservableProperty]
        private int serverPort = 8501;

        [ObservableProperty]
        private string imagePathUri;

        [RelayCommand]
        public void SelectImage()
        {
            var openFileDialog = new OpenFileDialog()
            {
                Filter =
                    "所有图片类型|*.png;*.bmp;*.jpg;*.jpeg;*.tiff;*.tif;*.gif|"
                    + "PNG (*.png)|*.png|"
                    + "BMP(*.bmp)|*.bmp|"
                    + "JPEG(*.jpg;*.jpeg)|*.jpg;*.jpeg|"
                    + "TIFF(*.tiff;*.tif)|*.tiff;*.tif|"
                    + "GIF(*.gif)|(*.gif)",
            };
            Nullable<bool> result = openFileDialog.ShowDialog();
            if (result == true)
            {
                ImagePathUri = openFileDialog.FileName;
            }
        }

        [ObservableProperty]
        private System.Windows.Media.Brush serverLEDColor = System.Windows.Media.Brushes.Green;

        [ObservableProperty]
        private System.Windows.Media.Brush clientLEDColor = System.Windows.Media.Brushes.Green;
    }
}
