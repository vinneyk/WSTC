using System;
using System.Collections.Generic;

namespace Pondtoon
{
    public class WaveformHelper
    {
        private const int ZeroCrossover = 128;
        private const int EightBitFriendlyAmplitude = 127;
        private const double Tau = Math.PI*2;

        public WaveForm MakeSine(int sampleRate, double frequency, int cycles, int amplitude = EightBitFriendlyAmplitude)
        {
            var radians = 0d; 
            var delta = Tau/(sampleRate/frequency); 
            var points = new List<double>();
            var requiredRadians = cycles*Tau;

            while (radians <= requiredRadians)
            {
                points.Add(Math.Sin(radians)*amplitude);
                radians += delta;
            }

            return new WaveForm
            {
                Amplitude = amplitude,
                Frequency = frequency,
                Points = points.ToArray(),
                SampleRate = sampleRate,
            };
        }

        public void ShiftPointsFor8Bit()
        {
            //todo: add 128 to each point to prevent negatives for 8bit friendly numbers
            throw new NotImplementedException();
        }
    }

    public struct WaveForm
    {
        public double[] Points { get; set; }
        public int Amplitude { get; set; }
        public double Frequency { get; set; }
        public int SampleRate { get; set; }
    }
}