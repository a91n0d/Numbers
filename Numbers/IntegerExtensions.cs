using System;

namespace Numbers
{
    public static class IntegerExtensions
    {
        /// <summary>
        /// Obtains formalized information in the form of an enum <see cref="ComparisonSigns"/>
        /// about the relationship of the order of two adjacent digits for all digits of a given number. 
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>Information in the form of an enum <see cref="ComparisonSigns"/>
        /// about the relationship of the order of two adjacent digits for all digits of a given number
        /// or null if the information is not defined.</returns>
        public static ComparisonSigns? GetTypeComparisonSigns(this long number)
        {
            if (number / 10 == 0)
            {
                return null;
            }

            ComparisonSigns comparisonSins = default;
            while (number / 10 != 0)
            {
                int rightNum = (int)(number % 10);
                int leftNum = (int)((number % 100) / 10);
                if (rightNum > leftNum)
                {
                    comparisonSins |= ComparisonSigns.LessThan;
                }
                else if (rightNum < leftNum)
                {
                    comparisonSins |= ComparisonSigns.MoreThan;
                }
                else
                {
                    comparisonSins |= ComparisonSigns.Equals;
                }

                number /= 10;
            }

            return comparisonSins;
        }

        /// <summary>
        /// Gets information in the form of a string about the type of sequence that the digit of a given number represents.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The information in the form of a string about the type of sequence that the digit of a given number represents.</returns>
        public static string GetTypeOfDigitsSequence(this long number)
        {
            ComparisonSigns? comparisonSigns = number.GetTypeComparisonSigns();
            if (comparisonSigns == (ComparisonSigns)2)
            {
                return "Strictly Decreasing.";
            }
            else if (comparisonSigns == (ComparisonSigns)7 || comparisonSigns == (ComparisonSigns)3)
            {
                return "Unordered.";
            }
            else if (comparisonSigns == (ComparisonSigns)1)
            {
                return "Strictly Increasing.";
            }
            else if (comparisonSigns == (ComparisonSigns)4)
            {
                return "Monotonous.";
            }
            else if (comparisonSigns == (ComparisonSigns)5)
            {
                return "Increasing.";
            }
            else if (comparisonSigns == (ComparisonSigns)6)
            {
                return "Decreasing.";
            }
            else
            {
                return "One digit number.";
            }
        }
    }
}
