using System.Runtime.InteropServices;
using FluentAssertions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tests
{
    public class Calculators
    {
        //Note: this formula is derived from the US Navy's PERT (Program Evaluation and Review Technique) formula.
        //The constants 4 and 6 are somewhat arbitrary numbers they developed through experience and calculation
        //to describe the likelihood of the optimistic and pessimistic estimates occurring.
        //The formula is: (Pessimistic + 4 * Most Likely + Optimistic)/6
        
        [Theory]
        [InlineData(1, 3, 12)]
        public void BetaDistributionProbability_ShouldEqual4_2(int pessimistic, int mostLikely, int optimistic)
        {
            var result = (pessimistic + 4 * mostLikely + optimistic) / 6;

            result.Should().Be((int)4.2);
        }

        [Theory]
        [InlineData(12, 1)]
        public void StandardDeviation_ShouldEqual1_8(int pessimistic, int optimistic)
        {
            var result = (pessimistic - optimistic) / 6;

            result.Should().Be((int)1.8);
        }

    }
}