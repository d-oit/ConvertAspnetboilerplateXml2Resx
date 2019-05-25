using System.Diagnostics;
using System.Resources;
using System.Xml;

namespace AspnetboilerplateXml2Resx
{
    internal class Program
    {
        private const string _aspnetboilerblateXmlLocalizationFile = "erp.xml";
        private const string _outputResxFile = "Erp.resx";

        private static void Main(string[] args)
        {
            XmlTextReader reader = new XmlTextReader(_aspnetboilerblateXmlLocalizationFile);

            ResXResourceWriter writer = new ResXResourceWriter(_outputResxFile);

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "text")
                {
                    var name = reader.GetAttribute("name");

                    Debug.WriteLine(string.Format("{0} - value {1} - inner: {2}", name, reader.GetAttribute("value"), reader.Value));

                    writer.AddResource(name, reader.Value.Trim() != "" ? reader.Value : reader.GetAttribute("value"));
                }
            }

            writer.Generate();
            writer.Close();
        }
    }
}