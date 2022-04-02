using Ap.SlMarsRover;
using AP.SlLoggerr;
using LoggerExampleApp;
using System.Diagnostics;

Debug.WriteLine("Hello, World!");
var controller = new LoggerController(new LoggerBase[] {new ConsoleLogger(),
    new OutputLogger(),
    new NewSomStufLogger(),
    new FileLogger()
}); 

var logger = new Logger(AP.SlLoggerr.Enums.LogLevel.Trace,controller);
var myMath = new MyMath(logger);

var marsRover = new MarsRover(logger);


var result = myMath.Add(5, 5);

var rr = myMath.Divide(2, 0);







