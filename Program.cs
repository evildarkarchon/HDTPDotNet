using CommandLine;
using System.Diagnostics;
using System.Numerics;
using System.Security.Cryptography;

namespace HDTPDotNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<CommandLineOptions>(args)
                .WithParsed(Run);
        }
        static void Robocopy(string source, string destination, string options)
        {
            using var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "robocopy.exe",
                    Arguments = $"{source} {destination} {options}",
                    CreateNoWindow = true
                }
            };
            process.Start();
            process.WaitForExit();
            Console.WriteLine(@"ROBOCOPY is complete.");
        }
        static void RunCathedralAssetsOptimizer(string caodirectory)
        {
            using var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = $@"{caodirectory}\Cathedral Assets Optimizer.exe"
                }
            };
        }
        static void Run(CommandLineOptions options)
        {
            switch (options.InputDirectory)
            {
                case null:
                case "":
                    {
                        options.InputDirectory = Directory.GetCurrentDirectory();
                        break;
                    }
                default:
                    if (!Directory.Exists(options.InputDirectory))
                    {
                        options.InputDirectory = Directory.GetCurrentDirectory();
                    }
                    break;
            }
            if (!Path.IsPathFullyQualified(options.InputDirectory))
            {
                options.InputDirectory = Path.GetFullPath(options.InputDirectory);
            }
            if (!Directory.Exists(options.OutputDirectory))
            {
                Directory.CreateDirectory(options.OutputDirectory);
            }

            switch (options.CaoDirectory)
            {
                case null:
                case "":
                    {
                        options.CaoDirectory = $@"{Directory.GetCurrentDirectory()}\CAO";
                        break;
                    }
                default:
                    if (!Directory.Exists(options.CaoDirectory))
                    {
                        throw new DirectoryNotFoundException("The specified CAO directory does not exist.");
                    }
                    break;
            }
            if (!Path.IsPathFullyQualified(options.CaoDirectory))
            {
                options.CaoDirectory = Path.GetFullPath(options.CaoDirectory);
            }

            switch (options.OutputDirectory)
            {
                case null:
                case "":
                    {
                        options.OutputDirectory = $@"{Directory.GetCurrentDirectory()}\Combined_Files";
                        break;
                    }
                default:
                    if (!Directory.Exists(options.OutputDirectory))
                    {
                        Directory.CreateDirectory(options.OutputDirectory);
                    }
                    break;
            }
            if (!Path.IsPathFullyQualified(options.OutputDirectory))
            {
                options.OutputDirectory = Path.GetFullPath(options.OutputDirectory);
            }
            if (!Directory.Exists($@"{options.OutputDirectory}"))
            {
                Directory.CreateDirectory($@"{options.OutputDirectory}");
            }
            foreach (var directory in Directory.GetDirectories(options.InputDirectory))
            {
                var directoryName = Path.GetFileName(directory);
                List<string> directories1 =
                [
                    Path.GetFullPath($@"{options.InputDirectory}\01_FlaconOil"),
                    Path.GetFullPath($@"{options.InputDirectory}\02_FlaconOil"),
                    Path.GetFullPath($@"{options.InputDirectory}\03_FlaconOil"),
                ];
                foreach (var directory1 in directories1)
                {
                    Console.WriteLine($@"Copying {directoryName} to {options.OutputDirectory}\temp");
                    Robocopy(directory1, $@"{options.OutputDirectory}", "/s");
                }
            }
            List<string> conflicts1 =
                [
                    Path.GetFullPath($@"{options.OutputDirectory}\textures\setdressing\office\OfficeBoxPapers01_Clean_d.dds"),
                    Path.GetFullPath($@"{options.OutputDirectory}\textures\setdressing\office\OfficeBoxPapers01_Clean_n.dds"),
                    Path.GetFullPath($@"{options.OutputDirectory}\textures\setdressing\office\OfficeBoxPapers01_d.dds"),
                    Path.GetFullPath($@"{options.OutputDirectory}\textures\setdressing\office\OfficeBoxPapers01_n.dds"),
                    Path.GetFullPath($@"{options.OutputDirectory}\textures\setdressing\Tires\Tires01_d.DDS"),
                    Path.GetFullPath($@"{options.OutputDirectory}\textures\setdressing\Tires\Tires01_n.DDS"),
                    Path.GetFullPath($@"{options.OutputDirectory}\textures\setdressing\Tires\Tires01_s.DDS")
                ];
            foreach (var conflict1 in conflicts1)
            {
                Console.WriteLine($@"Deleting {conflict1}");
                File.Delete(conflict1);
            }
            List<string > conflicts2 =
                [
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\Bricks01_d.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\Bricks01_n.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\Bricks01_s.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\Bricks01Painted01_d.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\Bricks01Painted01_s.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\Bricks01R_d.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\Bricks01R_n.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\Bricks01R_s.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\Bricks01Trim_d.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\Bricks01Trim_n.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\Bricks01Trim_s.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\Bricks02_d.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\Bricks02R_d.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\Bricks02Trim_d.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\BricksDarkRed01_d.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\BricksFactory01_d.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\BricksFactory01R_d.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\BricksGreen01_d.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\BricksGreen01_n.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\BricksGS01_d.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\BricksGS01_s.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\BricksRed01_d.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\BricksWhite01_d.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\BricksWhite01_n.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\BricksWhite01R_d.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\BrickTrim01_d.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\BrickTrim01_n.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\BrickTrim01_s.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\BrickWhite02Win01_d.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\BrickWhite02Win01_n.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\Debris01_d.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\Debris01_n.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\Debris01_s.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\Debris02_d.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\Plaster01_d.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\Plaster01_n.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\Plaster01_s.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\Plaster02_d.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\Plaster02_n.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\Plaster02_s.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\ResAwningFabric01_d.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\ResAwningFabric01_n.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\ResAwningFabric01_s.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\ResAwningFabric02_d.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\resawningfabric03_d.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\resawningfabric03_s.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\ResAwningFabric04_d.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\WoodFloor01_d.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\WoodFloor01_n.DDS",
                    $@"{options.InputDirectory}\04_Langley\textures\architecture\buildings\WoodFloor01_s.DDS",
                    $@"{options.InputDirectory}\04_Langley\materials\architecture\buildings\BrickBrownstone01.bgsm",
                    $@"{options.InputDirectory}\04_Langley\materials\architecture\buildings\BrickBrownstonePainted01.bgsm",
                    $@"{options.InputDirectory}\04_Langley\materials\architecture\buildings\BrickBrownstonePainted02.bgsm",
                    $@"{options.InputDirectory}\04_Langley\materials\architecture\buildings\BrickGreenLt01.bgsm",
                    $@"{options.InputDirectory}\04_Langley\materials\architecture\buildings\BrickRed01.BGSM",
                    $@"{options.InputDirectory}\04_Langley\materials\architecture\buildings\BrickRedDamageDecal01.BGSM",
                    $@"{options.InputDirectory}\04_Langley\materials\architecture\buildings\BricksFactory01.BGSM",
                    $@"{options.InputDirectory}\04_Langley\materials\architecture\buildings\BrickSolidWhitePaint01.bgsm",
                    $@"{options.InputDirectory}\04_Langley\materials\architecture\buildings\BrickTan01.BGSM",
                    $@"{options.InputDirectory}\04_Langley\materials\architecture\buildings\BrickTanLt01.bgsm"
                ];
            foreach (var conflict2 in conflicts2)
            {
                Console.WriteLine($@"Deleting {conflict2}");
                File.Delete(conflict2);
            }
            Robocopy($@"{options.InputDirectory}\04_Langley", $@"{options.OutputDirectory}", "/s");
            Robocopy($@"{options.InputDirectory}\05_Valius", $@"{options.OutputDirectory}", "/s");
            Robocopy($@"{options.InputDirectory}\06_NMC", $@"{options.OutputDirectory}", "/s");
            Robocopy($@"{options.InputDirectory}\07_Lucid", $@"{options.OutputDirectory}", "/s");
            Robocopy($@"{options.InputDirectory}\08_SavrenX", $@"{options.OutputDirectory}", "/s");

            if (File.Exists($@"{options.CaoDirectory}\Cathedral Assets Optimizer.exe"))
            {
                RunCathedralAssetsOptimizer(options.CaoDirectory);
            }
        }
    }
}
