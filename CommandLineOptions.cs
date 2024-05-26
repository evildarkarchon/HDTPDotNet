using CommandLine;

namespace HDTPDotNet
{
    public class CommandLineOptions
    {
        private const string blank = "";

        [Option('i', "input", Required = false, Default = blank, HelpText = "Directory where the texture folders are.")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string InputDirectory { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [Option('c', "cao", Required = false, Default = blank, HelpText = "Directory where the Cathedral Assets Optimizer files are.")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string CaoDirectory { get; set; }

        [Option('o', "output", Required = false, Default = blank, HelpText = "Directory where the combined textures will be saved.")]
        public string OutputDirectory { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
