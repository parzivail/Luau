using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommandLine;

namespace Luau
{
    class Options
    {
        [Option('d', "working-dir", Required = false, HelpText = "The directory to start the program in.", Default = null)]
        public string WorkingDirectory { get; set; }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(params string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(Run)
                .WithNotParsed(ShowErrors);
        }

        private static void ShowErrors(IEnumerable<Error> errs)
        {
            Environment.Exit(1);
        }

        private static void Run(Options opts)
        {
            if (opts.WorkingDirectory != null)
                Directory.SetCurrentDirectory(opts.WorkingDirectory);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LuauForm());
        }
    }
}
