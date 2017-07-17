Class Application
    Private Sub Application_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
        Logging_Service.LoadLogFile()
    End Sub

    Private Sub OnAppStartup_UpdateThemeName(sender As Object, e As StartupEventArgs)

        DevExpress.Xpf.Core.ApplicationThemeHelper.UpdateApplicationThemeName()
    End Sub

    ' Application-level events, such as Startup, Exit, and DispatcherUnhandledException
    ' can be handled in this file.

End Class
