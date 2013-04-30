// Copyright (C) CompatibL Technologies LLC. All rights reserved.
// This code contains valuable trade secrets and may be used, copied,
// stored, or distributed only in accordance with a written license
// agreement and with the inclusion of this copyright notice.

using System;
using System.Collections.Generic;

namespace NumbersTranslator
{
   public class TranslatorFactory : ITranslatorFactory
    {
        private readonly Dictionary<Languages, ITranslator> dictionary = new Dictionary<Languages, ITranslator>
                                                                           {
                                                                               {Languages.English, new EnglishTranslator()},
                                                                               {Languages.German, new GermanTranslator()},
                                                                           };

        public ITranslator GetTranslator(Languages language)
        {
            if (!dictionary.ContainsKey(language))
                throw new Exception(string.Format("Could not find specified language: '{0}'", language.ToString()));

            return dictionary[language];
        }
    }
}
