Imports System.Collections.ObjectModel
Imports Prism.Commands
Imports Prism.Mvvm

Public Class Logger_ViewModel
    Inherits BindableBase

#Region "Fields"
#Region "Msg"
    Private _Msg As String
    Public Property Msg As String
        Get
            Return _Msg
        End Get
        Set(value As String)
            _Msg = value
            RaisePropertyChanged("Msg")
        End Set
    End Property
#End Region
    Public Property Logs As New ObservableCollection(Of LogItem)
#End Region
#Region "Commands"
#Region "Log"
#Region "LogInfo_CMD"
    Public Property LogInfo_CMD As DelegateCommand = New DelegateCommand(AddressOf LogInfo)
    Private Sub LogInfo()
        Log("INFO","Msg # INFO INFO")
    End Sub
#End Region
#Region "LogWarning_CMD"
    Public Property LogWarning_CMD As DelegateCommand = New DelegateCommand(AddressOf LogWarning)
    Private Sub LogWarning()
        Log("WARN","Msg # WAWAWAWAWAWAW")
    End Sub
#End Region
#Region "LogError_CMD"
    Public Property LogError_CMD As DelegateCommand = New DelegateCommand(AddressOf LogError)
    Private Sub LogError()
        Log("ERROR","Msg # asdasasasasdasdasdsadsaddassda")
    End Sub
#End Region

#Region "Log_Method"
    Private Sub Log(LogType As String, Msg As String)
        Dim LogMsg As String = String.Concat(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"), "|", LogType, "|", Msg, Environment.NewLine)
        My.Computer.FileSystem.WriteAllText(Logging_Service.LogFilePath, LogMsg, True)
    End Sub
#End Region
#End Region
#Region "AddLogItem_CMD"
    Public Property AddLogItem_CMD As DelegateCommand = New DelegateCommand(AddressOf AddLogItem)
    Private Sub AddLogItem()
        For Each Line As String In System.IO.File.ReadAllLines(Logging_Service.LogFilePath)
            Logs.Add(New LogItem)
            'DataGridView1.Rows.Add(line.Split(","))
        Next

    End Sub
#End Region


#Region "Refresh_CMD"
    Public Property Refresh_CMD As DelegateCommand = New DelegateCommand(AddressOf Refresh)
    Private Sub Refresh()
        Dim newLogs = Logging_Service.TranslateLog

        For Each l In newLogs
            Logs.Add(l)
        Next

    End Sub
#End Region
#Region "OpenLogFile_CMD"
    Public Property OpenLogFile_CMD As DelegateCommand = New DelegateCommand(AddressOf OpenLogFile)
    Private Sub OpenLogFile()
        Process.Start(Logging_Service.LogFilePath)
    End Sub
#End Region
#End Region
End Class
