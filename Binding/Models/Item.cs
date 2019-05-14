using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Binding.Models
{
    public class Item : INotifyPropertyChanged
    {
        private string _name;

        public int Id { get; set; }
        public string Name {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                ChangePropertyData("Name");
            }
        }
        public int Price { get; set; }
        public string Description { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void ChangePropertyData([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
