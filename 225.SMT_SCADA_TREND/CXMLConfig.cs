using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace FORM
{
    class CXMLConfig
    {
        private string path;

        public CXMLConfig(string filepath)
        {
            path = filepath;
        }

        public string XmlReadValue(string Section)
        {
            XmlTextReader textReader = new XmlTextReader(path);
            ReadElements readEl = new ReadElements(textReader, Section);
            textReader.Close();
            return readEl.Value;
        }

        public string XmlReadValue(string Section, string Key)
        {
            XmlTextReader textReader = new XmlTextReader(path);
            ReadElements readEl = new ReadElements(textReader, Section, Key);
            textReader.Close();
            return readEl.Value;
        }

        private class ReadElements
        {
            XmlTextReader textReader;
            string Section;
            string Key;

            private bool inBase = false;
            private bool inSection = false;
            private bool inKey = false;

            public string Value { get; private set; }

            public ReadElements(XmlTextReader textReader_set, string Section_set)
            {
                Value = "";

                this.textReader = textReader_set;
                this.Section = Section_set;


                textReader.Read();
                while (textReader.Read())
                {
                    // Move to fist element
                    textReader.MoveToElement();

                    string nodetype = textReader.NodeType.ToString();

                    if (textReader.LocalName == "Base")
                    {
                        if (nodetype == "Element")
                        {
                            if (!inBase)
                                inBase = true;
                        }
                        else if (nodetype == "EndElement")
                        {
                            if (inBase)
                                inBase = false;
                        }
                    }
                    else if (inBase && textReader.LocalName == Section)
                    {
                        if (nodetype == "Element")
                        {
                            if (!inSection)
                                inSection = true;
                        }
                        else if (nodetype == "EndElement")
                        {
                            if (inSection)
                                inSection = false;
                        }
                    }

                    else if (inBase && inSection)
                    {
                        if (nodetype == "Text")
                        {
                            Value = textReader.Value.ToString();
                            //Console.WriteLine(Value);
                        }
                    }
                }
            }

            public ReadElements(XmlTextReader textReader_set, string Section_set, string Key_set)
            {
                Value = "";

                this.textReader = textReader_set;
                this.Section = Section_set;
                this.Key = Key_set;

                textReader.Read();
                while (textReader.Read())
                {
                    // Move to fist element
                    textReader.MoveToElement();

                    string nodetype = textReader.NodeType.ToString();

                    if (textReader.LocalName == "Base")
                    {
                        if (nodetype == "Element")
                        {
                            if (!inBase)
                                inBase = true;
                        }
                        else if (nodetype == "EndElement")
                        {
                            if (inBase)
                                inBase = false;
                        }
                    }
                    else if (inBase && textReader.LocalName == Section)
                    {
                        if (nodetype == "Element")
                        {
                            if (!inSection)
                                inSection = true;
                        }
                        else if (nodetype == "EndElement")
                        {
                            if (inSection)
                                inSection = false;
                        }
                    }
                    else if (inBase && inSection && textReader.LocalName == Key)
                    {
                        if (inSection)
                        {
                            if (nodetype == "Element")
                            {
                                if (!inKey)
                                    inKey = true;
                            }
                            else if (nodetype == "EndElement")
                            {
                                if (inKey)
                                    inKey = false;
                            }
                        }
                    }
                    else if (inBase && inSection && inKey)
                    {
                        if (nodetype == "Text")
                        {
                            Value = textReader.Value.ToString();
                            //Console.WriteLine(Value);
                        }
                    }
                }
            }

        }
    }
}