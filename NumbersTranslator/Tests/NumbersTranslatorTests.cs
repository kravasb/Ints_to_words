// Copyright (C) CompatibL Technologies LLC. All rights reserved.
// This code contains valuable trade secrets and may be used, copied,
// stored, or distributed only in accordance with a written license
// agreement and with the inclusion of this copyright notice.

using NSubstitute;
using Xunit;
using FluentAssertions;

namespace NumbersTranslator.Tests
{
    public class NumbersTranslatorTests
    {
        private readonly ITranslatorFactory factory = Substitute.For<ITranslatorFactory>();
        private readonly ITranslator translator = Substitute.For<ITranslator>();
        private readonly NumbersTranslator numbersTranslator;

        public NumbersTranslatorTests()
        {
            numbersTranslator = new NumbersTranslator(factory);
        }

        [Fact]
        public void should_translate_number_into_german()
        {
            Arrange();
            
            var result = Act();

            result.ShouldBeEquivalentTo("test");
        }

        private void Arrange()
        {
            factory.GetTranslator(Languages.English).Returns(translator);
            translator.Translate(1).Returns("test");
        }

        private string Act()
        {
            return numbersTranslator.Translate(1, Languages.English);
        }
    }
}
