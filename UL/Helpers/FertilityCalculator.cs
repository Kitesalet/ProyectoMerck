using Common_Layer.Models.ViewModels;

namespace ProyectoMerck.Helpers
{
    public static class FertilityCalculator
    {

        public static FertilityLevel LevelCalculator(int fertilityMeter)
        {

            if (fertilityMeter <= 100)
            {
                return FertilityLevel.High;
            }
            else if (fertilityMeter > 300)
            {
                return FertilityLevel.Low;
            }
            else
            {
                return FertilityLevel.Medium;
            }

        }

        public static int OvuleCalculator(int fertilityMeter)
        {
            return -fertilityMeter + 450;
        }

        public static int FertilityMeter(int currentAge, int firstAge)
        {
            return 10 * (currentAge - firstAge);
        }


    }
}
