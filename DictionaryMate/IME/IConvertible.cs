using System;
using System.Collections.Generic;
using System.Text;

namespace AioiLight.DictionaryMate.IME
{
    public interface IConvertible
    {
        Encoding Encoding { get; }
        string Convert(JsonFormat jsonFormat);
        string SpeechToString(Speech? speech);
    }
}
