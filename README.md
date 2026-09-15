# How to show empty view in a group without items in .NET MAUI ListView?

You can display an empty view in a group without items in [.NET MAUI ListView](https://www.syncfusion.com/maui-controls/maui-listview) by handling the visibility of the view within the [GroupHeaderTemplate](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.ListView.SfListView.html#Syncfusion_Maui_ListView_SfListView_GroupHeaderTemplate).

**Step 1:** When a group has no items, add dummy items to make the group header visible and set the dummy item height to 0.
```
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

 private void ListView_QueryItemSize(object sender, QueryItemSizeEventArgs e)
 {
     // set item size as 0 for dummy item to make invisible in view.
     var item = e.DataItem as Contacts;
     if (item != null && item.ContactName == "")
     {
         e.ItemSize = 0;
         e.Handled = true;
     }
 }
```

**Step 2:** Change the visibility and HeightRequest of an EmptyView grid inside the GroupHeaderTemplate based on the item count in the group.

```
<listView:SfListView.GroupHeaderTemplate>
    <DataTemplate>
        <Grid BackgroundColor="Teal" RowDefinitions="Auto,Auto" ColumnDefinitions="*,Auto">
            <Label Text="{Binding Key}"
                    FontSize="22"
                    TextColor="White"
                    FontAttributes="Bold"
                    VerticalOptions="Center"
                    Margin="10,0,0,0" />
            <Image Grid.Column="1" Source="addcontact.png" Margin="0,0,20,0"
                   HeightRequest="20" WidthRequest="20">
                <Image.GestureRecognizers>
                    <TapGestureRecognizer Tapped="AddContact_Tapped" CommandParameter="{Binding .}"/>
                </Image.GestureRecognizers>
            </Image>
            <Grid x:Name="groupEmptyView" BackgroundColor="LightCoral" Grid.Row="1"
                  IsVisible="{Binding . , Converter= {StaticResource EmptyViewHeightConverter}}" 
                  HeightRequest="{Binding ., Converter={StaticResource EmptyViewHeightConverter}}">

                <Label VerticalOptions="Center" VerticalTextAlignment="Center"
                       HorizontalOptions="Center" HorizontalTextAlignment="Center"
                       Text="No Items"/>
            </Grid>
        </Grid>                    
    </DataTemplate>
</listView:SfListView.GroupHeaderTemplate>
```

![emptyview-group.jpg](https://support.syncfusion.com/kb/attachment/article/16513/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjI1MDQ1Iiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.V4c52E-LXVJLzzIly4urzfyBjj0PF13Aukg2knVfkuU)

Download the complete sample from [GitHub](https://github.com/SyncfusionExamples/how-to-show-empty-view-in-a-group-without-items-in-.net-maui-listview).

**Conclusion:**

I hope you enjoyed learning how to show an empty view in a group without items in .NET MAUI ListView.

You can refer to our [.NET MAUI ListView feature tour](https://www.syncfusion.com/maui-controls/maui-listview) page to know about its other groundbreaking feature representations and [documentation](https://help.syncfusion.com/maui/listview/getting-started), and how to quickly get started with configuration specifications.

For current customers, check out our components from the [License and Downloads page](https://www.syncfusion.com/sales/teamlicense). If you are new to Syncfusion®, try our 30-day [free trial](https://www.syncfusion.com/downloads/maui) to check out our other controls.

Please let us know in the comments section if you have any queries or require clarification. You can also contact us through our [support forums](https://www.syncfusion.com/forums/), [Direct-Trac](https://support.syncfusion.com/create), or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sflistview). We are always happy to assist you!
