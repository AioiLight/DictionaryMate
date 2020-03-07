using System;
using System.Collections.Generic;
using CommandLine;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using System.Text;
using System.Linq;

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
            var file = File.ReadAllText(Path.GetFullPath(options.Input), Encoding.UTF8);
            var json = JsonConvert.DeserializeObject<List<Dictionary>>(file);

            var imeType = options.IMEType.Count() > 0 ? options.IMEType : new string[] { "atok", "msime", "googleime" };

            var myDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var outputPath = options.Output ?? Path.Combine(myDir, @"dest\");

            foreach (var ime in imeType)
            {
                var converter = GetConverterFromString(ime);
                if (converter == null)
                {
                    Console.WriteLine($"Invalid IME. Ignored:{ime}");
                    continue;
                }

                var converted = converter.Convert(json);

                Directory.CreateDirectory(outputPath);
                File.WriteAllText(Path.Combine(outputPath, $"{ime}.txt"), converted, converter.Encoding);
            }
        }

        static void Error(IEnumerable<Error> err)
        {

        }

        private static IME.IConvertible GetConverterFromString(string ime)
        {
            return ime switch {
                "googleime" => new IME.GoogleIME(),
                _ => null
            };
        }
    }
}
