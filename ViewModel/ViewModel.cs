using Logika;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        
        private ModelAbstract model;
        private int sphereCount;
        private ObservableCollection<SphereModel> sphereModels = new ObservableCollection<SphereModel>();
        public ICommand Start { get; set; }

        public ICommand Stop { get; set; }
        public ViewModel()
        {
            AbstractLogicAPI logicAPI =AbstractLogicAPI.CreateAPI();
            model = ModelAbstract.createApi(logicAPI);
            Start = new RelayCommand(() => start());
            Stop = new RelayCommand(() => stop());
        }


        

        public int SphereCount
        {
            get { return sphereCount; }
            set
            {
                sphereCount = value;
                OnPropertyChanged(nameof(sphereCount));
            }
        }
        public ObservableCollection<SphereModel> SphereModels
        {
            get {
                
                return sphereModels;
                
            }
            set { sphereModels = value; OnPropertyChanged(nameof(SphereModels)); }
        }
        public void stop()
        {
            model.stop();
        }
        public void start()
        {
            
            model.start(750, 350, SphereCount);
           
            this.SphereModels=model.getSphereModels();

            
        }






        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
