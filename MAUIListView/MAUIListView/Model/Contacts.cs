using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIListView
{
    public class Contacts : INotifyPropertyChanged
    {
        #region Fields

        private string? contactName;
        private string? group;
        private string? contactNumber;

        #endregion

        #region Constructor

        public Contacts()
        {
        }

        #endregion

        #region Properties
        public string? ContactName
        {
            get { return contactName; }
            set
            {
                if (contactName != value)
                {
                    contactName = value;
                    this.RaisedOnPropertyChanged("ContactName");
                }
            }
        }
        public string? Group
        {
            get { return group; }
            set
            {
                if (group != value)
                {
                    group = value;
                    this.RaisedOnPropertyChanged("Group");
                }
            }
        }

        public string? ContactNumber
        {
            get { return contactNumber; }
            set
            {
                if (contactNumber != value)
                {
                    contactNumber = value;
                    this.RaisedOnPropertyChanged("ContactNumber");
                }
            }
        }
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
