// See https://aka.ms/new-console-template for more information
public class DataSender : ITcp, INfc
{
    /// <summary>
    /// Jawna implementacja metody z interfejsu INfc
    /// </summary>
    /// <param name="data"></param>
    public void SendData(byte[] data)
    {
        Console.WriteLine($"Wysyłąm {data.Length} bajtow przez TCP ");
    }

    /// <summary>
    /// Niejawna implementacja metody z interfejsu ITcp
    /// (aby jej użyć musimy rzutować obiekt na ITcp np.za pomocą słowa "as"
    /// </summary>
    /// <param name="data"></param>
    void INfc.SendData(byte[] data)
    {
        Console.WriteLine($"Wysyłąm {data.Length} bajtow przez NFC ");
    }
}