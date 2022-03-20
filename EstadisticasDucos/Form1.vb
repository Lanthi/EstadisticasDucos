Imports System.Net
Imports System.IO
Imports System.Drawing.Graphics
Imports System.Web.Script.Serialization
Public Class Form1
    Dim Remover As Integer = 30
    Dim ContadorRemove As Integer = 0
    Dim Hora As Integer
    Dim Minutos As Integer = DateAndTime.Minute(Now)
    Dim Segundos As Integer
    Dim ContadorTiempo As Integer = 0
    Dim cuadro As Rectangle = New Rectangle(50, 500, 150, 150)
    Dim trazo As Pen = New Pen(Brushes.Gold, 30)
    Dim ángulo As Single = 50
    Dim letras As New Font("Arial", 25)
    Dim sf As New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
    Dim EnviosDias(4) As Integer
    Dim EnviosMes(4) As Integer
    Dim EnviosAño(4) As Integer
    Dim Recibido(4) As Boolean
    Dim Transacion(31) As Decimal
    Dim EstimadoViejo As Decimal = 0
    Dim EstimadoNuevo As Decimal = 0
    Dim ValorEstimado As Decimal
    Dim ValorEstimadoMes As Decimal
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            For I As Integer = 0 To 30
                Transacion(I) = 0
            Next
            Actualizar()
            Añadir()
            Timer1.Enabled = True
            lblHora.Text = DateAndTime.TimeValue(Now)
            If lblBalanceHora01.Text <> 0 And lblBalanceHora00.Text <> 0 Then lblHoraDiferencia00.Text = CDec(lblBalanceHora01.Text) - CDec(lblBalanceHora00.Text)
            If lblBalanceHora02.Text <> 0 And lblBalanceHora01.Text <> 0 Then lblHoraDiferencia01.Text = CDec(lblBalanceHora02.Text) - CDec(lblBalanceHora01.Text)
            If lblBalanceHora03.Text <> 0 And lblBalanceHora02.Text <> 0 Then lblHoraDiferencia02.Text = CDec(lblBalanceHora03.Text) - CDec(lblBalanceHora02.Text)
            If lblBalanceHora04.Text <> 0 And lblBalanceHora03.Text <> 0 Then lblHoraDiferencia03.Text = CDec(lblBalanceHora04.Text) - CDec(lblBalanceHora03.Text)
            If lblBalanceHora05.Text <> 0 And lblBalanceHora04.Text <> 0 Then lblHoraDiferencia04.Text = CDec(lblBalanceHora05.Text) - CDec(lblBalanceHora04.Text)
            If lblBalanceHora06.Text <> 0 And lblBalanceHora05.Text <> 0 Then lblHoraDiferencia05.Text = CDec(lblBalanceHora06.Text) - CDec(lblBalanceHora05.Text)
            If lblBalanceHora07.Text <> 0 And lblBalanceHora06.Text <> 0 Then lblHoraDiferencia06.Text = CDec(lblBalanceHora07.Text) - CDec(lblBalanceHora06.Text)
            If lblBalanceHora08.Text <> 0 And lblBalanceHora07.Text <> 0 Then lblHoraDiferencia07.Text = CDec(lblBalanceHora08.Text) - CDec(lblBalanceHora07.Text)
            If lblBalanceHora09.Text <> 0 And lblBalanceHora08.Text <> 0 Then lblHoraDiferencia08.Text = CDec(lblBalanceHora09.Text) - CDec(lblBalanceHora08.Text)
            If lblBalanceHora10.Text <> 0 And lblBalanceHora09.Text <> 0 Then lblHoraDiferencia09.Text = CDec(lblBalanceHora10.Text) - CDec(lblBalanceHora09.Text)
            If lblBalanceHora11.Text <> 0 And lblBalanceHora10.Text <> 0 Then lblHoraDiferencia10.Text = CDec(lblBalanceHora11.Text) - CDec(lblBalanceHora10.Text)
            If lblBalanceHora12.Text <> 0 And lblBalanceHora11.Text <> 0 Then lblHoraDiferencia11.Text = CDec(lblBalanceHora12.Text) - CDec(lblBalanceHora11.Text)
            If lblBalanceHora13.Text <> 0 And lblBalanceHora12.Text <> 0 Then lblHoraDiferencia12.Text = CDec(lblBalanceHora13.Text) - CDec(lblBalanceHora12.Text)
            If lblBalanceHora14.Text <> 0 And lblBalanceHora13.Text <> 0 Then lblHoraDiferencia13.Text = CDec(lblBalanceHora14.Text) - CDec(lblBalanceHora13.Text)
            If lblBalanceHora15.Text <> 0 And lblBalanceHora14.Text <> 0 Then lblHoraDiferencia14.Text = CDec(lblBalanceHora15.Text) - CDec(lblBalanceHora14.Text)
            If lblBalanceHora16.Text <> 0 And lblBalanceHora15.Text <> 0 Then lblHoraDiferencia15.Text = CDec(lblBalanceHora16.Text) - CDec(lblBalanceHora15.Text)
            If lblBalanceHora17.Text <> 0 And lblBalanceHora16.Text <> 0 Then lblHoraDiferencia16.Text = CDec(lblBalanceHora17.Text) - CDec(lblBalanceHora16.Text)
            If lblBalanceHora18.Text <> 0 And lblBalanceHora17.Text <> 0 Then lblHoraDiferencia17.Text = CDec(lblBalanceHora18.Text) - CDec(lblBalanceHora17.Text)
            If lblBalanceHora19.Text <> 0 And lblBalanceHora18.Text <> 0 Then lblHoraDiferencia18.Text = CDec(lblBalanceHora19.Text) - CDec(lblBalanceHora18.Text)
            If lblBalanceHora20.Text <> 0 And lblBalanceHora19.Text <> 0 Then lblHoraDiferencia19.Text = CDec(lblBalanceHora20.Text) - CDec(lblBalanceHora19.Text)
            If lblBalanceHora21.Text <> 0 And lblBalanceHora20.Text <> 0 Then lblHoraDiferencia20.Text = CDec(lblBalanceHora21.Text) - CDec(lblBalanceHora20.Text)
            If lblBalanceHora22.Text <> 0 And lblBalanceHora21.Text <> 0 Then lblHoraDiferencia21.Text = CDec(lblBalanceHora22.Text) - CDec(lblBalanceHora21.Text)
            If lblBalanceHora23.Text <> 0 And lblBalanceHora22.Text <> 0 Then lblHoraDiferencia22.Text = CDec(lblBalanceHora23.Text) - CDec(lblBalanceHora22.Text)
            If lblMesBalance01.Text <> 0 And lblMesBalance02.Text <> 0 Then lblMesDifencia01.Text = CDec(lblMesBalance01.Text) - CDec(lblMesBalance01.Text) + Transacion(31)
            If lblMesBalance02.Text <> 0 And lblMesBalance01.Text <> 0 Then lblMesDifencia01.Text = CDec(lblMesBalance02.Text) - CDec(lblMesBalance01.Text) + Transacion(1)
            If lblMesBalance03.Text <> 0 And lblMesBalance02.Text <> 0 Then lblMesDifencia02.Text = CDec(lblMesBalance03.Text) - CDec(lblMesBalance02.Text) + Transacion(2)
            If lblMesBalance04.Text <> 0 And lblMesBalance03.Text <> 0 Then lblMesDifencia03.Text = CDec(lblMesBalance04.Text) - CDec(lblMesBalance03.Text) + Transacion(3)
            If lblMesBalance05.Text <> 0 And lblMesBalance04.Text <> 0 Then lblMesDifencia04.Text = CDec(lblMesBalance05.Text) - CDec(lblMesBalance04.Text) + Transacion(4)
            If lblMesBalance06.Text <> 0 And lblMesBalance05.Text <> 0 Then lblMesDifencia05.Text = CDec(lblMesBalance06.Text) - CDec(lblMesBalance05.Text) + Transacion(5)
            If lblMesBalance07.Text <> 0 And lblMesBalance06.Text <> 0 Then lblMesDifencia06.Text = CDec(lblMesBalance07.Text) - CDec(lblMesBalance06.Text) + Transacion(6)
            If lblMesBalance08.Text <> 0 And lblMesBalance07.Text <> 0 Then lblMesDifencia07.Text = CDec(lblMesBalance08.Text) - CDec(lblMesBalance07.Text) + Transacion(7)
            If lblMesBalance09.Text <> 0 And lblMesBalance08.Text <> 0 Then lblMesDifencia08.Text = CDec(lblMesBalance09.Text) - CDec(lblMesBalance08.Text) + Transacion(8)
            If lblMesBalance10.Text <> 0 And lblMesBalance09.Text <> 0 Then lblMesDifencia09.Text = CDec(lblMesBalance10.Text) - CDec(lblMesBalance09.Text) + Transacion(9)
            If lblMesBalance11.Text <> 0 And lblMesBalance10.Text <> 0 Then lblMesDifencia10.Text = CDec(lblMesBalance11.Text) - CDec(lblMesBalance10.Text) + Transacion(10)
            If lblMesBalance12.Text <> 0 And lblMesBalance11.Text <> 0 Then lblMesDifencia11.Text = CDec(lblMesBalance12.Text) - CDec(lblMesBalance11.Text) + Transacion(11)
            If lblMesBalance13.Text <> 0 And lblMesBalance12.Text <> 0 Then lblMesDifencia12.Text = CDec(lblMesBalance13.Text) - CDec(lblMesBalance12.Text) + Transacion(12)
            If lblMesBalance14.Text <> 0 And lblMesBalance13.Text <> 0 Then lblMesDifencia13.Text = CDec(lblMesBalance14.Text) - CDec(lblMesBalance13.Text) + Transacion(13)
            If lblMesBalance15.Text <> 0 And lblMesBalance14.Text <> 0 Then lblMesDifencia14.Text = CDec(lblMesBalance15.Text) - CDec(lblMesBalance14.Text) + Transacion(14)
            If lblMesBalance16.Text <> 0 And lblMesBalance15.Text <> 0 Then lblMesDifencia15.Text = CDec(lblMesBalance16.Text) - CDec(lblMesBalance15.Text) + Transacion(15)
            If lblMesBalance17.Text <> 0 And lblMesBalance16.Text <> 0 Then lblMesDifencia16.Text = CDec(lblMesBalance17.Text) - CDec(lblMesBalance16.Text) + Transacion(16)
            If lblMesBalance18.Text <> 0 And lblMesBalance17.Text <> 0 Then lblMesDifencia17.Text = CDec(lblMesBalance18.Text) - CDec(lblMesBalance17.Text) + Transacion(17)
            If lblMesBalance19.Text <> 0 And lblMesBalance18.Text <> 0 Then lblMesDifencia18.Text = CDec(lblMesBalance19.Text) - CDec(lblMesBalance18.Text) + Transacion(18)
            If lblMesBalance20.Text <> 0 And lblMesBalance19.Text <> 0 Then lblMesDifencia19.Text = CDec(lblMesBalance20.Text) - CDec(lblMesBalance19.Text) + Transacion(19)
            If lblMesBalance21.Text <> 0 And lblMesBalance20.Text <> 0 Then lblMesDifencia20.Text = CDec(lblMesBalance21.Text) - CDec(lblMesBalance20.Text) + Transacion(20)
            If lblMesBalance22.Text <> 0 And lblMesBalance21.Text <> 0 Then lblMesDifencia21.Text = CDec(lblMesBalance22.Text) - CDec(lblMesBalance21.Text) + Transacion(21)
            If lblMesBalance23.Text <> 0 And lblMesBalance22.Text <> 0 Then lblMesDifencia22.Text = CDec(lblMesBalance23.Text) - CDec(lblMesBalance22.Text) + Transacion(22)
            If lblMesBalance24.Text <> 0 And lblMesBalance23.Text <> 0 Then lblMesDifencia23.Text = CDec(lblMesBalance24.Text) - CDec(lblMesBalance23.Text) + Transacion(23)
            If lblMesBalance25.Text <> 0 And lblMesBalance24.Text <> 0 Then lblMesDifencia24.Text = CDec(lblMesBalance25.Text) - CDec(lblMesBalance24.Text) + Transacion(24)
            If lblMesBalance26.Text <> 0 And lblMesBalance25.Text <> 0 Then lblMesDifencia25.Text = CDec(lblMesBalance26.Text) - CDec(lblMesBalance25.Text) + Transacion(25)
            If lblMesBalance27.Text <> 0 And lblMesBalance26.Text <> 0 Then lblMesDifencia26.Text = CDec(lblMesBalance27.Text) - CDec(lblMesBalance26.Text) + Transacion(26)
            If lblMesBalance28.Text <> 0 And lblMesBalance27.Text <> 0 Then lblMesDifencia27.Text = CDec(lblMesBalance28.Text) - CDec(lblMesBalance27.Text) + Transacion(27)
            If lblMesBalance29.Text <> 0 And lblMesBalance28.Text <> 0 Then lblMesDifencia28.Text = CDec(lblMesBalance29.Text) - CDec(lblMesBalance28.Text) + Transacion(28)
            If lblMesBalance30.Text <> 0 And lblMesBalance29.Text <> 0 Then lblMesDifencia29.Text = CDec(lblMesBalance30.Text) - CDec(lblMesBalance29.Text) + Transacion(29)
            If lblMesBalance31.Text <> 0 And lblMesBalance30.Text <> 0 Then lblMesDifencia30.Text = CDec(lblMesBalance31.Text) - CDec(lblMesBalance30.Text) + Transacion(30)

            lblTotalHora.Text = 0
            lblTotalHora.Text += CDec(lblHoraDiferencia00.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia01.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia02.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia03.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia04.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia05.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia06.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia07.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia08.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia09.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia10.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia11.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia12.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia13.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia14.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia15.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia16.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia17.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia18.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia19.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia20.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia21.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia22.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia23.Text)
            lblTotalMes.Text = 0
            lblTotalMes.Text += CDec(lblMesDifencia01.Text)
            lblTotalMes.Text += CDec(lblMesDifencia02.Text)
            lblTotalMes.Text += CDec(lblMesDifencia03.Text)
            lblTotalMes.Text += CDec(lblMesDifencia04.Text)
            lblTotalMes.Text += CDec(lblMesDifencia05.Text)
            lblTotalMes.Text += CDec(lblMesDifencia06.Text)
            lblTotalMes.Text += CDec(lblMesDifencia07.Text)
            lblTotalMes.Text += CDec(lblMesDifencia08.Text)
            lblTotalMes.Text += CDec(lblMesDifencia09.Text)
            lblTotalMes.Text += CDec(lblMesDifencia10.Text)
            lblTotalMes.Text += CDec(lblMesDifencia11.Text)
            lblTotalMes.Text += CDec(lblMesDifencia12.Text)
            lblTotalMes.Text += CDec(lblMesDifencia13.Text)
            lblTotalMes.Text += CDec(lblMesDifencia14.Text)
            lblTotalMes.Text += CDec(lblMesDifencia15.Text)
            lblTotalMes.Text += CDec(lblMesDifencia16.Text)
            lblTotalMes.Text += CDec(lblMesDifencia17.Text)
            lblTotalMes.Text += CDec(lblMesDifencia18.Text)
            lblTotalMes.Text += CDec(lblMesDifencia19.Text)
            lblTotalMes.Text += CDec(lblMesDifencia20.Text)
            lblTotalMes.Text += CDec(lblMesDifencia21.Text)
            lblTotalMes.Text += CDec(lblMesDifencia22.Text)
            lblTotalMes.Text += CDec(lblMesDifencia23.Text)
            lblTotalMes.Text += CDec(lblMesDifencia24.Text)
            lblTotalMes.Text += CDec(lblMesDifencia25.Text)
            lblTotalMes.Text += CDec(lblMesDifencia26.Text)
            lblTotalMes.Text += CDec(lblMesDifencia27.Text)
            lblTotalMes.Text += CDec(lblMesDifencia28.Text)
            lblTotalMes.Text += CDec(lblMesDifencia29.Text)
            lblTotalMes.Text += CDec(lblMesDifencia30.Text)
            lblTotalMes.Text += CDec(lblMesDifencia31.Text)

            MostrarMes()
            Chart3.Series(0).Points.Clear()
            Chart3.Series(0).Points.AddXY(TimeValue("00:00"), CDec(lblHoraDiferencia00.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("01:00"), CDec(lblHoraDiferencia01.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("02:00"), CDec(lblHoraDiferencia02.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("03:00"), CDec(lblHoraDiferencia03.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("04:00"), CDec(lblHoraDiferencia04.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("05:00"), CDec(lblHoraDiferencia05.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("06:00"), CDec(lblHoraDiferencia06.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("07:00"), CDec(lblHoraDiferencia07.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("08:00"), CDec(lblHoraDiferencia08.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("09:00"), CDec(lblHoraDiferencia09.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("10:00"), CDec(lblHoraDiferencia10.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("11:00"), CDec(lblHoraDiferencia11.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("12:00"), CDec(lblHoraDiferencia12.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("13:00"), CDec(lblHoraDiferencia13.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("14:00"), CDec(lblHoraDiferencia14.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("15:00"), CDec(lblHoraDiferencia15.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("16:00"), CDec(lblHoraDiferencia16.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("17:00"), CDec(lblHoraDiferencia17.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("18:00"), CDec(lblHoraDiferencia18.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("19:00"), CDec(lblHoraDiferencia19.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("20:00"), CDec(lblHoraDiferencia20.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("21:00"), CDec(lblHoraDiferencia21.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("22:00"), CDec(lblHoraDiferencia22.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("23:00"), CDec(lblHoraDiferencia23.Text))
            Chart6.Series(0).Points.AddXY(Format(DateAndTime.TimeValue(Now), "HH:mm:ss"), CDec(Format(ValorEstimado, "###0.00")))
        Catch ex As Exception
            MsgBox("Error!!" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub MostrarMes()
        Dim Dato As Date = DateAndTime.Now
        Dim UltimoDía As Date = DateSerial(Dato.Year, Dato.Month + 1, 0)
        Dim UltimoDiaMes As Integer = Mid(UltimoDía, 1, 2)

        Select Case UltimoDiaMes
            Case 31
                lbl31.Visible = True
                lblMesBalance31.Visible = True
                lblMesPrecio31.Visible = True
                lblMesDifencia31.Visible = True

                lbl30.Visible = True
                lblMesBalance30.Visible = True
                lblMesPrecio30.Visible = True
                lblMesDifencia30.Visible = True

                lbl29.Visible = True
                lblMesBalance29.Visible = True
                lblMesPrecio29.Visible = True
                lblMesDifencia29.Visible = True
                lblTotalMes.Location = New Point(156, 568)
                lblMesDaily.Location = New Point(13, 571)
                gpMes.Size = New Size(333, 607)
            Case 30
                lbl31.Visible = False
                lblMesBalance31.Visible = False
                lblMesPrecio31.Visible = False
                lblMesDifencia31.Visible = False

                lbl30.Visible = True
                lblMesBalance30.Visible = True
                lblMesPrecio30.Visible = True
                lblMesDifencia30.Visible = True

                lbl29.Visible = True
                lblMesBalance29.Visible = True
                lblMesPrecio29.Visible = True
                lblMesDifencia29.Visible = True
                lblTotalMes.Location = New Point(156, 551)
                lblMesDaily.Location = New Point(13, 554)
                gpMes.Size = New Size(333, 593)
            Case 29
                lbl31.Visible = False
                lblMesBalance31.Visible = False
                lblMesPrecio31.Visible = False
                lblMesDifencia31.Visible = False

                lbl30.Visible = False
                lblMesBalance30.Visible = False
                lblMesPrecio30.Visible = False
                lblMesDifencia30.Visible = False

                lbl29.Visible = True
                lblMesBalance29.Visible = True
                lblMesPrecio29.Visible = True
                lblMesDifencia29.Visible = True
                lblTotalMes.Location = New Point(156, 534)
                lblMesDaily.Location = New Point(13, 537)
                gpMes.Size = New Size(333, 577)
            Case 28
                lbl31.Visible = False
                lblMesBalance31.Visible = False
                lblMesPrecio31.Visible = False
                lblMesDifencia31.Visible = False

                lbl30.Visible = False
                lblMesBalance30.Visible = False
                lblMesPrecio30.Visible = False
                lblMesDifencia30.Visible = False

                lbl29.Visible = False
                lblMesBalance29.Visible = False
                lblMesPrecio29.Visible = False
                lblMesDifencia29.Visible = False
                lblTotalMes.Location = New Point(156, 517)
                lblMesDaily.Location = New Point(13, 520)
                gpMes.Size = New Size(333, 558)
        End Select
    End Sub
    Private Sub Actualizar()
        Try
            Dim Euro As Decimal
            Dim uriString3 As String = "http://www.floatrates.com/daily/eur.json"
            Dim uri3 As New Uri(uriString3)
            Dim Request3 As HttpWebRequest = HttpWebRequest.Create(uri3)
            Request3.Method = "GET"
            Dim Response3 As HttpWebResponse = Request3.GetResponse()
            Dim Read3 = New StreamReader(Response3.GetResponseStream())
            Dim Raw3 As String = Read3.ReadToEnd()
            Dim dict3 As Object = New JavaScriptSerializer().Deserialize(Of Dictionary(Of String, Object))(Raw3)

            Dim uriString2 As String = "https://server.duinocoin.com/users/Lanthi"
            Dim uri2 As New Uri(uriString2)
            Dim Request2 As HttpWebRequest = HttpWebRequest.Create(uri2)
            Request2.Method = "GET"
            Dim Response2 As HttpWebResponse = Request2.GetResponse()
            Dim Read2 = New StreamReader(Response2.GetResponseStream())
            Dim Raw2 As String = Read2.ReadToEnd()
            Dim dict2 As Object = New JavaScriptSerializer().Deserialize(Of Dictionary(Of String, Object))(Raw2)
            Dim uriString As String = "https://server.duinocoin.com/api.json"
            Dim uri As New Uri(uriString)
            Dim Request As HttpWebRequest = HttpWebRequest.Create(uri)
            Request.Method = "GET"
            Dim Response As HttpWebResponse = Request.GetResponse()
            Dim Read = New StreamReader(Response.GetResponseStream())
            Dim Raw As String = Read.ReadToEnd()
            Dim dict As Object = New JavaScriptSerializer().Deserialize(Of Dictionary(Of String, Object))(Raw)
            Euro = CDec(dict3.item("usd").item("rate"))
            txtDucoprice.Text = CDec(dict.item("Duco price"))
            txtbalance.Text = dict2.item("result").item("balance").item("balance")
            EstimadoNuevo = txtbalance.Text
            If EstimadoViejo = 0 Then
                EstimadoViejo = EstimadoNuevo
            Else
                ValorEstimado = (EstimadoNuevo - EstimadoViejo) * (86400 / 30)
                ValorEstimadoMes = (EstimadoNuevo - EstimadoViejo) * 86400
                EstimadoViejo = EstimadoNuevo
            End If
            lblEstimado.Text = Format(ValorEstimado, "###0.00")
            lblEstimadoDetalle.Text = "daily (≈" & Format(ValorEstimado * CDec(txtDucoprice.Text), "0.000") & ")"
            lblEstimadoMes.Text = Format(ValorEstimadoMes, "###0.00")
            lblEstimadoMesDetalle.Text = "monthly (≈" & Format(ValorEstimadoMes * CDec(txtDucoprice.Text), "0.000") & ")"
            Dim Segundoss As String = Segundos
            If ValorEstimado > 0 Then
                Select Case Segundos
                    Case "01" : Segundoss = "00"
                    Case "02" : Segundoss = "00"
                    Case "31" : Segundoss = "30"
                    Case "32" : Segundoss = "30"
                End Select

                If Segundos <= 9 Then
                    If Minutos <= 9 Then
                        ' lblHora.Text = Hora & ":0" & Minutos & ":0" & Segundos
                        Chart6.Series(0).Points.AddXY(Hora & ":0" & Minutos & ":0" & Segundoss, CDec(Format(ValorEstimado, "###0.00")))
                    Else
                        ' lblHora.Text = Hora & ":" & Minutos & ":0" & Segundos
                        Chart6.Series(0).Points.AddXY(Hora & ":" & Minutos & ":0" & Segundoss, CDec(Format(ValorEstimado, "###0.00")))
                    End If
                Else
                    If Minutos <= 9 Then
                        ' lblHora.Text = Hora & ":0" & Minutos & ":" & Segundos
                        Chart6.Series(0).Points.AddXY(Hora & ":0" & Minutos & ":" & Segundoss, CDec(Format(ValorEstimado, "###0.00")))
                    Else
                        ' lblHora.Text = Hora & ":" & Minutos & ":" & Segundos
                        Chart6.Series(0).Points.AddXY(Hora & ":" & Minutos & ":" & Segundoss, CDec(Format(ValorEstimado, "###0.00")))
                    End If

                End If




            End If


            lblValorEuro.Text = Euro & "€"
            lblGanado.Text = Format(CDec(txtbalance.Text) * CDec(txtDucoprice.Text) * Euro, "###0.0000")
            lblGanadoDolar.Text = Format(CDec(txtbalance.Text) * CDec(txtDucoprice.Text), "###0.0000")
            lstBalanceTiempoReal.Items.Add(txtbalance.Text)
            lstDUCOTiempoReal.Items.Add(txtDucoprice.Text)
            ContadorRemove += 1
            If ContadorRemove > Remover Then
                lstBalanceTiempoReal.Items.RemoveAt(0)
                lstDUCOTiempoReal.Items.RemoveAt(0)
            End If
            TreeView1.Nodes.Clear()
            Dim Mesis As String = DateAndTime.Month(Now)
            If DateAndTime.Month(Now) <= 9 Then
                Mesis = "0" & DateAndTime.Month(Now)
            Else
                Mesis = DateAndTime.Month(Now)
            End If
            For I As Integer = 4 To 0 Step -1
                EnviosDias(I) = Mid(dict2.item("result").item("transactions").item(I).item("datetime"), 1, 2)
                EnviosMes(I) = Mid(dict2.item("result").item("transactions").item(I).item("datetime"), 4, 2)
                EnviosAño(I) = Mid(dict2.item("result").item("transactions").item(I).item("datetime"), 7, 4)

                If dict2.item("result").item("transactions").item(I).item("sender") = "Lanthi" Then
                    TreeView1.Nodes.Add("Enviado: " & dict2.item("result").item("transactions").item(I).item("amount") & " Ducos enviado a " & dict2.item("result").item("transactions").item(I).item("recipient"))
                    If Transacion(EnviosDias(I)) = 0 Then If EnviosMes(I) = Mesis Then Transacion(EnviosDias(I)) += CDec(dict2.item("result").item("transactions").item(I).item("amount"))
                Else
                    TreeView1.Nodes.Add("Recibido: " & dict2.item("result").item("transactions").item(I).item("amount") & " Ducos recibido de " & dict2.item("result").item("transactions").item(I).item("sender"))
                    If Transacion(EnviosDias(I)) = 0 Then If EnviosMes(I) = DateAndTime.Month(Now) Then Transacion(EnviosDias(I)) -= CDec(dict2.item("result").item("transactions").item(I).item("amount"))
                End If
                TreeView1.Nodes.Add("Fecha/hora: " & dict2.item("result").item("transactions").item(I).item("datetime"))
                TreeView1.Nodes.Add("Hash: " & dict2.item("result").item("transactions").item(I).item("hash"))
                TreeView1.Nodes.Add("Memo: " & dict2.item("result").item("transactions").item(I).item("memo"))
                ' TreeView1.Nodes.Add(EnviosDias(I) & "/" & EnviosMes(I) & "/" & EnviosAño(I))
                ' TreeView1.Nodes.Add(Transacion(EnviosDias(I)))
                ' TreeView1.Nodes.Add(dict2.item("result").item("transactions").item(I).item("sender"))
                If I <> 0 Then TreeView1.Nodes.Add("")
            Next
            TreeView1.ExpandAll()
            Select Case Hour(Now)
                Case 0 : If lblBalanceHora00.Text <> 0 Then lblHoraDiferencia00.Text = CDec(txtbalance.Text) - CDec(lblBalanceHora00.Text)
                Case 1 : If lblBalanceHora01.Text <> 0 Then lblHoraDiferencia01.Text = CDec(txtbalance.Text) - CDec(lblBalanceHora01.Text)
                Case 2 : If lblBalanceHora02.Text <> 0 Then lblHoraDiferencia02.Text = CDec(txtbalance.Text) - CDec(lblBalanceHora02.Text)
                Case 3 : If lblBalanceHora03.Text <> 0 Then lblHoraDiferencia03.Text = CDec(txtbalance.Text) - CDec(lblBalanceHora03.Text)
                Case 4 : If lblBalanceHora04.Text <> 0 Then lblHoraDiferencia04.Text = CDec(txtbalance.Text) - CDec(lblBalanceHora04.Text)
                Case 5 : If lblBalanceHora05.Text <> 0 Then lblHoraDiferencia05.Text = CDec(txtbalance.Text) - CDec(lblBalanceHora05.Text)
                Case 6 : If lblBalanceHora06.Text <> 0 Then lblHoraDiferencia06.Text = CDec(txtbalance.Text) - CDec(lblBalanceHora06.Text)
                Case 7 : If lblBalanceHora07.Text <> 0 Then lblHoraDiferencia07.Text = CDec(txtbalance.Text) - CDec(lblBalanceHora07.Text)
                Case 8 : If lblBalanceHora08.Text <> 0 Then lblHoraDiferencia08.Text = CDec(txtbalance.Text) - CDec(lblBalanceHora08.Text)
                Case 9 : If lblBalanceHora09.Text <> 0 Then lblHoraDiferencia09.Text = CDec(txtbalance.Text) - CDec(lblBalanceHora09.Text)
                Case 10 : If lblBalanceHora10.Text <> 0 Then lblHoraDiferencia10.Text = CDec(txtbalance.Text) - CDec(lblBalanceHora10.Text)
                Case 11 : If lblBalanceHora11.Text <> 0 Then lblHoraDiferencia11.Text = CDec(txtbalance.Text) - CDec(lblBalanceHora11.Text)
                Case 12 : If lblBalanceHora12.Text <> 0 Then lblHoraDiferencia12.Text = CDec(txtbalance.Text) - CDec(lblBalanceHora12.Text)
                Case 13 : If lblBalanceHora13.Text <> 0 Then lblHoraDiferencia13.Text = CDec(txtbalance.Text) - CDec(lblBalanceHora13.Text)
                Case 14 : If lblBalanceHora14.Text <> 0 Then lblHoraDiferencia14.Text = CDec(txtbalance.Text) - CDec(lblBalanceHora14.Text)
                Case 15 : If lblBalanceHora15.Text <> 0 Then lblHoraDiferencia15.Text = CDec(txtbalance.Text) - CDec(lblBalanceHora15.Text)
                Case 16 : If lblBalanceHora16.Text <> 0 Then lblHoraDiferencia16.Text = CDec(txtbalance.Text) - CDec(lblBalanceHora16.Text)
                Case 17 : If lblBalanceHora17.Text <> 0 Then lblHoraDiferencia17.Text = CDec(txtbalance.Text) - CDec(lblBalanceHora17.Text)
                Case 18 : If lblBalanceHora18.Text <> 0 Then lblHoraDiferencia18.Text = CDec(txtbalance.Text) - CDec(lblBalanceHora18.Text)
                Case 19 : If lblBalanceHora19.Text <> 0 Then lblHoraDiferencia19.Text = CDec(txtbalance.Text) - CDec(lblBalanceHora19.Text)
                Case 20 : If lblBalanceHora20.Text <> 0 Then lblHoraDiferencia20.Text = CDec(txtbalance.Text) - CDec(lblBalanceHora20.Text)
                Case 21 : If lblBalanceHora21.Text <> 0 Then lblHoraDiferencia21.Text = CDec(txtbalance.Text) - CDec(lblBalanceHora21.Text)
                Case 22 : If lblBalanceHora22.Text <> 0 Then lblHoraDiferencia22.Text = CDec(txtbalance.Text) - CDec(lblBalanceHora22.Text)
                Case 23 : If lblBalanceHora23.Text <> 0 Then lblHoraDiferencia23.Text = CDec(txtbalance.Text) - CDec(lblBalanceHora23.Text)
            End Select
            Select Case DateAndTime.Day(Now)
                Case 1 : If lblMesBalance01.Text <> 0 Then lblMesDifencia01.Text = CDec(txtbalance.Text) - CDec(lblMesBalance01.Text) + Transacion(31)
                Case 2 : If lblMesBalance02.Text <> 0 Then lblMesDifencia02.Text = CDec(txtbalance.Text) - CDec(lblMesBalance02.Text) + Transacion(1)
                Case 3 : If lblMesBalance03.Text <> 0 Then lblMesDifencia03.Text = CDec(txtbalance.Text) - CDec(lblMesBalance03.Text) + Transacion(2)
                Case 4 : If lblMesBalance04.Text <> 0 Then lblMesDifencia04.Text = CDec(txtbalance.Text) - CDec(lblMesBalance04.Text) + Transacion(3)
                Case 5 : If lblMesBalance05.Text <> 0 Then lblMesDifencia05.Text = CDec(txtbalance.Text) - CDec(lblMesBalance05.Text) + Transacion(4)
                Case 6 : If lblMesBalance06.Text <> 0 Then lblMesDifencia06.Text = CDec(txtbalance.Text) - CDec(lblMesBalance06.Text) + Transacion(5)
                Case 7 : If lblMesBalance07.Text <> 0 Then lblMesDifencia07.Text = CDec(txtbalance.Text) - CDec(lblMesBalance07.Text) + Transacion(6)
                Case 8 : If lblMesBalance08.Text <> 0 Then lblMesDifencia08.Text = CDec(txtbalance.Text) - CDec(lblMesBalance08.Text) + Transacion(7)
                Case 9 : If lblMesBalance09.Text <> 0 Then lblMesDifencia09.Text = CDec(txtbalance.Text) - CDec(lblMesBalance09.Text) + Transacion(8)
                Case 10 : If lblMesBalance10.Text <> 0 Then lblMesDifencia10.Text = CDec(txtbalance.Text) - CDec(lblMesBalance10.Text) + Transacion(9)
                Case 11 : If lblMesBalance11.Text <> 0 Then lblMesDifencia11.Text = CDec(txtbalance.Text) - CDec(lblMesBalance11.Text) + Transacion(10)
                Case 12 : If lblMesBalance12.Text <> 0 Then lblMesDifencia12.Text = CDec(txtbalance.Text) - CDec(lblMesBalance12.Text) + Transacion(11)
                Case 13 : If lblMesBalance13.Text <> 0 Then lblMesDifencia13.Text = CDec(txtbalance.Text) - CDec(lblMesBalance13.Text) + Transacion(12)
                Case 14 : If lblMesBalance14.Text <> 0 Then lblMesDifencia14.Text = CDec(txtbalance.Text) - CDec(lblMesBalance14.Text) + Transacion(13)
                Case 15 : If lblMesBalance15.Text <> 0 Then lblMesDifencia15.Text = CDec(txtbalance.Text) - CDec(lblMesBalance15.Text) + Transacion(14)
                Case 16 : If lblMesBalance16.Text <> 0 Then lblMesDifencia16.Text = CDec(txtbalance.Text) - CDec(lblMesBalance16.Text) + Transacion(15)
                Case 17 : If lblMesBalance17.Text <> 0 Then lblMesDifencia17.Text = CDec(txtbalance.Text) - CDec(lblMesBalance17.Text) + Transacion(16)
                Case 18 : If lblMesBalance18.Text <> 0 Then lblMesDifencia18.Text = CDec(txtbalance.Text) - CDec(lblMesBalance18.Text) + Transacion(17)
                Case 19 : If lblMesBalance19.Text <> 0 Then lblMesDifencia19.Text = CDec(txtbalance.Text) - CDec(lblMesBalance19.Text) + Transacion(18)
                Case 20 : If lblMesBalance20.Text <> 0 Then lblMesDifencia20.Text = CDec(txtbalance.Text) - CDec(lblMesBalance20.Text) + Transacion(19)
                Case 21 : If lblMesBalance21.Text <> 0 Then lblMesDifencia21.Text = CDec(txtbalance.Text) - CDec(lblMesBalance21.Text) + Transacion(20)
                Case 22 : If lblMesBalance22.Text <> 0 Then lblMesDifencia22.Text = CDec(txtbalance.Text) - CDec(lblMesBalance22.Text) + Transacion(21)
                Case 23 : If lblMesBalance23.Text <> 0 Then lblMesDifencia23.Text = CDec(txtbalance.Text) - CDec(lblMesBalance23.Text) + Transacion(22)
                Case 24 : If lblMesBalance24.Text <> 0 Then lblMesDifencia24.Text = CDec(txtbalance.Text) - CDec(lblMesBalance24.Text) + Transacion(23)
                Case 25 : If lblMesBalance25.Text <> 0 Then lblMesDifencia25.Text = CDec(txtbalance.Text) - CDec(lblMesBalance25.Text) + Transacion(24)
                Case 26 : If lblMesBalance26.Text <> 0 Then lblMesDifencia26.Text = CDec(txtbalance.Text) - CDec(lblMesBalance26.Text) + Transacion(25)
                Case 27 : If lblMesBalance27.Text <> 0 Then lblMesDifencia27.Text = CDec(txtbalance.Text) - CDec(lblMesBalance27.Text) + Transacion(26)
                Case 28 : If lblMesBalance28.Text <> 0 Then lblMesDifencia28.Text = CDec(txtbalance.Text) - CDec(lblMesBalance28.Text) + Transacion(27)
                Case 29 : If lblMesBalance29.Text <> 0 Then lblMesDifencia29.Text = CDec(txtbalance.Text) - CDec(lblMesBalance29.Text) + Transacion(28)
                Case 30 : If lblMesBalance30.Text <> 0 Then lblMesDifencia30.Text = CDec(txtbalance.Text) - CDec(lblMesBalance30.Text) + Transacion(29)
                Case 31 : If lblMesBalance31.Text <> 0 Then lblMesDifencia31.Text = CDec(txtbalance.Text) - CDec(lblMesBalance01.Text) + Transacion(30)
            End Select

            lblTotalHora.Text = 0
            lblTotalHora.Text += CDec(lblHoraDiferencia00.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia01.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia02.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia03.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia04.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia05.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia06.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia07.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia08.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia09.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia10.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia11.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia12.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia13.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia14.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia15.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia16.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia17.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia18.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia19.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia20.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia21.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia22.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia23.Text)
            lblTotalMes.Text = 0
            lblTotalMes.Text += CDec(lblMesDifencia01.Text)
            lblTotalMes.Text += CDec(lblMesDifencia02.Text)
            lblTotalMes.Text += CDec(lblMesDifencia03.Text)
            lblTotalMes.Text += CDec(lblMesDifencia04.Text)
            lblTotalMes.Text += CDec(lblMesDifencia05.Text)
            lblTotalMes.Text += CDec(lblMesDifencia06.Text)
            lblTotalMes.Text += CDec(lblMesDifencia07.Text)
            lblTotalMes.Text += CDec(lblMesDifencia08.Text)
            lblTotalMes.Text += CDec(lblMesDifencia09.Text)
            lblTotalMes.Text += CDec(lblMesDifencia10.Text)
            lblTotalMes.Text += CDec(lblMesDifencia11.Text)
            lblTotalMes.Text += CDec(lblMesDifencia12.Text)
            lblTotalMes.Text += CDec(lblMesDifencia13.Text)
            lblTotalMes.Text += CDec(lblMesDifencia14.Text)
            lblTotalMes.Text += CDec(lblMesDifencia15.Text)
            lblTotalMes.Text += CDec(lblMesDifencia16.Text)
            lblTotalMes.Text += CDec(lblMesDifencia17.Text)
            lblTotalMes.Text += CDec(lblMesDifencia18.Text)
            lblTotalMes.Text += CDec(lblMesDifencia19.Text)
            lblTotalMes.Text += CDec(lblMesDifencia20.Text)
            lblTotalMes.Text += CDec(lblMesDifencia21.Text)
            lblTotalMes.Text += CDec(lblMesDifencia22.Text)
            lblTotalMes.Text += CDec(lblMesDifencia23.Text)
            lblTotalMes.Text += CDec(lblMesDifencia24.Text)
            lblTotalMes.Text += CDec(lblMesDifencia25.Text)
            lblTotalMes.Text += CDec(lblMesDifencia26.Text)
            lblTotalMes.Text += CDec(lblMesDifencia27.Text)
            lblTotalMes.Text += CDec(lblMesDifencia28.Text)
            lblTotalMes.Text += CDec(lblMesDifencia29.Text)
            lblTotalMes.Text += CDec(lblMesDifencia30.Text)
            lblTotalMes.Text += CDec(lblMesDifencia31.Text)
            Chart1.Series(0).Points.Clear()
            Chart1.Series(0).Points.AddXY(TimeValue("00:00"), CDec(lblPrecio00.Text))
            Chart1.Series(0).Points.AddXY(TimeValue("01:00"), CDec(lblPrecio01.Text))
            Chart1.Series(0).Points.AddXY(TimeValue("02:00"), CDec(lblPrecio02.Text))
            Chart1.Series(0).Points.AddXY(TimeValue("03:00"), CDec(lblPrecio03.Text))
            Chart1.Series(0).Points.AddXY(TimeValue("04:00"), CDec(lblPrecio04.Text))
            Chart1.Series(0).Points.AddXY(TimeValue("05:00"), CDec(lblPrecio05.Text))
            Chart1.Series(0).Points.AddXY(TimeValue("06:00"), CDec(lblPrecio06.Text))
            Chart1.Series(0).Points.AddXY(TimeValue("07:00"), CDec(lblPrecio07.Text))
            Chart1.Series(0).Points.AddXY(TimeValue("08:00"), CDec(lblPrecio08.Text))
            Chart1.Series(0).Points.AddXY(TimeValue("09:00"), CDec(lblPrecio09.Text))
            Chart1.Series(0).Points.AddXY(TimeValue("10:00"), CDec(lblPrecio10.Text))
            Chart1.Series(0).Points.AddXY(TimeValue("11:00"), CDec(lblPrecio11.Text))
            Chart1.Series(0).Points.AddXY(TimeValue("12:00"), CDec(lblPrecio12.Text))
            Chart1.Series(0).Points.AddXY(TimeValue("13:00"), CDec(lblPrecio13.Text))
            Chart1.Series(0).Points.AddXY(TimeValue("14:00"), CDec(lblPrecio14.Text))
            Chart1.Series(0).Points.AddXY(TimeValue("15:00"), CDec(lblPrecio15.Text))
            Chart1.Series(0).Points.AddXY(TimeValue("16:00"), CDec(lblPrecio16.Text))
            Chart1.Series(0).Points.AddXY(TimeValue("17:00"), CDec(lblPrecio17.Text))
            Chart1.Series(0).Points.AddXY(TimeValue("18:00"), CDec(lblPrecio18.Text))
            Chart1.Series(0).Points.AddXY(TimeValue("19:00"), CDec(lblPrecio19.Text))
            Chart1.Series(0).Points.AddXY(TimeValue("20:00"), CDec(lblPrecio20.Text))
            Chart1.Series(0).Points.AddXY(TimeValue("21:00"), CDec(lblPrecio21.Text))
            Chart1.Series(0).Points.AddXY(TimeValue("22:00"), CDec(lblPrecio22.Text))
            Chart1.Series(0).Points.AddXY(TimeValue("23:00"), CDec(lblPrecio23.Text))

            Chart2.Series(0).Points.Clear()
            Chart2.Series(0).Points.AddXY(TimeValue("00:00"), CDec(lblBalanceHora00.Text))
            Chart2.Series(0).Points.AddXY(TimeValue("01:00"), CDec(lblBalanceHora01.Text))
            Chart2.Series(0).Points.AddXY(TimeValue("02:00"), CDec(lblBalanceHora02.Text))
            Chart2.Series(0).Points.AddXY(TimeValue("03:00"), CDec(lblBalanceHora03.Text))
            Chart2.Series(0).Points.AddXY(TimeValue("04:00"), CDec(lblBalanceHora04.Text))
            Chart2.Series(0).Points.AddXY(TimeValue("05:00"), CDec(lblBalanceHora05.Text))
            Chart2.Series(0).Points.AddXY(TimeValue("06:00"), CDec(lblBalanceHora06.Text))
            Chart2.Series(0).Points.AddXY(TimeValue("07:00"), CDec(lblBalanceHora07.Text))
            Chart2.Series(0).Points.AddXY(TimeValue("08:00"), CDec(lblBalanceHora08.Text))
            Chart2.Series(0).Points.AddXY(TimeValue("09:00"), CDec(lblBalanceHora09.Text))
            Chart2.Series(0).Points.AddXY(TimeValue("10:00"), CDec(lblBalanceHora10.Text))
            Chart2.Series(0).Points.AddXY(TimeValue("11:00"), CDec(lblBalanceHora11.Text))
            Chart2.Series(0).Points.AddXY(TimeValue("12:00"), CDec(lblBalanceHora12.Text))
            Chart2.Series(0).Points.AddXY(TimeValue("13:00"), CDec(lblBalanceHora13.Text))
            Chart2.Series(0).Points.AddXY(TimeValue("14:00"), CDec(lblBalanceHora14.Text))
            Chart2.Series(0).Points.AddXY(TimeValue("15:00"), CDec(lblBalanceHora15.Text))
            Chart2.Series(0).Points.AddXY(TimeValue("16:00"), CDec(lblBalanceHora16.Text))
            Chart2.Series(0).Points.AddXY(TimeValue("17:00"), CDec(lblBalanceHora17.Text))
            Chart2.Series(0).Points.AddXY(TimeValue("18:00"), CDec(lblBalanceHora18.Text))
            Chart2.Series(0).Points.AddXY(TimeValue("19:00"), CDec(lblBalanceHora19.Text))
            Chart2.Series(0).Points.AddXY(TimeValue("20:00"), CDec(lblBalanceHora20.Text))
            Chart2.Series(0).Points.AddXY(TimeValue("21:00"), CDec(lblBalanceHora21.Text))
            Chart2.Series(0).Points.AddXY(TimeValue("22:00"), CDec(lblBalanceHora22.Text))
            Chart2.Series(0).Points.AddXY(TimeValue("23:00"), CDec(lblBalanceHora23.Text))

            Chart3.Series(0).Points.Clear()
            Chart3.Series(0).Points.AddXY(TimeValue("00:00"), CDec(lblHoraDiferencia00.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("01:00"), CDec(lblHoraDiferencia01.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("02:00"), CDec(lblHoraDiferencia02.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("03:00"), CDec(lblHoraDiferencia03.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("04:00"), CDec(lblHoraDiferencia04.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("05:00"), CDec(lblHoraDiferencia05.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("06:00"), CDec(lblHoraDiferencia06.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("07:00"), CDec(lblHoraDiferencia07.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("08:00"), CDec(lblHoraDiferencia08.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("09:00"), CDec(lblHoraDiferencia09.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("10:00"), CDec(lblHoraDiferencia10.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("11:00"), CDec(lblHoraDiferencia11.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("12:00"), CDec(lblHoraDiferencia12.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("13:00"), CDec(lblHoraDiferencia13.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("14:00"), CDec(lblHoraDiferencia14.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("15:00"), CDec(lblHoraDiferencia15.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("16:00"), CDec(lblHoraDiferencia16.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("17:00"), CDec(lblHoraDiferencia17.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("18:00"), CDec(lblHoraDiferencia18.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("19:00"), CDec(lblHoraDiferencia19.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("20:00"), CDec(lblHoraDiferencia20.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("21:00"), CDec(lblHoraDiferencia21.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("22:00"), CDec(lblHoraDiferencia22.Text))
            Chart3.Series(0).Points.AddXY(TimeValue("23:00"), CDec(lblHoraDiferencia23.Text))

            Chart4.Series(0).Points.Clear()
            Chart5.Series(0).Points.Clear()
            Chart4.Series(0).Points.AddXY("Day 01", CDec(lblMesBalance01.Text))
            Chart5.Series(0).Points.AddXY("Day 01", CDec(lblMesPrecio01.Text))
            Chart4.Series(0).Points.AddXY("Day 02", CDec(lblMesBalance02.Text))
            Chart5.Series(0).Points.AddXY("Day 02", CDec(lblMesPrecio02.Text))
            Chart4.Series(0).Points.AddXY("Day 03", CDec(lblMesBalance03.Text))
            Chart5.Series(0).Points.AddXY("Day 03", CDec(lblMesPrecio03.Text))
            Chart4.Series(0).Points.AddXY("Day 04", CDec(lblMesBalance04.Text))
            Chart5.Series(0).Points.AddXY("Day 04", CDec(lblMesPrecio04.Text))
            Chart4.Series(0).Points.AddXY("Day 05", CDec(lblMesBalance05.Text))
            Chart5.Series(0).Points.AddXY("Day 05", CDec(lblMesPrecio05.Text))
            Chart4.Series(0).Points.AddXY("Day 06", CDec(lblMesBalance06.Text))
            Chart5.Series(0).Points.AddXY("Day 06", CDec(lblMesPrecio06.Text))
            Chart4.Series(0).Points.AddXY("Day 07", CDec(lblMesBalance07.Text))
            Chart5.Series(0).Points.AddXY("Day 07", CDec(lblMesPrecio07.Text))
            Chart4.Series(0).Points.AddXY("Day 08", CDec(lblMesBalance08.Text))
            Chart5.Series(0).Points.AddXY("Day 08", CDec(lblMesPrecio08.Text))
            Chart4.Series(0).Points.AddXY("Day 09", CDec(lblMesBalance09.Text))
            Chart5.Series(0).Points.AddXY("Day 09", CDec(lblMesPrecio09.Text))
            Chart4.Series(0).Points.AddXY("Day 10", CDec(lblMesBalance10.Text))
            Chart5.Series(0).Points.AddXY("Day 10", CDec(lblMesPrecio10.Text))
            Chart4.Series(0).Points.AddXY("Day 11", CDec(lblMesBalance11.Text))
            Chart5.Series(0).Points.AddXY("Day 11", CDec(lblMesPrecio11.Text))
            Chart4.Series(0).Points.AddXY("Day 12", CDec(lblMesBalance12.Text))
            Chart5.Series(0).Points.AddXY("Day 12", CDec(lblMesPrecio12.Text))
            Chart4.Series(0).Points.AddXY("Day 13", CDec(lblMesBalance13.Text))
            Chart5.Series(0).Points.AddXY("Day 13", CDec(lblMesPrecio13.Text))
            Chart4.Series(0).Points.AddXY("Day 14", CDec(lblMesBalance14.Text))
            Chart5.Series(0).Points.AddXY("Day 14", CDec(lblMesPrecio14.Text))
            Chart4.Series(0).Points.AddXY("Day 15", CDec(lblMesBalance15.Text))
            Chart5.Series(0).Points.AddXY("Day 15", CDec(lblMesPrecio15.Text))
            Chart4.Series(0).Points.AddXY("Day 16", CDec(lblMesBalance16.Text))
            Chart5.Series(0).Points.AddXY("Day 16", CDec(lblMesPrecio16.Text))
            Chart4.Series(0).Points.AddXY("Day 17", CDec(lblMesBalance17.Text))
            Chart5.Series(0).Points.AddXY("Day 17", CDec(lblMesPrecio17.Text))
            Chart4.Series(0).Points.AddXY("Day 18", CDec(lblMesBalance18.Text))
            Chart5.Series(0).Points.AddXY("Day 18", CDec(lblMesPrecio18.Text))
            Chart4.Series(0).Points.AddXY("Day 19", CDec(lblMesBalance19.Text))
            Chart5.Series(0).Points.AddXY("Day 19", CDec(lblMesPrecio19.Text))
            Chart4.Series(0).Points.AddXY("Day 20", CDec(lblMesBalance20.Text))
            Chart5.Series(0).Points.AddXY("Day 20", CDec(lblMesPrecio20.Text))
            Chart4.Series(0).Points.AddXY("Day 21", CDec(lblMesBalance21.Text))
            Chart5.Series(0).Points.AddXY("Day 21", CDec(lblMesPrecio21.Text))
            Chart4.Series(0).Points.AddXY("Day 22", CDec(lblMesBalance22.Text))
            Chart5.Series(0).Points.AddXY("Day 22", CDec(lblMesPrecio22.Text))
            Chart4.Series(0).Points.AddXY("Day 23", CDec(lblMesBalance23.Text))
            Chart5.Series(0).Points.AddXY("Day 23", CDec(lblMesPrecio23.Text))
            Chart4.Series(0).Points.AddXY("Day 24", CDec(lblMesBalance24.Text))
            Chart5.Series(0).Points.AddXY("Day 24", CDec(lblMesPrecio24.Text))
            Chart4.Series(0).Points.AddXY("Day 25", CDec(lblMesBalance25.Text))
            Chart5.Series(0).Points.AddXY("Day 25", CDec(lblMesPrecio25.Text))
            Chart4.Series(0).Points.AddXY("Day 26", CDec(lblMesBalance26.Text))
            Chart5.Series(0).Points.AddXY("Day 26", CDec(lblMesPrecio26.Text))
            Chart4.Series(0).Points.AddXY("Day 27", CDec(lblMesBalance27.Text))
            Chart5.Series(0).Points.AddXY("Day 27", CDec(lblMesPrecio27.Text))
            Chart4.Series(0).Points.AddXY("Day 28", CDec(lblMesBalance28.Text))
            Chart5.Series(0).Points.AddXY("Day 28", CDec(lblMesPrecio28.Text))
            Chart4.Series(0).Points.AddXY("Day 29", CDec(lblMesBalance29.Text))
            Chart5.Series(0).Points.AddXY("Day 29", CDec(lblMesPrecio29.Text))
            Chart4.Series(0).Points.AddXY("Day 30", CDec(lblMesBalance30.Text))
            Chart5.Series(0).Points.AddXY("Day 30", CDec(lblMesPrecio30.Text))
            Chart4.Series(0).Points.AddXY("Day 31", CDec(lblMesBalance31.Text))
            Chart5.Series(0).Points.AddXY("Day 31", CDec(lblMesPrecio31.Text))
        Catch ex As Exception
            MsgBox("Error!!" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Añadir()
        Try

            Select Case Hour(Now)
                Case 0
                    lblBalanceHora00.Text = txtbalance.Text
                    lblPrecio00.Text = txtDucoprice.Text
                    lblHoraDiferencia00.Text = CDec(lblBalanceHora00.Text) - CDec(lblBalanceHora23.Text)
                    lblBalanceHora01.Text = "0"
                    lblBalanceHora02.Text = "0"
                    lblBalanceHora03.Text = "0"
                    lblBalanceHora04.Text = "0"
                    lblBalanceHora05.Text = "0"
                    lblBalanceHora06.Text = "0"
                    lblBalanceHora07.Text = "0"
                    lblBalanceHora08.Text = "0"
                    lblBalanceHora09.Text = "0"
                    lblBalanceHora10.Text = "0"
                    lblBalanceHora11.Text = "0"
                    lblBalanceHora12.Text = "0"
                    lblBalanceHora13.Text = "0"
                    lblBalanceHora14.Text = "0"
                    lblBalanceHora15.Text = "0"
                    lblBalanceHora16.Text = "0"
                    lblBalanceHora17.Text = "0"
                    lblBalanceHora18.Text = "0"
                    lblBalanceHora19.Text = "0"
                    lblBalanceHora20.Text = "0"
                    lblBalanceHora21.Text = "0"
                    lblBalanceHora22.Text = "0"
                    lblBalanceHora23.Text = "0"

                    lblPrecio01.Text = "0"
                    lblPrecio02.Text = "0"
                    lblPrecio03.Text = "0"
                    lblPrecio04.Text = "0"
                    lblPrecio05.Text = "0"
                    lblPrecio06.Text = "0"
                    lblPrecio07.Text = "0"
                    lblPrecio08.Text = "0"
                    lblPrecio09.Text = "0"
                    lblPrecio10.Text = "0"
                    lblPrecio11.Text = "0"
                    lblPrecio12.Text = "0"
                    lblPrecio13.Text = "0"
                    lblPrecio14.Text = "0"
                    lblPrecio15.Text = "0"
                    lblPrecio16.Text = "0"
                    lblPrecio17.Text = "0"
                    lblPrecio18.Text = "0"
                    lblPrecio19.Text = "0"
                    lblPrecio20.Text = "0"
                    lblPrecio21.Text = "0"
                    lblPrecio22.Text = "0"
                    lblPrecio23.Text = "0"

                    lblHoraDiferencia01.Text = 0
                    lblHoraDiferencia02.Text = 0
                    lblHoraDiferencia03.Text = 0
                    lblHoraDiferencia04.Text = 0
                    lblHoraDiferencia05.Text = 0
                    lblHoraDiferencia06.Text = 0
                    lblHoraDiferencia07.Text = 0
                    lblHoraDiferencia08.Text = 0
                    lblHoraDiferencia09.Text = 0
                    lblHoraDiferencia10.Text = 0
                    lblHoraDiferencia11.Text = 0
                    lblHoraDiferencia12.Text = 0
                    lblHoraDiferencia13.Text = 0
                    lblHoraDiferencia14.Text = 0
                    lblHoraDiferencia15.Text = 0
                    lblHoraDiferencia16.Text = 0
                    lblHoraDiferencia17.Text = 0
                    lblHoraDiferencia18.Text = 0
                    lblHoraDiferencia19.Text = 0
                    lblHoraDiferencia20.Text = 0
                    lblHoraDiferencia21.Text = 0
                    lblHoraDiferencia22.Text = 0
                    lblHoraDiferencia23.Text = 0
                    lblTotalHora.Text = lblHoraDiferencia00.Text

                    Select Case DateAndTime.Day(Now)
                        Case 1
                            If Hour(Now) = 0 And Minute(Now) = 0 Then
                                lblMesBalance01.Text = "0"
                                lblMesBalance02.Text = "0"
                                lblMesBalance03.Text = "0"
                                lblMesBalance04.Text = "0"
                                lblMesBalance05.Text = "0"
                                lblMesBalance06.Text = "0"
                                lblMesBalance07.Text = "0"
                                lblMesBalance08.Text = "0"
                                lblMesBalance09.Text = "0"
                                lblMesBalance10.Text = "0"
                                lblMesBalance11.Text = "0"
                                lblMesBalance12.Text = "0"
                                lblMesBalance13.Text = "0"
                                lblMesBalance14.Text = "0"
                                lblMesBalance15.Text = "0"
                                lblMesBalance16.Text = "0"
                                lblMesBalance17.Text = "0"
                                lblMesBalance18.Text = "0"
                                lblMesBalance19.Text = "0"
                                lblMesBalance20.Text = "0"
                                lblMesBalance21.Text = "0"
                                lblMesBalance22.Text = "0"
                                lblMesBalance23.Text = "0"
                                lblMesBalance24.Text = "0"
                                lblMesBalance25.Text = "0"
                                lblMesBalance26.Text = "0"
                                lblMesBalance27.Text = "0"
                                lblMesBalance28.Text = "0"
                                lblMesBalance29.Text = "0"
                                lblMesBalance30.Text = "0"
                                lblMesBalance31.Text = "0"

                                lblMesPrecio01.Text = "0"
                                lblMesPrecio02.Text = "0"
                                lblMesPrecio03.Text = "0"
                                lblMesPrecio04.Text = "0"
                                lblMesPrecio05.Text = "0"
                                lblMesPrecio06.Text = "0"
                                lblMesPrecio07.Text = "0"
                                lblMesPrecio08.Text = "0"
                                lblMesPrecio09.Text = "0"
                                lblMesPrecio10.Text = "0"
                                lblMesPrecio11.Text = "0"
                                lblMesPrecio12.Text = "0"
                                lblMesPrecio13.Text = "0"
                                lblMesPrecio14.Text = "0"
                                lblMesPrecio15.Text = "0"
                                lblMesPrecio16.Text = "0"
                                lblMesPrecio17.Text = "0"
                                lblMesPrecio18.Text = "0"
                                lblMesPrecio19.Text = "0"
                                lblMesPrecio20.Text = "0"
                                lblMesPrecio21.Text = "0"
                                lblMesPrecio22.Text = "0"
                                lblMesPrecio23.Text = "0"
                                lblMesPrecio24.Text = "0"
                                lblMesPrecio25.Text = "0"
                                lblMesPrecio26.Text = "0"
                                lblMesPrecio27.Text = "0"
                                lblMesPrecio28.Text = "0"
                                lblMesPrecio29.Text = "0"
                                lblMesPrecio30.Text = "0"
                                lblMesPrecio31.Text = "0"
                            End If
                            If lblMesBalance01.Text = "0" Then lblMesBalance01.Text = txtbalance.Text : lblMesPrecio01.Text = txtDucoprice.Text

                        Case 2 : If lblMesBalance02.Text = "0" Then lblMesBalance02.Text = txtbalance.Text : lblMesPrecio02.Text = txtDucoprice.Text
                        Case 3 : If lblMesBalance03.Text = "0" Then lblMesBalance03.Text = txtbalance.Text : lblMesPrecio03.Text = txtDucoprice.Text
                        Case 4 : If lblMesBalance04.Text = "0" Then lblMesBalance04.Text = txtbalance.Text : lblMesPrecio04.Text = txtDucoprice.Text
                        Case 5 : If lblMesBalance05.Text = "0" Then lblMesBalance05.Text = txtbalance.Text : lblMesPrecio05.Text = txtDucoprice.Text
                        Case 6 : If lblMesBalance06.Text = "0" Then lblMesBalance06.Text = txtbalance.Text : lblMesPrecio06.Text = txtDucoprice.Text
                        Case 7 : If lblMesBalance07.Text = "0" Then lblMesBalance07.Text = txtbalance.Text : lblMesPrecio07.Text = txtDucoprice.Text
                        Case 8 : If lblMesBalance08.Text = "0" Then lblMesBalance08.Text = txtbalance.Text : lblMesPrecio08.Text = txtDucoprice.Text
                        Case 9 : If lblMesBalance09.Text = "0" Then lblMesBalance09.Text = txtbalance.Text : lblMesPrecio09.Text = txtDucoprice.Text
                        Case 10 : If lblMesBalance10.Text = "0" Then lblMesBalance10.Text = txtbalance.Text : lblMesPrecio10.Text = txtDucoprice.Text
                        Case 11 : If lblMesBalance11.Text = "0" Then lblMesBalance11.Text = txtbalance.Text : lblMesPrecio11.Text = txtDucoprice.Text
                        Case 12 : If lblMesBalance12.Text = "0" Then lblMesBalance12.Text = txtbalance.Text : lblMesPrecio12.Text = txtDucoprice.Text
                        Case 13 : If lblMesBalance13.Text = "0" Then lblMesBalance13.Text = txtbalance.Text : lblMesPrecio13.Text = txtDucoprice.Text
                        Case 14 : If lblMesBalance14.Text = "0" Then lblMesBalance14.Text = txtbalance.Text : lblMesPrecio14.Text = txtDucoprice.Text
                        Case 15 : If lblMesBalance15.Text = "0" Then lblMesBalance15.Text = txtbalance.Text : lblMesPrecio15.Text = txtDucoprice.Text
                        Case 16 : If lblMesBalance16.Text = "0" Then lblMesBalance16.Text = txtbalance.Text : lblMesPrecio16.Text = txtDucoprice.Text
                        Case 17 : If lblMesBalance17.Text = "0" Then lblMesBalance17.Text = txtbalance.Text : lblMesPrecio17.Text = txtDucoprice.Text
                        Case 18 : If lblMesBalance18.Text = "0" Then lblMesBalance18.Text = txtbalance.Text : lblMesPrecio18.Text = txtDucoprice.Text
                        Case 19 : If lblMesBalance19.Text = "0" Then lblMesBalance19.Text = txtbalance.Text : lblMesPrecio19.Text = txtDucoprice.Text
                        Case 20 : If lblMesBalance20.Text = "0" Then lblMesBalance20.Text = txtbalance.Text : lblMesPrecio20.Text = txtDucoprice.Text
                        Case 21 : If lblMesBalance21.Text = "0" Then lblMesBalance21.Text = txtbalance.Text : lblMesPrecio21.Text = txtDucoprice.Text
                        Case 22 : If lblMesBalance22.Text = "0" Then lblMesBalance22.Text = txtbalance.Text : lblMesPrecio22.Text = txtDucoprice.Text
                        Case 23 : If lblMesBalance23.Text = "0" Then lblMesBalance23.Text = txtbalance.Text : lblMesPrecio23.Text = txtDucoprice.Text
                        Case 24 : If lblMesBalance24.Text = "0" Then lblMesBalance24.Text = txtbalance.Text : lblMesPrecio24.Text = txtDucoprice.Text
                        Case 25 : If lblMesBalance25.Text = "0" Then lblMesBalance25.Text = txtbalance.Text : lblMesPrecio25.Text = txtDucoprice.Text
                        Case 26 : If lblMesBalance26.Text = "0" Then lblMesBalance26.Text = txtbalance.Text : lblMesPrecio26.Text = txtDucoprice.Text
                        Case 27 : If lblMesBalance27.Text = "0" Then lblMesBalance27.Text = txtbalance.Text : lblMesPrecio27.Text = txtDucoprice.Text
                        Case 28 : If lblMesBalance28.Text = "0" Then lblMesBalance28.Text = txtbalance.Text : lblMesPrecio28.Text = txtDucoprice.Text
                        Case 29 : If lblMesBalance29.Text = "0" Then lblMesBalance29.Text = txtbalance.Text : lblMesPrecio29.Text = txtDucoprice.Text
                        Case 30 : If lblMesBalance30.Text = "0" Then lblMesBalance30.Text = txtbalance.Text : lblMesPrecio30.Text = txtDucoprice.Text
                        Case 31 : If lblMesBalance31.Text = "0" Then lblMesBalance31.Text = txtbalance.Text : lblMesPrecio31.Text = txtDucoprice.Text

                    End Select

                Case 1 : lblBalanceHora01.Text = txtbalance.Text : lblPrecio01.Text = txtDucoprice.Text
                Case 2 : lblBalanceHora02.Text = txtbalance.Text : lblPrecio02.Text = txtDucoprice.Text
                Case 3 : lblBalanceHora03.Text = txtbalance.Text : lblPrecio03.Text = txtDucoprice.Text
                Case 4 : lblBalanceHora04.Text = txtbalance.Text : lblPrecio04.Text = txtDucoprice.Text
                Case 5 : lblBalanceHora05.Text = txtbalance.Text : lblPrecio05.Text = txtDucoprice.Text
                Case 6 : lblBalanceHora06.Text = txtbalance.Text : lblPrecio06.Text = txtDucoprice.Text
                Case 7 : lblBalanceHora07.Text = txtbalance.Text : lblPrecio07.Text = txtDucoprice.Text
                Case 8 : lblBalanceHora08.Text = txtbalance.Text : lblPrecio08.Text = txtDucoprice.Text
                Case 9 : lblBalanceHora09.Text = txtbalance.Text : lblPrecio09.Text = txtDucoprice.Text
                Case 10 : lblBalanceHora10.Text = txtbalance.Text : lblPrecio10.Text = txtDucoprice.Text
                Case 11 : lblBalanceHora11.Text = txtbalance.Text : lblPrecio11.Text = txtDucoprice.Text
                Case 12 : lblBalanceHora12.Text = txtbalance.Text : lblPrecio12.Text = txtDucoprice.Text
                Case 13 : lblBalanceHora13.Text = txtbalance.Text : lblPrecio13.Text = txtDucoprice.Text
                Case 14 : lblBalanceHora14.Text = txtbalance.Text : lblPrecio14.Text = txtDucoprice.Text
                Case 15 : lblBalanceHora15.Text = txtbalance.Text : lblPrecio15.Text = txtDucoprice.Text
                Case 16 : lblBalanceHora16.Text = txtbalance.Text : lblPrecio16.Text = txtDucoprice.Text
                Case 17 : lblBalanceHora17.Text = txtbalance.Text : lblPrecio17.Text = txtDucoprice.Text
                Case 18 : lblBalanceHora18.Text = txtbalance.Text : lblPrecio18.Text = txtDucoprice.Text
                Case 19 : lblBalanceHora19.Text = txtbalance.Text : lblPrecio19.Text = txtDucoprice.Text
                Case 20 : lblBalanceHora20.Text = txtbalance.Text : lblPrecio20.Text = txtDucoprice.Text
                Case 21 : lblBalanceHora21.Text = txtbalance.Text : lblPrecio21.Text = txtDucoprice.Text
                Case 22 : lblBalanceHora22.Text = txtbalance.Text : lblPrecio22.Text = txtDucoprice.Text
                Case 23 : lblBalanceHora23.Text = txtbalance.Text : lblPrecio23.Text = txtDucoprice.Text
            End Select
            If lblBalanceHora01.Text <> 0 And lblBalanceHora00.Text <> 0 Then lblHoraDiferencia00.Text = CDec(lblBalanceHora01.Text) - CDec(lblBalanceHora00.Text)
            If lblBalanceHora02.Text <> 0 And lblBalanceHora01.Text <> 0 Then lblHoraDiferencia01.Text = CDec(lblBalanceHora02.Text) - CDec(lblBalanceHora01.Text)
            If lblBalanceHora03.Text <> 0 And lblBalanceHora02.Text <> 0 Then lblHoraDiferencia02.Text = CDec(lblBalanceHora03.Text) - CDec(lblBalanceHora02.Text)
            If lblBalanceHora04.Text <> 0 And lblBalanceHora03.Text <> 0 Then lblHoraDiferencia03.Text = CDec(lblBalanceHora04.Text) - CDec(lblBalanceHora03.Text)
            If lblBalanceHora05.Text <> 0 And lblBalanceHora04.Text <> 0 Then lblHoraDiferencia04.Text = CDec(lblBalanceHora05.Text) - CDec(lblBalanceHora04.Text)
            If lblBalanceHora06.Text <> 0 And lblBalanceHora05.Text <> 0 Then lblHoraDiferencia05.Text = CDec(lblBalanceHora06.Text) - CDec(lblBalanceHora05.Text)
            If lblBalanceHora07.Text <> 0 And lblBalanceHora06.Text <> 0 Then lblHoraDiferencia06.Text = CDec(lblBalanceHora07.Text) - CDec(lblBalanceHora06.Text)
            If lblBalanceHora08.Text <> 0 And lblBalanceHora07.Text <> 0 Then lblHoraDiferencia07.Text = CDec(lblBalanceHora08.Text) - CDec(lblBalanceHora07.Text)
            If lblBalanceHora09.Text <> 0 And lblBalanceHora08.Text <> 0 Then lblHoraDiferencia08.Text = CDec(lblBalanceHora09.Text) - CDec(lblBalanceHora08.Text)
            If lblBalanceHora10.Text <> 0 And lblBalanceHora09.Text <> 0 Then lblHoraDiferencia09.Text = CDec(lblBalanceHora10.Text) - CDec(lblBalanceHora09.Text)
            If lblBalanceHora11.Text <> 0 And lblBalanceHora10.Text <> 0 Then lblHoraDiferencia10.Text = CDec(lblBalanceHora11.Text) - CDec(lblBalanceHora10.Text)
            If lblBalanceHora12.Text <> 0 And lblBalanceHora11.Text <> 0 Then lblHoraDiferencia11.Text = CDec(lblBalanceHora12.Text) - CDec(lblBalanceHora11.Text)
            If lblBalanceHora13.Text <> 0 And lblBalanceHora12.Text <> 0 Then lblHoraDiferencia12.Text = CDec(lblBalanceHora13.Text) - CDec(lblBalanceHora12.Text)
            If lblBalanceHora14.Text <> 0 And lblBalanceHora13.Text <> 0 Then lblHoraDiferencia13.Text = CDec(lblBalanceHora14.Text) - CDec(lblBalanceHora13.Text)
            If lblBalanceHora15.Text <> 0 And lblBalanceHora14.Text <> 0 Then lblHoraDiferencia14.Text = CDec(lblBalanceHora15.Text) - CDec(lblBalanceHora14.Text)
            If lblBalanceHora16.Text <> 0 And lblBalanceHora15.Text <> 0 Then lblHoraDiferencia15.Text = CDec(lblBalanceHora16.Text) - CDec(lblBalanceHora15.Text)
            If lblBalanceHora17.Text <> 0 And lblBalanceHora16.Text <> 0 Then lblHoraDiferencia16.Text = CDec(lblBalanceHora17.Text) - CDec(lblBalanceHora16.Text)
            If lblBalanceHora18.Text <> 0 And lblBalanceHora17.Text <> 0 Then lblHoraDiferencia17.Text = CDec(lblBalanceHora18.Text) - CDec(lblBalanceHora17.Text)
            If lblBalanceHora19.Text <> 0 And lblBalanceHora18.Text <> 0 Then lblHoraDiferencia18.Text = CDec(lblBalanceHora19.Text) - CDec(lblBalanceHora18.Text)
            If lblBalanceHora20.Text <> 0 And lblBalanceHora19.Text <> 0 Then lblHoraDiferencia19.Text = CDec(lblBalanceHora20.Text) - CDec(lblBalanceHora19.Text)
            If lblBalanceHora21.Text <> 0 And lblBalanceHora20.Text <> 0 Then lblHoraDiferencia20.Text = CDec(lblBalanceHora21.Text) - CDec(lblBalanceHora20.Text)
            If lblBalanceHora22.Text <> 0 And lblBalanceHora21.Text <> 0 Then lblHoraDiferencia21.Text = CDec(lblBalanceHora22.Text) - CDec(lblBalanceHora21.Text)
            If lblBalanceHora23.Text <> 0 And lblBalanceHora22.Text <> 0 Then lblHoraDiferencia22.Text = CDec(lblBalanceHora23.Text) - CDec(lblBalanceHora22.Text)

            If lblMesBalance01.Text <> 0 And lblMesBalance02.Text <> 0 Then lblMesDifencia01.Text = CDec(lblMesBalance01.Text) - CDec(lblMesBalance01.Text)
            If lblMesBalance02.Text <> 0 And lblMesBalance01.Text <> 0 Then lblMesDifencia01.Text = CDec(lblMesBalance02.Text) - CDec(lblMesBalance01.Text)
            If lblMesBalance03.Text <> 0 And lblMesBalance02.Text <> 0 Then lblMesDifencia02.Text = CDec(lblMesBalance03.Text) - CDec(lblMesBalance02.Text)
            If lblMesBalance04.Text <> 0 And lblMesBalance03.Text <> 0 Then lblMesDifencia03.Text = CDec(lblMesBalance04.Text) - CDec(lblMesBalance03.Text)
            If lblMesBalance05.Text <> 0 And lblMesBalance04.Text <> 0 Then lblMesDifencia04.Text = CDec(lblMesBalance05.Text) - CDec(lblMesBalance04.Text)
            If lblMesBalance06.Text <> 0 And lblMesBalance05.Text <> 0 Then lblMesDifencia05.Text = CDec(lblMesBalance06.Text) - CDec(lblMesBalance05.Text)
            If lblMesBalance07.Text <> 0 And lblMesBalance06.Text <> 0 Then lblMesDifencia06.Text = CDec(lblMesBalance07.Text) - CDec(lblMesBalance06.Text)
            If lblMesBalance08.Text <> 0 And lblMesBalance07.Text <> 0 Then lblMesDifencia07.Text = CDec(lblMesBalance08.Text) - CDec(lblMesBalance07.Text)
            If lblMesBalance09.Text <> 0 And lblMesBalance08.Text <> 0 Then lblMesDifencia08.Text = CDec(lblMesBalance09.Text) - CDec(lblMesBalance08.Text)
            If lblMesBalance10.Text <> 0 And lblMesBalance09.Text <> 0 Then lblMesDifencia09.Text = CDec(lblMesBalance10.Text) - CDec(lblMesBalance09.Text)
            If lblMesBalance11.Text <> 0 And lblMesBalance10.Text <> 0 Then lblMesDifencia10.Text = CDec(lblMesBalance11.Text) - CDec(lblMesBalance10.Text)
            If lblMesBalance12.Text <> 0 And lblMesBalance11.Text <> 0 Then lblMesDifencia11.Text = CDec(lblMesBalance12.Text) - CDec(lblMesBalance11.Text)
            If lblMesBalance13.Text <> 0 And lblMesBalance12.Text <> 0 Then lblMesDifencia12.Text = CDec(lblMesBalance13.Text) - CDec(lblMesBalance12.Text)
            If lblMesBalance14.Text <> 0 And lblMesBalance13.Text <> 0 Then lblMesDifencia13.Text = CDec(lblMesBalance14.Text) - CDec(lblMesBalance13.Text)
            If lblMesBalance15.Text <> 0 And lblMesBalance14.Text <> 0 Then lblMesDifencia14.Text = CDec(lblMesBalance15.Text) - CDec(lblMesBalance14.Text)
            If lblMesBalance16.Text <> 0 And lblMesBalance15.Text <> 0 Then lblMesDifencia15.Text = CDec(lblMesBalance16.Text) - CDec(lblMesBalance15.Text)
            If lblMesBalance17.Text <> 0 And lblMesBalance16.Text <> 0 Then lblMesDifencia16.Text = CDec(lblMesBalance17.Text) - CDec(lblMesBalance16.Text)
            If lblMesBalance18.Text <> 0 And lblMesBalance17.Text <> 0 Then lblMesDifencia17.Text = CDec(lblMesBalance18.Text) - CDec(lblMesBalance17.Text)
            If lblMesBalance19.Text <> 0 And lblMesBalance18.Text <> 0 Then lblMesDifencia18.Text = CDec(lblMesBalance19.Text) - CDec(lblMesBalance18.Text)
            If lblMesBalance20.Text <> 0 And lblMesBalance19.Text <> 0 Then lblMesDifencia19.Text = CDec(lblMesBalance20.Text) - CDec(lblMesBalance19.Text)
            If lblMesBalance21.Text <> 0 And lblMesBalance20.Text <> 0 Then lblMesDifencia20.Text = CDec(lblMesBalance21.Text) - CDec(lblMesBalance20.Text)
            If lblMesBalance22.Text <> 0 And lblMesBalance21.Text <> 0 Then lblMesDifencia21.Text = CDec(lblMesBalance22.Text) - CDec(lblMesBalance21.Text)
            If lblMesBalance23.Text <> 0 And lblMesBalance22.Text <> 0 Then lblMesDifencia22.Text = CDec(lblMesBalance23.Text) - CDec(lblMesBalance22.Text)
            If lblMesBalance24.Text <> 0 And lblMesBalance23.Text <> 0 Then lblMesDifencia23.Text = CDec(lblMesBalance24.Text) - CDec(lblMesBalance23.Text)
            If lblMesBalance25.Text <> 0 And lblMesBalance24.Text <> 0 Then lblMesDifencia24.Text = CDec(lblMesBalance25.Text) - CDec(lblMesBalance24.Text)
            If lblMesBalance26.Text <> 0 And lblMesBalance25.Text <> 0 Then lblMesDifencia25.Text = CDec(lblMesBalance26.Text) - CDec(lblMesBalance25.Text)
            If lblMesBalance27.Text <> 0 And lblMesBalance26.Text <> 0 Then lblMesDifencia26.Text = CDec(lblMesBalance27.Text) - CDec(lblMesBalance26.Text)
            If lblMesBalance28.Text <> 0 And lblMesBalance27.Text <> 0 Then lblMesDifencia27.Text = CDec(lblMesBalance28.Text) - CDec(lblMesBalance27.Text)
            If lblMesBalance29.Text <> 0 And lblMesBalance28.Text <> 0 Then lblMesDifencia28.Text = CDec(lblMesBalance29.Text) - CDec(lblMesBalance28.Text)
            If lblMesBalance30.Text <> 0 And lblMesBalance29.Text <> 0 Then lblMesDifencia29.Text = CDec(lblMesBalance30.Text) - CDec(lblMesBalance29.Text)
            If lblMesBalance31.Text <> 0 And lblMesBalance30.Text <> 0 Then lblMesDifencia30.Text = CDec(lblMesBalance31.Text) - CDec(lblMesBalance30.Text)

            lblTotalHora.Text = 0
            lblTotalHora.Text += CDec(lblHoraDiferencia00.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia01.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia02.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia03.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia04.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia05.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia06.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia07.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia08.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia09.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia10.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia11.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia12.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia13.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia14.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia15.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia16.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia17.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia18.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia19.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia20.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia21.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia22.Text)
            lblTotalHora.Text += CDec(lblHoraDiferencia23.Text)

            lblTotalMes.Text = 0
            lblTotalMes.Text += CDec(lblMesDifencia01.Text)
            lblTotalMes.Text += CDec(lblMesDifencia02.Text)
            lblTotalMes.Text += CDec(lblMesDifencia03.Text)
            lblTotalMes.Text += CDec(lblMesDifencia04.Text)
            lblTotalMes.Text += CDec(lblMesDifencia05.Text)
            lblTotalMes.Text += CDec(lblMesDifencia06.Text)
            lblTotalMes.Text += CDec(lblMesDifencia07.Text)
            lblTotalMes.Text += CDec(lblMesDifencia08.Text)
            lblTotalMes.Text += CDec(lblMesDifencia09.Text)
            lblTotalMes.Text += CDec(lblMesDifencia10.Text)
            lblTotalMes.Text += CDec(lblMesDifencia11.Text)
            lblTotalMes.Text += CDec(lblMesDifencia12.Text)
            lblTotalMes.Text += CDec(lblMesDifencia13.Text)
            lblTotalMes.Text += CDec(lblMesDifencia14.Text)
            lblTotalMes.Text += CDec(lblMesDifencia15.Text)
            lblTotalMes.Text += CDec(lblMesDifencia16.Text)
            lblTotalMes.Text += CDec(lblMesDifencia17.Text)
            lblTotalMes.Text += CDec(lblMesDifencia18.Text)
            lblTotalMes.Text += CDec(lblMesDifencia19.Text)
            lblTotalMes.Text += CDec(lblMesDifencia20.Text)
            lblTotalMes.Text += CDec(lblMesDifencia21.Text)
            lblTotalMes.Text += CDec(lblMesDifencia22.Text)
            lblTotalMes.Text += CDec(lblMesDifencia23.Text)
            lblTotalMes.Text += CDec(lblMesDifencia24.Text)
            lblTotalMes.Text += CDec(lblMesDifencia25.Text)
            lblTotalMes.Text += CDec(lblMesDifencia26.Text)
            lblTotalMes.Text += CDec(lblMesDifencia27.Text)
            lblTotalMes.Text += CDec(lblMesDifencia28.Text)
            lblTotalMes.Text += CDec(lblMesDifencia29.Text)
            lblTotalMes.Text += CDec(lblMesDifencia30.Text)
            lblTotalMes.Text += CDec(lblMesDifencia31.Text)
            ' Chart6.Series(0).Points.Clear()
            ' Chart6.Series(0).Points.AddXY(Format(DateAndTime.TimeValue(Now), "HH:mm:ss"), CDec(Format(ValorEstimado, "###0.00")))

            My.Settings.Save()
        Catch ex As Exception
            MsgBox("Error!!" & vbCrLf & ex.Message)
        End Try

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Hora = DateAndTime.Hour(Now)
            Minutos = DateAndTime.Minute(Now)
            Segundos = DateAndTime.Second(Now)
            If Segundos <= 9 Then
                If Minutos <= 9 Then
                    lblHora.Text = Hora & ":0" & Minutos & ":0" & Segundos
                Else
                    lblHora.Text = Hora & ":" & Minutos & ":0" & Segundos
                End If
            Else
                If Minutos <= 9 Then
                    lblHora.Text = Hora & ":0" & Minutos & ":" & Segundos
                Else
                    lblHora.Text = Hora & ":" & Minutos & ":" & Segundos
                End If

            End If
            Select Case Segundos
                Case 0 : Actualizar()
                'Case 15 : Actualizar()
                Case 30 : Actualizar()
                    'Case 45 : Actualizar()
            End Select
            If Minutos = 0 Then Añadir()
        Catch ex As Exception
            MsgBox("Error!!" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        ' e.Graphics.DrawString(((ángulo) / 1.8).ToString("N0") & "%", letras, Brushes.Black, cuadro, sf)

        ' e.Graphics.DrawArc(trazo, cuadro, 180, ángulo)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        lblBalanceHora00.Text = "0"
        lblBalanceHora01.Text = "0"
        lblBalanceHora02.Text = "0"
        lblBalanceHora03.Text = "0"
        lblBalanceHora04.Text = "0"
        lblBalanceHora05.Text = "0"
        lblBalanceHora06.Text = "0"
        lblBalanceHora07.Text = "0"
        lblBalanceHora08.Text = "0"
        lblBalanceHora09.Text = "0"
        lblBalanceHora10.Text = "0"
        lblBalanceHora11.Text = "0"
        lblBalanceHora12.Text = "0"
        lblBalanceHora13.Text = "0"
        lblBalanceHora14.Text = "0"
        lblBalanceHora15.Text = "0"
        lblBalanceHora16.Text = "0"
        lblBalanceHora17.Text = "0"
        lblBalanceHora18.Text = "0"
        lblBalanceHora19.Text = "0"
        lblBalanceHora20.Text = "0"
        lblBalanceHora21.Text = "0"
        lblBalanceHora22.Text = "0"
        lblBalanceHora23.Text = "0"

        lblPrecio00.Text = "0"
        lblPrecio01.Text = "0"
        lblPrecio02.Text = "0"
        lblPrecio03.Text = "0"
        lblPrecio04.Text = "0"
        lblPrecio05.Text = "0"
        lblPrecio06.Text = "0"
        lblPrecio07.Text = "0"
        lblPrecio08.Text = "0"
        lblPrecio09.Text = "0"
        lblPrecio10.Text = "0"
        lblPrecio11.Text = "0"
        lblPrecio12.Text = "0"
        lblPrecio13.Text = "0"
        lblPrecio14.Text = "0"
        lblPrecio15.Text = "0"
        lblPrecio16.Text = "0"
        lblPrecio17.Text = "0"
        lblPrecio18.Text = "0"
        lblPrecio19.Text = "0"
        lblPrecio20.Text = "0"
        lblPrecio21.Text = "0"
        lblPrecio22.Text = "0"
        lblPrecio23.Text = "0"

        lblHoraDiferencia00.Text = 0
        lblHoraDiferencia01.Text = 0
        lblHoraDiferencia02.Text = 0
        lblHoraDiferencia03.Text = 0
        lblHoraDiferencia04.Text = 0
        lblHoraDiferencia05.Text = 0
        lblHoraDiferencia06.Text = 0
        lblHoraDiferencia07.Text = 0
        lblHoraDiferencia08.Text = 0
        lblHoraDiferencia09.Text = 0
        lblHoraDiferencia10.Text = 0
        lblHoraDiferencia11.Text = 0
        lblHoraDiferencia12.Text = 0
        lblHoraDiferencia13.Text = 0
        lblHoraDiferencia14.Text = 0
        lblHoraDiferencia15.Text = 0
        lblHoraDiferencia16.Text = 0
        lblHoraDiferencia17.Text = 0
        lblHoraDiferencia18.Text = 0
        lblHoraDiferencia19.Text = 0
        lblHoraDiferencia20.Text = 0
        lblHoraDiferencia21.Text = 0
        lblHoraDiferencia22.Text = 0
        lblHoraDiferencia23.Text = 0
        lblTotalHora.Text = 0
        lblTotalMes.Text = 0
    End Sub
End Class
