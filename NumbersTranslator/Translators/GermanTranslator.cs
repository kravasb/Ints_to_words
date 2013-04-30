using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumbersTranslator
{
    public class GermanTranslator : ITranslator
    {
        private readonly List<int> numbers = new List<int> { 1000000000, 1000000, 1000, 100, 90, 80, 70, 60, 50, 40, 30, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

        private readonly List<string> words = new List<string>
                                           {
                                               "milliarde","million","tausend",
                                               "hundert","neunzig","achtzig","siebzig","sechzig","funfzig","vierzig","dreißig","zwanzig",
                                               "neunzehn","achtzehn","siebenzehn","sechszehn","fünfzehn","vierzehn","dreuzehn","zwolf","elf",
                                               "zehn","neun","acht","sieben","sechs","fünf","vier","drei","zwei","ein"
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

                if (tmp > 20 && tmp < 100)
                {
                    AppendWithGermanSpecific(sb, tmp);
                    break;
                }

                if (value >= 100)
                    AppendWithCount(sb, count, value);
                else
                    AppendWithoutCount(sb, value);
                tmp -= count * value;
            }
            return sb.ToString().TrimEnd();
        }

        private void AppendWithGermanSpecific(StringBuilder sb, int value)
        {
            var tmp = value;
            var list = numbers.Where(x => x < 100).ToList();
            var dozensPart = string.Empty;
            var integer = string.Empty;
            foreach (var number in list)
            {
                var count = tmp / number;
                if (count <= 0)
                    continue;
                if (tmp > 20)
                    dozensPart = words[numbers.IndexOf(number)];
                else
                    integer = words[numbers.IndexOf(number)];
                tmp -= number;
            }
            sb.AppendFormat("{0} und {1}", integer, dozensPart);
        }


        private void AppendWithoutCount(StringBuilder sb, int value)
        {
            sb.Append(words[numbers.IndexOf(value)] + " ");
        }

        private void AppendWithCount(StringBuilder sb, int count, int value)
        {
            if (count >= 100)
            {
                var numberEnding = " ";
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
