using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace Matlabs.OwlRacer.Common.Model
{
    public class Session
    {
        public Guid Id { get; init; }
        public string Name { get; set; }
        public float GameTimeSetting { get; set; }
        public List<RaceCar> RaceCars { get; set; } = new();
        public RaceTrack RaceTrack { get; set; }
        public Dictionary<RaceCar, int> Scores { get; set; } = new();
        public TimeSpan GameTime { get; set; } = new();
        public bool IsPaused { get; set; } = false;
        
        public bool HasRaceStarted => GameTime.Ticks > 0;

        public Session() : this(Guid.NewGuid(), "") { }

        public Session(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
