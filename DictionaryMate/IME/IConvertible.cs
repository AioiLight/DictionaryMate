using System;
using System.Collections.Generic;
using System.Text;

namespace AioiLight.DictionaryMate.IME
{
    public interface IConvertible
    {
        string Output { get; set; }
        void Convert(JsonFormat jsonFormat);
    }
}
