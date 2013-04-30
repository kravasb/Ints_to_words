namespace NumbersTranslator
{
    public interface ITranslatorFactory
    {
        ITranslator GetTranslator(Languages language);
    }
}