Imports Microsoft.VisualBasic.ApplicationServices

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
    Partial Friend Class MyApplication
        Private Sub MyApplication_UnhandledException(sender As Object, e As UnhandledExceptionEventArgs) Handles Me.UnhandledException
            Dim Logs As New SettingsManager.LogsMangaer("Event Logs")

            Logs.WriteToErrorLog(e.Exception.Message, e.Exception.StackTrace, "Unhandled Exception")

            MessageBox.Show("The program has encountered an unrecoverable error situation. The details have been recorded to the error log." & vbCrLf & vbCrLf &
                "For technical support contact OptoTech Pty. Ltd. along with a description of the activity you werecurrenty undertaking, and a copy of all log files (both error and event logs).")


        End Sub
    End Class
End Namespace
