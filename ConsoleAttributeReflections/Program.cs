using System;

namespace ConsoleAttributeReflections
{
    class Program
    {

        /*
            ATTRİBUTESLER VE REFLECTİONSLAR GENELDE BERABER KULLANILIRLAR.
            RUN TİME ESNASINDA CLASS ENUM METOD GİBİ YAPILARLA İLGİLİ BİLGİ VEREN  
            VE KONTROL ETMEMİZİ SAĞLAYAN YAPILARDIR.
                ------------------------------------------------------------
        AŞAĞIDAKİ ÖRNEĞİMİZDE TANIMLADIĞIMIZ PROPERTYLERİN HEPSİNE DEĞER GİRİLMESİNİ
        OLUŞTURDUĞUMUZ ATTRİBUTES SAYESİNDE ZORUNLU HALE GETİRDİK.
        CONTROL SINIFIMIZDAKİ CHECK METODUMUZLADA BU CONTROL İŞLEMLERİNİ YAPTIK.
        FOREACH VE İF LERLE DOLULUK DURUMUNA BAKIP BOOL BİR DEĞER DÖNDÜRDÜK.
         
         */

        static void Main(string[] args)
        {
            person p1 = new person()
            {
                name = "Cemal",
                Age = 27
            };

            Console.WriteLine(Control.Check(p1));
        }

        public class person
        {
            [Zorunlu]
            public string name;
            [Zorunlu]
            public string ID;
            [Zorunlu]
            public int Age;
        }

        public class ZorunluAttribute : Attribute
        {

        }

        public static class Control
        {
            public static bool Check(person ins)
            {
                Type type = ins.GetType();
                foreach (var item in type.GetFields())
                {
                    object[] attributes = item.GetCustomAttributes(typeof(ZorunluAttribute), true);
                    if (attributes.Length !=0)
                    {
                        object value = item.GetValue(ins);

                        if (value == value)
                        {
                            return false;
                        }
                    }

                }
                return true;
            }
        }

    }
}
