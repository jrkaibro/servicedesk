﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DealerNet.Packages.ServiceDesk {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DealerNet.Packages.ServiceDesk.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Demanda não encontrada!.
        /// </summary>
        internal static string DemandaNaoEncontrada {
            get {
                return ResourceManager.GetString("DemandaNaoEncontrada", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon document {
            get {
                object obj = ResourceManager.GetObject("document", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon Folder {
            get {
                object obj = ResourceManager.GetObject("Folder", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon Object {
            get {
                object obj = ResourceManager.GetObject("Object", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Update não realizado, ocorreram erros !.
        /// </summary>
        internal static string ServiceDeskUpdadeErro {
            get {
                return ResourceManager.GetString("ServiceDeskUpdadeErro", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Update realizado com sucesso !.
        /// </summary>
        internal static string ServiceDeskUpdadeSucesso {
            get {
                return ResourceManager.GetString("ServiceDeskUpdadeSucesso", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Service Desk.
        /// </summary>
        internal static string toolWindowTitle {
            get {
                return ResourceManager.GetString("toolWindowTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Somente números!..
        /// </summary>
        internal static string txtDemandaSomenteNumeros {
            get {
                return ResourceManager.GetString("txtDemandaSomenteNumeros", resourceCulture);
            }
        }
    }
}