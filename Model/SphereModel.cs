using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Logika;

namespace Model
{
    public class SphereModel:INotifyPropertyChanged
    {
        private double[] dimensions=new double[2];
        private double radius;
         public SphereModel(SphereLogic sphere)
        {
            dimensions[0] = sphere.X;
            dimensions[1] = sphere.Y;
            radius = sphere.Radius;
            sphere.PropertyChanged += Update;
        }
        private void Update(object source,PropertyChangedEventArgs property)
        {
            SphereLogic sphere = (SphereLogic)source;
            switch (property.PropertyName)
            {
                case "X":
                    this.X = sphere.X;
                    break;
                case "Y":
                    this.Y = sphere.Y;
                    break;
                case "Radius": 
                    this.Radius = sphere.Radius;
                    break;
            }

        }
        public double X
        {
            get { return dimensions[0]; }
            set 
            {
                dimensions[0] = value; 
                OnPropertyChanged(nameof(X));
                
            }
        }
        public double Y
        {
            get { return dimensions[1]; }
            set
            {
                dimensions[1] = value;
                OnPropertyChanged(nameof(Y));

            }
        }
        public double Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                OnPropertyChanged(nameof(Radius));

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
