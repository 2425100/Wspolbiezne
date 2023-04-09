using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Logika
{
    public class Sphere : INotifyPropertyChanged
    {
        private int x;
        private int y;
        private int radius;


        public Sphere(int x, int y, int radius)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }

        public int Radius
        {
            get => radius;
            set
            {
                if (value == radius) return;
                radius = value;
                OnPropertyChanged();
            }
        }

        public int Y
        {
            get => y;
            set
            {
                if (value == y) return;
                y = value;
                OnPropertyChanged();
            }
        }

        public int X
        {
            get => x;
            set
            {
                if (value == x) return;
                x = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
}