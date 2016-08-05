Imports System.Reflection
Imports SkyEditor.Core
Imports SkyEditor.Core.Utilities

Public Class PluginPackPluginCore
    Inherits SkyEditor.Core.Windows.CoreMods.ConsoleCoreMod

    Public Sub New(targetFilename As String)
        MyBase.New
        Me.TargetFilename = targetFilename
    End Sub

    Public Property TargetFilename As String

    ''' <summary>
    ''' The plugin located at <see cref="TargetFilename"/>.  Will be null until <see cref="Load(PluginManager)"/> is called.
    ''' </summary>
    Public Property DependantPlugin As SkyEditorPlugin


    Public Overrides Sub Load(manager As PluginManager)
        MyBase.Load(manager)

        Dim targetAssembly = LoadAssembly(TargetFilename)
        Dim firstPluginType = targetAssembly.GetTypes.Where(Function(x) ReflectionHelpers.IsOfType(x, GetType(SkyEditorPlugin).GetTypeInfo) AndAlso ReflectionHelpers.CanCreateInstance(x)).FirstOrDefault
        If firstPluginType Is Nothing Then
            Throw New Exception("Target assembly is not a valid Sky Editor plugin.")
        Else
            Dim plugin = ReflectionHelpers.CreateInstance(firstPluginType)
            manager.LoadRequiredPlugin(plugin, Me)
            DependantPlugin = plugin
        End If
    End Sub

End Class
