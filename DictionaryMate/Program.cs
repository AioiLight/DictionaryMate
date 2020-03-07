using System;
using System.Collections.Generic;
using CommandLine;

namespace AioiLight.DictionaryMate
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<CommandOptions>(args)
                .WithParsed(Generate)
                .WithNotParsed(Error);
        }

        static void Generate(CommandOptions options)
        {
            var input = options.Input;
            var output = options.Output;
        }

        static void Error(IEnumerable<Error> err)
        {

        }
    }
}
