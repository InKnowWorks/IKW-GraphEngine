﻿using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GraphEngine.DataImporter
{
    class CmdOptions
    {
        [Option('t', "tsl", HelpText = "Specifies the TSL file for data importing")]
        public string TSL { get; set;}
		
        [Option('d', "dir", HelpText = "Import all .json and .txt files from directory", Required = false)]
        public string InputDirectory { get; set; }

        [Option('o', "output", HelpText = "Specifies data import output directory for importing tasks, and specifies the output TSL file name for TSL generation tasks", Required = false)]
        public string Output { get; set; }

        [Option('g', "generate_tsl", HelpText = "Generates TSL", SetName = "Action")]
        public bool GenerateTSL { get; set; }

        [Option('s', "sorted", HelpText = "Specifies that the data is already sorted/grouped by entities", Default = false)]
        public bool Sorted { get; set; }

        [Option("delimiter", HelpText = "Specifies the delimiter of CSV or TSV file", Required = false)]
        public char Delimiter { get; set; }

        [Option("dtr_threshold", HelpText = "Specifies the threshold of dominating type ratio (between 0 and 1.0)", Required = false, Default = 1.0)]
        public double DominatingTypeThreshold { get; set; }

        [Option('f', "fileFormat", HelpText = "Specifies the default file format for the input parser, when file format cannot be determined from the file extension", Required = false)]
        public string FileFormat { get; set; }

        [Option("notrim", HelpText = "Specifies that the data fields in CSV/TSV files are not trimmed", Required = false)]
        public bool NoTrim { get; set; }

        [Option('a', "tsl_assembly", HelpText = "Specifies the TSL assembly for data importing.", SetName = "Action")]
        public string TSLAssembly { get; set; }
		
        [Value(11, Default = typeof(List<string>))]
        public IList<string> ExplicitFiles { get; set; }


        public string GetUsage()
        {
            var help = new HelpText
            {
                AdditionalNewLineAfterOption = true,
                AddDashesToOption = true
            };

            help.AddPreOptionsLine("Import from files to Graph Engine storage.");
            help.AddPreOptionsLine(string.Format("Usage: {0} [-t tsl] [-d directory] [-o output_dir] [--delimiter delimiter] [-f file_format] [--notrim] [-a tsl_assembly|-g] [explicit files]", Path.GetFileName(Assembly.GetExecutingAssembly().Location)));

            //help.AddOptions(this);
            // todo scan for supported file types
            help.AddPostOptionsLine("Only files with .json, .csv, .tsv and .ntriples suffix are recognized.");
            help.AddPostOptionsLine("The file name of a data file will be used as the type for deserialization (except for RDF files).");
            help.AddPostOptionsLine("The type must be defined as a Graph Engine cell in the TSL.\n");

            return help;
        }
    }
}
