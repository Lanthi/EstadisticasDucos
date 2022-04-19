Imports System.Net
Imports System.IO
Imports System.Drawing.Graphics
Imports System.Web.Script.Serialization
Public Class Form1
    ' _____                                                _____
    '/\  _`\              __                              /\  _`\             __             
    '\ \ \/\ \   __  __  /\_\     ___      ___            \ \ \/\_\    ___   /\_\     ___    
    ' \ \ \ \ \ /\ \/\ \ \/\ \  /' _ `\   / __`\  _______  \ \ \/_/_  / __`\ \/\ \  /' _ `\  
    '  \ \ \_\ \\ \ \_\ \ \ \ \ /\ \/\ \ /\ \L\ \/\______\  \ \ \L\ \/\ \L\ \ \ \ \ /\ \/\ \ 
    '   \ \____/ \ \____/  \ \_\\ \_\ \_\\ \____/\/______/   \ \____/\ \____/  \ \_\\ \_\ \_\
    '    \/___/   \/___/    \/_/ \/_/\/_/ \/___/              \/___/  \/___/    \/_/ \/_/\/_/
    '
    '  
    ' _                 _                    _    _      _ 
    '| |            _  | |                  | |  | |    (_)
    '| |__   _   _ (_) | |      __ _  _ __  | |_ | |__   _ 
    '| '_ \ | | | |    | |     / _` || '_ \ | __|| '_ \ | |
    '| |_) || |_| | _  | |____| (_| || | | || |_ | | | || |
    '|_.__/  \__, |(_) \_____/ \__,_||_| |_| \__||_| |_||_|
    '         __/ |                                        
    '        |___/                                         
    'Designed and produced by Lanthi, for the Duino-Coin community
    'https://duinocoin.com
    'https://github.com/revoxhere/duino-coin
    'https://github.com/Lanthi/EstadisticasDucos
    'Do not change
    ReadOnly Remover As Integer = 30
    Dim ContadorRemove As Integer = 0
    Dim Hora As Integer
    Dim Minutos As Integer = DateAndTime.Minute(Now)
    Dim Segundos As Integer
    Dim ContadorTiempo As Integer = 0
    Dim EnviosDias(5000) As Integer
    Dim EnviosMes(5000) As Integer
    Dim EnviosAño(5000) As Integer
    Dim Recibido(5000) As Boolean
    Dim Transacion(31) As Decimal
    Dim TransacionPorDia(31) As Integer
    Dim TransacionAño(12) As Decimal
    Dim TransacionPorAño(12) As Integer
    Dim EstimadoViejo As Decimal = 0
    Dim EstimadoNuevo As Decimal = 0
    Dim ValorEstimado As Decimal
    Dim ValorEstimadoMes As Decimal
    Dim ContadorEstimacion As Integer = 0
    Dim Euro As Decimal = 0
    Dim Mineros(0, 7) As String
    Dim LogAñadido As Boolean = False
    Dim RutaApp As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Estadisticas Duco"
    Dim FechaLog As Date
    Dim ContaTransa As Integer
    Dim Dict2Public As Object
    Dim Temperatura As Integer = 0
    Dim Humedad As Integer = 0
    Dim Cargado As Boolean = True
    Dim DucosNuevoDia As Decimal
    Private Sub BalanceHora()
        If lblBalanceHora01.Text <> 0 And lblBalanceHora00.Text <> 0 Then lblHoraDiferencia00.Text = FormatDuco(CDec(lblBalanceHora01.Text) - CDec(lblBalanceHora00.Text), 8)
        If lblBalanceHora02.Text <> 0 And lblBalanceHora01.Text <> 0 Then lblHoraDiferencia01.Text = FormatDuco(CDec(lblBalanceHora02.Text) - CDec(lblBalanceHora01.Text), 8)
        If lblBalanceHora03.Text <> 0 And lblBalanceHora02.Text <> 0 Then lblHoraDiferencia02.Text = FormatDuco(CDec(lblBalanceHora03.Text) - CDec(lblBalanceHora02.Text), 8)
        If lblBalanceHora04.Text <> 0 And lblBalanceHora03.Text <> 0 Then lblHoraDiferencia03.Text = FormatDuco(CDec(lblBalanceHora04.Text) - CDec(lblBalanceHora03.Text), 8)
        If lblBalanceHora05.Text <> 0 And lblBalanceHora04.Text <> 0 Then lblHoraDiferencia04.Text = FormatDuco(CDec(lblBalanceHora05.Text) - CDec(lblBalanceHora04.Text), 8)
        If lblBalanceHora06.Text <> 0 And lblBalanceHora05.Text <> 0 Then lblHoraDiferencia05.Text = FormatDuco(CDec(lblBalanceHora06.Text) - CDec(lblBalanceHora05.Text), 8)
        If lblBalanceHora07.Text <> 0 And lblBalanceHora06.Text <> 0 Then lblHoraDiferencia06.Text = FormatDuco(CDec(lblBalanceHora07.Text) - CDec(lblBalanceHora06.Text), 8)
        If lblBalanceHora08.Text <> 0 And lblBalanceHora07.Text <> 0 Then lblHoraDiferencia07.Text = FormatDuco(CDec(lblBalanceHora08.Text) - CDec(lblBalanceHora07.Text), 8)
        If lblBalanceHora09.Text <> 0 And lblBalanceHora08.Text <> 0 Then lblHoraDiferencia08.Text = FormatDuco(CDec(lblBalanceHora09.Text) - CDec(lblBalanceHora08.Text), 8)
        If lblBalanceHora10.Text <> 0 And lblBalanceHora09.Text <> 0 Then lblHoraDiferencia09.Text = FormatDuco(CDec(lblBalanceHora10.Text) - CDec(lblBalanceHora09.Text), 8)
        If lblBalanceHora11.Text <> 0 And lblBalanceHora10.Text <> 0 Then lblHoraDiferencia10.Text = FormatDuco(CDec(lblBalanceHora11.Text) - CDec(lblBalanceHora10.Text), 8)
        If lblBalanceHora12.Text <> 0 And lblBalanceHora11.Text <> 0 Then lblHoraDiferencia11.Text = FormatDuco(CDec(lblBalanceHora12.Text) - CDec(lblBalanceHora11.Text), 8)
        If lblBalanceHora13.Text <> 0 And lblBalanceHora12.Text <> 0 Then lblHoraDiferencia12.Text = FormatDuco(CDec(lblBalanceHora13.Text) - CDec(lblBalanceHora12.Text), 8)
        If lblBalanceHora14.Text <> 0 And lblBalanceHora13.Text <> 0 Then lblHoraDiferencia13.Text = FormatDuco(CDec(lblBalanceHora14.Text) - CDec(lblBalanceHora13.Text), 8)
        If lblBalanceHora15.Text <> 0 And lblBalanceHora14.Text <> 0 Then lblHoraDiferencia14.Text = FormatDuco(CDec(lblBalanceHora15.Text) - CDec(lblBalanceHora14.Text), 8)
        If lblBalanceHora16.Text <> 0 And lblBalanceHora15.Text <> 0 Then lblHoraDiferencia15.Text = FormatDuco(CDec(lblBalanceHora16.Text) - CDec(lblBalanceHora15.Text), 8)
        If lblBalanceHora17.Text <> 0 And lblBalanceHora16.Text <> 0 Then lblHoraDiferencia16.Text = FormatDuco(CDec(lblBalanceHora17.Text) - CDec(lblBalanceHora16.Text), 8)
        If lblBalanceHora18.Text <> 0 And lblBalanceHora17.Text <> 0 Then lblHoraDiferencia17.Text = FormatDuco(CDec(lblBalanceHora18.Text) - CDec(lblBalanceHora17.Text), 8)
        If lblBalanceHora19.Text <> 0 And lblBalanceHora18.Text <> 0 Then lblHoraDiferencia18.Text = FormatDuco(CDec(lblBalanceHora19.Text) - CDec(lblBalanceHora18.Text), 8)
        If lblBalanceHora20.Text <> 0 And lblBalanceHora19.Text <> 0 Then lblHoraDiferencia19.Text = FormatDuco(CDec(lblBalanceHora20.Text) - CDec(lblBalanceHora19.Text), 8)
        If lblBalanceHora21.Text <> 0 And lblBalanceHora20.Text <> 0 Then lblHoraDiferencia20.Text = FormatDuco(CDec(lblBalanceHora21.Text) - CDec(lblBalanceHora20.Text), 8)
        If lblBalanceHora22.Text <> 0 And lblBalanceHora21.Text <> 0 Then lblHoraDiferencia21.Text = FormatDuco(CDec(lblBalanceHora22.Text) - CDec(lblBalanceHora21.Text), 8)
        If lblBalanceHora23.Text <> 0 And lblBalanceHora22.Text <> 0 Then lblHoraDiferencia22.Text = FormatDuco(CDec(lblBalanceHora23.Text) - CDec(lblBalanceHora22.Text), 8)
        If lblBalanceHora00.Text <> 0 And lblBalanceHora23.Text <> 0 Then lblHoraDiferencia23.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceHora23.Text), 8)
    End Sub
    Private Sub BalanceMes()
        If lblMesBalance01.Text <> 0 And lblMesBalance02.Text <> 0 Then lblMesDifencia01.Text = FormatDuco(CDec(lblMesBalance01.Text) - CDec(lblMesBalance01.Text) - CDec(Transacion(31)), 13)
        If lblMesBalance02.Text <> 0 And lblMesBalance01.Text <> 0 Then lblMesDifencia01.Text = FormatDuco(CDec(lblMesBalance02.Text) - CDec(lblMesBalance01.Text) - CDec(Transacion(1)), 13)
        If lblMesBalance03.Text <> 0 And lblMesBalance02.Text <> 0 Then lblMesDifencia02.Text = FormatDuco(CDec(lblMesBalance03.Text) - CDec(lblMesBalance02.Text) - CDec(Transacion(2)), 13)
        If lblMesBalance04.Text <> 0 And lblMesBalance03.Text <> 0 Then lblMesDifencia03.Text = FormatDuco(CDec(lblMesBalance04.Text) - CDec(lblMesBalance03.Text) - CDec(Transacion(3)), 13)
        If lblMesBalance05.Text <> 0 And lblMesBalance04.Text <> 0 Then lblMesDifencia04.Text = FormatDuco(CDec(lblMesBalance05.Text) - CDec(lblMesBalance04.Text) - CDec(Transacion(4)), 13)
        If lblMesBalance06.Text <> 0 And lblMesBalance05.Text <> 0 Then lblMesDifencia05.Text = FormatDuco(CDec(lblMesBalance06.Text) - CDec(lblMesBalance05.Text) - CDec(Transacion(5)), 13)
        If lblMesBalance07.Text <> 0 And lblMesBalance06.Text <> 0 Then lblMesDifencia06.Text = FormatDuco(CDec(lblMesBalance07.Text) - CDec(lblMesBalance06.Text) - CDec(Transacion(6)), 13)
        If lblMesBalance08.Text <> 0 And lblMesBalance07.Text <> 0 Then lblMesDifencia07.Text = FormatDuco(CDec(lblMesBalance08.Text) - CDec(lblMesBalance07.Text) - CDec(Transacion(7)), 13)
        If lblMesBalance09.Text <> 0 And lblMesBalance08.Text <> 0 Then lblMesDifencia08.Text = FormatDuco(CDec(lblMesBalance09.Text) - CDec(lblMesBalance08.Text) - CDec(Transacion(8)), 13)
        If lblMesBalance10.Text <> 0 And lblMesBalance09.Text <> 0 Then lblMesDifencia09.Text = FormatDuco(CDec(lblMesBalance10.Text) - CDec(lblMesBalance09.Text) - CDec(Transacion(9)), 13)
        If lblMesBalance11.Text <> 0 And lblMesBalance10.Text <> 0 Then lblMesDifencia10.Text = FormatDuco(CDec(lblMesBalance11.Text) - CDec(lblMesBalance10.Text) - CDec(Transacion(10)), 13)
        If lblMesBalance12.Text <> 0 And lblMesBalance11.Text <> 0 Then lblMesDifencia11.Text = FormatDuco(CDec(lblMesBalance12.Text) - CDec(lblMesBalance11.Text) - CDec(Transacion(11)), 13)
        If lblMesBalance13.Text <> 0 And lblMesBalance12.Text <> 0 Then lblMesDifencia12.Text = FormatDuco(CDec(lblMesBalance13.Text) - CDec(lblMesBalance12.Text) - CDec(Transacion(12)), 13)
        If lblMesBalance14.Text <> 0 And lblMesBalance13.Text <> 0 Then lblMesDifencia13.Text = FormatDuco(CDec(lblMesBalance14.Text) - CDec(lblMesBalance13.Text) - CDec(Transacion(13)), 13)
        If lblMesBalance15.Text <> 0 And lblMesBalance14.Text <> 0 Then lblMesDifencia14.Text = FormatDuco(CDec(lblMesBalance15.Text) - CDec(lblMesBalance14.Text) - CDec(Transacion(14)), 13)
        If lblMesBalance16.Text <> 0 And lblMesBalance15.Text <> 0 Then lblMesDifencia15.Text = FormatDuco(CDec(lblMesBalance16.Text) - CDec(lblMesBalance15.Text) - CDec(Transacion(15)), 13)
        If lblMesBalance17.Text <> 0 And lblMesBalance16.Text <> 0 Then lblMesDifencia16.Text = FormatDuco(CDec(lblMesBalance17.Text) - CDec(lblMesBalance16.Text) - CDec(Transacion(16)), 13)
        If lblMesBalance18.Text <> 0 And lblMesBalance17.Text <> 0 Then lblMesDifencia17.Text = FormatDuco(CDec(lblMesBalance18.Text) - CDec(lblMesBalance17.Text) - CDec(Transacion(17)), 13)
        If lblMesBalance19.Text <> 0 And lblMesBalance18.Text <> 0 Then lblMesDifencia18.Text = FormatDuco(CDec(lblMesBalance19.Text) - CDec(lblMesBalance18.Text) - CDec(Transacion(18)), 13)
        If lblMesBalance20.Text <> 0 And lblMesBalance19.Text <> 0 Then lblMesDifencia19.Text = FormatDuco(CDec(lblMesBalance20.Text) - CDec(lblMesBalance19.Text) - CDec(Transacion(19)), 13)
        If lblMesBalance21.Text <> 0 And lblMesBalance20.Text <> 0 Then lblMesDifencia20.Text = FormatDuco(CDec(lblMesBalance21.Text) - CDec(lblMesBalance20.Text) - CDec(Transacion(20)), 13)
        If lblMesBalance22.Text <> 0 And lblMesBalance21.Text <> 0 Then lblMesDifencia21.Text = FormatDuco(CDec(lblMesBalance22.Text) - CDec(lblMesBalance21.Text) - CDec(Transacion(21)), 13)
        If lblMesBalance23.Text <> 0 And lblMesBalance22.Text <> 0 Then lblMesDifencia22.Text = FormatDuco(CDec(lblMesBalance23.Text) - CDec(lblMesBalance22.Text) - CDec(Transacion(22)), 13)
        If lblMesBalance24.Text <> 0 And lblMesBalance23.Text <> 0 Then lblMesDifencia23.Text = FormatDuco(CDec(lblMesBalance24.Text) - CDec(lblMesBalance23.Text) - CDec(Transacion(23)), 13)
        If lblMesBalance25.Text <> 0 And lblMesBalance24.Text <> 0 Then lblMesDifencia24.Text = FormatDuco(CDec(lblMesBalance25.Text) - CDec(lblMesBalance24.Text) - CDec(Transacion(24)), 13)
        If lblMesBalance26.Text <> 0 And lblMesBalance25.Text <> 0 Then lblMesDifencia25.Text = FormatDuco(CDec(lblMesBalance26.Text) - CDec(lblMesBalance25.Text) - CDec(Transacion(25)), 13)
        If lblMesBalance27.Text <> 0 And lblMesBalance26.Text <> 0 Then lblMesDifencia26.Text = FormatDuco(CDec(lblMesBalance27.Text) - CDec(lblMesBalance26.Text) - CDec(Transacion(26)), 13)
        If lblMesBalance28.Text <> 0 And lblMesBalance27.Text <> 0 Then lblMesDifencia27.Text = FormatDuco(CDec(lblMesBalance28.Text) - CDec(lblMesBalance27.Text) - CDec(Transacion(27)), 13)
        If lblMesBalance29.Text <> 0 And lblMesBalance28.Text <> 0 Then lblMesDifencia28.Text = FormatDuco(CDec(lblMesBalance29.Text) - CDec(lblMesBalance28.Text) - CDec(Transacion(28)), 13)
        If lblMesBalance30.Text <> 0 And lblMesBalance29.Text <> 0 Then lblMesDifencia29.Text = FormatDuco(CDec(lblMesBalance30.Text) - CDec(lblMesBalance29.Text) - CDec(Transacion(29)), 13)
        If lblMesBalance31.Text <> 0 And lblMesBalance30.Text <> 0 Then lblMesDifencia30.Text = FormatDuco(CDec(lblMesBalance31.Text) - CDec(lblMesBalance30.Text) - CDec(Transacion(30)), 13)
    End Sub
    Private Sub MostrarMes()
        Dim Dato As Date = DateAndTime.Now
        Dim UltimoDía As Date = DateSerial(Dato.Year, Dato.Month + 1, 0)
        Dim UltimoDiaMes As Integer = 31 'Mid(UltimoDía, 1, 2)
        Select Case UltimoDiaMes
            Case 31
                lbl31.Visible = True
                lblMesBalance31.Visible = True
                lblMesPrecio31.Visible = True
                lblMesDifencia31.Visible = True
                lblTransacionMes31.Visible = True
                lbl30.Visible = True
                lblMesBalance30.Visible = True
                lblMesPrecio30.Visible = True
                lblMesDifencia30.Visible = True
                lbl29.Visible = True
                lblMesBalance29.Visible = True
                lblMesPrecio29.Visible = True
                lblMesDifencia29.Visible = True
                lblTotalMes.Location = New Point(299, 633)
                lblTransacionMes.Location = New Point(218, 633)
                lblMesDaily.Location = New Point(8, 633)
                'gpMes.Size = New Size(411, 676)
            Case 30
                lbl31.Visible = False
                lblMesBalance31.Visible = False
                lblMesPrecio31.Visible = False
                lblTransacionMes31.Visible = False
                lblMesDifencia31.Visible = False
                lbl30.Visible = True
                lblMesBalance30.Visible = True
                lblMesPrecio30.Visible = True
                lblMesDifencia30.Visible = True
                lbl29.Visible = True
                lblMesBalance29.Visible = True
                lblMesPrecio29.Visible = True
                lblMesDifencia29.Visible = True
                lblTotalMes.Location = New Point(299, 614)
                lblTransacionMes.Location = New Point(218, 614)
                lblMesDaily.Location = New Point(8, 614)
                'gpMes.Size = New Size(411, 676)
            Case 29
                lbl31.Visible = False
                lblMesBalance31.Visible = False
                lblMesPrecio31.Visible = False
                lblTransacionMes31.Visible = False
                lblMesDifencia31.Visible = False
                lbl30.Visible = False
                lblMesBalance30.Visible = False
                lblMesPrecio30.Visible = False
                lblMesDifencia30.Visible = False
                lbl29.Visible = True
                lblMesBalance29.Visible = True
                lblMesPrecio29.Visible = True
                lblMesDifencia29.Visible = True
                lblTotalMes.Location = New Point(299, 595)
                lblTransacionMes.Location = New Point(218, 595)
                lblMesDaily.Location = New Point(8, 595)
                'gpMes.Size = New Size(411, 577)
            Case 28
                lbl31.Visible = False
                lblMesBalance31.Visible = False
                lblMesPrecio31.Visible = False
                lblTransacionMes31.Visible = False
                lblMesDifencia31.Visible = False
                lbl30.Visible = False
                lblMesBalance30.Visible = False
                lblMesPrecio30.Visible = False
                lblMesDifencia30.Visible = False
                lbl29.Visible = False
                lblMesBalance29.Visible = False
                lblMesPrecio29.Visible = False
                lblMesDifencia29.Visible = False
                lblTotalMes.Location = New Point(299, 576)
                lblTransacionMes.Location = New Point(218, 576)
                lblMesDaily.Location = New Point(13, 576)
                'gpMes.Size = New Size(411, 558)
        End Select
    End Sub
    Public Function UnixTimeToDate(ByVal Timestamp As Long) As String
        Dim intDays As Integer, intHours As Integer, intMins As Integer, intSecs As Integer
        intDays = Timestamp / 86400
        intHours = (Timestamp / 86400) / 3600 - 3
        intMins = (Timestamp Mod 3600) / 60
        intSecs = Timestamp Mod 60
        UnixTimeToDate = DateSerial(1970, 1, intDays + 1) & " " & TimeSerial(intHours, intMins, intSecs)
    End Function
    Function sTiempo(dInicio As Date, dFin As Date) As String
        sTiempo = Str((DateDiff("s", dInicio, dFin) \ 86400) Mod 365) & " days, "
        Dim THora As String

        THora = Str((DateDiff("s", dInicio, dFin) \ 3600) Mod 24) & ":"
        THora &= Str((DateDiff("s", dInicio, dFin) \ 60) Mod 60) '& ":"
        '  THora = THora & Str(DateDiff("s", dInicio, dFin) Mod 60)
        sTiempo &= Format(CDate(THora), "HH:mm") & "h."
    End Function

    Private Sub Actualizar()
        Try
            If Minute(Now) = 0 Or Cargado = True Then
                Cargado = False
                Dim uriString3 As String = "http://www.floatrates.com/daily/eur.json"
                Dim uri3 As New Uri(uriString3)
                Dim Request3 As HttpWebRequest = HttpWebRequest.Create(uri3)
                Request3.Method = "GET"
                Dim Response3 As HttpWebResponse = Request3.GetResponse()
                Dim Read3 = New StreamReader(Response3.GetResponseStream())
                Dim Raw3 As String = Read3.ReadToEnd()
                Dim dict3 As Object = New JavaScriptSerializer().Deserialize(Of Dictionary(Of String, Object))(Raw3)
                Euro = CDec(dict3.item("usd").item("rate"))
                Dim uriString As String = "https://server.duinocoin.com/api.json"
                Dim uri As New Uri(uriString)
                Dim Request As HttpWebRequest = HttpWebRequest.Create(uri)
                Request.Method = "GET"
                Dim Response As HttpWebResponse = Request.GetResponse()
                Dim Read = New StreamReader(Response.GetResponseStream())
                Dim Raw As String = Read.ReadToEnd()
                Dim dict As Object = New JavaScriptSerializer().Deserialize(Of Dictionary(Of String, Object))(Raw)
                txtDucoprice.Text = CDec(dict.item("Duco price"))
                txtDucoNodeSprice.Text = CDec(dict.item("Duco Node-S price"))
                txtDucoPancakeSwapprice.Text = CDec(dict.item("Duco PancakeSwap price"))
                txtDucoSushiSwapprice.Text = CDec(dict.item("Duco SushiSwap price"))
                txtDucoJustSwapprice.Text = CDec(dict.item("Duco SunSwap price"))
                txtDucoprice1.Text = CDec(dict.item("Duco price"))
                txtDucopriceBCH.Text = CDec(dict.item("Duco price BCH"))
                txtDucopriceNANO.Text = CDec(dict.item("Duco price NANO"))
                txtDucopriceTRX.Text = CDec(dict.item("Duco price TRX"))
                txtDucopriceXMG.Text = CDec(dict.item("Duco price XMG"))
                txtActiveconnections.Text = dict.item("Active connections")
                txtDUCOS1hashrate.Text = dict.item("DUCO-S1 hashrate")
                txtNetenergyusage.Text = dict.item("Net energy usage")
                txtOpenthreads.Text = dict.item("Open threads")
                txtPoolhashrate.Text = dict.item("Pool hashrate")
                txtRegisteredusers.Text = dict.item("Registered users")
                txtServerCPUusage.Text = dict.item("Server CPU usage") & " %"
                txtServerRAMusage.Text = dict.item("Server RAM usage") & " %"
                txtServerversion.Text = dict.item("Server version") & " v"
                txtAll.Text = dict.item("Miner distribution").item("All")
                txtArduinos.Text = dict.item("Miner distribution").item("Arduino")
                txtCPU.Text = dict.item("Miner distribution").item("CPU")
                txtESP32.Text = dict.item("Miner distribution").item("ESP32")
                txtESP8266.Text = dict.item("Miner distribution").item("ESP8266")
                txtOther.Text = dict.item("Miner distribution").item("Other")
                txtPhone.Text = dict.item("Miner distribution").item("Phone")
                txtRPi.Text = dict.item("Miner distribution").item("RPi")
                txtWeb.Text = dict.item("Miner distribution").item("Web")
                txtLastblockhash.Text = dict.item("Last block hash")
                txtBanned.Text = dict.item("Kolka").item("Banned")
                txtJailed.Text = dict.item("Kolka").item("Jailed")
                txtLastsync.Text = dict.item("Last sync")
                txtLastupdate.Text = dict.item("Last update")
                txtMinedblocks.Text = dict.item("Mined blocks")
                lstboxTop10.Items.Clear()
                For K As Integer = 0 To 9
                    lstboxTop10.Items.Add(dict.item("Top 10 richest miners").item(K))
                Next
            End If

            Dim HasesUsuario As Integer = 0
            Dim uriString2 As String = "https://server.duinocoin.com/users/" & txtUser.Text & "?limit=5000"
            Dim uri2 As New Uri(uriString2)
            Dim Request2 As HttpWebRequest = HttpWebRequest.Create(uri2)
            Request2.Method = "GET"
            Dim Response2 As HttpWebResponse = Request2.GetResponse()
            Dim Read2 = New StreamReader(Response2.GetResponseStream())
            Dim Raw2 As String = Read2.ReadToEnd()
            Dim dict2 As Object = New JavaScriptSerializer().Deserialize(Of Dictionary(Of String, Object))(Raw2)
            Dict2Public = dict2

            Dim Deposito As Integer = dict2.item("result").item("balance").item("stake_amount")
            Dim FechafinDeposito As Integer = dict2.item("result").item("balance").item("stake_date")
            lblDeposito.Text = Deposito
            If Deposito > 0 Then
                lblFechaFinDeposito.Text = UnixTimeToDate(FechafinDeposito)
                lblTiempoRestante.Text = "Time Left:" & sTiempo(Now, lblFechaFinDeposito.Text)
                lblRecompensa.Text = Format(Deposito * (1.5 / 100), "#0.00")
                gbStaking.Enabled = True
            Else
                gbStaking.Enabled = False
            End If
            lblDucoDeposito.Left = lblDeposito.Left + lblDeposito.Width - 5
            lblEtiquetaDucoRecompensa.Left = lblRecompensa.Left + lblRecompensa.Width - 5
            txtbalance.Text = FormatDuco(dict2.item("result").item("balance").item("balance"), 17)
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
                        Chart6.Series(0).Points.AddXY(Hora & ":0" & Minutos & ":0" & Segundoss, CDec(Format(ValorEstimado, "###0.00")))
                    Else
                        Chart6.Series(0).Points.AddXY(Hora & ":" & Minutos & ":0" & Segundoss, CDec(Format(ValorEstimado, "###0.00")))
                    End If
                Else
                    If Minutos <= 9 Then
                        Chart6.Series(0).Points.AddXY(Hora & ":0" & Minutos & ":" & Segundoss, CDec(Format(ValorEstimado, "###0.00")))
                    Else
                        Chart6.Series(0).Points.AddXY(Hora & ":" & Minutos & ":" & Segundoss, CDec(Format(ValorEstimado, "###0.00")))
                    End If
                End If
                Chart7.Series(0).Points.AddY(Temperatura)
                Chart7.Series(1).Points.AddY(Humedad)
                ContadorEstimacion += 1
                If ContadorEstimacion >= 100 Then
                    Chart6.Series(0).Points.RemoveAt(0)
                    Chart7.Series(0).Points.RemoveAt(0)
                    Chart7.Series(1).Points.RemoveAt(0)
                End If
            End If
            Chart6.ChartAreas(0).RecalculateAxesScale()
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
            ContaTransa = CInt(dict2.item("result").item("transactions").Count) - 1
            If ContaTransa > 1 Then
                TreeView1.Nodes.Clear()
                Dim Mesis As String = DateAndTime.Month(Now)
                If DateAndTime.Month(Now) <= 9 Then
                    Mesis = "0" & DateAndTime.Month(Now)
                Else
                    Mesis = DateAndTime.Month(Now)
                End If
                For I As Integer = 0 To 31
                    Transacion(I) = 0
                    TransacionPorDia(I) = 0
                Next
                For I As Integer = ContaTransa To 0 Step -1
                    'For I As Integer = 0 To ContaTransa
                    EnviosDias(I) = Mid(dict2.item("result").item("transactions").item(I).item("datetime"), 1, 2)
                    EnviosMes(I) = Mid(dict2.item("result").item("transactions").item(I).item("datetime"), 4, 2)
                    EnviosAño(I) = Mid(dict2.item("result").item("transactions").item(I).item("datetime"), 7, 4)
                    If dict2.item("result").item("transactions").item(I).item("sender") = "Lanthi" Then
                        TreeView1.Nodes.Add("Enviado: " & dict2.item("result").item("transactions").item(I).item("amount") & " Ducos enviado a " & dict2.item("result").item("transactions").item(I).item("recipient"))
                        If EnviosMes(I) = Mesis Then Transacion(EnviosDias(I)) -= CDec(dict2.item("result").item("transactions").item(I).item("amount")) : TransacionPorDia(EnviosDias(I)) += 1
                    Else
                        TreeView1.Nodes.Add("Recibido: " & dict2.item("result").item("transactions").item(I).item("amount") & " Ducos recibido de " & dict2.item("result").item("transactions").item(I).item("sender"))
                        If EnviosMes(I) = Mesis Then Transacion(EnviosDias(I)) += CDec(dict2.item("result").item("transactions").item(I).item("amount")) : TransacionPorDia(EnviosDias(I)) += 1
                    End If
                    TreeView1.Nodes.Add("Fecha/hora: " & dict2.item("result").item("transactions").item(I).item("datetime"))
                    TreeView1.Nodes.Add("Hash: " & dict2.item("result").item("transactions").item(I).item("hash"))
                    TreeView1.Nodes.Add("Memo: " & dict2.item("result").item("transactions").item(I).item("memo"))
                    If I <> 0 Then TreeView1.Nodes.Add("")
                Next
                TabPage5.Text = "Transactions (" & ContaTransa + 1 & ")"
                TreeView1.ExpandAll()
                lblTransacionMes01.Text = Format(Transacion(1), "######0.#####")
                lblTransacionMes02.Text = Format(Transacion(2), "######0.#####")
                lblTransacionMes03.Text = Format(Transacion(3), "######0.#####")
                lblTransacionMes04.Text = Format(Transacion(4), "######0.#####")
                lblTransacionMes05.Text = Format(Transacion(5), "######0.#####")
                lblTransacionMes06.Text = Format(Transacion(6), "######0.#####")
                lblTransacionMes07.Text = Format(Transacion(7), "######0.#####")
                lblTransacionMes08.Text = Format(Transacion(8), "######0.#####")
                lblTransacionMes09.Text = Format(Transacion(9), "######0.#####")
                lblTransacionMes10.Text = Format(Transacion(10), "######0.#####")
                lblTransacionMes11.Text = Format(Transacion(11), "######0.#####")
                lblTransacionMes12.Text = Format(Transacion(12), "######0.#####")
                lblTransacionMes13.Text = Format(Transacion(13), "######0.#####")
                lblTransacionMes14.Text = Format(Transacion(14), "######0.#####")
                lblTransacionMes15.Text = Format(Transacion(15), "######0.#####")
                lblTransacionMes16.Text = Format(Transacion(16), "######0.#####")
                lblTransacionMes17.Text = Format(Transacion(17), "######0.#####")
                lblTransacionMes18.Text = Format(Transacion(18), "######0.#####")
                lblTransacionMes19.Text = Format(Transacion(19), "######0.#####")
                lblTransacionMes20.Text = Format(Transacion(20), "######0.#####")
                lblTransacionMes21.Text = Format(Transacion(21), "######0.#####")
                lblTransacionMes22.Text = Format(Transacion(22), "######0.#####")
                lblTransacionMes23.Text = Format(Transacion(23), "######0.#####")
                lblTransacionMes24.Text = Format(Transacion(24), "######0.#####")
                lblTransacionMes25.Text = Format(Transacion(25), "######0.#####")
                lblTransacionMes26.Text = Format(Transacion(26), "######0.#####")
                lblTransacionMes27.Text = Format(Transacion(27), "######0.#####")
                lblTransacionMes28.Text = Format(Transacion(28), "######0.#####")
                lblTransacionMes29.Text = Format(Transacion(29), "######0.#####")
                lblTransacionMes30.Text = Format(Transacion(30), "######0.#####")
                lblTransacionMes31.Text = Format(Transacion(31), "######0.#####")
                If lblTransacionMes01.Text <> 0 Then lblTransacionMes01.Text = lblTransacionMes01.Text & "(" & TransacionPorDia(1) & ")"
                If lblTransacionMes02.Text <> 0 Then lblTransacionMes02.Text = lblTransacionMes02.Text & "(" & TransacionPorDia(2) & ")"
                If lblTransacionMes03.Text <> 0 Then lblTransacionMes03.Text = lblTransacionMes03.Text & "(" & TransacionPorDia(3) & ")"
                If lblTransacionMes04.Text <> 0 Then lblTransacionMes04.Text = lblTransacionMes04.Text & "(" & TransacionPorDia(4) & ")"
                If lblTransacionMes05.Text <> 0 Then lblTransacionMes05.Text = lblTransacionMes05.Text & "(" & TransacionPorDia(5) & ")"
                If lblTransacionMes06.Text <> 0 Then lblTransacionMes06.Text = lblTransacionMes06.Text & "(" & TransacionPorDia(6) & ")"
                If lblTransacionMes07.Text <> 0 Then lblTransacionMes07.Text = lblTransacionMes07.Text & "(" & TransacionPorDia(7) & ")"
                If lblTransacionMes08.Text <> 0 Then lblTransacionMes08.Text = lblTransacionMes08.Text & "(" & TransacionPorDia(8) & ")"
                If lblTransacionMes09.Text <> 0 Then lblTransacionMes09.Text = lblTransacionMes09.Text & "(" & TransacionPorDia(9) & ")"
                If lblTransacionMes10.Text <> 0 Then lblTransacionMes10.Text = lblTransacionMes10.Text & "(" & TransacionPorDia(10) & ")"
                If lblTransacionMes11.Text <> 0 Then lblTransacionMes11.Text = lblTransacionMes11.Text & "(" & TransacionPorDia(11) & ")"
                If lblTransacionMes12.Text <> 0 Then lblTransacionMes12.Text = lblTransacionMes12.Text & "(" & TransacionPorDia(12) & ")"
                If lblTransacionMes13.Text <> 0 Then lblTransacionMes13.Text = lblTransacionMes13.Text & "(" & TransacionPorDia(13) & ")"
                If lblTransacionMes14.Text <> 0 Then lblTransacionMes14.Text = lblTransacionMes14.Text & "(" & TransacionPorDia(14) & ")"
                If lblTransacionMes15.Text <> 0 Then lblTransacionMes15.Text = lblTransacionMes15.Text & "(" & TransacionPorDia(15) & ")"
                If lblTransacionMes16.Text <> 0 Then lblTransacionMes16.Text = lblTransacionMes16.Text & "(" & TransacionPorDia(16) & ")"
                If lblTransacionMes17.Text <> 0 Then lblTransacionMes17.Text = lblTransacionMes17.Text & "(" & TransacionPorDia(17) & ")"
                If lblTransacionMes18.Text <> 0 Then lblTransacionMes18.Text = lblTransacionMes18.Text & "(" & TransacionPorDia(18) & ")"
                If lblTransacionMes19.Text <> 0 Then lblTransacionMes19.Text = lblTransacionMes19.Text & "(" & TransacionPorDia(19) & ")"
                If lblTransacionMes20.Text <> 0 Then lblTransacionMes20.Text = lblTransacionMes20.Text & "(" & TransacionPorDia(20) & ")"
                If lblTransacionMes21.Text <> 0 Then lblTransacionMes21.Text = lblTransacionMes21.Text & "(" & TransacionPorDia(21) & ")"
                If lblTransacionMes22.Text <> 0 Then lblTransacionMes22.Text = lblTransacionMes22.Text & "(" & TransacionPorDia(22) & ")"
                If lblTransacionMes23.Text <> 0 Then lblTransacionMes23.Text = lblTransacionMes23.Text & "(" & TransacionPorDia(23) & ")"
                If lblTransacionMes24.Text <> 0 Then lblTransacionMes24.Text = lblTransacionMes24.Text & "(" & TransacionPorDia(24) & ")"
                If lblTransacionMes25.Text <> 0 Then lblTransacionMes25.Text = lblTransacionMes25.Text & "(" & TransacionPorDia(25) & ")"
                If lblTransacionMes26.Text <> 0 Then lblTransacionMes26.Text = lblTransacionMes26.Text & "(" & TransacionPorDia(26) & ")"
                If lblTransacionMes27.Text <> 0 Then lblTransacionMes27.Text = lblTransacionMes27.Text & "(" & TransacionPorDia(27) & ")"
                If lblTransacionMes28.Text <> 0 Then lblTransacionMes28.Text = lblTransacionMes28.Text & "(" & TransacionPorDia(28) & ")"
                If lblTransacionMes29.Text <> 0 Then lblTransacionMes29.Text = lblTransacionMes29.Text & "(" & TransacionPorDia(29) & ")"
                If lblTransacionMes30.Text <> 0 Then lblTransacionMes30.Text = lblTransacionMes30.Text & "(" & TransacionPorDia(30) & ")"
                If lblTransacionMes31.Text <> 0 Then lblTransacionMes31.Text = lblTransacionMes31.Text & "(" & TransacionPorDia(31) & ")"
            End If
            TreeView2.Sorted = False
            Dim Contador As Integer = dict2.item("result").item("miners").Count
            ReDim Mineros(Contador, 8)
            TreeView2.Nodes.Clear()
            txtMinerosHArduino.Text = 0
            txtMinerosHCPU.Text = 0
            txtMinerosHEsp8266.Text = 0
            txtMinerosHEsp32.Text = 0
            txtMinerosHotros.Text = 0
            txtMinerosHPhone.Text = 0
            txtMinerosHRPI.Text = 0
            txtMinerosHWeb.Text = 0
            txtMinerosNArduino.Text = 0
            txtMinerosNCPU.Text = 0
            txtMinerosNEsp8266.Text = 0
            txtMinerosNEsp32.Text = 0
            txtMinerosNotros.Text = 0
            txtMinerosNPhone.Text = 0
            txtMinerosNRPI.Text = 0
            txtMinerosNWeb.Text = 0
            TreeView2.Nodes.Add("Mineros" & " (" & Contador & ")")
            For T As Integer = 0 To Contador - 1
                Mineros(T, 0) = dict2.item("result").item("miners").item(T).item("identifier") & " (" & CalcularHases(dict2.item("result").item("miners").item(T).item("hashrate")) & ")"
                Mineros(T, 1) = "Accepted: " & dict2.item("result").item("miners").item(T).item("accepted")
                Mineros(T, 2) = "Algorithm: " & dict2.item("result").item("miners").item(T).item("algorithm")
                Mineros(T, 3) = "Diff: " & dict2.item("result").item("miners").item(T).item("diff")
                Mineros(T, 4) = "Hashrate: " & CalcularHases(dict2.item("result").item("miners").item(T).item("hashrate"))
                HasesUsuario += dict2.item("result").item("miners").item(T).item("hashrate")
                Mineros(T, 5) = "Pool: " & dict2.item("result").item("miners").item(T).item("pool")
                Mineros(T, 6) = "Rejected: " & dict2.item("result").item("miners").item(T).item("rejected")
                Mineros(T, 7) = "Soft.: " & dict2.item("result").item("miners").item(T).item("software")
                Dim Tmp As String = dict2.item("result").item("miners").item(T).item("it")
                If Tmp <> "" Then
                    Mineros(T, 8) = "Temperature - Humidity : " & Mid(Tmp, 1, 2) & "° - " & Mid(Tmp, 4) & "%"
                    TreeView2.Nodes(0).Nodes.Add(Mineros(T, 0) & " [IOT]")
                Else
                    TreeView2.Nodes(0).Nodes.Add(Mineros(T, 0))
                End If
                If Tmp <> "" Then
                    For A As Integer = 0 To 8
                        TreeView2.Nodes(0).Nodes(T).Nodes.Add(Mineros(T, A))
                    Next A
                Else
                    For A As Integer = 0 To 7
                        TreeView2.Nodes(0).Nodes(T).Nodes.Add(Mineros(T, A))
                    Next A
                End If
                Select Case dict2.item("result").item("miners").item(T).item("software")
                    Case "Official AVR Miner 3.1"
                        txtMinerosNArduino.Text += 1
                        txtMinerosHArduino.Text += dict2.item("result").item("miners").item(T).item("hashrate")
                        TreeView2.Nodes(0).Nodes(T).ImageIndex = 0
                        TreeView2.Nodes(0).Nodes(T).SelectedImageIndex = 0
                    Case "Official PC Miner 3.1"
                        txtMinerosHCPU.Text += dict2.item("result").item("miners").item(T).item("hashrate")
                        txtMinerosNCPU.Text += 1
                        TreeView2.Nodes(0).Nodes(T).ImageIndex = 1
                        TreeView2.Nodes(0).Nodes(T).SelectedImageIndex = 1
                    Case "Official ESP32 Miner 3.1"
                        txtMinerosNEsp32.Text += 1
                        txtMinerosHEsp32.Text += dict2.item("result").item("miners").item(T).item("hashrate")
                        TreeView2.Nodes(0).Nodes(T).ImageIndex = 7
                        TreeView2.Nodes(0).Nodes(T).SelectedImageIndex = 7
                    Case "Official ESP8266 Miner 3.1"
                        txtMinerosNEsp8266.Text += 1
                        txtMinerosHEsp8266.Text += dict2.item("result").item("miners").item(T).item("hashrate")
                        TreeView2.Nodes(0).Nodes(T).ImageIndex = 8
                        TreeView2.Nodes(0).Nodes(T).SelectedImageIndex = 8
                    Case "Official ESP8266 Miner 3.18"
                        Dim temp As String = dict2.item("result").item("miners").item(T).item("it")
                        txtMinerosNEsp8266.Text += 1
                        txtMinerosHEsp8266.Text += dict2.item("result").item("miners").item(T).item("hashrate")
                        TreeView2.Nodes(0).Nodes(T).ImageIndex = 8
                        TreeView2.Nodes(0).Nodes(T).SelectedImageIndex = 8
                        If temp <> "" Then
                            lblTemperatura.Text = Mid(temp, 1, 2) & "°"
                            Temperatura = Mid(temp, 1, 2)
                            lblHumedad.Text = Mid(temp, 4) & "%"
                            Humedad = Mid(temp, 4)
                        End If
                    Case "Official Web Miner 2.8"
                        txtMinerosNWeb.Text += 1
                        txtMinerosHWeb.Text += dict2.item("result").item("miners").item(T).item("hashrate")
                        TreeView2.Nodes(0).Nodes(T).ImageIndex = 2
                        TreeView2.Nodes(0).Nodes(T).SelectedImageIndex = 2
                    Case Else
                        txtMinerosNotros.Text += 1
                        txtMinerosHotros.Text += dict2.item("result").item("miners").item(T).item("hashrate")
                End Select
                TreeView2.Refresh()
            Next
            GroupBox8.Text = "Miners (" & Contador & ") " & CalcularHases(HasesUsuario)
            TabPage4.Text = "Miners (" & Contador & ")"
            lblHases.Text = CalcularHases1(HasesUsuario)
            lblMineros.Text = Contador
            txtMinerosHArduino.Text = CalcularHases(txtMinerosHArduino.Text)
            txtMinerosHCPU.Text = CalcularHases(txtMinerosHCPU.Text)
            txtMinerosNEsp32.Text = txtMinerosNEsp32.Text / 2
            txtMinerosHEsp32.Text = CalcularHases(txtMinerosHEsp32.Text)
            txtMinerosHEsp8266.Text = CalcularHases(txtMinerosHEsp8266.Text)
            txtMinerosHWeb.Text = CalcularHases(txtMinerosHWeb.Text)
            txtMinerosHotros.Text = CalcularHases(txtMinerosHotros.Text)
            txtMinerosHPhone.Text = CalcularHases(txtMinerosHPhone.Text)
            txtMinerosHRPI.Text = CalcularHases(txtMinerosHRPI.Text)
            TreeView2.Nodes(0).ImageIndex = 6
            TreeView2.Nodes(0).SelectedImageIndex = 6
            TreeView2.Nodes(0).Expand()
            TreeView2.Sorted = True

            Select Case Hour(Now)
                Case 0 : If lblBalanceHora00.Text <> 0 Then lblHoraDiferencia00.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceHora00.Text), 8)
                Case 1 : If lblBalanceHora01.Text <> 0 Then lblHoraDiferencia01.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceHora01.Text), 8)
                Case 2 : If lblBalanceHora02.Text <> 0 Then lblHoraDiferencia02.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceHora02.Text), 8)
                Case 3 : If lblBalanceHora03.Text <> 0 Then lblHoraDiferencia03.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceHora03.Text), 8)
                Case 4 : If lblBalanceHora04.Text <> 0 Then lblHoraDiferencia04.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceHora04.Text), 8)
                Case 5 : If lblBalanceHora05.Text <> 0 Then lblHoraDiferencia05.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceHora05.Text), 8)
                Case 6 : If lblBalanceHora06.Text <> 0 Then lblHoraDiferencia06.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceHora06.Text), 8)
                Case 7 : If lblBalanceHora07.Text <> 0 Then lblHoraDiferencia07.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceHora07.Text), 8)
                Case 8 : If lblBalanceHora08.Text <> 0 Then lblHoraDiferencia08.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceHora08.Text), 8)
                Case 9 : If lblBalanceHora09.Text <> 0 Then lblHoraDiferencia09.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceHora09.Text), 8)
                Case 10 : If lblBalanceHora10.Text <> 0 Then lblHoraDiferencia10.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceHora10.Text), 8)
                Case 11 : If lblBalanceHora11.Text <> 0 Then lblHoraDiferencia11.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceHora11.Text), 8)
                Case 12 : If lblBalanceHora12.Text <> 0 Then lblHoraDiferencia12.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceHora12.Text), 8)
                Case 13 : If lblBalanceHora13.Text <> 0 Then lblHoraDiferencia13.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceHora13.Text), 8)
                Case 14 : If lblBalanceHora14.Text <> 0 Then lblHoraDiferencia14.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceHora14.Text), 8)
                Case 15 : If lblBalanceHora15.Text <> 0 Then lblHoraDiferencia15.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceHora15.Text), 8)
                Case 16 : If lblBalanceHora16.Text <> 0 Then lblHoraDiferencia16.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceHora16.Text), 8)
                Case 17 : If lblBalanceHora17.Text <> 0 Then lblHoraDiferencia17.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceHora17.Text), 8)
                Case 18 : If lblBalanceHora18.Text <> 0 Then lblHoraDiferencia18.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceHora18.Text), 8)
                Case 19 : If lblBalanceHora19.Text <> 0 Then lblHoraDiferencia19.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceHora19.Text), 8)
                Case 20 : If lblBalanceHora20.Text <> 0 Then lblHoraDiferencia20.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceHora20.Text), 8)
                Case 21 : If lblBalanceHora21.Text <> 0 Then lblHoraDiferencia21.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceHora21.Text), 8)
                Case 22 : If lblBalanceHora22.Text <> 0 Then lblHoraDiferencia22.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceHora22.Text), 8)
                Case 23 : If lblBalanceHora23.Text <> 0 Then lblHoraDiferencia23.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceHora23.Text), 8)
            End Select
            Select Case DateAndTime.Day(Now)
                Case 1 : If lblMesBalance01.Text <> 0 Then lblMesDifencia01.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblMesBalance01.Text) - CDec(Transacion(1)), 13)
                Case 2 : If lblMesBalance02.Text <> 0 Then lblMesDifencia02.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblMesBalance02.Text) - CDec(Transacion(2)), 13)
                Case 3 : If lblMesBalance03.Text <> 0 Then lblMesDifencia03.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblMesBalance03.Text) - CDec(Transacion(3)), 13)
                Case 4 : If lblMesBalance04.Text <> 0 Then lblMesDifencia04.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblMesBalance04.Text) - CDec(Transacion(4)), 13)
                Case 5 : If lblMesBalance05.Text <> 0 Then lblMesDifencia05.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblMesBalance05.Text) - CDec(Transacion(5)), 13)
                Case 6 : If lblMesBalance06.Text <> 0 Then lblMesDifencia06.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblMesBalance06.Text) - CDec(Transacion(6)), 13)
                Case 7 : If lblMesBalance07.Text <> 0 Then lblMesDifencia07.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblMesBalance07.Text) - CDec(Transacion(7)), 13)
                Case 8 : If lblMesBalance08.Text <> 0 Then lblMesDifencia08.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblMesBalance08.Text) - CDec(Transacion(8)), 13)
                Case 9 : If lblMesBalance09.Text <> 0 Then lblMesDifencia09.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblMesBalance09.Text) - CDec(Transacion(9)), 13)
                Case 10 : If lblMesBalance10.Text <> 0 Then lblMesDifencia10.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblMesBalance10.Text) - CDec(Transacion(10)), 13)
                Case 11 : If lblMesBalance11.Text <> 0 Then lblMesDifencia11.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblMesBalance11.Text) - CDec(Transacion(11)), 13)
                Case 12 : If lblMesBalance12.Text <> 0 Then lblMesDifencia12.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblMesBalance12.Text) - CDec(Transacion(12)), 13)
                Case 13 : If lblMesBalance13.Text <> 0 Then lblMesDifencia13.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblMesBalance13.Text) - CDec(Transacion(13)), 13)
                Case 14 : If lblMesBalance14.Text <> 0 Then lblMesDifencia14.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblMesBalance14.Text) - CDec(Transacion(14)), 13)
                Case 15 : If lblMesBalance15.Text <> 0 Then lblMesDifencia15.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblMesBalance15.Text) - CDec(Transacion(15)), 14)
                Case 16 : If lblMesBalance16.Text <> 0 Then lblMesDifencia16.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblMesBalance16.Text) - CDec(Transacion(16)), 13)
                Case 17 : If lblMesBalance17.Text <> 0 Then lblMesDifencia17.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblMesBalance17.Text) - CDec(Transacion(17)), 13)
                Case 18 : If lblMesBalance18.Text <> 0 Then lblMesDifencia18.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblMesBalance18.Text) - CDec(Transacion(18)), 13)
                Case 19 : If lblMesBalance19.Text <> 0 Then lblMesDifencia19.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblMesBalance19.Text) - CDec(Transacion(19)), 13)
                Case 20 : If lblMesBalance20.Text <> 0 Then lblMesDifencia20.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblMesBalance20.Text) - CDec(Transacion(20)), 13)
                Case 21 : If lblMesBalance21.Text <> 0 Then lblMesDifencia21.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblMesBalance21.Text) - CDec(Transacion(21)), 13)
                Case 22 : If lblMesBalance22.Text <> 0 Then lblMesDifencia22.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblMesBalance22.Text) - CDec(Transacion(22)), 13)
                Case 23 : If lblMesBalance23.Text <> 0 Then lblMesDifencia23.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblMesBalance23.Text) - CDec(Transacion(23)), 13)
                Case 24 : If lblMesBalance24.Text <> 0 Then lblMesDifencia24.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblMesBalance24.Text) - CDec(Transacion(24)), 13)
                Case 25 : If lblMesBalance25.Text <> 0 Then lblMesDifencia25.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblMesBalance25.Text) - CDec(Transacion(25)), 13)
                Case 26 : If lblMesBalance26.Text <> 0 Then lblMesDifencia26.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblMesBalance26.Text) - CDec(Transacion(26)), 13)
                Case 27 : If lblMesBalance27.Text <> 0 Then lblMesDifencia27.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblMesBalance27.Text) - CDec(Transacion(27)), 13)
                Case 28 : If lblMesBalance28.Text <> 0 Then lblMesDifencia28.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblMesBalance28.Text) - CDec(Transacion(28)), 13)
                Case 29 : If lblMesBalance29.Text <> 0 Then lblMesDifencia29.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblMesBalance29.Text) - CDec(Transacion(29)), 13)
                Case 30 : If lblMesBalance30.Text <> 0 Then lblMesDifencia30.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblMesBalance30.Text) - CDec(Transacion(30)), 13)
                Case 31 : If lblMesBalance31.Text <> 0 Then lblMesDifencia31.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblMesBalance31.Text) - CDec(Transacion(31)), 13)
            End Select
            MostrarTotales()
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
            Chart1.ChartAreas(0).RecalculateAxesScale()
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
            Chart5.Series(0).Points.Clear()
            Chart4.Series(0).Points.Clear()
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
            My.Settings.Save()
        Catch ex As Exception
            MsgBox("Error!!" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub MostrarTotales()
        Dim TotalHoras As Decimal = 0
        Dim PrecioMedioHora As Decimal = 0
        Dim PrecioMin As Decimal
        Dim PrecioMax As Decimal
        lblTotalHora.Text = 0
        PrecioMin = CDec(lblPrecio00.Text)
        PrecioMax = CDec(lblPrecio00.Text)
        If lblPrecio02.Text <> "0" Then
            If PrecioMin >= CDec(lblPrecio02.Text) Then
                PrecioMin = CDec(lblPrecio02.Text)
            ElseIf PrecioMax <= CDec(lblPrecio02.Text) Then
                PrecioMax = CDec(lblPrecio02.Text)
            End If
        End If
        If lblPrecio03.Text <> "0" Then
            If PrecioMin >= CDec(lblPrecio03.Text) Then
                PrecioMin = CDec(lblPrecio03.Text)
            ElseIf PrecioMax <= CDec(lblPrecio03.Text) Then
                PrecioMax = CDec(lblPrecio03.Text)
            End If
        End If
        If lblPrecio04.Text <> "0" Then
            If PrecioMin >= CDec(lblPrecio04.Text) Then
                PrecioMin = CDec(lblPrecio04.Text)
            ElseIf PrecioMax <= CDec(lblPrecio04.Text) Then
                PrecioMax = CDec(lblPrecio04.Text)
            End If
        End If
        If lblPrecio05.Text <> "0" Then
            If PrecioMin >= CDec(lblPrecio05.Text) Then
                PrecioMin = CDec(lblPrecio05.Text)
            ElseIf PrecioMax <= CDec(lblPrecio05.Text) Then
                PrecioMax = CDec(lblPrecio05.Text)
            End If
        End If
        If lblPrecio06.Text <> "0" Then
            If PrecioMin >= CDec(lblPrecio06.Text) Then
                PrecioMin = CDec(lblPrecio06.Text)
            ElseIf PrecioMax <= CDec(lblPrecio06.Text) Then
                PrecioMax = CDec(lblPrecio06.Text)
            End If
        End If
        If lblPrecio07.Text <> "0" Then
            If PrecioMin >= CDec(lblPrecio07.Text) Then
                PrecioMin = CDec(lblPrecio07.Text)
            ElseIf PrecioMax <= CDec(lblPrecio07.Text) Then
                PrecioMax = CDec(lblPrecio07.Text)
            End If
        End If
        If lblPrecio08.Text <> "0" Then
            If PrecioMin >= CDec(lblPrecio08.Text) Then
                PrecioMin = CDec(lblPrecio08.Text)
            ElseIf PrecioMax <= CDec(lblPrecio08.Text) Then
                PrecioMax = CDec(lblPrecio08.Text)
            End If
        End If
        If lblPrecio09.Text <> "0" Then
            If PrecioMin >= CDec(lblPrecio09.Text) Then
                PrecioMin = CDec(lblPrecio09.Text)
            ElseIf PrecioMax <= CDec(lblPrecio09.Text) Then
                PrecioMax = CDec(lblPrecio09.Text)
            End If
        End If
        If lblPrecio10.Text <> "0" Then
            If PrecioMin >= CDec(lblPrecio10.Text) Then
                PrecioMin = CDec(lblPrecio10.Text)
            ElseIf PrecioMax <= CDec(lblPrecio10.Text) Then
                PrecioMax = CDec(lblPrecio10.Text)
            End If
        End If
        If lblPrecio11.Text <> "0" Then
            If PrecioMin >= CDec(lblPrecio11.Text) Then
                PrecioMin = CDec(lblPrecio11.Text)
            ElseIf PrecioMax <= CDec(lblPrecio11.Text) Then
                PrecioMax = CDec(lblPrecio11.Text)
            End If
        End If
        If lblPrecio12.Text <> "0" Then
            If PrecioMin >= CDec(lblPrecio12.Text) Then
                PrecioMin = CDec(lblPrecio12.Text)
            ElseIf PrecioMax <= CDec(lblPrecio12.Text) Then
                PrecioMax = CDec(lblPrecio12.Text)
            End If
        End If
        If lblPrecio13.Text <> "0" Then
            If PrecioMin >= CDec(lblPrecio13.Text) Then
                PrecioMin = CDec(lblPrecio13.Text)
            ElseIf PrecioMax <= CDec(lblPrecio13.Text) Then
                PrecioMax = CDec(lblPrecio13.Text)
            End If
        End If
        If lblPrecio14.Text <> "0" Then
            If PrecioMin >= CDec(lblPrecio14.Text) Then
                PrecioMin = CDec(lblPrecio14.Text)
            ElseIf PrecioMax <= CDec(lblPrecio14.Text) Then
                PrecioMax = CDec(lblPrecio14.Text)
            End If
        End If
        If lblPrecio15.Text <> "0" Then
            If PrecioMin >= CDec(lblPrecio15.Text) Then
                PrecioMin = CDec(lblPrecio15.Text)
            ElseIf PrecioMax <= CDec(lblPrecio15.Text) Then
                PrecioMax = CDec(lblPrecio15.Text)
            End If
        End If
        If lblPrecio16.Text <> "0" Then
            If PrecioMin >= CDec(lblPrecio16.Text) Then
                PrecioMin = CDec(lblPrecio16.Text)
            ElseIf PrecioMax <= CDec(lblPrecio16.Text) Then
                PrecioMax = CDec(lblPrecio16.Text)
            End If
        End If
        If lblPrecio17.Text <> "0" Then
            If PrecioMin >= CDec(lblPrecio17.Text) Then
                PrecioMin = CDec(lblPrecio17.Text)
            ElseIf PrecioMax <= CDec(lblPrecio17.Text) Then
                PrecioMax = CDec(lblPrecio17.Text)
            End If
        End If
        If lblPrecio18.Text <> "0" Then
            If PrecioMin >= CDec(lblPrecio18.Text) Then
                PrecioMin = CDec(lblPrecio18.Text)
            ElseIf PrecioMax <= CDec(lblPrecio18.Text) Then
                PrecioMax = CDec(lblPrecio18.Text)
            End If
        End If
        If lblPrecio19.Text <> "0" Then
            If PrecioMin >= CDec(lblPrecio19.Text) Then
                PrecioMin = CDec(lblPrecio19.Text)
            ElseIf PrecioMax <= CDec(lblPrecio19.Text) Then
                PrecioMax = CDec(lblPrecio19.Text)
            End If
        End If
        If lblPrecio20.Text <> "0" Then
            If PrecioMin >= CDec(lblPrecio20.Text) Then
                PrecioMin = CDec(lblPrecio20.Text)
            ElseIf PrecioMax <= CDec(lblPrecio20.Text) Then
                PrecioMax = CDec(lblPrecio20.Text)
            End If
        End If
        If lblPrecio21.Text <> "0" Then
            If PrecioMin >= CDec(lblPrecio21.Text) Then
                PrecioMin = CDec(lblPrecio21.Text)
            ElseIf PrecioMax <= CDec(lblPrecio21.Text) Then
                PrecioMax = CDec(lblPrecio21.Text)
            End If
        End If
        If lblPrecio22.Text <> "0" Then
            If PrecioMin >= CDec(lblPrecio22.Text) Then
                PrecioMin = CDec(lblPrecio22.Text)
            ElseIf PrecioMax <= CDec(lblPrecio22.Text) Then
                PrecioMax = CDec(lblPrecio22.Text)
            End If
        End If
        If lblPrecio23.Text <> "0" Then
            If PrecioMin >= CDec(lblPrecio23.Text) Then
                PrecioMin = CDec(lblPrecio23.Text)
            ElseIf PrecioMax <= CDec(lblPrecio23.Text) Then
                PrecioMax = CDec(lblPrecio23.Text)
            End If
        End If
        If Hour(Now) = 0 Then
            lblPrecioDia.Text = lblPrecio00.Text
        Else
            lblPrecioDia.Text = (PrecioMax + PrecioMin) / 2
        End If
        Dim PrecioMesMin As Decimal
        Dim PrecioMesMax As Decimal
        PrecioMesMin = CDec(lblMesPrecio01.Text)
        PrecioMesMax = CDec(lblMesPrecio01.Text)
        If lblMesPrecio02.Text <> "0" Then
            If PrecioMesMin > CDec(lblMesPrecio02.Text) Then
                PrecioMesMin = CDec(lblMesPrecio02.Text)
            ElseIf PrecioMesMax < CDec(lblMesPrecio02.Text) Then
                PrecioMesMax = CDec(lblMesPrecio02.Text)
            End If
        End If
        If lblMesPrecio03.Text <> "0" Then
            If PrecioMesMin > CDec(lblMesPrecio03.Text) Then
                PrecioMesMin = CDec(lblMesPrecio03.Text)
            ElseIf PrecioMesMax < CDec(lblMesPrecio03.Text) Then
                PrecioMesMax = CDec(lblMesPrecio03.Text)
            End If
        End If
        If lblMesPrecio04.Text <> "0" Then
            If PrecioMesMin > CDec(lblMesPrecio04.Text) Then
                PrecioMesMin = CDec(lblMesPrecio04.Text)
            ElseIf PrecioMesMax < CDec(lblMesPrecio04.Text) Then
                PrecioMesMax = CDec(lblMesPrecio04.Text)
            End If
        End If
        If lblMesPrecio05.Text <> "0" Then
            If PrecioMesMin > CDec(lblMesPrecio05.Text) Then
                PrecioMesMin = CDec(lblMesPrecio05.Text)
            ElseIf PrecioMesMax < CDec(lblMesPrecio05.Text) Then
                PrecioMesMax = CDec(lblMesPrecio05.Text)
            End If
        End If
        If lblMesPrecio06.Text <> "0" Then
            If PrecioMesMin > CDec(lblMesPrecio06.Text) Then
                PrecioMesMin = CDec(lblMesPrecio06.Text)
            ElseIf PrecioMesMax < CDec(lblMesPrecio06.Text) Then
                PrecioMesMax = CDec(lblMesPrecio06.Text)
            End If
        End If
        If lblMesPrecio07.Text <> "0" Then
            If PrecioMesMin > CDec(lblMesPrecio07.Text) Then
                PrecioMesMin = CDec(lblMesPrecio07.Text)
            ElseIf PrecioMesMax < CDec(lblMesPrecio07.Text) Then
                PrecioMesMax = CDec(lblMesPrecio07.Text)
            End If
        End If
        If lblMesPrecio08.Text <> "0" Then
            If PrecioMesMin > CDec(lblMesPrecio08.Text) Then
                PrecioMesMin = CDec(lblMesPrecio08.Text)
            ElseIf PrecioMesMax < CDec(lblMesPrecio08.Text) Then
                PrecioMesMax = CDec(lblMesPrecio08.Text)
            End If
        End If
        If lblMesPrecio09.Text <> "0" Then
            If PrecioMesMin > CDec(lblMesPrecio09.Text) Then
                PrecioMesMin = CDec(lblMesPrecio09.Text)
            ElseIf PrecioMesMax < CDec(lblMesPrecio09.Text) Then
                PrecioMesMax = CDec(lblMesPrecio09.Text)
            End If
        End If
        If lblMesPrecio10.Text <> "0" Then
            If PrecioMesMin > CDec(lblMesPrecio10.Text) Then
                PrecioMesMin = CDec(lblMesPrecio10.Text)
            ElseIf PrecioMesMax < CDec(lblMesPrecio10.Text) Then
                PrecioMesMax = CDec(lblMesPrecio10.Text)
            End If
        End If
        If lblMesPrecio11.Text <> "0" Then
            If PrecioMesMin > CDec(lblMesPrecio11.Text) Then
                PrecioMesMin = CDec(lblMesPrecio11.Text)
            ElseIf PrecioMesMax < CDec(lblMesPrecio11.Text) Then
                PrecioMesMax = CDec(lblMesPrecio11.Text)
            End If
        End If
        If lblMesPrecio12.Text <> "0" Then
            If PrecioMesMin > CDec(lblMesPrecio12.Text) Then
                PrecioMesMin = CDec(lblMesPrecio12.Text)
            ElseIf PrecioMesMax < CDec(lblMesPrecio12.Text) Then
                PrecioMesMax = CDec(lblMesPrecio12.Text)
            End If
        End If
        If lblMesPrecio13.Text <> "0" Then
            If PrecioMesMin > CDec(lblMesPrecio13.Text) Then
                PrecioMesMin = CDec(lblMesPrecio13.Text)
            ElseIf PrecioMesMax < CDec(lblMesPrecio13.Text) Then
                PrecioMesMax = CDec(lblMesPrecio13.Text)
            End If
        End If
        If lblMesPrecio14.Text <> "0" Then
            If PrecioMesMin > CDec(lblMesPrecio14.Text) Then
                PrecioMesMin = CDec(lblMesPrecio14.Text)
            ElseIf PrecioMesMax < CDec(lblMesPrecio14.Text) Then
                PrecioMesMax = CDec(lblMesPrecio14.Text)
            End If
        End If
        If lblMesPrecio15.Text <> "0" Then
            If PrecioMesMin > CDec(lblMesPrecio15.Text) Then
                PrecioMesMin = CDec(lblMesPrecio15.Text)
            ElseIf PrecioMesMax < CDec(lblMesPrecio15.Text) Then
                PrecioMesMax = CDec(lblMesPrecio15.Text)
            End If
        End If
        If lblMesPrecio16.Text <> "0" Then
            If PrecioMesMin > CDec(lblMesPrecio16.Text) Then
                PrecioMesMin = CDec(lblMesPrecio16.Text)
            ElseIf PrecioMesMax < CDec(lblMesPrecio16.Text) Then
                PrecioMesMax = CDec(lblMesPrecio16.Text)
            End If
        End If
        If lblMesPrecio17.Text <> "0" Then
            If PrecioMesMin > CDec(lblMesPrecio17.Text) Then
                PrecioMesMin = CDec(lblMesPrecio17.Text)
            ElseIf PrecioMesMax < CDec(lblMesPrecio17.Text) Then
                PrecioMesMax = CDec(lblMesPrecio17.Text)
            End If
        End If
        If lblMesPrecio18.Text <> "0" Then
            If PrecioMesMin > CDec(lblMesPrecio18.Text) Then
                PrecioMesMin = CDec(lblMesPrecio18.Text)
            ElseIf PrecioMesMax < CDec(lblMesPrecio18.Text) Then
                PrecioMesMax = CDec(lblMesPrecio18.Text)
            End If
        End If
        If lblMesPrecio19.Text <> "0" Then
            If PrecioMesMin > CDec(lblMesPrecio19.Text) Then
                PrecioMesMin = CDec(lblMesPrecio19.Text)
            ElseIf PrecioMesMax < CDec(lblMesPrecio19.Text) Then
                PrecioMesMax = CDec(lblMesPrecio19.Text)
            End If
        End If
        If lblMesPrecio20.Text <> "0" Then
            If PrecioMesMin > CDec(lblMesPrecio20.Text) Then
                PrecioMesMin = CDec(lblMesPrecio20.Text)
            ElseIf PrecioMesMax < CDec(lblMesPrecio20.Text) Then
                PrecioMesMax = CDec(lblMesPrecio20.Text)
            End If
        End If
        If lblMesPrecio21.Text <> "0" Then
            If PrecioMesMin > CDec(lblMesPrecio21.Text) Then
                PrecioMesMin = CDec(lblMesPrecio21.Text)
            ElseIf PrecioMesMax < CDec(lblMesPrecio21.Text) Then
                PrecioMesMax = CDec(lblMesPrecio21.Text)
            End If
        End If
        If lblMesPrecio22.Text <> "0" Then
            If PrecioMesMin > CDec(lblMesPrecio22.Text) Then
                PrecioMesMin = CDec(lblMesPrecio22.Text)
            ElseIf PrecioMesMax < CDec(lblMesPrecio22.Text) Then
                PrecioMesMax = CDec(lblMesPrecio22.Text)
            End If
        End If
        If lblMesPrecio23.Text <> "0" Then
            If PrecioMesMin > CDec(lblMesPrecio23.Text) Then
                PrecioMesMin = CDec(lblMesPrecio23.Text)
            ElseIf PrecioMesMax < CDec(lblMesPrecio23.Text) Then
                PrecioMesMax = CDec(lblMesPrecio23.Text)
            End If
        End If
        If lblMesPrecio24.Text <> "0" Then
            If PrecioMesMin > CDec(lblMesPrecio24.Text) Then
                PrecioMesMin = CDec(lblMesPrecio24.Text)
            ElseIf PrecioMesMax < CDec(lblMesPrecio24.Text) Then
                PrecioMesMax = CDec(lblMesPrecio24.Text)
            End If
        End If
        If lblMesPrecio25.Text <> "0" Then
            If PrecioMesMin > CDec(lblMesPrecio25.Text) Then
                PrecioMesMin = CDec(lblMesPrecio25.Text)
            ElseIf PrecioMesMax < CDec(lblMesPrecio25.Text) Then
                PrecioMesMax = CDec(lblMesPrecio25.Text)
            End If
        End If
        If lblMesPrecio26.Text <> "0" Then
            If PrecioMesMin > CDec(lblMesPrecio26.Text) Then
                PrecioMesMin = CDec(lblMesPrecio26.Text)
            ElseIf PrecioMesMax < CDec(lblMesPrecio26.Text) Then
                PrecioMesMax = CDec(lblMesPrecio26.Text)
            End If
        End If
        If lblMesPrecio27.Text <> "0" Then
            If PrecioMesMin > CDec(lblMesPrecio27.Text) Then
                PrecioMesMin = CDec(lblMesPrecio27.Text)
            ElseIf PrecioMesMax < CDec(lblMesPrecio27.Text) Then
                PrecioMesMax = CDec(lblMesPrecio27.Text)
            End If
        End If
        If lblMesPrecio28.Text <> "0" Then
            If PrecioMesMin > CDec(lblMesPrecio28.Text) Then
                PrecioMesMin = CDec(lblMesPrecio28.Text)
            ElseIf PrecioMesMax < CDec(lblMesPrecio28.Text) Then
                PrecioMesMax = CDec(lblMesPrecio28.Text)
            End If
        End If
        If lblMesPrecio29.Text <> "0" Then
            If PrecioMesMin > CDec(lblMesPrecio29.Text) Then
                PrecioMesMin = CDec(lblMesPrecio29.Text)
            ElseIf PrecioMesMax < CDec(lblMesPrecio29.Text) Then
                PrecioMesMax = CDec(lblMesPrecio29.Text)
            End If
        End If
        If lblMesPrecio30.Text <> "0" Then
            If PrecioMesMin > CDec(lblMesPrecio30.Text) Then
                PrecioMesMin = CDec(lblMesPrecio30.Text)
            ElseIf PrecioMesMax < CDec(lblMesPrecio30.Text) Then
                PrecioMesMax = CDec(lblMesPrecio30.Text)
            End If
        End If
        If lblMesPrecio31.Text <> "0" Then
            If PrecioMesMin > CDec(lblMesPrecio31.Text) Then
                PrecioMesMin = CDec(lblMesPrecio31.Text)
            ElseIf PrecioMesMax < CDec(lblMesPrecio31.Text) Then
                PrecioMesMax = CDec(lblMesPrecio31.Text)
            End If
        End If
        lblPrecioMes.Text = (PrecioMesMax + PrecioMesMin) / 2
        TotalHoras += CDec(lblHoraDiferencia00.Text)
        TotalHoras += CDec(lblHoraDiferencia01.Text)
        TotalHoras += CDec(lblHoraDiferencia02.Text)
        TotalHoras += CDec(lblHoraDiferencia03.Text)
        TotalHoras += CDec(lblHoraDiferencia04.Text)
        TotalHoras += CDec(lblHoraDiferencia05.Text)
        TotalHoras += CDec(lblHoraDiferencia06.Text)
        TotalHoras += CDec(lblHoraDiferencia07.Text)
        TotalHoras += CDec(lblHoraDiferencia08.Text)
        TotalHoras += CDec(lblHoraDiferencia09.Text)
        TotalHoras += CDec(lblHoraDiferencia10.Text)
        TotalHoras += CDec(lblHoraDiferencia11.Text)
        TotalHoras += CDec(lblHoraDiferencia12.Text)
        TotalHoras += CDec(lblHoraDiferencia13.Text)
        TotalHoras += CDec(lblHoraDiferencia14.Text)
        TotalHoras += CDec(lblHoraDiferencia15.Text)
        TotalHoras += CDec(lblHoraDiferencia16.Text)
        TotalHoras += CDec(lblHoraDiferencia17.Text)
        TotalHoras += CDec(lblHoraDiferencia18.Text)
        TotalHoras += CDec(lblHoraDiferencia19.Text)
        TotalHoras += CDec(lblHoraDiferencia20.Text)
        TotalHoras += CDec(lblHoraDiferencia21.Text)
        TotalHoras += CDec(lblHoraDiferencia22.Text)
        TotalHoras += CDec(lblHoraDiferencia23.Text)
        lblTotalHora.Text = FormatDuco(TotalHoras, 4) & "¬"
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
        lblTotalMes.Text = FormatDuco(lblTotalMes.Text, 7) & "¬"
    End Sub
    Function FormatDuco(ByVal Ducos As Decimal, ByVal Digitos As Integer) As String
        Select Case Digitos
            Case 3
                If Ducos < 10 Then
                    FormatDuco = Format(Ducos, "0.00")
                ElseIf Ducos < 100 And Ducos >= 10 Then
                    FormatDuco = Format(Ducos, "00.0")
                ElseIf Ducos < 1000 And Ducos >= 100 Then
                    FormatDuco = Format(Ducos, "000")
                ElseIf Ducos < 10000 And Ducos >= 1000 Then
                    FormatDuco = Format(Ducos, "000")
                End If
            Case 4
                If Ducos < 100 Then
                    FormatDuco = Format(Ducos, "00.00")
                ElseIf Ducos < 1000 And Ducos >= 100 Then
                    FormatDuco = Format(Ducos, "000.0")
                ElseIf Ducos < 10000 And Ducos >= 1000 Then
                    FormatDuco = Format(Ducos, "0000")
                End If
            Case 5
                If Ducos < 10 Then
                    FormatDuco = Format(Ducos, "0.0000")
                ElseIf Ducos < 100 And Ducos >= 10 Then
                    FormatDuco = Format(Ducos, "00.000")
                ElseIf Ducos < 1000 And Ducos >= 100 Then
                    FormatDuco = Format(Ducos, "000.00")
                ElseIf Ducos < 10000 And Ducos >= 1000 Then
                    FormatDuco = Format(Ducos, "0000.0")
                End If
            Case 6
                If Ducos < 10 Then
                    FormatDuco = Format(Ducos, "0.00000")
                ElseIf Ducos < 100 And Ducos >= 10 Then
                    FormatDuco = Format(Ducos, "00.0000")
                ElseIf Ducos < 1000 And Ducos >= 100 Then
                    FormatDuco = Format(Ducos, "000.000")
                ElseIf Ducos < 10000 And Ducos >= 1000 Then
                    FormatDuco = Format(Ducos, "0000.00")
                End If
            Case 7
                If Ducos < 1000 Then
                    FormatDuco = Format(Ducos, "0000.00")
                ElseIf Ducos < 10000 And Ducos >= 1000 Then
                    FormatDuco = Format(Ducos, "00000.00")
                End If
            Case 8
                If Ducos < 10 Then
                    FormatDuco = Format(Ducos, "0.0000000")
                ElseIf Ducos < 100 And Ducos >= 10 Then
                    FormatDuco = Format(Ducos, "00.000000")
                ElseIf Ducos < 1000 And Ducos >= 100 Then
                    FormatDuco = Format(Ducos, "000.00000")
                ElseIf Ducos < 10000 And Ducos >= 1000 Then
                    FormatDuco = Format(Ducos, "0000.0000")
                End If
            Case 9
                If Ducos < 100 Then
                    FormatDuco = Format(Ducos, "00.0000000")

                ElseIf Ducos < 1000 And Ducos >= 100 Then
                    FormatDuco = Format(Ducos, "000.000000")
                ElseIf Ducos < 10000 And Ducos >= 1000 Then
                    FormatDuco = Format(Ducos, "0000.00000")
                End If
            Case 10
                If Ducos < 10 Then
                    FormatDuco = Format(Ducos, "0.000000000")
                ElseIf Ducos < 100 And Ducos >= 10 Then
                    FormatDuco = Format(Ducos, "00.00000000")
                ElseIf Ducos < 1000 And Ducos >= 100 Then
                    FormatDuco = Format(Ducos, "000.0000000")
                ElseIf Ducos < 10000 And Ducos >= 1000 Then
                    FormatDuco = Format(Ducos, "0000.000000")
                End If
            Case 11
                If Ducos < 10 Then
                    FormatDuco = Format(Ducos, "0.0000000000")
                ElseIf Ducos < 100 And Ducos >= 10 Then
                    FormatDuco = Format(Ducos, "00.000000000")
                ElseIf Ducos < 1000 And Ducos >= 100 Then
                    FormatDuco = Format(Ducos, "000.00000000")
                ElseIf Ducos < 10000 And Ducos >= 1000 Then
                    FormatDuco = Format(Ducos, "0000.0000000")
                End If
            Case 12
                If Ducos < 10 Then
                    FormatDuco = Format(Ducos, "0.00000000000")
                ElseIf Ducos < 100 And Ducos >= 10 Then
                    FormatDuco = Format(Ducos, "00.0000000000")
                ElseIf Ducos < 1000 And Ducos >= 100 Then
                    FormatDuco = Format(Ducos, "000.000000000")
                ElseIf Ducos < 10000 And Ducos >= 1000 Then
                    FormatDuco = Format(Ducos, "0000.00000000")
                End If
            Case 13
                If Ducos < 100 Then
                    FormatDuco = Format(Ducos, "00.00000000000")

                ElseIf Ducos < 1000 And Ducos >= 100 Then
                    FormatDuco = Format(Ducos, "000.0000000000")
                ElseIf Ducos < 10000 And Ducos >= 1000 Then
                    FormatDuco = Format(Ducos, "0000.000000000")
                End If
            Case 14
                If Ducos < 100 Then
                    FormatDuco = Format(Ducos, "00.000000000000")

                ElseIf Ducos < 1000 And Ducos >= 100 Then
                    FormatDuco = Format(Ducos, "000.00000000000")
                ElseIf Ducos < 10000 And Ducos >= 1000 Then
                    FormatDuco = Format(Ducos, "0000.0000000000")
                End If
            Case 15
                If Ducos < 10 Then
                    FormatDuco = Format(Ducos, "0.00000000000000")
                ElseIf Ducos < 100 And Ducos >= 10 Then
                    FormatDuco = Format(Ducos, "00.0000000000000")
                ElseIf Ducos < 1000 And Ducos >= 100 Then
                    FormatDuco = Format(Ducos, "000.000000000000")
                ElseIf Ducos < 10000 And Ducos >= 1000 Then
                    FormatDuco = Format(Ducos, "0000.00000000000")
                End If
            Case 16
                If Ducos < 10 Then
                    FormatDuco = Format(Ducos, "0.000000000000000")
                ElseIf Ducos < 100 And Ducos >= 10 Then
                    FormatDuco = Format(Ducos, "00.00000000000000")
                ElseIf Ducos < 1000 And Ducos >= 100 Then
                    FormatDuco = Format(Ducos, "000.0000000000000")
                ElseIf Ducos < 10000 And Ducos >= 1000 Then
                    FormatDuco = Format(Ducos, "0000.000000000000")
                End If
            Case 17
                If Ducos < 10 Then
                    FormatDuco = Format(Ducos, "0.0000000000000000")
                ElseIf Ducos < 100 And Ducos >= 10 Then
                    FormatDuco = Format(Ducos, "00.000000000000000")
                ElseIf Ducos < 1000 And Ducos >= 100 Then
                    FormatDuco = Format(Ducos, "000.00000000000000")
                ElseIf Ducos < 10000 And Ducos >= 1000 Then
                    FormatDuco = Format(Ducos, "0000.0000000000000")
                End If
            Case 18
                If Ducos < 10 Then
                    FormatDuco = Format(Ducos, "0.00000000000000000")
                ElseIf Ducos < 100 And Ducos >= 10 Then
                    FormatDuco = Format(Ducos, "00.0000000000000000")
                ElseIf Ducos < 1000 And Ducos >= 100 Then
                    FormatDuco = Format(Ducos, "000.000000000000000")
                ElseIf Ducos < 10000 And Ducos >= 1000 Then
                    FormatDuco = Format(Ducos, "0000.00000000000000")
                End If
            Case 19
                If Ducos < 10 Then
                    FormatDuco = Format(Ducos, "0.000000000000000000")
                ElseIf Ducos < 100 And Ducos >= 10 Then
                    FormatDuco = Format(Ducos, "00.00000000000000000")
                ElseIf Ducos < 1000 And Ducos >= 100 Then
                    FormatDuco = Format(Ducos, "000.0000000000000000")
                ElseIf Ducos < 10000 And Ducos >= 1000 Then
                    FormatDuco = Format(Ducos, "0000.000000000000000")
                End If
            Case Else
                FormatDuco = Ducos
        End Select
#Disable Warning BC42105 ' La función no devuelve un valor en todas las rutas de código
    End Function
#Enable Warning BC42105 ' La función no devuelve un valor en todas las rutas de código
    Function CalcularHases(Hases As Integer) As String
        If Hases >= 10000 And Hases < 100000 Then
            CalcularHases = Format(Hases / 1000, "0.00") & " Kh/s"
        ElseIf Hases >= 100000 Then
            CalcularHases = Format(Hases / 1000000, "0.00") & " MH/s"
        Else
            CalcularHases = Hases & " H/s"
        End If
    End Function
    Function CalcularHases1(Hases As Integer) As String
        If Hases >= 100000 And Hases < 1000000 Then
            CalcularHases1 = Format(Hases / 1000, "0.00") : lblHaseEstiquta.Text = "Kh/s"
        ElseIf Hases >= 1000000 Then
            CalcularHases1 = Format(Hases / 1000000, "0.00") : lblHaseEstiquta.Text = "MH/s"
        Else
            CalcularHases1 = Hases : lblHaseEstiquta.Text = "H/s"
        End If
    End Function
    Private Sub ResetDia()
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
    End Sub
    Private Sub Añadir()
        Try
            Select Case Hour(Now)
                Case 0
                    ResetDia()
                    lblReinicioApp.Text = -1
                    If lblBalanceHora00.Text = "0" Then lblBalanceHora00.Text = FormatDuco(CDec(DucosNuevoDia), 16) : lblPrecio00.Text = CDec(txtDucoprice.Text) : DucosNuevoDia = 0
                    lblHoraDiferencia00.Text = FormatDuco(CDec(lblBalanceHora00.Text) - CDec(txtbalance.Text), 8)
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
                            If lblMesBalance01.Text = "0" Then lblMesBalance01.Text = FormatDuco(txtbalance.Text, 14) : lblMesPrecio01.Text = CDec(lblPrecioDia.Text)
                        Case 2 : If lblMesBalance02.Text = "0" Then lblMesBalance02.Text = FormatDuco(txtbalance.Text, 14) : lblMesPrecio02.Text = CDec(lblPrecioDia.Text) : DucosNuevoDia = CDec(txtbalance.Text)
                        Case 3 : If lblMesBalance03.Text = "0" Then lblMesBalance03.Text = FormatDuco(txtbalance.Text, 14) : lblMesPrecio03.Text = CDec(lblPrecioDia.Text) : DucosNuevoDia = CDec(txtbalance.Text)
                        Case 4 : If lblMesBalance04.Text = "0" Then lblMesBalance04.Text = FormatDuco(txtbalance.Text, 14) : lblMesPrecio04.Text = CDec(lblPrecioDia.Text) : DucosNuevoDia = CDec(txtbalance.Text)
                        Case 5 : If lblMesBalance05.Text = "0" Then lblMesBalance05.Text = FormatDuco(txtbalance.Text, 14) : lblMesPrecio05.Text = CDec(lblPrecioDia.Text) : DucosNuevoDia = CDec(txtbalance.Text)
                        Case 6 : If lblMesBalance06.Text = "0" Then lblMesBalance06.Text = FormatDuco(txtbalance.Text, 14) : lblMesPrecio06.Text = CDec(lblPrecioDia.Text) : DucosNuevoDia = CDec(txtbalance.Text)
                        Case 7 : If lblMesBalance07.Text = "0" Then lblMesBalance07.Text = FormatDuco(txtbalance.Text, 14) : lblMesPrecio07.Text = CDec(lblPrecioDia.Text) : DucosNuevoDia = CDec(txtbalance.Text)
                        Case 8 : If lblMesBalance08.Text = "0" Then lblMesBalance08.Text = FormatDuco(txtbalance.Text, 14) : lblMesPrecio08.Text = CDec(lblPrecioDia.Text) : DucosNuevoDia = CDec(txtbalance.Text)
                        Case 9 : If lblMesBalance09.Text = "0" Then lblMesBalance09.Text = FormatDuco(txtbalance.Text, 14) : lblMesPrecio09.Text = CDec(lblPrecioDia.Text) : DucosNuevoDia = CDec(txtbalance.Text)
                        Case 10 : If lblMesBalance10.Text = "0" Then lblMesBalance10.Text = FormatDuco(txtbalance.Text, 14) : lblMesPrecio10.Text = CDec(lblPrecioDia.Text) : DucosNuevoDia = CDec(txtbalance.Text)
                        Case 11 : If lblMesBalance11.Text = "0" Then lblMesBalance11.Text = FormatDuco(txtbalance.Text, 14) : lblMesPrecio11.Text = CDec(lblPrecioDia.Text) : DucosNuevoDia = CDec(txtbalance.Text)
                        Case 12 : If lblMesBalance12.Text = "0" Then lblMesBalance12.Text = FormatDuco(txtbalance.Text, 14) : lblMesPrecio12.Text = CDec(lblPrecioDia.Text) : DucosNuevoDia = CDec(txtbalance.Text)
                        Case 13 : If lblMesBalance13.Text = "0" Then lblMesBalance13.Text = FormatDuco(txtbalance.Text, 14) : lblMesPrecio13.Text = CDec(lblPrecioDia.Text) : DucosNuevoDia = CDec(txtbalance.Text)
                        Case 14 : If lblMesBalance14.Text = "0" Then lblMesBalance14.Text = FormatDuco(txtbalance.Text, 14) : lblMesPrecio14.Text = CDec(lblPrecioDia.Text) : DucosNuevoDia = CDec(txtbalance.Text)
                        Case 15 : If lblMesBalance15.Text = "0" Then lblMesBalance15.Text = FormatDuco(txtbalance.Text, 14) : lblMesPrecio15.Text = CDec(lblPrecioDia.Text) : DucosNuevoDia = CDec(txtbalance.Text)
                        Case 16 : If lblMesBalance16.Text = "0" Then lblMesBalance16.Text = FormatDuco(txtbalance.Text, 14) : lblMesPrecio16.Text = CDec(lblPrecioDia.Text) : DucosNuevoDia = CDec(txtbalance.Text)
                        Case 17 : If lblMesBalance17.Text = "0" Then lblMesBalance17.Text = FormatDuco(txtbalance.Text, 14) : lblMesPrecio17.Text = CDec(lblPrecioDia.Text) : DucosNuevoDia = CDec(txtbalance.Text)
                        Case 18 : If lblMesBalance18.Text = "0" Then lblMesBalance18.Text = FormatDuco(txtbalance.Text, 14) : lblMesPrecio18.Text = CDec(lblPrecioDia.Text) : DucosNuevoDia = CDec(txtbalance.Text)
                        Case 19 : If lblMesBalance19.Text = "0" Then lblMesBalance19.Text = FormatDuco(txtbalance.Text, 14) : lblMesPrecio19.Text = CDec(lblPrecioDia.Text) : DucosNuevoDia = CDec(txtbalance.Text)
                        Case 20 : If lblMesBalance20.Text = "0" Then lblMesBalance20.Text = FormatDuco(txtbalance.Text, 14) : lblMesPrecio20.Text = CDec(lblPrecioDia.Text) : DucosNuevoDia = CDec(txtbalance.Text)
                        Case 21 : If lblMesBalance21.Text = "0" Then lblMesBalance21.Text = FormatDuco(txtbalance.Text, 14) : lblMesPrecio21.Text = CDec(lblPrecioDia.Text) : DucosNuevoDia = CDec(txtbalance.Text)
                        Case 22 : If lblMesBalance22.Text = "0" Then lblMesBalance22.Text = FormatDuco(txtbalance.Text, 14) : lblMesPrecio22.Text = CDec(lblPrecioDia.Text) : DucosNuevoDia = CDec(txtbalance.Text)
                        Case 23 : If lblMesBalance23.Text = "0" Then lblMesBalance23.Text = FormatDuco(txtbalance.Text, 14) : lblMesPrecio23.Text = CDec(lblPrecioDia.Text) : DucosNuevoDia = CDec(txtbalance.Text)
                        Case 24 : If lblMesBalance24.Text = "0" Then lblMesBalance24.Text = FormatDuco(txtbalance.Text, 14) : lblMesPrecio24.Text = CDec(lblPrecioDia.Text) : DucosNuevoDia = CDec(txtbalance.Text)
                        Case 25 : If lblMesBalance25.Text = "0" Then lblMesBalance25.Text = FormatDuco(txtbalance.Text, 14) : lblMesPrecio25.Text = CDec(lblPrecioDia.Text) : DucosNuevoDia = CDec(txtbalance.Text)
                        Case 26 : If lblMesBalance26.Text = "0" Then lblMesBalance26.Text = FormatDuco(txtbalance.Text, 14) : lblMesPrecio26.Text = CDec(lblPrecioDia.Text) : DucosNuevoDia = CDec(txtbalance.Text)
                        Case 27 : If lblMesBalance27.Text = "0" Then lblMesBalance27.Text = FormatDuco(txtbalance.Text, 14) : lblMesPrecio27.Text = CDec(lblPrecioDia.Text) : DucosNuevoDia = CDec(txtbalance.Text)
                        Case 28 : If lblMesBalance28.Text = "0" Then lblMesBalance28.Text = FormatDuco(txtbalance.Text, 14) : lblMesPrecio28.Text = CDec(lblPrecioDia.Text) : DucosNuevoDia = CDec(txtbalance.Text)
                        Case 29 : If lblMesBalance29.Text = "0" Then lblMesBalance29.Text = FormatDuco(txtbalance.Text, 14) : lblMesPrecio29.Text = CDec(lblPrecioDia.Text) : DucosNuevoDia = CDec(txtbalance.Text)
                        Case 30 : If lblMesBalance30.Text = "0" Then lblMesBalance30.Text = FormatDuco(txtbalance.Text, 14) : lblMesPrecio30.Text = CDec(lblPrecioDia.Text) : DucosNuevoDia = CDec(txtbalance.Text)
                        Case 31 : If lblMesBalance31.Text = "0" Then lblMesBalance31.Text = FormatDuco(txtbalance.Text, 14) : lblMesPrecio31.Text = CDec(lblPrecioDia.Text) : DucosNuevoDia = CDec(txtbalance.Text)

                    End Select
                Case 1 : If lblBalanceHora01.Text = 0 Then lblBalanceHora01.Text = FormatDuco(txtbalance.Text, 16) : lblPrecio01.Text = CDec(txtDucoprice.Text)
                Case 2 : If lblBalanceHora02.Text = 0 Then lblBalanceHora02.Text = FormatDuco(txtbalance.Text, 16) : lblPrecio02.Text = CDec(txtDucoprice.Text)
                Case 3 : If lblBalanceHora03.Text = 0 Then lblBalanceHora03.Text = FormatDuco(txtbalance.Text, 16) : lblPrecio03.Text = CDec(txtDucoprice.Text)
                Case 4 : If lblBalanceHora04.Text = 0 Then lblBalanceHora04.Text = FormatDuco(txtbalance.Text, 16) : lblPrecio04.Text = CDec(txtDucoprice.Text)
                Case 5 : If lblBalanceHora05.Text = 0 Then lblBalanceHora05.Text = FormatDuco(txtbalance.Text, 16) : lblPrecio05.Text = CDec(txtDucoprice.Text)
                Case 6 : If lblBalanceHora06.Text = 0 Then lblBalanceHora06.Text = FormatDuco(txtbalance.Text, 16) : lblPrecio06.Text = CDec(txtDucoprice.Text)
                Case 7 : If lblBalanceHora07.Text = 0 Then lblBalanceHora07.Text = FormatDuco(txtbalance.Text, 16) : lblPrecio07.Text = CDec(txtDucoprice.Text)
                Case 8 : If lblBalanceHora08.Text = 0 Then lblBalanceHora08.Text = FormatDuco(txtbalance.Text, 16) : lblPrecio08.Text = CDec(txtDucoprice.Text)
                Case 9 : If lblBalanceHora09.Text = 0 Then lblBalanceHora09.Text = FormatDuco(txtbalance.Text, 16) : lblPrecio09.Text = CDec(txtDucoprice.Text)
                Case 10 : If lblBalanceHora10.Text = 0 Then lblBalanceHora10.Text = FormatDuco(txtbalance.Text, 16) : lblPrecio10.Text = CDec(txtDucoprice.Text)
                Case 11 : If lblBalanceHora11.Text = 0 Then lblBalanceHora11.Text = FormatDuco(txtbalance.Text, 16) : lblPrecio11.Text = CDec(txtDucoprice.Text)
                Case 12 : If lblBalanceHora12.Text = 0 Then lblBalanceHora12.Text = FormatDuco(txtbalance.Text, 16) : lblPrecio12.Text = CDec(txtDucoprice.Text)
                Case 13 : If lblBalanceHora13.Text = 0 Then lblBalanceHora13.Text = FormatDuco(txtbalance.Text, 16) : lblPrecio13.Text = CDec(txtDucoprice.Text)
                Case 14 : If lblBalanceHora14.Text = 0 Then lblBalanceHora14.Text = FormatDuco(txtbalance.Text, 16) : lblPrecio14.Text = CDec(txtDucoprice.Text)
                Case 15 : If lblBalanceHora15.Text = 0 Then lblBalanceHora15.Text = FormatDuco(txtbalance.Text, 16) : lblPrecio15.Text = CDec(txtDucoprice.Text)
                Case 16 : If lblBalanceHora16.Text = 0 Then lblBalanceHora16.Text = FormatDuco(txtbalance.Text, 16) : lblPrecio16.Text = CDec(txtDucoprice.Text)
                Case 17 : If lblBalanceHora17.Text = 0 Then lblBalanceHora17.Text = FormatDuco(txtbalance.Text, 16) : lblPrecio17.Text = CDec(txtDucoprice.Text)
                Case 18 : If lblBalanceHora18.Text = 0 Then lblBalanceHora18.Text = FormatDuco(txtbalance.Text, 16) : lblPrecio18.Text = CDec(txtDucoprice.Text)
                Case 19 : If lblBalanceHora19.Text = 0 Then lblBalanceHora19.Text = FormatDuco(txtbalance.Text, 16) : lblPrecio19.Text = CDec(txtDucoprice.Text)
                Case 20 : If lblBalanceHora20.Text = 0 Then lblBalanceHora20.Text = FormatDuco(txtbalance.Text, 16) : lblPrecio20.Text = CDec(txtDucoprice.Text)
                Case 21 : If lblBalanceHora21.Text = 0 Then lblBalanceHora21.Text = FormatDuco(txtbalance.Text, 16) : lblPrecio21.Text = CDec(txtDucoprice.Text)
                Case 22 : If lblBalanceHora22.Text = 0 Then lblBalanceHora22.Text = FormatDuco(txtbalance.Text, 16) : lblPrecio22.Text = CDec(txtDucoprice.Text)
                Case 23 : If lblBalanceHora23.Text = 0 Then lblBalanceHora23.Text = FormatDuco(txtbalance.Text, 16) : lblPrecio23.Text = CDec(txtDucoprice.Text)
            End Select
            BalanceHora()
            BalanceMes()
            MostrarTotales()
            Dim TmpTransacion As Decimal
            Dim tmpTransacionNumeros As Integer
            For I As Integer = 1 To 31
                TmpTransacion += Transacion(I)
                tmpTransacionNumeros += TransacionPorDia(I)
            Next
            TransacionAño(Month(Now)) = TmpTransacion
            TransacionPorAño(Month(Now)) = tmpTransacionNumeros
            lblTransacionMes.Text = Format(TransacionAño(Month(Now)), "#0.0#") & "(" & TransacionPorAño(Month(Now)) & ")"
            Select Case Month(Now)
                Case 1 : If lblBalanceAño01.Text = 0 Then lblBalanceAño01.Text = FormatDuco(txtbalance.Text, 9) : lblPrecioAño01.Text = CDec(lblPrecioMes.Text) : lblTransasionesAño01.Text = Format(TransacionAño(1), "#0.0#") & "(" & TransacionPorAño(1) & ")"
                Case 2 : If lblBalanceAño02.Text = 0 Then lblBalanceAño02.Text = FormatDuco(txtbalance.Text, 9) : lblPrecioAño02.Text = CDec(lblPrecioMes.Text) : lblTransasionesAño02.Text = Format(TransacionAño(2), "#0.0#") & "(" & TransacionPorAño(2) & ")"
                Case 3 : If lblBalanceAño03.Text = 0 Then lblBalanceAño03.Text = FormatDuco(txtbalance.Text, 9) : lblPrecioAño03.Text = CDec(lblPrecioMes.Text) : lblTransasionesAño03.Text = Format(TransacionAño(3), "#0.0#") & "(" & TransacionPorAño(3) & ")"
                Case 4 : If lblBalanceAño04.Text = 0 Then lblBalanceAño04.Text = FormatDuco(txtbalance.Text, 9) : lblPrecioAño04.Text = CDec(lblPrecioMes.Text) : lblTransasionesAño04.Text = Format(TransacionAño(4), "#0.0#") & "(" & TransacionPorAño(4) & ")"
                Case 5 : If lblBalanceAño05.Text = 0 Then lblBalanceAño05.Text = FormatDuco(txtbalance.Text, 9) : lblPrecioAño05.Text = CDec(lblPrecioMes.Text) : lblTransasionesAño05.Text = Format(TransacionAño(5), "#0.0#") & "(" & TransacionPorAño(5) & ")"
                Case 6 : If lblBalanceAño06.Text = 0 Then lblBalanceAño06.Text = FormatDuco(txtbalance.Text, 9) : lblPrecioAño06.Text = CDec(lblPrecioMes.Text) : lblTransasionesAño06.Text = Format(TransacionAño(6), "#0.0#") & "(" & TransacionPorAño(6) & ")"
                Case 7 : If lblBalanceAño07.Text = 0 Then lblBalanceAño07.Text = FormatDuco(txtbalance.Text, 9) : lblPrecioAño07.Text = CDec(lblPrecioMes.Text) : lblTransasionesAño07.Text = Format(TransacionAño(7), "#0.0#") & "(" & TransacionPorAño(7) & ")"
                Case 8 : If lblBalanceAño08.Text = 0 Then lblBalanceAño08.Text = FormatDuco(txtbalance.Text, 9) : lblPrecioAño08.Text = CDec(lblPrecioMes.Text) : lblTransasionesAño08.Text = Format(TransacionAño(8), "#0.0#") & "(" & TransacionPorAño(8) & ")"
                Case 9 : If lblBalanceAño09.Text = 0 Then lblBalanceAño09.Text = FormatDuco(txtbalance.Text, 9) : lblPrecioAño09.Text = CDec(lblPrecioMes.Text) : lblTransasionesAño09.Text = Format(TransacionAño(9), "#0.0#") & "(" & TransacionPorAño(9) & ")"
                Case 10 : If lblBalanceAño10.Text = 0 Then lblBalanceAño10.Text = FormatDuco(txtbalance.Text, 9) : lblPrecioAño10.Text = CDec(lblPrecioMes.Text) : lblTransasionesAño10.Text = Format(TransacionAño(10), "#0.0#") & "(" & TransacionPorAño(10) & ")"
                Case 11 : If lblBalanceAño11.Text = 0 Then lblBalanceAño11.Text = FormatDuco(txtbalance.Text, 9) : lblPrecioAño11.Text = CDec(lblPrecioMes.Text) : lblTransasionesAño11.Text = Format(TransacionAño(11), "#0.0#") & "(" & TransacionPorAño(11) & ")"
                Case 12 : If lblBalanceAño12.Text = 0 Then lblBalanceAño12.Text = FormatDuco(txtbalance.Text, 9) : lblPrecioAño12.Text = CDec(lblPrecioMes.Text) : lblTransasionesAño12.Text = Format(TransacionAño(12), "#0.0#") & "(" & TransacionPorAño(12) & ")"
            End Select
            lblTransasionesAño01.Text = TransasionesAnuales("01")
            lblTransasionesAño02.Text = TransasionesAnuales("02")
            lblTransasionesAño03.Text = TransasionesAnuales("03")
            lblTransasionesAño04.Text = TransasionesAnuales("04")
            lblTransasionesAño05.Text = TransasionesAnuales("05")
            lblTransasionesAño06.Text = TransasionesAnuales("06")
            lblTransasionesAño07.Text = TransasionesAnuales("07")
            lblTransasionesAño08.Text = TransasionesAnuales("08")
            lblTransasionesAño09.Text = TransasionesAnuales("09")
            lblTransasionesAño10.Text = TransasionesAnuales("10")
            lblTransasionesAño11.Text = TransasionesAnuales("11")
            lblTransasionesAño12.Text = TransasionesAnuales("12")
            Select Case Month(Now)
                Case 1 : If lblBalanceAño01.Text <> 0 Then lblGananciasAño01.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceAño01.Text) - CDec(lblTransasionesAño01.Text), 10)
                Case 2 : If lblBalanceAño02.Text <> 0 Then lblGananciasAño02.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceAño02.Text) - CDec(lblTransasionesAño02.Text), 10)
                Case 3 : If lblBalanceAño03.Text <> 0 Then lblGananciasAño03.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceAño03.Text) - CDec(lblTransasionesAño03.Text), 10)
                Case 4 : If lblBalanceAño04.Text <> 0 Then lblGananciasAño04.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceAño04.Text) - CDec(lblTransasionesAño04.Text), 10)
                Case 5 : If lblBalanceAño05.Text <> 0 Then lblGananciasAño05.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceAño05.Text) - CDec(lblTransasionesAño05.Text), 10)
                Case 6 : If lblBalanceAño06.Text <> 0 Then lblGananciasAño06.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceAño06.Text) - CDec(lblTransasionesAño06.Text), 10)
                Case 7 : If lblBalanceAño07.Text <> 0 Then lblGananciasAño07.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceAño07.Text) - CDec(lblTransasionesAño07.Text), 10)
                Case 8 : If lblBalanceAño08.Text <> 0 Then lblGananciasAño08.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceAño08.Text) - CDec(lblTransasionesAño08.Text), 10)
                Case 9 : If lblBalanceAño09.Text <> 0 Then lblGananciasAño09.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceAño09.Text) - CDec(lblTransasionesAño09.Text), 10)
                Case 10 : If lblBalanceAño10.Text <> 0 Then lblGananciasAño10.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceAño10.Text) - CDec(lblTransasionesAño10.Text), 10)
                Case 11 : If lblBalanceAño11.Text <> 0 Then lblGananciasAño11.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceAño11.Text) - CDec(lblTransasionesAño11.Text), 10)
                Case 12 : If lblBalanceAño12.Text <> 0 Then lblGananciasAño12.Text = FormatDuco(CDec(txtbalance.Text) - CDec(lblBalanceAño12.Text) - CDec(lblTransasionesAño12.Text), 10)
            End Select
            Dim Suma As Decimal
            Dim Suma2 As Decimal
            Suma = lblGananciasAño01.Text
            Suma += lblGananciasAño02.Text
            Suma += lblGananciasAño03.Text
            Suma += lblGananciasAño04.Text
            Suma += lblGananciasAño05.Text
            Suma += lblGananciasAño06.Text
            Suma += lblGananciasAño07.Text
            Suma += lblGananciasAño08.Text
            Suma += lblGananciasAño09.Text
            Suma += lblGananciasAño10.Text
            Suma += lblGananciasAño11.Text
            Suma += lblGananciasAño12.Text
            lblTotalGananciaAño.Text = FormatDuco(Suma, 6) & "¬"
            lblGanadoAño2022.Text = FormatDuco(Suma, 6)

            Suma = CDec(lblTransasionesAño01.Text)
            Suma += CDec(lblTransasionesAño02.Text)
            Suma += CDec(lblTransasionesAño03.Text)
            Suma += CDec(lblTransasionesAño04.Text)
            Suma += CDec(lblTransasionesAño05.Text)
            Suma += CDec(lblTransasionesAño06.Text)
            Suma += CDec(lblTransasionesAño07.Text)
            Suma += CDec(lblTransasionesAño08.Text)
            Suma += CDec(lblTransasionesAño09.Text)
            Suma += CDec(lblTransasionesAño10.Text)
            Suma += CDec(lblTransasionesAño11.Text)
            Suma += CDec(lblTransasionesAño12.Text)
            lblTransacionesTotalAño.Text = Suma
            lblTransasionesAño2022.Text = lblTransacionesTotalAño.Text
            Suma = CDec(lblGanadoAño2021.Text)
            Suma += CDec(lblGanadoAño2022.Text)
            Suma += CDec(lblGanadoAño2023.Text)
            lblGanadoAñoTotal.Text = FormatDuco(Suma, 6) & "¬"

            Suma2 = CDec(lblTransasionesAño2021.Text)
            Suma2 += CDec(lblTransasionesAño2022.Text)
            Suma2 += CDec(lblTransasionesAño2023.Text)
            lblTransasionesAñoTotal.Text = Suma2
            lblTotalTransasiones.Text = CInt(ContaTransa + 1)
            lblDucosTotales.Text = Format(CDec(txtbalance.Text - Suma2), "###0.00")
            lblTotalGanadoAños.Text = Format(CDec(txtbalance.Text - Suma2) * CDec(txtDucoprice.Text) * Euro, "###0.00")
            lblEtiquetaDuco.Left = lblDucosTotales.Left + lblDucosTotales.Width - 5
            lblEtiquetaEuro.Left = lblTotalGanadoAños.Left + lblTotalGanadoAños.Width '- 5
            My.Settings.Save()
        Catch ex As Exception
            'MsgBox("Error!!" & vbCrLf & ex.Message)
        End Try
    End Sub
    Function TransasionesAnuales(ByVal Mesis As String) As Decimal
        Dim TransAño(ContaTransa) As Decimal
        For I As Integer = ContaTransa To 0 Step -1
            EnviosDias(I) = Mid(Dict2Public.item("result").item("transactions").item(I).item("datetime"), 1, 2)
            EnviosMes(I) = Mid(Dict2Public.item("result").item("transactions").item(I).item("datetime"), 4, 2)
            EnviosAño(I) = Mid(Dict2Public.item("result").item("transactions").item(I).item("datetime"), 7, 4)
            If Dict2Public.item("result").item("transactions").item(I).item("sender") = "Lanthi" Then
                If EnviosMes(I) = Mesis Then
                    TransAño(I) = -CDec(Dict2Public.item("result").item("transactions").item(I).item("amount"))
                End If
            Else
                If EnviosMes(I) = Mesis Then
                    TransAño(I) = CDec(Dict2Public.item("result").item("transactions").item(I).item("amount"))
                End If
            End If
        Next
        Dim TRansacionTotalMes As Decimal
        For I As Integer = 0 To ContaTransa
            If TransAño(I) <> 0 Then TRansacionTotalMes += TransAño(I) ': ListBox1.Items.Add(TransAño(I))
        Next I
        If TRansacionTotalMes <> 0 Then
            TransasionesAnuales = Format(TRansacionTotalMes, "#0.00")
        Else
            Return Nothing
        End If
    End Function
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Hora = DateAndTime.Hour(Now)
            Minutos = DateAndTime.Minute(Now)
            Segundos = DateAndTime.Second(Now)
            Dim HoraString As String
            Dim MinutosString As String
            Dim SegundosString As String
            If Hora <= 9 Then
                HoraString = "0" & Hora
            Else
                HoraString = Hora
            End If
            If Minutos <= 9 Then
                MinutosString = "0" & Minutos
            Else
                MinutosString = Minutos
            End If
            If Segundos <= 9 Then
                SegundosString = "0" & Segundos
            Else
                SegundosString = Segundos
            End If
            lblHora.Text = HoraString & ":" & MinutosString & ":" & SegundosString
            Select Case Segundos
                Case 0 : Actualizar()
                Case 30 : Actualizar()
            End Select
            Select Case Minutos
                Case 0, "00" : If LogAñadido = False Then Log()
                Case Else
                    LogAñadido = False
            End Select
            If Minutos = 0 Then Añadir()
            If Hora = 23 And Minutos = 59 And Segundos = 59 Then GuardarLog()
            If CInt(Temperatura) >= CInt(txtGradosFan.Value) Then
                picFan.Visible = False
                picFanAni.Visible = True
            Else
                picFan.Visible = True
                picFanAni.Visible = False
            End If
            If Temperatura >= CInt(txtGradosFan.Value) Then
                lblTemperatura.ForeColor = Color.Red
            ElseIf Temperatura < CInt(txtGradosFan.Value) And Temperatura >= CInt(txtFanAmarillo.Value) Then
                lblTemperatura.ForeColor = Color.DarkKhaki
            ElseIf Temperatura < CInt(txtFanAmarillo.Value) And Temperatura >= CInt(txtFanVerde.Value) Then
                lblTemperatura.ForeColor = Color.Green
            Else
                lblTemperatura.ForeColor = Color.Green
            End If

        Catch ex As Exception
            ' MsgBox("Error!!" & vbCrLf & ex.Message)
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        ResetDia()
    End Sub
    Private Sub GuardarLog()
        Dim Intru As Object
        Dim Archivo As Object
        Dim RutaArchivo As String = RutaApp & "\Logs\Log " & DateAndTime.Day(FechaLog) & "-" & DateAndTime.Month(FechaLog) & "-" & DateAndTime.Year(FechaLog) & ".log"
        My.Computer.FileSystem.CreateDirectory(RutaApp & "\Logs")
        Intru = CreateObject("Scripting.FileSystemObject")
        If File.Exists(RutaArchivo) Then
            Archivo = Intru.CreateTextFile(RutaApp & "\Logs\Log " & DateAndTime.Day(FechaLog) & "-" & DateAndTime.Month(FechaLog) & "-" & DateAndTime.Year(FechaLog) & "(" & lblReinicioApp.Text & ").log", True)
        Else
            Archivo = Intru.CreateTextFile(RutaApp & "\Logs\Log " & DateAndTime.Day(FechaLog) & "-" & DateAndTime.Month(FechaLog) & "-" & DateAndTime.Year(FechaLog) & ".log", True)
        End If
        Archivo.WriteLine(txtLog.Text)
        Archivo.Close()
        ' Process.Start("explorer.exe", RutaApp)
        LogReinicio()
    End Sub
    Private Sub Log()
        'log
        LogAñadido = True
        txtLogMineros.Text += vbCrLf & DateAndTime.DateValue(Now) & " " & Format(DateAndTime.TimeValue(Now), "HH:mm") & vbCrLf
        If txtMinerosNArduino.Text > 0 Then txtLogMineros.Text += vbCrLf & "ARDUINOS Nº: " & txtMinerosNArduino.Text & " - Hases: " & txtMinerosHArduino.Text
        If txtMinerosNCPU.Text > 0 Then txtLogMineros.Text += vbCrLf & "CPU Nº: " & txtMinerosNCPU.Text & " - Hases: " & txtMinerosHCPU.Text
        If txtMinerosNEsp8266.Text > 0 Then txtLogMineros.Text += vbCrLf & "ESP8266 Nº: " & txtMinerosNEsp8266.Text & " - Hases: " & txtMinerosHEsp8266.Text
        If txtMinerosNEsp32.Text > 0 Then txtLogMineros.Text += vbCrLf & "ESP32 Nº: " & txtMinerosNEsp32.Text & " - Hases: " & txtMinerosHEsp32.Text
        If txtMinerosNotros.Text > 0 Then txtLogMineros.Text += vbCrLf & "OTHER Nº: " & txtMinerosNotros.Text & " - Hases: " & txtMinerosHotros.Text
        If txtMinerosNPhone.Text > 0 Then txtLogMineros.Text += vbCrLf & "PHONE Nº: " & txtMinerosNPhone.Text & " - Hases: " & txtMinerosHPhone.Text
        If txtMinerosNRPI.Text > 0 Then txtLogMineros.Text += vbCrLf & "RPI Nº: " & txtMinerosNRPI.Text & " - Hases: " & txtMinerosHRPI.Text
        If txtMinerosNWeb.Text > 0 Then txtLogMineros.Text += vbCrLf & "WEB Nº: " & txtMinerosNWeb.Text & " - Hases: " & txtMinerosHWeb.Text
        txtLogMineros.Text += vbCrLf & vbCrLf & "TOTAL Nº: " & lblMineros.Text & " - Hases: " & lblHases.Text & lblHaseEstiquta.Text
        txtLogBalanceYprecio.Text += vbCrLf & DateAndTime.DateValue(Now) & " " & Format(DateAndTime.TimeValue(Now), "HH:mm") & " = Ducos: " & txtbalance.Text & " * Price: " & txtDucoprice.Text & " = " & lblGanado.Text & "€"
        txtLogMineros.Text += vbCrLf & "---------------------------------"
        txtLog.Text = txtLogBalanceYprecio.Text & vbCrLf & vbCrLf & txtLogMineros.Text & vbCrLf & vbCrLf & txtLogTransasiones.Text
        FechaLog = DateAndTime.DateValue(Now)
    End Sub
    Private Sub LogReinicio()
        txtLogBalanceYprecio.Text = "Balance and Price:" & vbCrLf & "==================" & vbCrLf
        txtLogMineros.Text = "Miners and Hanses:" & vbCrLf & "==================" & vbCrLf
        txtLogTransasiones.Text = "Transactions:" & vbCrLf & "==================" & vbCrLf
    End Sub
    Private Sub Form1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        GuardarLog()
        My.Settings.Save()
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        lblMesBalance15.Text = 574.27681404615259
        lblMesPrecio15.Text = lblPrecio00.Text
        ResetDia()
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            lblReinicioApp.Text += 1
            LogReinicio()
            lblHora.Text = DateAndTime.TimeValue(Now)
            For I As Integer = 0 To 30
                Transacion(I) = 0
                TransacionPorDia(I) = 0
            Next
            Timer1.Enabled = True
            If txtUser.Text = "" Then
                txtUser.Text = InputBox("Enter the Duino-Coin username", "Ducos Statistics - User")
                lblUser.Text = txtUser.Text
            End If
            Actualizar()
            Añadir()
            BalanceHora()
            BalanceMes()
            MostrarTotales()
            Dim TmpTransacion As Decimal
            Dim tmpTransacionNumeros As Integer
            For I As Integer = 1 To 31
                TmpTransacion += Transacion(I)
                tmpTransacionNumeros += TransacionPorDia(I)
            Next
            TransacionAño(Month(Now)) = TmpTransacion
            TransacionPorAño(Month(Now)) = tmpTransacionNumeros
            lblTransacionMes.Text = Format(TransacionAño(Month(Now)), "#0.0#") & "(" & TransacionPorAño(Month(Now)) & ")"
            MostrarMes()
            Log()
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
            Chart7.Series(0).Points.AddY(Temperatura)
            Chart7.Series(1).Points.AddY(Humedad)
        Catch ex As Exception
            ' MsgBox("Error!!" & vbCrLf & ex.Message)
        End Try
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        txtUser.Text = InputBox("Enter the Duino-Coin username", "Ducos Statistics - User", txtUser.Text)
        lblUser.Text = txtUser.Text
    End Sub

    Private Sub lblPrecioDia_Click(sender As Object, e As EventArgs) Handles lblPrecioDia.Click

    End Sub

    Private Sub TabPage4_Click(sender As Object, e As EventArgs) Handles TabPage4.Click

    End Sub
End Class