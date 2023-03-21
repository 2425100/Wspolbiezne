using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace ViewModel
{
    using Model;
    
    public class GreeterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Greeter greeter=new Greeter();

        public GreeterViewModel()
        {
            UpdateTextCommand = new RelayCommand(new Action<object>(UpdateText));
        }
        public void UpdateText(object obj)
        {
            greeter.setText(obj as string);
        }
        public string text {
            get
            {
                return greeter.getText();
            }
            set
            {
                greeter.setText(value);
                onPropertyChanged(nameof(text));
                
            }
        }

        private void onPropertyChanged(string name)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        public ICommand UpdateTextCommand { get; set; }
        
        
    }
}
