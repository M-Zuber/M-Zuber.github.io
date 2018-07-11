#load nuget:https://www.myget.org/F/cake-contrib/api/v2?package=Cake.Wyam.Recipe&version=0.5.0

Environment.SetVariableNames();

BuildParameters.SetParameters(context: Context,
                            buildSystem: BuildSystem,
                            title: "M-Zuber",
                            repositoryOwner: "M-Zuber",
                            repositoryName: "M-Zuber.github.io",
                            appVeyorAccountName: "M-Zuber",
                            wyamTheme: "Phantom");

BuildParameters.PrintParameters(Context);

Build.Run();