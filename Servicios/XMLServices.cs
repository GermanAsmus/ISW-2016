using System.Xml;
using System.Windows.Forms;
using System;
using System.Threading.Tasks;

namespace Servicios
{
    /// <summary>
    /// Clase responsable del manejo, tratamiento y utilizacion de archivos XML
    /// </summary>
    public class XMLServices
    {
        /// <summary>
        /// Convierte un Nodo XML an un Nodo Árbol
        /// </summary>
        /// <param name="nodoXML">Nodo XML a convertir</param>
        /// <param name="nodoArbol">Nodo del árbol al que se convertirá</param>
        private static void ConvertNodoXMLANodoArbol(XmlNode nodoXML, TreeNodeCollection nodoArbol)
        {
            TreeNode nodoAInsertar = nodoArbol.Add(nodoXML.Name);
            switch (nodoXML.NodeType)
            {
                case XmlNodeType.Element:
                    nodoAInsertar.Text = nodoXML.Name;
                    nodoAInsertar.Tag = "Element";
                    nodoAInsertar.ImageIndex = 1;
                    break;
                case XmlNodeType.Attribute:
                    nodoAInsertar.Text = "@" + nodoXML.Name;
                    nodoAInsertar.Tag = "Attribute";
                    nodoAInsertar.ImageIndex = 2;
                    break;
                case XmlNodeType.Text:
                    nodoAInsertar.Text = nodoXML.Value;
                    nodoAInsertar.Tag = "Text";
                    nodoAInsertar.ImageIndex = 3;
                    break;
                case XmlNodeType.CDATA:
                    nodoAInsertar.Text = nodoXML.Value;
                    nodoAInsertar.Tag = "CDATA";
                    nodoAInsertar.ImageIndex = 4;
                    break;
                case XmlNodeType.Comment:
                    nodoAInsertar.Text = nodoXML.Value;
                    nodoAInsertar.Tag = "Comment";
                    nodoAInsertar.ImageIndex = 5;
                    break;
                case XmlNodeType.Entity:
                    nodoAInsertar.Text = nodoXML.Value;
                    nodoAInsertar.Tag = "Entity";
                    nodoAInsertar.ImageIndex = 6;
                    break;
                case XmlNodeType.Notation:
                    nodoAInsertar.Text = nodoXML.Value;
                    nodoAInsertar.Tag = "Notation";
                    nodoAInsertar.ImageIndex = 7;
                    break;
                default:
                    break;
            }
            if (nodoXML.Attributes != null && nodoXML.Attributes.Count > 0)
            {
                //Escribe los atributos al treeView
                foreach (XmlAttribute atributo in nodoXML.Attributes)
                {
                    ConvertNodoXMLANodoArbol(atributo, nodoAInsertar.Nodes);
                }
            }
            //Chekea el nodo actual por los nodos hijos
            if (nodoXML.HasChildNodes)
            {
                //Escribe el nodo hijo al treeView
                foreach (XmlNode nodoHijo in nodoXML.ChildNodes)
                {
                    ConvertNodoXMLANodoArbol(nodoHijo, nodoAInsertar.Nodes);
                }
            }
        }

        /// <summary>
        /// Convierte el XML suministrado a un Nodo Árbol
        /// </summary>
        /// <param name="archivoXML">Archivo XML como string</param>
        /// <param name="nodoArbol">Nodo Árbol al cual se traduce el XML</param>
        public static void XMLANodoArbol(string archivoXML, TreeView nodoArbol)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(archivoXML);
                ConvertNodoXMLANodoArbol(doc, nodoArbol.Nodes);
            }
            catch(XmlException ex)
            {
                throw new Excepciones.ExcepcionXML("Error al intentar cargar archivo no reconocido como XML", ex);
            }
        }

        /// <summary>
        /// Extraer el valor del atributo elegido del nodo dado
        /// </summary>
        /// <param name="prueba"></param>
        /// <returns></returns>
        private static string Extraer(string prueba)
        {
            int pos = prueba.IndexOf('"');
            string resultado = prueba.Remove(0, pos + 1);
            return resultado.Remove(resultado.Length - 1, 1);
        }

        /// <summary>
        /// Extrae el valor del atributo del nodo seleccionado
        /// </summary>
        /// <param name="pWebURL">Web URL de la cual se obtiene el XML</param>
        /// <param name="XPath">Full Path del Nodo Seleccionado del Árbol</param>
        /// <returns></returns>
        public static async Task<string> WebValorNodoXML(string pWebURL, string XPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(await WebServices.DescargarURLAsync(pWebURL));
            return Extraer(doc.SelectSingleNode(TratamientoValorXML(XPath)).OuterXml);
        }

        /// <summary>
        /// Extrae el valor del atributo del nodo seleccionado
        /// </summary>
        /// <param name="pRutaArchivo">Ruta de archivo del XML</param>
        /// <param name="XPath">Full Path del Nodo Seleccionado del Árbol</param>
        /// <returns></returns>
        public static async Task<string> DireccionLocalValorNodoXML(string pRutaArchivo, string XPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(await ArchivoServices.LeerArchivoAsync(pRutaArchivo));
            return Extraer(doc.SelectSingleNode(TratamientoValorXML(XPath)).OuterXml);
        }

        /// <summary>
        /// Transforma el XPath en uno válido para seleccionar el nodo
        /// </summary>
        /// <param name="XPath">Path del Nodo a tratar</param>
        /// <returns>Tipo de dato String que representa el XPath procesado</returns>
        private static string TratamientoValorXML(string XPath)
        {
            string tmp = XPath;
            tmp = tmp.Replace("#document", "");
            tmp = tmp.Replace(@"\", "/");
            int arrobaPos = tmp.LastIndexOf("@");
            int barraPos = tmp.LastIndexOf("/");
            if (barraPos > arrobaPos)
            {
                tmp = tmp.Remove(barraPos, tmp.Length - barraPos);
            }
            return tmp;
        }
    }
}
