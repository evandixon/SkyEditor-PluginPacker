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

            Dim a = Assembly.ReflectionOnlyLoadFrom(args(1))
            Dim assemblyName = a.GetName

            'Create info.skyext with relevant info (possibly grabbed using reflection)
            Dim info As ExtensionInfo
            Dim infoPath As String = Path.Combine(Path.GetDirectoryName(args(1)), "info.skyext")
            If File.Exists(infoPath) Then
                info = Json.DeserializeFromFile(Of ExtensionInfo)(infoPath)
            Else
                info = New ExtensionInfo
            End If

            'Set/update relevant info (like extension type)
            info.ExtensionTypeName = GetType(PluginExtensionType).AssemblyQualifiedName
            info.Name = assemblyName.Name
            info.Version = assemblyName.Version.ToString(4)

            'Zip the directory, including info.skyext
            Utilities.Zip.Zip(Path.GetDirectoryName(args(1)), args(2))
        Else
            Console.WriteLine("Usage: SkyEditor-PluginPacker.exe <AssemblyPath> <TargetZipPath>")
            Environment.Exit(1)
        End If
    End Sub

End Module
