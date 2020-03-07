using System;
using System.Collections.Generic;
using System.Text;

namespace AioiLight.DictionaryMate.IME
{
    public interface IConvertible
    {
        string Output { get; set; }
        Encoding Encoding { get; }
        void Convert(JsonFormat jsonFormat);
        string SpeechToString(Speech? speech);
    }
}
