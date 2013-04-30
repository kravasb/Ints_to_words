using FluentAssertions;
using Xunit;

namespace NumbersTranslator
{
    public class GermanTranslatorTests
    {
        private readonly GermanTranslator translator = new GermanTranslator();

        [Fact]
        public void when_1_should_returb_ein()
        {
            var translate = translator.Translate(1);

            translate.ShouldAllBeEquivalentTo("ein");
        }

        [Fact]
        public void when_12_should_returb_zwolf()
        {
            var translate = translator.Translate(12);

            translate.ShouldAllBeEquivalentTo("zwolf");
        }

        [Fact]
        public void when_23_should_returb_drei_und_zwanzig()
        {
            var translate = translator.Translate(23);

            translate.ShouldAllBeEquivalentTo("drei und zwanzig");
        }

        [Fact]
        public void when_37_should_return_sieben_und_dreißig()
        {
            var translate = translator.Translate(37);

            translate.ShouldAllBeEquivalentTo("sieben und dreißig");
        }

        [Fact]
        public void when_137_return_ein_hundert_sieben_und_dreißig()
        {
            var translate = translator.Translate(137);

            translate.ShouldAllBeEquivalentTo("ein hundert sieben und dreißig");
        }

        [Fact]
        public void when_123137_return_ein_hundert_sieben_und_dreißig()
        {
            var translate = translator.Translate(123137);

            translate.ShouldAllBeEquivalentTo("ein hundert drei und zwanzig tausend ein hundert sieben und dreißig");
        }
    }
}