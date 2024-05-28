# YE.Control
YE.Control是一个基于WPF框架的控件库。



## UserControl

#### IP  IP地址控件，可绑定IP地址、端口号。IP端口号通过'HasPort'设置启用与否。

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

#### ImageEx  图像显示控件，基于System.Windows.Controls.Image控件增加了图像缩放、拖动、鼠标点击事件[右键单击-图像大小还原]

```xaml
xmlns:yecontrol="clr-namespace:YE.Control.UserControls;assembly=YE.Control"

<yecontrol:ImageEx Height="300"
                   BorderBrush="LightGreen"
                   BorderThickness="3"
                   ImageExSource="{Binding ImagePathUri}" />
```

#### StatueLED 状态灯控件，用于网络状态或其它状态

```xaml
xmlns:yecontrol="clr-namespace:YE.Control.UserControls;assembly=YE.Control"

<yecontrol:StatusLED Margin="5"
                     HorizontalAlignment="Left"
                     StatusText="服务器"
                     StatusColor="{Binding ServerLEDColor}" />
<yecontrol:StatusLED Margin="5"
                     HorizontalAlignment="Left"
                     StatusText="客户端"
                     StatusColor="{Binding ClientLEDColor}" />
```

