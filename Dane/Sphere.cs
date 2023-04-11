using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dane
{
    public class Sphere : INotifyPropertyChanged
    {
        private double x;
        private double y;
        private double radius;
        private double xspeed;
        private double yspeed;
        private double mass;

        public double Mass
        {
            get => mass;
            set => mass = value;
        }

        public Sphere(double x, double y, double radius, double mass)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
            this.mass = mass;
            randomizeSpeed();
        }

        public double Yspeed
        {
            get => yspeed;
            set
            {
                if (value.Equals(Yspeed)) return;
                yspeed = value;
                OnPropertyChanged();
            }
        }

        public double Xspeed
        {
            get => xspeed;
            set
            {
                if (value.Equals(Xspeed)) return;
                xspeed = value;
                OnPropertyChanged();
            }
        }

        public double Radius
        {
            get => radius;
            set
            {
                if (value.Equals(radius)) return;
                radius = value;
                OnPropertyChanged();
            }
        }

        public double Y
        {
            get => y;
            set
            {
                if (value.Equals(y)) return;
                y = value;
                OnPropertyChanged();
            }
        }

        public double X
        {
            get => x;
            set
            {
                if (value.Equals(x)) return;
                x = value;
                OnPropertyChanged();
            }
        }

        public void randomizeSpeed()
        {
            Random random = new Random();
            this.xspeed = random.NextDouble();
            this.yspeed = random.NextDouble();
        }

        public void movement()
        {
            this.X += this.Xspeed;
            this.Y += this.Yspeed;
            OnPropertyChanged("Location");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
}