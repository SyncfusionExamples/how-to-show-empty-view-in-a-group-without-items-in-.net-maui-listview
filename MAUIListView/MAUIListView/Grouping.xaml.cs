using Syncfusion.Maui.DataSource;
using Syncfusion.Maui.DataSource.Extensions;
using Syncfusion.Maui.ListView;

namespace MAUIListView;

public partial class Grouping : ContentPage
{
	public Grouping()
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
}