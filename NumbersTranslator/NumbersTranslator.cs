namespace NumbersTranslator
{
    public class NumbersTranslator
    {
        private readonly ITranslatorFactory factory;

        public NumbersTranslator(ITranslatorFactory factory)
        {
            this.factory = factory;
        }

        public string Translate(int number, Languages language)
        {
            var translator = factory.GetTranslator(language);
            var result = translator.Translate(number);
            return result;
        }
    }
}
