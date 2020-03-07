using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;
using CommandLine.Text;

namespace AioiLight.DictionaryMate
{
    public class CommandOptions
    {
        [Option('i', "input", Required = true,
            HelpText = "A .json file for generating dictionary.")]
        public string Input { get; set; }

        [Option('o', "output", Required = false,
            HelpText = "A destination to output.")]
        public string Output { get; set; }

        [Option('i', "ime", Required = false, Separator = ','
            , HelpText = "Which IME's dictionary to generate.")]
        public IEnumerable<string> IMEType { get; set; }

        [Usage(ApplicationAlias = "DictionaryMate")]
        public static IEnumerable<Example> Examples
        {
            get
            {
                return new List<Example>()
                {
                    new Example("Generate dictionary", new CommandOptions { Input = "dic.json" }),
                    new Example("Specify a directory, generate dictionary", new CommandOptions { Input = "dic.json", Output="C:\\MyGreatDictionary\\"}),
                    new Example("Generate dictionary of specific IME(ATOK)", new CommandOptions { Input = "dic.json", IMEType = new string[] { "atok" } }),
                    new Example("Generate dictionary of specific IME(MS-IME, GoogleIME)", new CommandOptions { Input = "dic.json", IMEType = new string[] { "msime", "googleime" } }),
                };
            }
        }
    }
}
