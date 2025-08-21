using System;

class RemoteControlCar
{
    private readonly int _speed;
    private readonly int _batteryDrain;

    private int _distance = 0;
    private int _battery = 100;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        _speed = speed;
        _batteryDrain = batteryDrain;
    }
    public bool BatteryDrained()
    {
        return _battery < _batteryDrain;
    }

    public int DistanceDriven() => _distance;

    public void Drive()
    {
        if (BatteryDrained())
        {
            return;
        }

        _battery -= _batteryDrain;
        _distance += _speed;
    }

    public static RemoteControlCar Nitro() => new(50, 4);
}

class RaceTrack
{
    private readonly int _distance;

    public RaceTrack(int distance)
    {
        _distance = distance;
    }
    
    public bool TryFinishTrack(RemoteControlCar car)
    {
        var initialDistance = car.DistanceDriven();

        while (!car.BatteryDrained())
        {
            car.Drive();

            var trackDrivenDistance = car.DistanceDriven() - initialDistance;
            
            if (trackDrivenDistance >= _distance)
            {
                return true;
            }
        }

        return false;
    }
}
