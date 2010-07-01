using dotless.Core.Engine;

namespace dotless.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Exceptions;
    using Loggers;
    using Parser.Infrastructure;

    public class LessEngine : ILessEngine
    {
        public Parser.Parser Parser { get; set; }
        public ILogger Logger { get; set; }
		  public bool Compress { get; set; }
		  public ColorFormat ColorFormat { get; set; }

		  public LessEngine(Parser.Parser parser, ILogger logger, bool compress, ColorFormat colorFormat)
        {
            Parser = parser;
            Logger = logger;
            Compress = compress;
				ColorFormat = colorFormat;
        }

        public LessEngine(Parser.Parser parser)
            : this(parser, new ConsoleLogger(LogLevel.Error), false, ColorFormat.Named)
        {
        }

        public LessEngine()
            : this(new Parser.Parser())
        {
        }

        public string TransformToCss(string source, string fileName)
        {
            try
            {
                var tree = Parser.Parse(source, fileName);

					 var env = new Env { Compress = Compress, ColorFormat = ColorFormat };

                var css = tree.ToCSS(env);

                return css;
            }
            catch (ParserException e)
            {
                Logger.Error(e.Message);
            }

            return "";
        }

        public IEnumerable<string> GetImports()
        {
            return Parser.Importer.Imports.Distinct();
        }
    }
}