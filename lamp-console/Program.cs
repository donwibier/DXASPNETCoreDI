using System;
using System.Collections.Generic;
using System.Linq;

namespace lamp_console
{
    public enum Status{ Off, On }
        
    public interface IOnOff
    {
        void GoOn(object sender);
        void GoOff(object sender);
    }

    public class MySwitch {
        private IEnumerable<IOnOff> _Outlets = null;
        private Status _Status = Status.Off;
        public MySwitch(IEnumerable<IOnOff> outlets){
            _Outlets = outlets;
        }
        public MySwitch(IOnOff outlet)
            : this(new IOnOff[] { outlet })
        {          
        }
        public void FlipUp()
        {
            if (_Status != Status.On)
            {
                _Status = Status.On;                
                _Outlets.ToList().ForEach(l => l.GoOn(this));
            }
        }

        public void FlipDown()
        {
            if (_Status != Status.Off){
                _Status = Status.Off;
                _Outlets.ToList().ForEach(l => l.GoOff(this));
            }
        }
    }

    public class MyLamp : IOnOff {        
        private bool _isOn;
        private string _Name;

        public MyLamp(string name)
        {
            _Name = name;
            IsOn = false;
        }

        public bool IsOn { get => _isOn; set => _isOn = value; }

        public void GoOff(object sender)
        {
            this.IsOn = false;
            Console.WriteLine($"{this.GetType().Name} ({_Name}) switched off.");
        }

        public void GoOn(object sender)
        {
            this.IsOn = true;
            Console.WriteLine($"{this.GetType().Name} ({_Name}) switched on.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyLamp l = new MyLamp("A");            
            MySwitch s = new MySwitch(l);

            s.FlipUp();
            s.FlipDown();
            
        }
    }
}
