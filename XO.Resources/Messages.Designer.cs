﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace XO.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("XO.Resources.Messages", typeof(Messages).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to It&apos;s a draw..
        /// </summary>
        public static string Draw {
            get {
                return ResourceManager.GetString("Draw", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Game is pending..
        /// </summary>
        public static string GamePending {
            get {
                return ResourceManager.GetString("GamePending", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Player {0} marks {1}..
        /// </summary>
        public static string PlayerMarks {
            get {
                return ResourceManager.GetString("PlayerMarks", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Player O win!.
        /// </summary>
        public static string PlayerOWin {
            get {
                return ResourceManager.GetString("PlayerOWin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Player {0} turn..
        /// </summary>
        public static string PlayerTurn {
            get {
                return ResourceManager.GetString("PlayerTurn", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Player X win!.
        /// </summary>
        public static string PlayerXWin {
            get {
                return ResourceManager.GetString("PlayerXWin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select cell:.
        /// </summary>
        public static string SelectCell {
            get {
                return ResourceManager.GetString("SelectCell", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select player {0} type:.
        /// </summary>
        public static string SelectPlayerType {
            get {
                return ResourceManager.GetString("SelectPlayerType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Welcome to Tic-tac-toe game!.
        /// </summary>
        public static string Welcome {
            get {
                return ResourceManager.GetString("Welcome", resourceCulture);
            }
        }
    }
}
