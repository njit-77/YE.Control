using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace YE.Control.UserControls
{
    /// <summary>
    /// 状态灯信息
    /// <para>
    /// 状态灯有三种状态，[离线(默认Brushes.Gray)、在线正常(默认Brushes.Green,1s一次闪烁)、在线错误(默认Brushes.Red)]
    /// </para>
    /// </summary>
    public partial class StatusLED : UserControl, INotifyPropertyChanged
    {
        public StatusLED()
        {
            InitializeComponent();
        }


        #region DependencyProperty

        /// <summary>
        /// 状态灯信息，Default Value = StatusType.OffLine
        /// </summary>
        public StatusType LEDType
        {
            get { return (StatusType)GetValue(LEDTypeProperty); }
            set { SetValue(LEDTypeProperty, value); }
        }

        public static readonly DependencyProperty LEDTypeProperty = DependencyProperty.Register(
            nameof(LEDType),
            typeof(StatusType),
            typeof(StatusLED),
            new PropertyMetadata(
                StatusType.OffLine,
                (d, e) =>
                {
                    if (d is StatusLED control)
                    {
                        switch (control.LEDType)
                        {
                            case StatusType.OffLine:
                                {
                                    control.StatusColor = control.OffLineColor;
                                    VisualStateManager.GoToElementState(control.ellipse, "OffLine", true);
                                }
                                break;
                            case StatusType.OnLine_OK:
                                {
                                    control.StatusColor = control.OnLineOKColor;
                                    VisualStateManager.GoToElementState(control.ellipse, "OnLineOk", true);
                                }
                                break;
                            case StatusType.OnLine_Error:
                                {
                                    control.StatusColor = control.OnLineErrorColor;
                                    VisualStateManager.GoToElementState(control.ellipse, "OnLineError", true);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
            )
        );


        /// <summary>
        ///  状态灯信息，Default Value = Empty
        /// </summary>
        public string StatusText
        {
            get { return (string)GetValue(StatusTextProperty); }
            set { SetValue(StatusTextProperty, value); }
        }

        public static readonly DependencyProperty StatusTextProperty = DependencyProperty.Register(
            nameof(StatusText),
            typeof(string),
            typeof(StatusLED),
            new PropertyMetadata(string.Empty)
        );


        /// <summary>
        /// 状态灯离线颜色，Default Value = Brushes.Gray
        /// </summary>
        public Brush OffLineColor
        {
            get { return (Brush)GetValue(OffLineColorProperty); }
            set { SetValue(OffLineColorProperty, value); }
        }

        public static readonly DependencyProperty OffLineColorProperty =
            DependencyProperty.Register(
                nameof(OffLineColor),
                typeof(Brush),
                typeof(StatusLED),
                new PropertyMetadata(Brushes.Gray)
            );


        /// <summary>
        /// 状态灯在线正常颜色，Default Value = Brushes.Green[默认1s闪烁一次]
        /// </summary>
        public Brush OnLineOKColor
        {
            get { return (Brush)GetValue(OnLineOKColorProperty); }
            set { SetValue(OnLineOKColorProperty, value); }
        }

        public static readonly DependencyProperty OnLineOKColorProperty =
            DependencyProperty.Register(
                nameof(OnLineOKColor),
                typeof(Brush),
                typeof(StatusLED),
                new PropertyMetadata(Brushes.Green)
            );


        /// <summary>
        /// 状态灯在线错误颜色，Default Value = Brushes.Red
        /// </summary>
        public Brush OnLineErrorColor
        {
            get { return (Brush)GetValue(OnLineErrorColorProperty); }
            set { SetValue(OnLineErrorColorProperty, value); }
        }

        public static readonly DependencyProperty OnLineErrorColorProperty =
            DependencyProperty.Register(
                nameof(OnLineErrorColor),
                typeof(Brush),
                typeof(StatusLED),
                new PropertyMetadata(Brushes.Red)
            );

        #endregion


        #region Event

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        #endregion


        #region Property

        private Brush statusColor = Brushes.Gray;
        public Brush StatusColor
        {
            get { return statusColor; }
            set
            {
                if (statusColor != value)
                {
                    statusColor = value;
                    OnPropertyChanged(nameof(StatusColor));
                }
            }
        }

        #endregion

    }

    public enum StatusType
    {
        /// <summary>离线状态</summary>
        OffLine,

        /// <summary>在线正常状态</summary>
        OnLine_OK,

        /// <summary>在线错误状态</summary>
        OnLine_Error,
    }
}
