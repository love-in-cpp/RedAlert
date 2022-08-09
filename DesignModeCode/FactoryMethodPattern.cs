using UnityEngine;
 /*
  * 使用工厂方法模式设计一个程序来读取各种不同类型的图片格式，
  * 针对每一种图片格式都设计一个图片读取器，如GIF图片读取器用于读取GIF格式的图片、
  * JPG图片读取器用于读取JPG格式的图片。需充分考虑系统的灵活性和可扩展性。
  */
public class FactoryMethodPattern : MonoBehaviour
{
    private void Start()
    {
        PicReaderFactory factory = new JPGReaderFacotory();
        // PicReader reader = factory.GetPicReader();
        // reader.Read();
        
        factory.Read();
    }
}

public abstract class PicReader
{
    public abstract void Read();
}

public class GIFReader : PicReader
{
    public override void Read()
    {
        Debug.Log("GIFReader is working");
    }
}

public class JPGReader : PicReader
{
    public override void Read()
    {
        Debug.Log("JPGReader is working");
    }
}

public abstract class PicReaderFactory
{
    public void Read()
    {
        PicReader reader = this.GetPicReader();
        reader.Read();
    }
    public abstract PicReader GetPicReader();
}

public class GIFReaderFactory:PicReaderFactory
{
    public override PicReader GetPicReader()
    {
        return new GIFReader();
    }
}

public class JPGReaderFacotory : PicReaderFactory
{
    public override PicReader GetPicReader()
    {
        return new JPGReader();
    }
}


    
