using Microsoft.Extensions.Diagnostics.HealthChecks;
using ProyectoMerck.Models;
using System.Reflection;

namespace ProyectoMerck.Helpers
{
    public static class FertilityCalculator
    {

        public static FertilityLevel LevelCalculator(int fertilityMeter)
        {

            if (fertilityMeter >= 30)
            {
                return FertilityLevel.Low;
            }
            else if (fertilityMeter < 20)
            {
                return FertilityLevel.High;
            }
            else
            {
                return FertilityLevel.Medium;
            }

        }

        public static int OvuleCalculator(int fertilityMeter)
        {
            return (-1 * fertilityMeter + 100);
        }

        public static int FertilityMeter(int currentAge, int firstAge)
        {
            return currentAge - firstAge;
        }


    }
}
