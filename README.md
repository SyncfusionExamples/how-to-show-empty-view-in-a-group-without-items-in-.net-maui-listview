# how-to-show-empty-view-in-a-group-without-items-in-.net-maui-listview

This example demonstrate how to show empty view in a group without items in .NET MAUI ListView.

## Sample

```xaml
<ContentPage.Resources>
    <ResourceDictionary>
        <local:EmptyViewHeightConverter x:Key="EmptyViewHeightConverter" />
        <local:EmptyViewVisibilityConverter x:Key="EmptyViewVisibilityConverter" />
    </ResourceDictionary>
</ContentPage.Resources>

<ContentPage.Content>
    <listView:SfListView
        x:Name="listView"
        AutoFitMode="DynamicHeight"
        ItemTapped="listView_ItemTapped"
        ItemsSource="{Binding ContactsInfo}"
        SelectionBackground="Transparent">
        <listView:SfListView.ItemsLayout>
            <listView:GridLayout SpanCount="3" />
        </listView:SfListView.ItemsLayout>

        <listView:SfListView.GroupHeaderTemplate>
            <DataTemplate>
                <Grid
                    BackgroundColor="Teal"
                    ColumnDefinitions="*,Auto"
                    RowDefinitions="Auto,Auto">
                    <Label
                        Margin="10,0,0,0"
                        FontAttributes="Bold"
                        FontSize="22"
                        Text="{Binding Key}"
                        TextColor="White"
                        VerticalOptions="Center" />
                    <Image
                        Grid.Column="1"
                        Margin="0,0,20,0"
                        HeightRequest="20"
                        Source="addcontact.png"
                        WidthRequest="20">
                        <Image.GestureRecognizers>
                            <TapGestureRecognizer CommandParameter="{Binding .}" Tapped="AddContact_Tapped" />
                        </Image.GestureRecognizers>
                    </Image>
                    <Grid
                        x:Name="groupEmptyView"
                        Grid.Row="1"
                        Grid.ColumnSpan="2"
                        BackgroundColor="LightCoral"
                        HeightRequest="{Binding ., Converter={StaticResource EmptyViewHeightConverter}}"
                        IsVisible="{Binding ., Converter={StaticResource EmptyViewHeightConverter}}">

                        <Label
                            HorizontalOptions="Center"
                            HorizontalTextAlignment="Center"
                            Text="No Items"
                            VerticalOptions="Center"
                            VerticalTextAlignment="Center" />
                    </Grid>
                </Grid>
            </DataTemplate>
        </listView:SfListView.GroupHeaderTemplate>

        <listView:SfListView.ItemTemplate>
            <DataTemplate>
                ...
            </DataTemplate>
        </listView:SfListView.ItemTemplate>
    </listView:SfListView>
</ContentPage.Content>
```

```c#
public MainPage()
{
    InitializeComponent();
    listView.QueryItemSize += ListView_QueryItemSize;
    listView.DataSource!.SourceCollectionChanged += DataSource_SourceCollectionChanged;
    listView.DataSource!.GroupDescriptors.Add(new GroupDescriptor()
    {
        PropertyName = "Group",
        KeySelector = (object obj1) =>
        {
            var item = (obj1 as Contacts);
            return item!.Group!;
        },
    });
}

private void ListView_QueryItemSize(object? sender, QueryItemSizeEventArgs e)
{
    var item = e.DataItem as Contacts;
    if (item != null && item.ContactName == "")
    {
        e.ItemSize = 0;
        e.Handled = true;
    }
}

private void DataSource_SourceCollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
{
    if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add || e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
    {
        listView.RefreshItem(-1, -1, true);
    }
}

private void AddContact_Tapped(object sender, TappedEventArgs e)
{
    var groupResult = e.Parameter as GroupResult;
    foreach (var item in groupResult!.Items)
    {
        if ((item as Contacts)?.ContactName == "")
        {
            viewModel.ContactsInfo!.Remove(item as Contacts);
        }
    }
    var contact = new Contacts() { ContactName = "New Contact", Group = groupResult.Key.ToString(), ContactNumber = "9876543210" };
    viewModel.ContactsInfo!.Add(contact);
}

private void listView_ItemTapped(object sender, Syncfusion.Maui.ListView.ItemTappedEventArgs e)
{
    var item = e.DataItem as Contacts;
    GroupResult group = null;

    if (item != null)
    {
        foreach (var a in this.listView.DataSource!.Groups)
        {
            if (a.Key.ToString() == item.Group)
            {
                group = a;
                break;
            }
        }

        if (group!.Count == 1 && item.ContactName != "")
        {
            var record = new Contacts() { ContactName = "", ContactNumber = ""};
            record.Group = item.Group;
            viewModel.ContactsInfo!.Add(record);
        }

        if (item.ContactName != "")
        {
            viewModel.ContactsInfo!.Remove(item);
        }
    }
}
```

```c#
public class EmptyViewHeightConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var groupresult = value as GroupResult;
        var listView = parameter as SfListView;
        if (groupresult != null)
        {
            foreach (var item in groupresult.Items)
            {
                if ((item as Contacts)!.ContactName == "")
                {
                    return 100;
                }
                else
                {
                    return 0;
                }
            }

            return 0;
        }
        else
        {
            return 0;
        }
    }
}

public class EmptyViewVisibilityConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if( value != null)
        {
            var groupresult = value as GroupResult;
            if (groupresult != null)
            {
                foreach (var item in groupresult.Items)
                {
                    if ((item as Contacts)!.ContactName == "")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                return false;
            }               
        }
        
        return false;
    }
}
```

## Requirements to run the demo

* [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/) or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/)
* Xamarin add-ons for Visual Studio (available via the Visual Studio installer).

## Troubleshooting

### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.
