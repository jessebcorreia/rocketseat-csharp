namespace FirstAPI.Entities;

public sealed class Laptop : Device
{
    public override string GetBrand()
    {
        return "Apple";
    }

    public string GetModel()
    {
        bool isConnected = IsConnected();
        if (isConnected)
            return "Macbook";

        return "Unknow";
    }
}
