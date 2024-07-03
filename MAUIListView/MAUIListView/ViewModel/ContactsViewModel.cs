using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MAUIListView
{
    public class ContactsViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<Contacts>? contactsinfo;

        #endregion

        #region Properties
        public ObservableCollection<Contacts>? ContactsInfo
        {
            get { return contactsinfo; }
            set { contactsinfo = value; RaisedOnPropertyChanged("ContactsInfo"); }
        }    
        #endregion

        #region Constructor

        public ContactsViewModel()
        {
            Random random = new Random();
            ContactsInfo = new ObservableCollection<Contacts>();
            for (int i = 0; i < 20; i++)
            {
                var contact = new Contacts();              
                if(i%2 == 0)
                {                    
                    contact.ContactName = CustomerNames[i];
                    contact.ContactNumber = random.Next(1234567890, 1876543210).ToString();
                    contact.Group = "PERSONAL";
                }
                else
                {
                    contact.ContactName = "";
                    contact.ContactNumber = "";
                    contact.Group = "BUSINESS";
                }

                ContactsInfo.Add(contact);
            }
        }

        #endregion

        #region Collection

        private string[] CustomerNames = new string[]
        {
            "Kyle",
            "Gina",
            "Irene",
            "Katie",
            "Michael",
            "Oscar",
            "Ralph",
            "Torrey",
            "William",
            "Bill",
            "Daniel",
            "Frank",
            "Brenda",
            "Danielle",
            "Fiona",
            "Howard",
            "Jack",
            "Larry",
            "Holly",
            "Jennifer",
            "Liz",
            "Pete",
            "Steve",
            "Vince",
            "Zeke",
            "Aiden",
            "Jackson",
            "Mason",
            "Liam",
            "Jacob",
            "Jayden",
            "Ethan",
            "Noah",
            "Lucas",
            "Logan",
            "Caleb",
            "Caden",
            "Jack",
            "Ryan",
            "Connor",
            "Michael",
            "Elijah",
            "Brayden",
            "Benjamin",
            "Nicholas",
            "Alexander",
            "William",
            "Matthew",
            "James",
            "Landon",
            "Nathan",
            "Dylan",
            "Evan",
            "Luke",
            "Andrew",
            "Gabriel",
            "Gavin",
            "Joshua",
            "Owen",
            "Daniel",
            "Carter",
            "Tyler",
            "Cameron",
            "Christian",
            "Wyatt",
            "Henry",
            "Eli",
            "Joseph",
            "Max",
            "Isaac",
            "Samuel",
            "Anthony",
            "Grayson",
            "Zachary",
            "David",
            "Christopher",
            "John",
            "Isaiah",
            "Levi",
            "Jonathan",
            "Oliver",
            "Chase",
            "Cooper",
            "Tristan",
            "Colton",
            "Austin",
            "Colin",
            "Charlie",
            "Dominic",
            "Parker"
        };

        #endregion

        #region NotifyEvent

        public event PropertyChangedEventHandler? PropertyChanged;

        public void RaisedOnPropertyChanged(string _PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(_PropertyName));
            }
        }

        #endregion
    }
}