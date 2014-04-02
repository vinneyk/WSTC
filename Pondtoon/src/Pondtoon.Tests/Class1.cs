using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pondtoon.Tests
{
    public class Class1
    {
        [Fact]
        public void SineWaveContainsExpectedCountOfPoints()
        {
            // arrange
            const int sampleRate = 44100;
            const int frequency = 10000;
            const int cycles = 100;
            var systemUnderTest = new WaveformHelper();

            // act
            var result = systemUnderTest.MakeSine(sampleRate, frequency, cycles);

            // assert
            Assert.Equal(441, result.Points.Length);
        }

        [Fact]
        public void Test()
        {
            // arrange
            const int sampleRate = 44100;
            const int frequency = 10000;
            const int cycles = 441;
            var systemUnderTest = new WaveformHelper();
            var expected = SineWaveCalculator.ComputePoint(127, frequency, .01);

            // act
            var result = systemUnderTest.MakeSine(sampleRate, frequency, cycles);

            // assert
            Assert.Equal(expected, result.Points.Last());
        }

        internal static class SineWaveCalculator
        {
            internal static double ComputePoint(int amplitude, double frequency, double seconds, double phaseShift = 0)
            {
                return amplitude*(((2*Math.PI)*frequency*seconds)+phaseShift);
            }
        }
    }
}
