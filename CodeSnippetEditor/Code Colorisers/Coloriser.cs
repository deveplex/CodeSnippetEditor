using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
//-----------------------------------------------------------------
// Copyright (c) Bill McCarthy.  
// This code and information are provided "as is"  without warranty
// of any kind either expressed or implied. Use at your own risk.
//-----------------------------------------------------------------




// ERROR: Not supported in C#: OptionDeclaration
namespace CodeColorisers
{

    /// <summary>
    /// Provides Shared methods that provide the default code colorisers for different languages
    /// </summary>
    /// <remarks>
    /// Theoretically this should be plug-in extensible, however there is no practical need
    ///  If needed, the defaults could be  determined by via a config file entry, where the language
    ///  name is a lookup in the config file, and the type in that entry implements IColorTokenProvider.
    ///  Should other languages get with the snippet program, and/or folks want to provide their own
    ///  code coloriser for a given language, then we should look at doing this
    /// </remarks>

    public sealed class Coloriser
    {

        private Coloriser()
        {
            // all members of the class are shared
        }

        #region "default colorisers"



        private static VBCodeColoriser _VBColoriser;
        public static IColorTokenProvider VBColoriser
        {
            get
            {
                if (_VBColoriser == null)
                {
                    _VBColoriser = new VBCodeColoriser();
                }
                return _VBColoriser;
            }
        }




        private static CSharpCodeColoriser _CSharpColoriser;
        public static IColorTokenProvider CSharpColoriser
        {
            get
            {
                if (_CSharpColoriser == null)
                {
                    _CSharpColoriser = new CSharpCodeColoriser();
                }
                return _CSharpColoriser;
            }
        }




        private static JSharpCodeColoriser _JSharpColoriser;
        public static IColorTokenProvider JSharpColoriser
        {
            get
            {
                if (_JSharpColoriser == null)
                {
                    _JSharpColoriser = new JSharpCodeColoriser();
                }
                return _JSharpColoriser;
            }
        }






        private static XmlCodeColoriser _XmlColoriser;
        public static IColorTokenProvider XmlColoriser
        {
            get
            {
                if (_XmlColoriser == null)
                {
                    _XmlColoriser = new XmlCodeColoriser();
                }
                return _XmlColoriser;
            }
        }





        private static UnknownCodeColoriser _UnknownColoriser;
        public static IColorTokenProvider UnknownColoriser
        {
            get
            {
                if (_UnknownColoriser == null)
                {
                    _UnknownColoriser = new UnknownCodeColoriser();
                }
                return _UnknownColoriser;
            }
        }

        #endregion



        public static IColorTokenProvider GetColoriser(string language)
        {

            switch (language.ToLower())
            {
                case "vb":
                case "visual basic":

                    return VBColoriser;
                case "csharp":

                    return CSharpColoriser;
                case "jsharp":

                    return JSharpColoriser;
                case "xml":

                    return XmlColoriser;
                default:

                    return UnknownColoriser;
            }

        }




        public static IColorTokenProvider GetColoriser(CodeLanguage language)
        {

            switch (language)
            {
                case CodeLanguage.VB:

                    return VBColoriser;
                case CodeLanguage.CSharp:

                    return CSharpColoriser;
                case CodeLanguage.JSharp:

                    return JSharpColoriser;
                case CodeLanguage.XML:

                    return XmlColoriser;
                case CodeLanguage.Unknown:

                    return UnknownColoriser;
                default:

                    return UnknownColoriser;
            }

        }



    }



}


