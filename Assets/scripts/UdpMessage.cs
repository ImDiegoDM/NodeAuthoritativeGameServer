using Newtonsoft.Json;

public enum UdpTypeMessage{
    CREATEGAME
}

public struct UdpMessage{
    public UdpTypeMessage typeMessage;
    public object data;

    public string ToJson(){
        return JsonConvert.SerializeObject(this);
    }
}