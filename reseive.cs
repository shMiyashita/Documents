private void DoReceive(){
int localPort = 5678;
UdpClient client = new UdpClient(localPort);
 
// 送信元。任意のIPアドレス、任意のポートから許可
IPEndPoint remoteEP = IPEndPoint(IPAddress.Any, 0);
 
// 受信するまで待ち続ける
byte[] res = client.Receive(ref remoteEP);
 
// バイト配列から ASCII 文字列に変換して表示
System.Console.Write(
   "送信元:" + remoteEP + "\n" + // 実際に送信が行われた IPアドレス, ポートが格納されているので一緒に表示
   "受信内容:"+Encoding.ASCII.GetString(res)
  );
}
