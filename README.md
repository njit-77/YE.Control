# YE.Control
## UserControl

#### IP

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

#### ImageEx

```xaml
xmlns:yecontrol="clr-namespace:YE.Control.UserControls;assembly=YE.Control"

<yecontrol:ImageEx Height="300"
                   BorderBrush="LightGreen"
                   BorderThickness="3"
                   ImageExSource="{Binding ImagePathUri}" />
```

