public interface ICarBuilder
{
    void SetSeats(int number);
    void SetEngine(string engine);
    void SetTripComputer();
    void SetGPS();
    void Reset();
    Car GetResult();
}

public class Car
{
    public int Seats { get; set; }
    public string Engine { get; set; }
    public bool HasTripComputer { get; set; }
    public bool HasGPS { get; set; }
}
public class Director
{
    public void MakeSportCar(ICarBuilder builder)
    {
        builder.Reset();
        builder.SetSeats(2);
        builder.SetEngine("SportEngine");
        builder.SetTripComputer();
        builder.SetGPS();
    }

    public void MakeSUV(ICarBuilder builder)
    {
        builder.Reset();
        builder.SetSeats(5);
        builder.SetEngine("SUVEngine");
        builder.SetGPS();
    }
}

public class CarBuilderI : ICarBuilder
{
    Car car;

    public CarBuilderI()
    {
        this.Reset();
    }

    public void Reset()
    {
        this.car = new Car();
    }

    public void SetSeats(int number)
    {
        this.car.Seats = number;
    }

    public void SetEngine(string engine)
    {
        this.car.Engine = engine;
    }

    public void SetTripComputer()
    {
        this.car.HasTripComputer = true;
    }

    public void SetGPS()
    {
        this.car.HasGPS = true;
    }

    public Car GetResult()
    {
        return this.car;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Director director = new Director();
        ICarBuilder builder = new CarBuilderI();

        director.MakeSportCar(builder);
        Car sportCar = builder.GetResult();

        Console.WriteLine("Sport Car:");
        Console.WriteLine($"Seats: {sportCar.Seats}");
        Console.WriteLine($"Engine: {sportCar.Engine}");
        Console.WriteLine($"Has Trip Computer: {sportCar.HasTripComputer}");
        Console.WriteLine($"Has GPS: {sportCar.HasGPS}");

        Console.WriteLine();

        director.MakeSUV(builder);
        Car suv = builder.GetResult();

        Console.WriteLine("SUV:");
        Console.WriteLine($"Seats: {suv.Seats}");
        Console.WriteLine($"Engine: {suv.Engine}");
        Console.WriteLine($"Has Trip Computer: {suv.HasTripComputer}");
        Console.WriteLine($"Has GPS: {suv.HasGPS}");
    }
}
