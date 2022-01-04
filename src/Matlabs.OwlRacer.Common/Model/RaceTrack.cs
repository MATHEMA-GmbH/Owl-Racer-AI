using Matlabs.OwlRacer.Common.Options;

namespace Matlabs.OwlRacer.Common.Model
{
    public class RaceTrack
    {
        public int TrackNumber { get; init; }
        public byte[] ImageData { get; init; }
        public byte[] CheckpointImageData { get; init; }
        public VectorOptions StartPosition { get; init; }
        public StartLineOptions StartLine { get; init; }
        public float StartRotation { get; init; }
    }
}
