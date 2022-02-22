Imports System.Net
Imports System.IO
Imports System.Web.Script.Serialization
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Actualizar()
        Timer1.Enabled = True
    End Sub
    Private Sub Actualizar()
        Dim uriString2 As String = "https://server.duinocoin.com/balances/Lanthi"
        Dim uri2 As New Uri(uriString2)
        Dim Request2 As HttpWebRequest = HttpWebRequest.Create(uri2)
        Request2.Method = "GET"
        Dim Response2 As HttpWebResponse = Request2.GetResponse()
        Dim Read2 = New StreamReader(Response2.GetResponseStream())
        Dim Raw2 As String = Read2.ReadToEnd()
        Dim dict2 As Object = New JavaScriptSerializer().Deserialize(Of Dictionary(Of String, Object))(Raw2)
        Dim HasesUsuario As Integer = 0
        ' txtUsuario.Text = dict2.item("result").item("balance").item("username")
        txtbalance.Text = dict2.item("result").item("balance")

        Dim uriString As String = "https://server.duinocoin.com/statistics"
        Dim uri As New Uri(uriString)
        Dim Request As HttpWebRequest = HttpWebRequest.Create(uri)
        Request.Method = "GET"
        Dim Response As HttpWebResponse = Request.GetResponse()
        Dim Read = New StreamReader(Response.GetResponseStream())
        Dim Raw As String = Read.ReadToEnd()
        Dim dict As Object = New JavaScriptSerializer().Deserialize(Of Dictionary(Of String, Object))(Raw)
        txtDucoprice.Text = dict.item("Duco price")
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Actualizar()
    End Sub
End Class
