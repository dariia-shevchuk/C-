using AP.SlLoggerr;
using LoggerExampleApp;
using System.Diagnostics;

Debug.WriteLine("Hello, World!");

var logger = new Logger(AP.SlLoggerr.Enums.LogLevel.Information);
var myMath = new MyMath(logger);


