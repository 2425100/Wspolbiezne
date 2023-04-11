using Logika;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class ModelAbstract
    {
        public static ModelAbstract createApi(AbstractLogicAPI logic)
        {
            return new Model(logic);
        }
        public abstract ObservableCollection<SphereModel> getSphereModels();
        public abstract void stop();
        
        public abstract void start(int width, int height, int amount);
        private class Model: ModelAbstract 
        {
            private ObservableCollection<SphereModel> sphereModels=new ObservableCollection<SphereModel>();
            private AbstractLogicAPI logic;
            public Model(AbstractLogicAPI logic)
            {
                this.logic = logic;
            }
            public override ObservableCollection<SphereModel> getSphereModels()
            {
                return sphereModels;
            }
            public override void start(int width, int height, int amount)
            {
                sphereModels.Clear();
                logic.createPlane(width, height, amount);
                foreach(SphereLogic sphere in logic.GetSphereLogics())
                {
                    sphereModels.Add(new SphereModel(sphere));
                }


            }
            public override void stop() { 
                logic.Stop();
               
            }
          

        }

    }
}
