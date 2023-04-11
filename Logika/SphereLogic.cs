using Dane;
using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Logika
{
    public class SphereLogic : INotifyPropertyChanged
    {
        private Dane.Sphere sphere;
        public SphereLogic(Dane.Sphere sphere)
        {
            this.sphere = sphere;
        }
        public int Radius
        {
            get { return sphere.Radius; }
            set
            {
                sphere.Radius = value;
                OnPropertyChanged(nameof(Radius));
            }
        }
        public int X
        {
            get { return sphere.X; }
            set { sphere.X = value; OnPropertyChanged(nameof(X));}
        }
        public int Y
        {
            get { return sphere.Y; }
            set { sphere.Y = value; OnPropertyChanged( nameof(Y));}
        }
        public int Xspeed
        {
            get { return sphere.Xspeed; }
            set { sphere.Xspeed = value; OnPropertyChanged(nameof(Xspeed));}
        }
        public int Yspeed
        {
            get { return sphere.Yspeed; }
            set { sphere.Yspeed = value; OnPropertyChanged(nameof(Yspeed)); }
            
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        
    }
}