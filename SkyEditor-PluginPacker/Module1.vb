Imports System.IO
Imports System.Reflection
Imports SkyEditor.Core
Imports SkyEditor.Core.Extensions
Imports SkyEditor.Core.Windows.Utilities

Module Module1

    Sub Main()
        Dim args = Environment.GetCommandLineArgs
        If args.Length > 2 Then
            Console.WriteLine("Sky Editor Plugin Packer v" & Assembly.GetExecutingAssembly.GetName.Version.ToString(3))
            Console.WriteLine()

            'Todo: create info.skyext with relevant info (possibly grabbed using reflection)
            'Todo: if info.skyext exists, update relevant info (like extension type)
            'Todo: zip the directory, including info.skyext

            Throw New NotImplementedException

            ''Scrap this
            'Using manager As New PluginManager
            '    Dim core As New PluginPackPluginCore(args(1))
            '    Console.WriteLine("Loading core...")
            '    manager.LoadCore(core).Wait()

            '    Console.WriteLine("Setting up...")
            '    Dim dependant = core.DependantPlugin
            '    Dim a = dependant.GetType.Assembly
            '    Dim info As New ExtensionInfo
            '    info.Name = dependant.PluginName
            '    'Todo: set description
            '    info.Author = dependant.PluginAuthor
            '    info.Version = a.GetName.Version.ToString(3)

            '    If Not Directory.Exists(Path.GetDirectoryName(args(2))) Then
            '        Directory.CreateDirectory(Path.GetDirectoryName(args(2)))
            '    End If

            '    Console.WriteLine("Packing plugin...")
            '    RedistributionHelpers.PackPlugins({dependant}, args(2), info, manager).Wait()

            '    Console.WriteLine("Done!")
            'End Using
        Else
            Console.WriteLine("Usage: SkyEditor-PluginPacker.exe <AssemblyPath> <TargetZipPath>")
            Environment.Exit(1)
        End If
    End Sub

End Module
