﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASuppes.FlightParser.Properties {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ASuppes.FlightParser.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Поиск дешевого авиаперелета.
        /// </summary>
        internal static string AppTitle {
            get {
                return ResourceManager.GetString("AppTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Дата вылета не может быть пустой..
        /// </summary>
        internal static string SearchRequestEmptyDepartureDateError {
            get {
                return ResourceManager.GetString("SearchRequestEmptyDepartureDateError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Место вылета не может быть пустым..
        /// </summary>
        internal static string SearchRequestEmptyDeparturePlaceError {
            get {
                return ResourceManager.GetString("SearchRequestEmptyDeparturePlaceError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Место назначения не может быть пустым..
        /// </summary>
        internal static string SearchRequestEmptyDestinationPlaceError {
            get {
                return ResourceManager.GetString("SearchRequestEmptyDestinationPlaceError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Укажите параметры поиска..
        /// </summary>
        internal static string SearchRequestEmptyRequestError {
            get {
                return ResourceManager.GetString("SearchRequestEmptyRequestError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Дата возврата не может быть пустой..
        /// </summary>
        internal static string SearchRequestEmptyReturnDateError {
            get {
                return ResourceManager.GetString("SearchRequestEmptyReturnDateError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Дата возврата не может быть раньше даты вылета..
        /// </summary>
        internal static string SearchRequestReturnBeforeDepartureError {
            get {
                return ResourceManager.GetString("SearchRequestReturnBeforeDepartureError", resourceCulture);
            }
        }
    }
}
