using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace xBountyHunter.NativeViews
{
    public class NativeSwitchViewModel : INotifyPropertyChanged
    {
        bool isSwitchOn;
        public bool IsSwitchOn
        {
            get { return isSwitchOn; }
            set
            {
                if(isSwitchOn != value)
                {
                    isSwitchOn = value;
                    OnPropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
