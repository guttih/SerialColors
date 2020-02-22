using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("SerialColors")]
[assembly: AssemblyDescription(@"This is a server application which sends colors to COM ports.

The program expects to get a number from a connected COM port when sending the text string ""status"" to it.

On the other end of the COM port should be a microcontroller eather Arduino, Esp2866 or Esp32.
The program for these microcontollers is located in the application folder accessable from the Menu
""Open Client folder"".

Before running this application, upload the Client program to one of the microcontoller mentioned above, 
connect them to a RGB light or a RGB strip (not addressable) and connect them to the computer via USB or Bluetooth.
")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("XGuðjón Hólm Sigurðsson")]
[assembly: AssemblyProduct("SerialColors")]
[assembly: AssemblyCopyright("Copyright ©  2019")]
[assembly: AssemblyTrademark("guttih")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
                
[assembly: Guid("25e607d7-7c70-4fc1-a6d0-a87f8b4b89b0")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
