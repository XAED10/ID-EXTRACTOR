Imports System.Net, System.IO, System.Text.RegularExpressions, System.Console
Imports Microsoft.VisualBasic.CompilerServices
Module Module1
    Dim cookies As New CookieContainer
    Dim Account_ID, username, totalinfo As String
    Dim banner As String = "  _____ _____    ________   _________ _____           _____ _______ ____  _____
 |_   _|  __ \  |  ____\ \ / /__   __|  __ \    /\   / ____|__   __/ __ \|  __ \
   | | | |  | | | |__   \ V /   | |  | |__) |  /  \ | |       | | | |  | | |__) |
   | | | |  | | |  __|   > <    | |  |  _  /  / /\ \| |       | | | |  | |  _  /
  _| |_| |__| | | |____ / . \   | |  | | \ \ / ____ \ |____   | | | |__| | | \ \
 |_____|_____/  |______/_/ \_\  |_|  |_|  \_\_/    \_\_____|  |_|  \____/|_|  \_\

                                            "
    Sub Main()
        Title = "Account ID Extractor By @xaed"
        Console.ForegroundColor = ConsoleColor.Blue
        Write(banner)
        Console.ForegroundColor = ConsoleColor.Magenta
        Write("[?] => instagram.com/xaed")
        Console.ForegroundColor = ConsoleColor.Yellow
        Write(vbNewLine & "[+] Enter Username : ")
        username = ReadLine()
        Console.ForegroundColor = ConsoleColor.Green
        Write(vbNewLine & account_info() & vbNewLine)
        Console.ForegroundColor = ConsoleColor.DarkMagenta
        Write(vbNewLine & "[X] Press Enter To Exit ...")
        ReadLine()
        Environment.Exit(0)
    End Sub
    Function account_info()
        Try
            Dim web As HttpWebRequest = DirectCast(WebRequest.Create($"https://www.instagram.com/" & username & "/?__a=1"), HttpWebRequest)
            web.Method = "GET"
            web.Headers.Add("Accept-Language", "en-US,en;q=0.5")
            web.Headers.Add("X-IG-App-ID", "936619743392459")
            web.Headers.Add("X-Requested-With", "XMLHttpRequest")
            web.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.111 Safari/537.36"
            web.Accept = "*/*"
            web.CookieContainer = cookies
            Dim HttpWebResponse As HttpWebResponse = web.GetResponse
            Dim streamreader As New StreamReader(HttpWebResponse.GetResponseStream())
            Dim response As String = streamreader.ReadToEnd
            Account_ID = Regex.Match(response, """profilePage_(.*?)""").Groups(1).Value
        Catch ex As Exception
            MsgBox(ex.Message)
            ProjectData.EndApp()
        End Try
        totalinfo = "[+] Account ID For @" & username & " : " & Account_ID
        Return totalinfo
    End Function
End Module
