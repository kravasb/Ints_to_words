using System.Collections.Generic;
using System.Text;

namespace NumbersTranslator
{
    class EnglishTranslator : ITranslator
    {
        private readonly List<int> numbers = new List<int> { 1000000000, 1000000, 1000, 100, 90, 80, 70, 60, 50, 40, 30, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

        private readonly List<string> words = new List<string>
                                           {
                                               "billion","million","thousand",
                                               "hundred","ninty","eighty","seventy","sixty","fifty","fourty","thirty","twenty",
                                               "nineteen","eighteen","seventeen","sixteen","fifteen","fourteen","thirteen","twelve","eleven",
                                               "ten","nine","eight","seven","six","five","four","three","two","one"
                                           };


        public string Translate(int number)
        {
            var sb = new StringBuilder();
            var tmp = number;
            foreach (var value in numbers)
            {
                var count = tmp / value;
                if (count <= 0)
                    continue;

                if (value >= 100)
                    AppendWithCount(sb, count, value);
                else
                    AppendWithoutCount(sb, value);
                tmp -= count * value;
            }
            return sb.ToString().TrimEnd();
        }

        private void AppendWithoutCount(StringBuilder sb, int value)
        {
            sb.Append(words[numbers.IndexOf(value)] + " ");
        }

        private void AppendWithCount(StringBuilder sb, int count, int value)
        {
            if (count >= 100)
            {
                var numberEnding = count > 1 && value > 100 ? "s " : " ";
                sb.Append(Translate(count) + " " + words[numbers.IndexOf(value)] + numberEnding);
                return;
            }

            var amount = words[numbers.IndexOf(count)];
            var number = words[numbers.IndexOf(value)];
            var ending = count > 1 && value > 100 ? "s " : " ";
            var formulation = amount + " " + number + ending;
            sb.Append(formulation);
        }
    }
}
