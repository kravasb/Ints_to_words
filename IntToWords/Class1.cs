using Xunit;
using FluentAssertions;

namespace IntToWords
{
    using System.Collections.Generic;
    using System.Text;

    public class Converter
    {
        private Dictionary<int, string> dictionary = new Dictionary<int, string>
                                                      {
                                                      {1000000000,"billion"},    
                                                      {1000000,"million"},
                                                      {1000,"thousand"},
                                                      {100,"hundred"},
                                                      {90,"ninty"},
                                                      {80,"eighty"},
                                                      {70, "seventy"},
                                                      {60,"sixty"},
                                                      {50,"fifty"},
                                                      {40,"forty"},
                                                      {30,"thirty"},
                                                      {20,"twenty"},
                                                      {19, "nineteen"},
                                                      {18,"eighteen"},
                                                      {17,"seventeen"},
                                                      {16,"sixteen"},
                                                      {15,"fifteen"},
                                                      {14,"fourteen"},
                                                      {13,"thirteen"},
                                                      {12,"twelve"},
                                                      {11,"eleven"},
                                                      {10, "ten"},
                                                      {9, "nine"},
                                                      {8,"eight"},
                                                      {7,"seven"},
                                                      {6,"six"},
                                                      {5,"five"},
                                                      {4,"four"},
                                                      {3,"three"},
                                                      {2,"two"},
                                                      {1,"one"}};
        public string Convert(int i)
        {
            var sb = new StringBuilder();

            var tmp = i;

            foreach (var pair in dictionary)
            {
                var amount = tmp / pair.Key;
                if (amount > 0)
                {
                    tmp -= amount * pair.Key;
                    sb.Append(dictionary[amount] + " " + pair.Value);
                }
            }
            return sb.ToString();
        }
    }

    public class ConverterTest
    {
        private readonly Converter converter = new Converter();

        [Fact]
        public void when_1_should_return_one()
        {
            var result = converter.Convert(1);

            result.ShouldBeEquivalentTo("one");
        }

        [Fact]
        public void when_2_return_two()
        {
            var result = converter.Convert(2);

            result.ShouldBeEquivalentTo("two");
        }

        [Fact]
        public void when_2000_print_two_thousand()
        {
            var result = converter.Convert(2000);

            result.ShouldBeEquivalentTo("two thousand");
        }
    }
}
