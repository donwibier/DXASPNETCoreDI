using System;
using System.Collections.Generic;
using System.Linq;

namespace lamp_console
{       
    public interface IOnOff
    {
        void GoOn(object sender);
        void GoOff(object sender);
    }

    public class MySwitch {
        private IEnumerable<IOnOff> _Outlets = null;
        private bool _IsOn;
        private readonly string _Id;
        public MySwitch(string id, IEnumerable<IOnOff> outlets)
        {
            _Id = id;
            _Outlets = outlets;            
        }
        public MySwitch(string id, IOnOff outlet)
            : this(id, new IOnOff[] { outlet })
        {          
        }
        protected virtual void Log(string msg) => Console.WriteLine(msg);
        
        public void FlipUp()
        {
            if (!_IsOn)
            {
                _IsOn = true;
                Log($"{this.GetType().Name} ({_Id}) flipped up.");               
                _Outlets.ToList().ForEach(l => l.GoOn(this));
            }
        }

        public void FlipDown()
        {
            if (_IsOn){
                _IsOn = false;
                Log($"{this.GetType().Name} ({_Id}) flipped down.");        
                _Outlets.ToList().ForEach(l => l.GoOff(this));
            }
        }
        #region IOnOff interface
        public void GoOn(object sender)
        {
            if (!_IsOn)
            {
                _IsOn = true;
                Log($"{this.GetType().Name} ({_Id}) switched on.");        
            }
        }

        public void GoOff(object sender)
        {
            if (_IsOn)
            {
                _IsOn = false;
                Log($"{this.GetType().Name} ({_Id}) switched off.");        
            }
        }
        #endregion
    }

    public class MyLamp : IOnOff {        
        private bool _isOn;
        private readonly string _Id;

        public MyLamp(string id)
        {
            _Id = id;
            IsOn = false;
        }
        protected virtual void Log(string msg) => Console.WriteLine(msg);
        public bool IsOn { get => _isOn; set => _isOn = value; }

        public void GoOff(object sender)
        {
            this.IsOn = false;
            Log($"{this.GetType().Name} ({_Id}) switched off.");
        }

        public void GoOn(object sender)
        {
            this.IsOn = true;
            Log($"{this.GetType().Name} ({_Id}) switched on.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyLamp l = new MyLamp("A");            
            MySwitch s = new MySwitch("1", l);
            s.FlipUp();
            s.FlipDown();     

            #region Complete demo
            // IOnOff[] stuff = new IOnOff[] {
            //     new MyLamp("A"),
            //     null,
            //     new MyLamp("B"),
            //     null
            // };

            // MySwitch s1 = new MySwitch("1", stuff);
            // MySwitch s2 = new MySwitch("2", stuff);
            // stuff[1] = s1;
            // stuff[3] = s2;

            // s1.FlipUp();
            // Console.WriteLine("==============");
            // s2.FlipUp();
            // Console.WriteLine("==============");
            // s2.FlipDown();
            // Console.WriteLine("==============");
            // s1.FlipUp();
            #endregion
        }
    }
}
