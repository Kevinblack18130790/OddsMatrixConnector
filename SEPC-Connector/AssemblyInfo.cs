using log4net.Config;
using System.Reflection;
using System.Resources;

[assembly: XmlConfigurator(ConfigFile = "log4net.config.xml", Watch = true)]
[assembly: AssemblyCompany("Everymatrix")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyDescription("The Sports Engine Publication Component (SEPC) is the component to which clients connect in order to get the Sports Engine data.\nWe provide a C#-based connector which knows how to connect to and communicate with the SEPC.")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("SEPC-Connector")]
[assembly: AssemblyTitle("SEPC-Connector")]
[assembly: NeutralResourcesLanguage("en")]
[assembly: AssemblyVersion("1.0.0.0")]
