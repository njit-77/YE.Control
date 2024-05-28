using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace YE.Control.UserControls
{
    /// <summary>
    /// 状态灯信息
    /// </summary>
    public partial class StatusLED : UserControl
    {
        public StatusLED()
        {
            InitializeComponent();
        }

        #region DependencyProperty

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
        /// 状态灯颜色，Default Value = Brushes.Green
        /// </summary>
        public System.Windows.Media.Brush StatusColor
        {
            get { return (System.Windows.Media.Brush)GetValue(StatusColorProperty); }
            set { SetValue(StatusColorProperty, value); }
        }

        public static readonly DependencyProperty StatusColorProperty = DependencyProperty.Register(
            nameof(StatusColor),
            typeof(System.Windows.Media.Brush),
            typeof(StatusLED),
            new PropertyMetadata(Brushes.Green)
        );

        #endregion
    }
}
