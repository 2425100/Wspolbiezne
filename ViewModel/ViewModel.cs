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
        //api modelu
        //api logiki
        private ModelAbstract model;
        //private AbstractLogicAPI logic;
       // private int canvasPositionX;
       // private int canvasPositionY;
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


        
//public ICommand Restart { get; set; }

      /*  public int CanvasPositionX
        {
            get { return canvasPositionX; }
            set 
            { 
                canvasPositionX = value; 
                OnPropertyChanged(nameof(canvasPositionX));
            }
        }
        public int CanvasPositionY
        {
            get { return canvasPositionY; }
            set
            {
                canvasPositionY = value;
                OnPropertyChanged(nameof(canvasPositionY));
            }
        }*/
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
            //model.getSphereModels().Clear();
            model.start(750, 350, SphereCount);
            //this.sphereModels=model.getSphereModels();
            this.SphereModels=model.getSphereModels();

            
        }






        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
