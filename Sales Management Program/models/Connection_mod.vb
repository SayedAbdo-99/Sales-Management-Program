Imports System.Data.SqlClient
Module Connection_mod

    Public ConStr As String = "Data Source=" & Edit_Connection.GetconectionData().D_source & ";Initial Catalog =" & Edit_Connection.GetconectionData().D_Basc & ";integrated security=true"
    'Public ConStr As String = "Data Source=192.168.1.4.1433; Initial Catalog=SMSDB; User ID = sayed99;Password=sayed99"
    Public Con As New SqlClient.SqlConnection(ConStr)
    'DESKTOP-8J96CGF\MSSQLEXPRESS
    'SMSDB
End Module
