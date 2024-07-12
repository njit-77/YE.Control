# YE.Control
YE.Control是一个基于WPF框架的控件库。



## UserControl

#### IP  IP地址控件，可绑定IP地址、端口号。IP端口号通过'HasPort'设置启用与否。

###### 依赖属性

```csharp
/// IP地址，Default Value = "127.0.0.1"
string IPAddress;

/// 是否有端口号，Default Value = false
bool HasPort;
    
/// IP端口号，Default Value = 8501
int IPPort;
```

###### 样例

```xaml
xmlns:yecontrol="clr-namespace:YE.Control.UserControls;assembly=YE.Control"

<yecontrol:IP Width="240"
              Height="30"
              Margin="5"
              HorizontalAlignment="Left"
              HasPort="{Binding ElementName=IPPort, Path=IsChecked}"
              IPAddress="{Binding ServerIP}"
              IPPort="{Binding ServerPort}"
              BorderBrush="LightGreen"
              BorderThickness="1" />
```

![](https://github.com/njit-77/YE.Control/blob/6d3fa61f8a2f0cc2b20d9d17da7a3ab8035c19b1/Image/IP.gif)

#### ImageEx  图像显示控件，基于System.Windows.Controls.Image控件增加了图像缩放、拖动、鼠标点击事件[右键单击-图像大小还原]

###### 依赖属性

```csharp
/// Image控件边框颜色 Default Value = Brushes.LightGray
System.Windows.Media.Brush MarginColor;

/// 图像内容
ImageSource ImageExSource;
```

###### 样例

```xaml
xmlns:yecontrol="clr-namespace:YE.Control.UserControls;assembly=YE.Control"

<yecontrol:ImageEx Height="300"
                   BorderBrush="LightGreen"
                   BorderThickness="3"
                   ImageExSource="{Binding ImagePathUri}" />
```

![](https://github.com/njit-77/YE.Control/blob/6d3fa61f8a2f0cc2b20d9d17da7a3ab8035c19b1/Image/ImageEx.gif)



#### StatueLED 状态灯控件，用于显示网络状态或其它状态

###### 依赖属性

```csharp
public enum StatusType
{
    /// <summary>离线状态</summary>
    OffLine,

    /// <summary>在线正常状态</summary>
    OnLine_OK,

    /// <summary>在线错误状态</summary>
    OnLine_Error,
}
/// 状态灯信息，Default Value = StatusType.OffLine
StatusType LEDType;
    
/// 状态灯信息，Default Value = Empty   
string StatusText;

/// 状态灯离线颜色，Default Value = Brushes.Gray
System.Windows.Media.Brush OffLineColor;

/// 状态灯在线正常颜色，Default Value = Brushes.Green[默认1s闪烁一次]
System.Windows.Media.Brush OnLineOKColor;

/// 状态灯在线错误颜色，Default Value = Brushes.Red
System.Windows.Media.Brush OnLineErrorColor;
```

###### 样例

```xaml
xmlns:yecontrol="clr-namespace:YE.Control.UserControls;assembly=YE.Control"

<yecontrol:StatusLED Margin="5"
                     HorizontalAlignment="Left"
                     StatusText="服务器"
                     LEDType="{Binding ServerLEDType}"
                     OffLineColor="Orange"
                     OnLineOKColor="LightGreen"
                     OnLineErrorColor="OrangeRed"/>
<yecontrol:StatusLED Margin="5"
                     HorizontalAlignment="Left"
                     StatusText="客户端"
                     LEDType="{Binding ClientLEDType}" />
```

![](https://github.com/njit-77/YE.Control/blob/6d3fa61f8a2f0cc2b20d9d17da7a3ab8035c19b1/Image/StatusLED.gif)
