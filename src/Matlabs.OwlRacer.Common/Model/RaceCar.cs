using System;
using System.Numerics;

namespace Matlabs.OwlRacer.Common.Model
{
    public sealed class RaceCar
    {
        public Guid Id { get; init; }
        public Guid SessionId { get; }


        public RaceCar(Guid sessionId, Guid raceId, string name, string color)
        {
            Id = raceId;
            SessionId = sessionId;
            Distance = new CarDistance();
            LastAction = DateTimeOffset.UtcNow;
            Name = name;
            Color = color; 
        }

        public RaceCar(Guid sessionId, string name, string color)
        {
            Id = Guid.NewGuid();
            SessionId = sessionId;
            Distance = new CarDistance();
            LastAction = DateTimeOffset.UtcNow;
            Name = name;
            Color = color;
        }

        public RaceCar(Guid sessionId, float maxVelocity, float acceleration, string name, string color) : this(sessionId, name, color)
        {
            MaxVelocity = maxVelocity;
            Acceleration = acceleration;
            Name = name;
            Color = color;
        }

        public int LastStepCommand { get; set; }
        public Vector2 Position { get; set; }
        public float Rotation { get; set; }
        public float Velocity { get; set; }
        public bool IsCrashed { get; set; }
        public bool UnCrashed { get; set; }
        public bool WrongDirection { get; set; }
        public float MaxVelocity { get; init; }
        public float Acceleration { get; init; }
        public int ScoreStep { get; set; }
        public int ScoreOverall { get; set; }
        public int Ticks { get; set; }
        public CarDistance Distance { get; set; }
        public int Checkpoint { get; set; }
        public int PreviousCheckpoint { get; set; }
        public DateTimeOffset LastAction { get; set; }
        public double TraveledDistance { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int NumRounds { get; set; }
        public int NumCrashes { get; set; }
    }
}
