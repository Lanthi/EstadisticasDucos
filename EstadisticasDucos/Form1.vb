Imports System.Net
Imports System.IO
Imports System.Web.Script.Serialization
Public Class Form1
    Dim Remover As Integer = 30
    Dim ContadorRemove As Integer = 0
    Dim BalanceHora(23) As Decimal
    Dim PrecioHora(23) As Decimal
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
        Añadir()
    End Sub
    Private Sub Añadir()
        lstBalanceTiempoReal.Items.Add(txtbalance.Text)
        lstDUCOTiempoReal.Items.Add(txtDucoprice.Text)
        BalanceHora(Hour(Now)) = txtbalance.Text
        PrecioHora(Hour(Now)) = txtDucoprice.Text
        'Chart1.Series(0).Points.Add(txtbalance.Text)
        ContadorRemove += 1
        If ContadorRemove > Remover Then
            lstBalanceTiempoReal.Items.RemoveAt(0)
            lstDUCOTiempoReal.Items.RemoveAt(0)
        End If
        lstBalanceHora.Items.Clear()
        lstDucoHora.Items.Clear()
        For I As Integer = 0 To 23
            If I > 9 Then
                lstDucoHora.Items.Add("Hora: " & I & ":00 = " & PrecioHora(I))
                'lstBalanceHora.Items.Add("Hora: " & I & ":00 = " & BalanceHora(I))
            Else
                lstDucoHora.Items.Add("Hora: 0" & I & ":00 = " & PrecioHora(I))
                ' lstBalanceHora.Items.Add("Hora: 0" & I & ":00 = " & BalanceHora(I))
            End If
        Next
        Select Case Hour(Now)
            Case 0 : If lblBalanceHora00.Text <> "" Then lblBalanceHora00.Text = txtbalance.Text
            Case 12 : If lblBalanceHora12.Text <> "" Then lblBalanceHora12.Text = txtbalance.Text
        End Select
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Actualizar()
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub
End Class
