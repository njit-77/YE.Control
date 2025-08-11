using System;
using System.Threading.Tasks;
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
            if (timer == null)
            {
                timer = new System.Threading.Timer(
                    (obj) =>
                    {
                        if (ServerLEDType == UserControls.StatusType.OffLine)
                        {
                            ServerLEDType = UserControls.StatusType.OnLine_OK;
                        }
                        else if (ServerLEDType == UserControls.StatusType.OnLine_OK)
                        {
                            ServerLEDType = UserControls.StatusType.OnLine_Error;
                        }
                        else if (ServerLEDType == UserControls.StatusType.OnLine_Error)
                        {
                            ServerLEDType = UserControls.StatusType.OffLine;
                        }

                        if (ClientLEDType == UserControls.StatusType.OffLine)
                        {
                            ClientLEDType = UserControls.StatusType.OnLine_OK;
                        }
                    },
                    null,
                    5_000,
                    5_000
                );
            }

            Task.Delay(3_000)
                .ContinueWith(_ =>
                {
                    throw new Exception("Exception From MainViewModel 3_000");
                });
            App.Current.GetService<IServers.ILogger>().Info("测试");
            App.Current.GetService<IServers.ILogger>().Info("Test");
            App.Current.GetService<IServers.ILogger>().Info("테스트");
            App.Current.GetService<IServers.ILogger>().Info("テスト");
        }

        [ObservableProperty]
        private string serverIP = "192.168.0.5";

        [ObservableProperty]
        private int serverPort = 8501;

        [RelayCommand]
        public void SaveIP()
        {
            System.Windows.MessageBox.Show(
                $"IP:{ServerIP}, Port:{ServerPort}",
                "Information",
                System.Windows.MessageBoxButton.OK,
                System.Windows.MessageBoxImage.Information
            );
        }

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
        private YE.Control.UserControls.StatusType serverLEDType = YE.Control
            .UserControls
            .StatusType
            .OffLine;

        [ObservableProperty]
        private YE.Control.UserControls.StatusType clientLEDType = YE.Control
            .UserControls
            .StatusType
            .OffLine;
    }
}
