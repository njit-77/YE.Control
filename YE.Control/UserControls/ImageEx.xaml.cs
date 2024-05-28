using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace YE.Control.UserControls
{
    /// <summary>
    /// Image自定义控件，添加了缩放拖动功能
    /// <para>
    /// 1、Image.Source = new Bitmap(newUri());
    /// 2、Image.Source = new WriteableBitmap();
    /// eg：WriteableBitmap效率 CopyMemory[kernel32.dll] > RtlMoveMemory[kernel32.dll] > Buffer.MemoryCopy
    /// </para>
    /// </summary>
    public partial class ImageEx : UserControl
    {
        public ImageEx()
        {
            InitializeComponent();
        }


        #region DependencyProperty

        /// <summary>
        /// Border.BorderBrush Default Value = Brushes.LightGray
        /// </summary>
        public Brush MarginColor
        {
            get { return (Brush)GetValue(MarginColorProperty); }
            set { SetValue(MarginColorProperty, value); }
        }

        public static readonly DependencyProperty MarginColorProperty = DependencyProperty.Register(
            nameof(MarginColor),
            typeof(Brush),
            typeof(ImageEx),
            new PropertyMetadata(Brushes.LightGray)
        );

        /// <summary>
        /// Image控件的Source值
        /// </summary>
        public ImageSource ImageExSource
        {
            get { return (ImageSource)GetValue(ImageExSourceProperty); }
            set { SetValue(ImageExSourceProperty, value); }
        }

        public static readonly DependencyProperty ImageExSourceProperty =
            DependencyProperty.Register(
                nameof(ImageExSource),
                typeof(ImageSource),
                typeof(ImageEx),
                new PropertyMetadata(null)
            );

        #endregion


        #region Method

        private const double ZoomOutScaleValue = 1.1;
        private const double ZoomInScaleValue = 1 / ZoomOutScaleValue;
        private Point start;

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is System.Windows.Controls.Image img)
            {
                start = e.GetPosition(img);
            }
        }

        private void Image_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is System.Windows.Controls.Image img)
            {
                Matrix m = img.RenderTransform.Value;

                m.M11 = m.M22 = 1;
                m.M12 = m.M21 = 0;
                m.OffsetX = m.OffsetY = 0;

                img.RenderTransform = new MatrixTransform(m);
            }
        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            if (
                sender is System.Windows.Controls.Image img
                && e.LeftButton == MouseButtonState.Pressed
            )
            {
                var control = img.Parent as FrameworkElement;

                Point p = e.GetPosition(img);
                Matrix m = img.RenderTransform.Value;

                SetImageBorder(ref m, p, img, control);
                img.RenderTransform = new MatrixTransform(m);
            }
        }

        private void Image_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (sender is System.Windows.Controls.Image img)
            {
                var control = img.Parent as FrameworkElement;

                Point p = e.GetPosition(img);
                Matrix m = img.RenderTransform.Value;
                if (e.Delta > 0)
                    m.ScaleAtPrepend(ZoomOutScaleValue, ZoomOutScaleValue, p.X, p.Y);
                else
                    m.ScaleAtPrepend(ZoomInScaleValue, ZoomInScaleValue, p.X, p.Y);

                img.RenderTransform = new MatrixTransform(m);
            }
        }

        private void SetImageBorder(
            ref Matrix m,
            Point p,
            System.Windows.Controls.Image img,
            FrameworkElement control
        )
        {
            double parentW = img.ActualWidth; /*容器控件宽*/
            double parentH = img.ActualHeight; /*容器控件高*/
            double xCount = parentW * m.M11; /*当前图像宽*/
            double yCount = parentH * m.M22; /*当前图像高*/
            double xLeft = (img.ActualWidth - control.ActualWidth) * 0.5; /*容器与图像宽的差*/
            double xRight = control.ActualWidth - xCount + xLeft; /*容器与图像宽的差*/
            double yUp = (img.ActualHeight - control.ActualHeight) * 0.5; /*容器与图像高的差*/
            double yBottom = control.ActualHeight - yCount + yUp; /*容器与图像高的差*/
            double diffX = (p.X - start.X); /*当前申请的平移X分量*/
            double diffY = (p.Y - start.Y); /*当前申请的平移Y分量*/
            if (img.ActualWidth * m.M11 > control.ActualWidth)
            {
                if (m.OffsetX + diffX < xRight)
                {
                    m.OffsetX = xRight;
                }
                else if (m.OffsetX + diffX > xLeft)
                {
                    m.OffsetX = xLeft;
                }
                else
                {
                    m.OffsetX += diffX;
                }
            }
            if (img.ActualHeight * m.M22 > control.ActualHeight)
            {
                if (m.OffsetY + diffY < yBottom)
                {
                    m.OffsetY = yBottom;
                }
                else if (m.OffsetY + diffY > yUp)
                {
                    m.OffsetY = yUp;
                }
                else
                {
                    m.OffsetY += diffY;
                }
            }
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.SizeAll;
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        #endregion

    }
}
