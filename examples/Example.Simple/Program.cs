using Tags.Logging;

// only do this once
Logger.RegisterLogFunction(Logger.toConsole);

Sender identity = new Sender("Example.Simple");

Logger.Debug("Hello, Debug!");

Logger.Debug("Hello, Debug! (with identity)", identity);
// OR
identity.Debug("Hello, Debug! (called from identity)");

Logger.Info("Hello, Info!");
Logger.Warn("Hello, Warn!");
Logger.Error("Hello, Error!");
Logger.Fatal("Hello, Fatal!");