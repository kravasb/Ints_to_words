using FluentAssertions;
using Xunit;

namespace NumbersTranslator
{
    public class EnglishTranslatorTests
    {
        private readonly EnglishTranslator translator = new EnglishTranslator();

        [Fact]
        public void when_1_return_one()
        {
            var result = translator.Translate(1);

            result.Should().BeEquivalentTo("one");
        }

        [Fact]
        public void when_2_return_two()
        {
            var translate = translator.Translate(2);

            translate.Should().BeEquivalentTo("two");
        }

        [Fact]
        public void when_1000000_should_return_one_million()
        {
            var translate = translator.Translate(1000000);

            translate.ShouldBeEquivalentTo("one million");
        }

        [Fact]
        public void when_93_should_return_ninty_three()
        {
            var translate = translator.Translate(93);

            translate.ShouldBeEquivalentTo("ninty three");
        }

        [Fact]
        public void when_123_should_return_one_hundred_twenty_three()
        {
            var translate = translator.Translate(123);

            translate.ShouldBeEquivalentTo("one hundred twenty three");
        }

        [Fact]
        public void when_1100000000_should_return_one_billion_one_hundred_millions()
        {
            var translate = translator.Translate(1100000000);

            translate.ShouldBeEquivalentTo("one billion one hundred millions");
        }

        [Fact]
        public void when_1900000000_should_return_one_billion_one_hundred_millions()
        {
            var translate = translator.Translate(1900000000);

            translate.ShouldBeEquivalentTo("one billion nine hundred millions");
        }

        [Fact]
        public void when_1_123_000_000_should_return_one_billion_one_hundred_twenty_three_millions()
        {
            var translate = translator.Translate(1123000000);

            translate.ShouldBeEquivalentTo("one billion one hundred twenty three millions");
        }

        [Fact]
        public void when_1000000123_should_return_one_billion_one_hundred_twenty_three()
        {
            var translate = translator.Translate(1000000123);

            translate.ShouldBeEquivalentTo("one billion one hundred twenty three");
        }

        [Fact]
        public void when_11004_should_return_eleven_thousands_four()
        {
            var translate = translator.Translate(11004);

            translate.ShouldBeEquivalentTo("eleven thousands four");
        }
    }
}