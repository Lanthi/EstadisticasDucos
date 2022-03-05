Imports System.Net
Imports System.IO
Imports System.Web.Script.Serialization
Public Class Form1
    Dim Remover As Integer = 30
    Dim ContadorRemove As Integer = 0
    Dim BalanceHora(23) As Decimal
    Dim PrecioHora(23) As Decimal
    Dim Hora As Integer
    Dim MInutos As Integer
    Dim Segundos As Integer
    Dim ContadorTiempo As Integer = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Actualizar()
        Timer1.Enabled = True
        lblHora.Text = DateAndTime.TimeValue(Now)
        Chart1.ChartAreas(0).AxisY.Minimum = CDec(txtDucoprice.Text) - 0.000001
        Chart2.ChartAreas(0).AxisY.Minimum = Format(CDec(txtbalance.Text) - 0.1, "00000.000")
        lblHoraDiferencia00.Text = CDec(lblBalanceHora00.Text)
        If lblBalanceHora01.Text <> 0 And lblBalanceHora00.Text <> 0 Then lblHoraDiferencia01.Text = CDec(lblBalanceHora01.Text) - CDec(lblBalanceHora00.Text)
        If lblBalanceHora02.Text <> 0 And lblBalanceHora01.Text <> 0 Then lblHoraDiferencia02.Text = CDec(lblBalanceHora02.Text) - CDec(lblBalanceHora01.Text)
        If lblBalanceHora03.Text <> 0 And lblBalanceHora02.Text <> 0 Then lblHoraDiferencia03.Text = CDec(lblBalanceHora03.Text) - CDec(lblBalanceHora02.Text)
        If lblBalanceHora04.Text <> 0 And lblBalanceHora03.Text <> 0 Then lblHoraDiferencia04.Text = CDec(lblBalanceHora04.Text) - CDec(lblBalanceHora03.Text)
        If lblBalanceHora05.Text <> 0 And lblBalanceHora04.Text <> 0 Then lblHoraDiferencia05.Text = CDec(lblBalanceHora05.Text) - CDec(lblBalanceHora04.Text)
        If lblBalanceHora06.Text <> 0 And lblBalanceHora05.Text <> 0 Then lblHoraDiferencia06.Text = CDec(lblBalanceHora06.Text) - CDec(lblBalanceHora05.Text)
        If lblBalanceHora07.Text <> 0 And lblBalanceHora06.Text <> 0 Then lblHoraDiferencia07.Text = CDec(lblBalanceHora07.Text) - CDec(lblBalanceHora06.Text)
        If lblBalanceHora08.Text <> 0 And lblBalanceHora07.Text <> 0 Then lblHoraDiferencia08.Text = CDec(lblBalanceHora08.Text) - CDec(lblBalanceHora07.Text)
        If lblBalanceHora09.Text <> 0 And lblBalanceHora08.Text <> 0 Then lblHoraDiferencia09.Text = CDec(lblBalanceHora09.Text) - CDec(lblBalanceHora08.Text)
        If lblBalanceHora10.Text <> 0 And lblBalanceHora09.Text <> 0 Then lblHoraDiferencia10.Text = CDec(lblBalanceHora10.Text) - CDec(lblBalanceHora09.Text)
        If lblBalanceHora11.Text <> 0 And lblBalanceHora10.Text <> 0 Then lblHoraDiferencia11.Text = CDec(lblBalanceHora11.Text) - CDec(lblBalanceHora10.Text)
        If lblBalanceHora12.Text <> 0 And lblBalanceHora11.Text <> 0 Then lblHoraDiferencia12.Text = CDec(lblBalanceHora12.Text) - CDec(lblBalanceHora11.Text)
        If lblBalanceHora13.Text <> 0 And lblBalanceHora12.Text <> 0 Then lblHoraDiferencia13.Text = CDec(lblBalanceHora13.Text) - CDec(lblBalanceHora12.Text)
        If lblBalanceHora14.Text <> 0 And lblBalanceHora13.Text <> 0 Then lblHoraDiferencia14.Text = CDec(lblBalanceHora14.Text) - CDec(lblBalanceHora13.Text)
        If lblBalanceHora15.Text <> 0 And lblBalanceHora14.Text <> 0 Then lblHoraDiferencia15.Text = CDec(lblBalanceHora15.Text) - CDec(lblBalanceHora14.Text)
        If lblBalanceHora16.Text <> 0 And lblBalanceHora15.Text <> 0 Then lblHoraDiferencia16.Text = CDec(lblBalanceHora16.Text) - CDec(lblBalanceHora15.Text)
        If lblBalanceHora17.Text <> 0 And lblBalanceHora16.Text <> 0 Then lblHoraDiferencia17.Text = CDec(lblBalanceHora17.Text) - CDec(lblBalanceHora16.Text)
        If lblBalanceHora18.Text <> 0 And lblBalanceHora17.Text <> 0 Then lblHoraDiferencia18.Text = CDec(lblBalanceHora18.Text) - CDec(lblBalanceHora17.Text)
        If lblBalanceHora19.Text <> 0 And lblBalanceHora18.Text <> 0 Then lblHoraDiferencia19.Text = CDec(lblBalanceHora19.Text) - CDec(lblBalanceHora18.Text)
        If lblBalanceHora20.Text <> 0 And lblBalanceHora19.Text <> 0 Then lblHoraDiferencia20.Text = CDec(lblBalanceHora20.Text) - CDec(lblBalanceHora19.Text)
        If lblBalanceHora21.Text <> 0 And lblBalanceHora20.Text <> 0 Then lblHoraDiferencia21.Text = CDec(lblBalanceHora21.Text) - CDec(lblBalanceHora20.Text)
        If lblBalanceHora22.Text <> 0 And lblBalanceHora21.Text <> 0 Then lblHoraDiferencia22.Text = CDec(lblBalanceHora22.Text) - CDec(lblBalanceHora21.Text)
        If lblBalanceHora23.Text <> 0 And lblBalanceHora22.Text <> 0 Then lblHoraDiferencia23.Text = CDec(lblBalanceHora23.Text) - CDec(lblBalanceHora22.Text)
        lblTotalHora.Text = 0
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
        lblTotalHora.Text = lblTotalHora.Text
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

        Dim uriString As String = "https://server.duinocoin.com/api.json"
        Dim uri As New Uri(uriString)
        Dim Request As HttpWebRequest = HttpWebRequest.Create(uri)
        Request.Method = "GET"
        Dim Response As HttpWebResponse = Request.GetResponse()
        Dim Read = New StreamReader(Response.GetResponseStream())
        Dim Raw As String = Read.ReadToEnd()
        Dim dict As Object = New JavaScriptSerializer().Deserialize(Of Dictionary(Of String, Object))(Raw)
        txtDucoprice.Text = dict.item("Duco price")
        txtbalance.Text = dict2.item("result").item("balance")
        lblGanado.Text = Format(CDec(txtbalance.Text) * CDec(txtDucoprice.Text), "0000.0000") & "€"
        lstBalanceTiempoReal.Items.Add(txtbalance.Text)
        lstDUCOTiempoReal.Items.Add(txtDucoprice.Text)
        BalanceHora(Hour(Now)) = txtbalance.Text
        PrecioHora(Hour(Now)) = txtDucoprice.Text
        ContadorRemove += 1
        If ContadorRemove > Remover Then
            lstBalanceTiempoReal.Items.RemoveAt(0)
            lstDUCOTiempoReal.Items.RemoveAt(0)
        End If
        If ckEstadisticas.Checked = True Then
            Dim Valor As Decimal = Format(CDec(txtbalance.Text), "00000.000")
            Dim Valor2 As Decimal = CDec(txtDucoprice.Text)
            If Chart1.ChartAreas(0).AxisY.Minimum <Valor2 Then
                Chart1.ChartAreas(0).AxisY.Minimum = CDec(txtDucoprice.Text) - 0.000001
            End If
            Chart1.Series(0).Points.AddXY(TimeValue(Now), Valor2)
            Chart2.Series(0).Points.AddXY(TimeValue(Now), Valor)
            Chart1.ChartAreas(0).AxisY.Maximum = CDec(txtDucoprice.Text) + 0.000001
            Chart2.ChartAreas(0).AxisY.Maximum = Format(CDec(txtbalance.Text) + 0.1, "00000.000")
        End If
    End Sub
    Private Sub Añadir()

        Select Case Hour(Now)
            Case 0
                lblBalanceHora00.Text = txtbalance.Text
                lblPrecio00.Text = txtDucoprice.Text
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

            Case 1 : If lblBalanceHora01.Text = "0" Then lblBalanceHora01.Text = txtbalance.Text : lblPrecio01.Text = txtDucoprice.Text : lblHoraDiferencia01.Text = CDec(lblBalanceHora00.Text) - CDec(lblBalanceHora01.Text)
            Case 2 : If lblBalanceHora02.Text = "0" Then lblBalanceHora02.Text = txtbalance.Text : lblPrecio02.Text = txtDucoprice.Text : lblHoraDiferencia02.Text = CDec(lblBalanceHora01.Text) - CDec(lblBalanceHora02.Text)
            Case 3 : If lblBalanceHora03.Text = "0" Then lblBalanceHora03.Text = txtbalance.Text : lblPrecio03.Text = txtDucoprice.Text : lblHoraDiferencia03.Text = CDec(lblBalanceHora02.Text) - CDec(lblBalanceHora03.Text)
            Case 4 : If lblBalanceHora04.Text = "0" Then lblBalanceHora04.Text = txtbalance.Text : lblPrecio04.Text = txtDucoprice.Text : lblHoraDiferencia04.Text = CDec(lblBalanceHora03.Text) - CDec(lblBalanceHora04.Text)
            Case 5 : If lblBalanceHora05.Text = "0" Then lblBalanceHora05.Text = txtbalance.Text : lblPrecio05.Text = txtDucoprice.Text : lblHoraDiferencia05.Text = CDec(lblBalanceHora04.Text) - CDec(lblBalanceHora05.Text)
            Case 6 : If lblBalanceHora06.Text = "0" Then lblBalanceHora06.Text = txtbalance.Text : lblPrecio06.Text = txtDucoprice.Text : lblHoraDiferencia06.Text = CDec(lblBalanceHora05.Text) - CDec(lblBalanceHora06.Text)
            Case 7 : If lblBalanceHora07.Text = "0" Then lblBalanceHora07.Text = txtbalance.Text : lblPrecio07.Text = txtDucoprice.Text : lblHoraDiferencia07.Text = CDec(lblBalanceHora06.Text) - CDec(lblBalanceHora07.Text)
            Case 8 : If lblBalanceHora08.Text = "0" Then lblBalanceHora08.Text = txtbalance.Text : lblPrecio08.Text = txtDucoprice.Text : lblHoraDiferencia08.Text = CDec(lblBalanceHora07.Text) - CDec(lblBalanceHora08.Text)
            Case 9 : If lblBalanceHora09.Text = "0" Then lblBalanceHora09.Text = txtbalance.Text : lblPrecio09.Text = txtDucoprice.Text : lblHoraDiferencia09.Text = CDec(lblBalanceHora08.Text) - CDec(lblBalanceHora09.Text)
            Case 10 : If lblBalanceHora10.Text = "0" Then lblBalanceHora10.Text = txtbalance.Text : lblPrecio10.Text = txtDucoprice.Text : lblHoraDiferencia10.Text = CDec(lblBalanceHora09.Text) - CDec(lblBalanceHora10.Text)
            Case 11 : If lblBalanceHora11.Text = "0" Then lblBalanceHora11.Text = txtbalance.Text : lblPrecio11.Text = txtDucoprice.Text : lblHoraDiferencia11.Text = CDec(lblBalanceHora10.Text) - CDec(lblBalanceHora11.Text)
            Case 12 : If lblBalanceHora12.Text = "0" Then lblBalanceHora12.Text = txtbalance.Text : lblPrecio12.Text = txtDucoprice.Text : lblHoraDiferencia12.Text = CDec(lblBalanceHora11.Text) - CDec(lblBalanceHora12.Text)
            Case 13 : If lblBalanceHora13.Text = "0" Then lblBalanceHora13.Text = txtbalance.Text : lblPrecio13.Text = txtDucoprice.Text : lblHoraDiferencia13.Text = CDec(lblBalanceHora12.Text) - CDec(lblBalanceHora13.Text)
            Case 14 : If lblBalanceHora14.Text = "0" Then lblBalanceHora14.Text = txtbalance.Text : lblPrecio14.Text = txtDucoprice.Text : lblHoraDiferencia14.Text = CDec(lblBalanceHora13.Text) - CDec(lblBalanceHora14.Text)
            Case 15 : If lblBalanceHora15.Text = "0" Then lblBalanceHora15.Text = txtbalance.Text : lblPrecio15.Text = txtDucoprice.Text : lblHoraDiferencia15.Text = CDec(lblBalanceHora14.Text) - CDec(lblBalanceHora15.Text)
            Case 16 : If lblBalanceHora16.Text = "0" Then lblBalanceHora16.Text = txtbalance.Text : lblPrecio16.Text = txtDucoprice.Text : lblHoraDiferencia16.Text = CDec(lblBalanceHora15.Text) - CDec(lblBalanceHora16.Text)
            Case 17 : If lblBalanceHora17.Text = "0" Then lblBalanceHora17.Text = txtbalance.Text : lblPrecio17.Text = txtDucoprice.Text : lblHoraDiferencia17.Text = CDec(lblBalanceHora16.Text) - CDec(lblBalanceHora17.Text)
            Case 18 : If lblBalanceHora18.Text = "0" Then lblBalanceHora18.Text = txtbalance.Text : lblPrecio18.Text = txtDucoprice.Text : lblHoraDiferencia18.Text = CDec(lblBalanceHora17.Text) - CDec(lblBalanceHora18.Text)
            Case 19 : If lblBalanceHora19.Text = "0" Then lblBalanceHora19.Text = txtbalance.Text : lblPrecio19.Text = txtDucoprice.Text : lblHoraDiferencia19.Text = CDec(lblBalanceHora18.Text) - CDec(lblBalanceHora19.Text)
            Case 20 : If lblBalanceHora20.Text = "0" Then lblBalanceHora20.Text = txtbalance.Text : lblPrecio20.Text = txtDucoprice.Text : lblHoraDiferencia20.Text = CDec(lblBalanceHora19.Text) - CDec(lblBalanceHora20.Text)
            Case 21 : If lblBalanceHora21.Text = "0" Then lblBalanceHora21.Text = txtbalance.Text : lblPrecio21.Text = txtDucoprice.Text : lblHoraDiferencia21.Text = CDec(lblBalanceHora20.Text) - CDec(lblBalanceHora21.Text)
            Case 22 : If lblBalanceHora22.Text = "0" Then lblBalanceHora22.Text = txtbalance.Text : lblPrecio22.Text = txtDucoprice.Text : lblHoraDiferencia22.Text = CDec(lblBalanceHora21.Text) - CDec(lblBalanceHora22.Text)
            Case 23 : If lblBalanceHora23.Text = "0" Then lblBalanceHora23.Text = txtbalance.Text : lblPrecio23.Text = txtDucoprice.Text : lblHoraDiferencia23.Text = CDec(lblBalanceHora22.Text) - CDec(lblBalanceHora23.Text)
        End Select
        lblTotalHora.Text = 0
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
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Hora = DateAndTime.Hour(Now)
        MInutos = DateAndTime.Minute(Now)
        Segundos = DateAndTime.Second(Now)
        If Segundos <= 9 Then
            If MInutos <= 9 Then
                lblHora.Text = Hora & ":0" & MInutos & ":0" & Segundos
            Else
                lblHora.Text = Hora & ":" & MInutos & ":0" & Segundos
            End If
        Else
            If MInutos <= 9 Then
                lblHora.Text = Hora & ":0" & MInutos & ":" & Segundos
            Else
                lblHora.Text = Hora & ":" & MInutos & ":" & Segundos
            End If

        End If
        Select Case MInutos
            Case 0 : If Segundos = 0 Then Añadir()
            Case 15 : If Segundos = 0 Then Añadir()
            Case 30 : If Segundos = 0 Then Añadir()
            Case 45 : If Segundos = 0 Then Añadir()
        End Select
        If Segundos = 0 Then Actualizar()
    End Sub
    Private Sub txtbalance_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ckEstadisticas_CheckedChanged(sender As Object, e As EventArgs) Handles ckEstadisticas.CheckedChanged
        If ckEstadisticas.Checked = True Then
            Chart1.Visible = True
            Chart2.Visible = True
        Else
            Chart1.Visible = False
            Chart2.Visible = False
        End If
    End Sub
    Private Sub lblBalanceHora01_TextChanged(sender As Object, e As EventArgs) Handles lblBalanceHora01.TextChanged
        lblHoraDiferencia01.Text = CDec(lblBalanceHora00.Text) - CDec(lblBalanceHora01.Text)
    End Sub
    Private Sub lblBalanceHora02_TextChanged(sender As Object, e As EventArgs) Handles lblBalanceHora02.TextChanged
        '  lblHoraDiferencia02.Text = CDec(lblBalanceHora01.Text) - CDec(lblBalanceHora02.Text)
    End Sub
    Private Sub lblBalanceHora03_TextChanged(sender As Object, e As EventArgs) Handles lblBalanceHora03.TextChanged
        'lblHoraDiferencia03.Text = CDec(lblBalanceHora02.Text) - CDec(lblBalanceHora01.Text)
    End Sub

    Private Sub lblPrecio23_Click(sender As Object, e As EventArgs) Handles lblPrecio23.Click

    End Sub
End Class
