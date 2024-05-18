using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System.Windows.Media.Media3D;
using System;
using YE.Control.UserControls;

namespace YE.Control.Demo
{
    public partial class MainViewModel : ObservableObject
    {
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
                Filter = "所有图片类型|*.png;*.bmp;*.jpg;*.jpeg;*.tiff;*.tif;*.gif|" +
                "PNG (*.png)|*.png|" +
                "BMP(*.bmp)|*.bmp|" +
                "JPEG(*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                "TIFF(*.tiff;*.tif)|*.tiff;*.tif|" +
                "GIF(*.gif)|(*.gif)",
            };
            Nullable<bool> result = openFileDialog.ShowDialog();
            if (result == true)
            {
                ImagePathUri = openFileDialog.FileName;
            }
        }
    }
}
