using System;
namespace _05112020
{
    //public interface IEngine
    //{
    //    void EngineStart();
    //    void EngineStop();
    //}
    public interface IEngineRun
    {
        void EngineStart();
    }
    public interface IEngineBreak
    {
        void EngineStop();
    }
    public interface IEngine : IEngineBreak, IEngineRun
    {

    }
    public interface IFuel
    {
        string Fuel { get; set; }
        double FuelConsuption { get; set; }
    }
    class V4 : IEngine, IFuel
    {
        public double FuelConsuption { get; set; }
        public string Fuel { get; set; }
        public void EngineStart()
        {
            Console.WriteLine($"V4 Engine start - {FuelConsuption} l/100");
        }
        public void EngineStop()
        {
            Console.WriteLine($"V4 Engine stop - 0 l/100");
        }
    }
    class V6 : IEngine, IFuel
    {
        public double FuelConsuption { get; set; }
        public string Fuel { get; set; }
        public void EngineStart()
        {
            Console.WriteLine($"V6 Engine start - {FuelConsuption} l/100");
        }
        public void EngineStop()
        {
            Console.WriteLine($"V6 Engine stop - 0 l/100");
        }
    }
    class Electric : IEngine, IFuel
    {
        public double FuelConsuption { get; set; }
        public string Fuel { get; set; }
        public void EngineStart()
        {
            Console.WriteLine($"Electric Engine start - {FuelConsuption} kw/h");
        }
        public void EngineStop()
        {
            Console.WriteLine($"Electric Engine stop - 0 kw/h");
        }
    }
    class Car
    {
        IEngine Engine;
        public Car(IEngine eng)
        {
            Engine = eng;
        }
        public void DriveCar()
        {
            Engine.EngineStart();
        }
        public void StopCar()
        {
            Engine.EngineStop();
        }
    }
    interface IA
    {
        void Do();
        void Work();
    }
    interface IB
    {
        void Work();
    }
    interface IC
    {
        void Work();
    }
    class Realization : IA, IB, IC
    {
        //public void Work()
        //{
        //    Console.WriteLine("Hello Realization");
        //}
        public void Do()
        {
            Console.WriteLine("Hello IA Do");
        }
        void IA.Work()
        {
            Console.WriteLine("Hello IA.Work");
        }
        void IB.Work()
        {
            Console.WriteLine("Hello IB.Work");
        }
        void IC.Work()
        {
            Console.WriteLine("Hello IC.Work");
        }
    }
    class Program
    {
        static void Test3()
        {
            Realization re = new Realization();
            //re.Work();
            ((IA)re).Work();
            re.Do();
            IA ia = re;
            ia.Work();
            IB ib = re;
            ib.Work();
            IC ic = re;
            ic.Work();

        }
        static void Test2()
        {
            // Car zaz = new Car(new V4 { FuelConsuption = 8, Fuel = "Аи-95" });
            // Car zaz = new Car(new V6 { FuelConsuption = 8, Fuel = "Аи-95" });
            Car zaz = new Car(new Electric { FuelConsuption = 2, Fuel = "220v" });
            zaz.DriveCar();
        }

        static void Test1()
        {
            V4 v4 = new V4 { FuelConsuption = 8, Fuel = "Аи-95" };
            v4.EngineStart();
            v4.EngineStop();
            V6 v6 = new V6 { FuelConsuption = 12, Fuel = "Аи-98" };
            v6.EngineStart();
            v6.EngineStop();
            // IEngine engine = new V4 { FuelConsuption = 15, Fuel = "Аи-95" };
            IEngine engine = v4;
            engine.EngineStart();
            engine.EngineStop();
            // IFuel fuel = new V6 { FuelConsuption = 15, Fuel = "Аи-95" };
            IFuel fuel = v4;
            fuel.Fuel = "Аи-76";
            fuel.FuelConsuption = 22.9;
            if (engine is V4 vv4)
                Console.WriteLine(vv4.FuelConsuption);
            IFuel fuel76 = (IFuel)engine;
            fuel76.FuelConsuption = 30;
            if (engine is V4 vvv4)
                Console.WriteLine(vvv4.FuelConsuption);
            (fuel76 as V6)?.EngineStart();

        }
        static void Main(string[] args)
        {
            //Test1();
            //Test2();
            Test3();
        }
    }
}