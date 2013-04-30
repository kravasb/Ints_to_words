using FluentAssertions;
using Xunit;

namespace NumbersTranslator.Tests
{
    public class TranslatorsFactoryTests
    {
        private readonly TranslatorFactory factory = new TranslatorFactory();

        [Fact]
        public void get_translator_should_get_English_translator_for_English_language()
        {
            var result = factory.GetTranslator(Languages.English);

            result.Should().BeOfType<EnglishTranslator>();
        }

        [Fact]
        public void get_translator_should_get_German_translator_for_German_language()
        {
            var result = factory.GetTranslator(Languages.German);

            result.Should().BeOfType<GermanTranslator>();
        }
    }
}
