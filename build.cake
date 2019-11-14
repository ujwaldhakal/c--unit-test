#tool "xunit.runner.console"

var target = Argument("target", "Default");

Task("Default")
  .Does(() =>
{
  MSBuild("./codingTask.sln");
});

RunTarget(target);